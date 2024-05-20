using ChallengerAgroCare.Data;
using ChallengerAgroCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChallengerAgroCare.Controllers
{
    public class UserController : Controller
    {
        private readonly DataContext _dataContext;

        public UserController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        
        public async Task<IActionResult> Index()
        {
            return View(await _dataContext.users.ToListAsync());
        }

        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar([Bind("Name,Password,UserEmail")] User user) 
        {
            if (ModelState.IsValid)
            {
                _dataContext.Add(user);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);

        }
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastrouser = await _dataContext.users.FindAsync(id);
            if (cadastrouser == null)
            {
                return NotFound();
            }
            return View(cadastrouser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id,Name,Avatar,Password,UserEmail")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dataContext.Update(user);
                    await _dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExist(user.Id))
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
            return View(user);
        }
        private bool UserExist(int id)
        {
            return _dataContext.users.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user= await _dataContext.users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View("DeleteConfirmacao",user);
        }

        
        [HttpPost, ActionName("DeleteConfirmacao")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmacao(int id)
        {
            var user = await _dataContext.users.FindAsync(id);
            if (user != null)
            {
                _dataContext.users.Remove(user);
            }

            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
