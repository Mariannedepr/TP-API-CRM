using Microsoft.AspNetCore.Mvc;
namespace TP.CRM;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]

public class ClientController : ControllerBase{

    public static CRMContext context = new();
    public List<Client> List = new();

    public ClientController(){
        
    }

     //CREATE
    [HttpPost]
    public string Post(Client tmp)
    {
        //vérif que mon tmp.id_user existe (via find)
        //il faut que je find le user qui a le meme id 
        //User Usertmp = context.Users.Find(id); //on cherche un user qui a l'id passé en paramètre
        User db = context.Users.Find(tmp.id_user);
        
        // if (db != null)  //si mon id_user rentré dans mon client n'est pas null
        // {
        //        //alors mon user stocké dans mon client prend la valeur de mon user de l'id passé en param
        //     tmp.utilisateur = db;
        //     context.Clients.Add(tmp); //on ajoute le client à db
        //     context.SaveChanges();
        //     System.Console.WriteLine("Client ajouté");
        // }
        // else {
        //     Console.WriteLine("ID user incorrect ou inexistant") ;
        // }
        // return "Operation terminée";
         

        if (db == null)  
        {
            System.Console.WriteLine("ID user incorrect ou inexistant");
            return "operation failed";
        }  
            tmp.utilisateur = db;
            context.Clients.Add(tmp); //on ajoute le client à db
            context.SaveChanges();
            return "Client ajouté";     
    }


     //READ
        [HttpGet]
     public List<Client> Get()
     {
      return context.Clients.ToList();
     }

     [HttpGet("{id}")]
     public Client Get(int id)
     {
        return context.Clients.Find(id);
     }

     //UPDATE
     [HttpPut("{id}")]
    public Client Put(int id, Client tmp)
    {
        Client db = context.Clients.Find(id);
        if(db != null)
        {
            db.Name = tmp.Name;
            db.State = tmp.State;
            db.TVA = tmp.TVA;
            db.TotalCaHt = tmp.TotalCaHt;
            db.Comment = tmp.Comment;
            context.SaveChanges();
        }
        
        return tmp;
    }

     //DELETE
     [HttpDelete("{id}")]
     public void Delete(int id)
     {
        Client clientToGo = context.Clients.Find(id);
        context.Clients.Remove(clientToGo);
        context.SaveChanges();
        System.Console.WriteLine("Client supprimé");
     }
}