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
        //sil existe les valeurs de mon Tmp.user prennent les valeurs de mon context.user 
        //sil existe pas je drop la requete
        Client db = context.Clients.Find();
        if(db !=null)
        {
            
        }

        context.Clients.Add(tmp);
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