using ChallengerAgroCare.Data;
using ChallengerAgroCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChallengerAgroCare.Controllers
{
    public class ComentarioController : Controller
    {

        private readonly DataContext _dataContext;

        public ComentarioController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        

        public async Task<IActionResult> Index()
        {
            return View(await _dataContext.Comentarios.ToListAsync());
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar([Bind("UseId,TxtComment,CommentDate,Like")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Add(comentario);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comentario);
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentario = await _dataContext.Comentarios.FindAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }
            return View(comentario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id,UserId,TxtComment,CommentDate,Like")] Comentario comentario)
        {
            if (id != comentario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dataContext.Update(comentario);
                    await _dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComentarioExist(comentario.Id))
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
            return View(comentario);
        }

        private bool ComentarioExist(int id)
        {
            return _dataContext.Comentarios.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentario = await _dataContext.Comentarios.FirstOrDefaultAsync(u => u.Id == id);
            if (comentario == null)
            {
                return NotFound();
            }

            return View("DeleteConfirmacao", comentario);
        }

        [HttpPost, ActionName("DeleteConfirmacao")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmacao(int id)
        {
            var comentario = await _dataContext.Comentarios.FindAsync(id);
            if (comentario != null)
            {
                _dataContext.Comentarios.Remove(comentario);
            }

            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

