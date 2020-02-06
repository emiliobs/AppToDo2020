using AppToDo.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppToDo.DAL.Services
{
    public interface IToDoListService
    {
        Task<List<ToDo>> GetAll();
        Task<ToDo> GetById(int id);
        Task<ToDo> Add(ToDo toDo);
        Task<ToDo> Update(ToDo toDo);
        Task<ToDo> Delete(ToDo id);
    }
}
