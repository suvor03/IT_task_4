using System.Windows;

namespace TradePointSimulation
{
    public partial class TradePointWindow : Window
    {
        private TradePoint tradePoint;
        private Customer customer;

        public TradePointWindow()
        {
            InitializeComponent();

            tradePoint = new TradePoint();

            tradePoint.AddProduct(new Product { Name = "Product 1", Price = 10.0, Quantity = 5 });
            tradePoint.AddProduct(new Product { Name = "Product 2", Price = 15.0, Quantity = 3 });
            tradePoint.AddProduct(new Product { Name = "Product 3", Price = 20.0, Quantity = 7 });

            customer = new Customer();

            tradePoint.ProductPurchased += TradePoint_ProductPurchased;
            tradePoint.ProductSoldOut += TradePoint_ProductSoldOut;

            UpdateProductList();
        }

        private void UpdateProductList()
        {
            productListBox.Items.Clear();
            foreach (var product in tradePoint.Products)
            {
                productListBox.Items.Add($"{product.Name} - {product.Price}$ ({product.Quantity} available)");
            }
        }

        private void TradePoint_ProductPurchased(object sender, Product e)
        {
            MessageBox.Show($"Product {e.Name} purchased successfully!");
            UpdateProductList();
        }

        private void TradePoint_ProductSoldOut(object sender, Product e)
        {
            MessageBox.Show($"Product {e.Name} is sold out!");
            UpdateProductList();
        }

        private void buyButton_Click(object sender, RoutedEventArgs e)
        {
            if (productListBox.SelectedIndex >= 0)
            {
                string productName = productListBox.SelectedItem.ToString().Split('-')[0].Trim();
                Product selectedProduct = tradePoint.Products.FirstOrDefault(p => p.Name == productName);

                if (selectedProduct != null)
                {
                    customer.BuyProduct(tradePoint, selectedProduct);
                }
            }
            else
            {
                MessageBox.Show("Please select a product to buy.");
            }
        }
    }
}
