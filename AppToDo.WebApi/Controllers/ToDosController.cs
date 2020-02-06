using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppToDo.DAL.Services;
using AppToDo.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppToDo.WebApi.Controllers
{
    [Produces("application/json")]
    [EnableCors("CORSPolicy")]
    [Route("todos")]
    [ApiController]
    public class ToDosController : ControllerBase
    {
        private readonly IToDoListService _toDoListService;

        public ToDosController(IToDoListService toDoListService)
        {
            _toDoListService = toDoListService;
        }

        [HttpGet]
        public async Task<List<ToDo>> GetAll() => await _toDoListService.GetAll();
        
        [HttpPost]
        public async Task<ToDo> Post(ToDo toDo)
        {
            if (ModelState.IsValid)
            {
               return await _toDoListService.Add(toDo);

            }

            return null;

        }
    }
}