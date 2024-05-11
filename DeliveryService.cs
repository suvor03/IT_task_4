using System.Windows;

namespace TradePointSimulation
{
    public class DeliveryService : IDeliveryService
    {
        public void Deliver(string address, Product product)
        {
            MessageBox.Show($"Товар {product.Name} доставлен по адресу: {address}");
        }
    }
}