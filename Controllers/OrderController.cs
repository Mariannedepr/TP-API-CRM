using Microsoft.AspNetCore.Mvc;
namespace TP.CRM;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]

public class OrderController : ControllerBase{

    public static CRMContext context = new();
    public List<Order> ListOrder = new();

    public OrderController(){
        
    }

    //CREATE
    [HttpPost]
    public string Post(Order tmp)
    {
        Client db = context.Clients.Find(tmp.id_clients);
        if (db != null)
        {
            tmp.bob = db;
            context.Orders.Add(tmp);
            context.SaveChanges();
            Console.WriteLine("Commande ajoutée au client");
        }

        else {
            Console.WriteLine("operation failed");
        }

            return "Operation Post une commande terminée";
    }

     //READ
     [HttpGet("{id}")]
     public Order Get(int id)
     {
        return context.Orders.Find(id);
     }

     //UPDATE
     [HttpPut("{id}")]
    public Order Put(int id, Order tmp)
    {
        Order db = context.Orders.Find(id);
        if (db != null)
        {
            db.TypePresta = tmp.TypePresta;
            db.Client = tmp.Client;
            db.NbJours = tmp.NbJours;
            context.SaveChanges(); 
        }  
        return tmp;
    }

     //DELETE
     [HttpDelete("{id}")]
     public void Delete(int id)
     {
        Order orderToGo = context.Orders.Find(id);
        context.Orders.Remove(orderToGo);
        context.SaveChanges();
        System.Console.WriteLine("Order supprimé");
     }
}