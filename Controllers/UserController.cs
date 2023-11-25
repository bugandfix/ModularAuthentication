using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModularAuthentication.Attributes;
using ModularAuthentication.Constants;
using ModularAuthentication.Entities;
using ModularAuthentication.Exceptions;
using ModularAuthentication.Repositories;

namespace ModularAuthentication_Temp.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private readonly DataContext _db;

    public UserController(DataContext db)
    {
        _db = db;
    }

    [Authorize]
    [HttpGet("{id}")]
    public ActionResult Get(int id)
    {
        var response = _db.User.Find(id);

        if (response == null) throw new NotFoundException("User not found.");
        
        return Ok(response);
    }
    
    [Authorize(PrivilegeConst.ReadUser)]
    [HttpGet]
    public ActionResult GetAll()
    {
        var response = _db.User.Include(x => x.Role).ToList();
        return Ok(response);
    }

    [Authorize(PrivilegeConst.CreateUser)]
    [HttpPost]
    public ActionResult Create([FromBody] User user)
    {
        _db.User.Add(user);
        _db.SaveChanges();
        return Ok(user);
    }
}