using System;
using System.Net;
using System.Threading.Tasks;
using API.Usuarios.Domain.Entities;
using API.Usuarios.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace API.Usuarios.Controllers
{
    //http://localhost/api/aspnet/
    [Route("api/aspnet/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        protected readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }



        [HttpGet]
        public async Task<ActionResult> GetAllUsers()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.getAllUsers());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
        //http://localhost:5000/api/aspnet/user/{id}
        [HttpGet]
        [Route("{idUser}", Name = "GetWithId")]
        public async Task<ActionResult> GetUser(Guid idUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.getUser(idUser));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] UserEntity user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.postUser(user);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetWithId", new { idUser = result.Id })), result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser([FromBody] UserEntity user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.putUser(user);
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete]
        [Route("{idUser}", Name = "DeleteUserWithId")]
        public async Task<ActionResult> DeleteUser(Guid idUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.deleteUser(idUser);
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
