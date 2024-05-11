using System.Windows;

namespace TradePointSimulation
{
    public class TradePoint
    {
        public event EventHandler<Product> ProductSoldOut;
        public event EventHandler<Product> ProductPurchased;

        private List<Product> products = new List<Product>();

        public IReadOnlyList<Product> Products => products;

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void SellProduct(Product product)
        {
            if (products.Contains(product))
            {
                if (product.Quantity > 0)
                {
                    product.Quantity--;
                    ProductPurchased?.Invoke(this, product);
                }
                else
                {
                    ProductSoldOut?.Invoke(this, product);
                }
            }
            else
            {
                MessageBox.Show("Товар не найден!");
            }
        }
    }
}