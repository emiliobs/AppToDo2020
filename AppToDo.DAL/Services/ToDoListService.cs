using AppToDo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppToDo.DAL.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly AppDbContext _contex;

        public ToDoListService(AppDbContext contex)
        {
            _contex = contex;
        }
        public async Task<List<ToDo>> GetAll() => await _contex.ToDos.OrderBy(t => t.Name).ToListAsync();

        public async Task<ToDo> GetById(int id) => await _contex.ToDos.Where(t => t.Id == id).FirstOrDefaultAsync();
       
        public async Task<ToDo> Add(ToDo toDo)
        {
            _contex.ToDos.Add(toDo);
            await _contex.SaveChangesAsync();
            return toDo;
        }     
      
        public async Task<ToDo> Update(ToDo toDo)
        {
            
            _contex.Entry(toDo).State = EntityState.Modified;
            await _contex.SaveChangesAsync();
            return toDo;
        }

        public async Task<ToDo> Delete(int id)
        {
            var toDo = await _contex.ToDos.FindAsync(id);
            _contex.ToDos.Remove(toDo);
            await _contex.SaveChangesAsync();
            return toDo;
        }
    }
}
