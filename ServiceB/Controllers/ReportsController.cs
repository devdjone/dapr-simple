using Dapr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ServiceB.Controllers;



[ApiController]
[Route("[controller]")]

public class ReportsController(ILogger<ReportsController> logger) : ControllerBase
{
    private  string _defaultMessage = "Hello from private field!";

    //[Topic("pubsub", "orders")]
    [HttpPost("Order")]
    [Topic("pubsub", "orders")]
    public async Task<IActionResult> Subscribe66(Order order)
    {
        logger.LogInformation($"Received a new order! Id: {order.Id} Product: {order.Product} Quantity: {order.Quantity} Price: {order.Price} Total: {order.Total:N2}");
        _defaultMessage = $"Received a new order! Id: {order.Id} Product: {order.Product} Quantity: {order.Quantity} Price: {order.Price} Total: {order.Total:N2}";
        return Ok();
    }

    [HttpGet]
    public string GetPlacedOrder()
    {
        return _defaultMessage;
    }

}

 
public record Order(int Id, string Product, int Quantity, decimal Price)
{
    public decimal Total => Quantity * Price;
}