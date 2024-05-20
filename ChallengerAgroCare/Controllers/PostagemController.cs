using ChallengerAgroCare.Data;
using ChallengerAgroCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChallengerAgroCare.Controllers
{
    public class PostagemController : Controller

    {
        private readonly DataContext _dataContext;

        public PostagemController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _dataContext.Postagens.ToListAsync());
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar([Bind("TxtPost")] Postagem Post)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Add(Post);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Post);

        }
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postagem = await _dataContext.Postagens.FindAsync(id);
            if (postagem == null)
            {
                return NotFound();
            }
            return View(postagem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id,UserId,TxtPost,PostDate")] Postagem postagem)
        {
            if (id != postagem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dataContext.Update(postagem);
                    await _dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostagemExist(postagem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(postagem);
        }

        // Helper method to check if a post exists
        private bool PostagemExist(int id)
        {
            return _dataContext.Postagens.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postagem = await _dataContext.Postagens.FirstOrDefaultAsync(p => p.Id == id);
            if (postagem == null)
            {
                return NotFound();
            }

            return View("DeleteConfirmacao", postagem);
        }

        [HttpPost, ActionName("DeleteConfirmacao")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmacao(int id)
        {
            var postagem = await _dataContext.Postagens.FindAsync(id);
            if (postagem != null)
            {
                _dataContext.Postagens.Remove(postagem);
            }

            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
