namespace kidsffw.Application.Service;

using Common.Configuration;
using Common.DTO;
using Interfaces.Service;
using Razorpay.Api;

public class RazorPayOrderService : IRazorPayOrderService
{
    private readonly RazorPayConfiguration _razorPayConfiguration;
    private static readonly Random Random = new Random();

    public RazorPayOrderService(RazorPayConfiguration razorPayConfiguration) =>
        _razorPayConfiguration = razorPayConfiguration;

    public RazorPayOrderDetails CreateOrder(decimal amount)
    {
        var orderOptions = new Dictionary<string, object>();
        var razorPayClient = new RazorpayClient(_razorPayConfiguration.KeyId, _razorPayConfiguration.KeySecret);
        orderOptions.Add("amount", amount);
        orderOptions.Add("currency", "INR");
        orderOptions.Add("receipt", GetReceiptId());
        Order orderCreated = razorPayClient.Order.Create(orderOptions);
        var orderDetails = new RazorPayOrderDetails()
        {
            Key = _razorPayConfiguration.KeyId,
            OrderId = orderCreated.Attributes["id"],
            Status = orderCreated.Attributes["status"],
            DueAmount = orderCreated.Attributes["amount_due"],
            TotalAmount = orderCreated.Attributes["amount"]
        };
        return orderDetails;
    }
    private static string GetReceiptId()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, 10)
            .Select(s => s[Random.Next(s.Length)]).ToArray());
    }


}