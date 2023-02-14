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
        //vérif si le client associé existe avec FIND
        //si le client n'existe pas j'annnule mon post

        context.Orders.Add(tmp);
        context.SaveChanges();
        return "order added";
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