using Microsoft.AspNetCore.Mvc;
namespace TP.CRM;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]

public class UserController : ControllerBase
{
    public static CRMContext context = new();
    public List<User> ListUser = new List<User>();

    public UserController()
    {
      // if(ListUser.Count() == 0)
      //   {
            ListUser.Add(new User("john@example.com", "1234", "John", "Smith", "1234", "ADMIN"));
            context.SaveChanges();
        //}
    }

     //CREATE
    [HttpPost]
    public List<User> Post(User tmp)
    {
        context.Users.Add(tmp);
        context.SaveChanges();
        return ListUser;
    }

     //READ
     [HttpGet]
     public List<User> Get()
     {
      return context.Users.ToList();
     }

     [HttpGet ("{id}")]
     public User Get(int id)
     {
        return context.Users.Find(id);
     }

     //UPDATE
    [HttpPut("{id}")]
    public User Put(int id, User tmp)
    {
       User db = context.Users.Find(id);
       if (db != null)  //si l'utilisateur existe bien sur la db
       {
        db.Email = tmp.Email;
        db.Password = tmp.Password;
        db.FirstName = tmp.FirstName;
        db.LastName = tmp.LastName;
        db.ConfirmedPassword = tmp.Password;
        db.Grants = tmp.Grants;
      context.SaveChanges();
       }
  
        return tmp;
    }

     //DELETE
     [HttpDelete("{id}")]
     public string Delete(int id)
     {
        User userToGo = context.Users.Find(id);
        context.Users.Remove(userToGo);
        context.SaveChanges();
        return ("Utilisateur supprimé");
     }

}