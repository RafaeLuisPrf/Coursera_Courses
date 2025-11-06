namespace Coursera.Course1;
public static class ProductOperation
{

    public static List<Product> products = new List<Product>();

    public static void run()
    {
        
        Console.WriteLine("Welcome to the Inventory Management System!");
        MainLoop();
        
        
    }

    public static void MainLoop()
    {
        while (true)
        {
            Console.WriteLine("Choose the desired action:\n" +
                              "1 - Add Product\n" +
                              "2 - Update Stock\n" +
                              "3 - Delete Product\n" +
                              "4 - View all Products\n" +
                              "5 - Leave\n");

            if (int.TryParse(readLineImp(), out int selectedOption))
            {
                switch (selectedOption)
                {
                    case 1:
                        AddProduct();
                        break;
                    case 2:
                        UpdateStock();
                        break;
                    case 3:
                        DeleteProduct();
                        break;
                    case 4:
                        ShowProducts();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Wrong Input! Try Again!\n");
                        break;
                }
                
            }
            else
            {
                Console.WriteLine("Wrong Input! Try Again!\n");
            }
        }
    }

    public static void AddProduct()
    {

        Console.WriteLine("Product Name:");
        string productName = readLineImp();
        
        Console.WriteLine("Price:");
        double price;
        while (!double.TryParse(readLineImp(), out price))
        {
            Console.WriteLine("Price:");
        }
        
        Console.WriteLine("Stock:");
        int stock;

        while (!int.TryParse(readLineImp(), out stock))
        {
            Console.WriteLine("Stock:");
        }
        
        products.Add(new Product(productName,price,stock));
        Console.WriteLine("Products Added Successfully!");         
    
    }

    public static void UpdateStock()
    {
        
        if (products.Count == 0)
        {
            Console.WriteLine("No products to show!!");
            return;
        }
        
        Console.WriteLine("Select a Product to Update Stock:");
        ShowProducts();

        int opt;
        while (!int.TryParse(readLineImp(), out opt) || opt < 1 || opt > products.Count)
        {
            Console.WriteLine("Error, Select a valid Product!!");
            ShowProducts();
        }
        
        Console.WriteLine("Product Selected:" + products[opt-1].name + " | Stock ="+ products[opt-1].stock);
        Console.WriteLine("New Stock:");

        int res;
        while (!int.TryParse(readLineImp(), out res) || res < 0)
        {
            Console.WriteLine("Invalid Stock, Try Again!");
        }
        products[opt-1].UpdateStock(res);
        Console.WriteLine("Stock Updated Successfully!");


    }

    public static void DeleteProduct()
    {
        
        if (products.Count == 0)
        {
            Console.WriteLine("No products to show!!");
            return;
        }
        
        Console.WriteLine("Select a Product to Delete:");
        ShowProducts();

        int opt;
        while (!int.TryParse(readLineImp(), out opt) || opt < 1 || opt > products.Count)
        {
            Console.WriteLine("Error, Select a valid Product!!");
            ShowProducts();
        }
        
        Console.WriteLine("Product Selected:" + products[opt-1].name + " | Stock ="+ products[opt-1].stock);
        products.RemoveAt(opt-1);
        Console.WriteLine("Product Deleted Successfully!");
        
    }

    public static void ShowProducts()
    {
        if (products.Count == 0)
        {
            Console.WriteLine("No products to show!!");
            return;
        }
        
        Console.WriteLine("Products:");
        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine( (i+1) + " - " +products[i].name + " | Stock ="+ products[i].stock);
        }
        
    }

    public static string readLineImp()
    {
        Console.Write("R:");
        return Console.ReadLine();
    }
    
    
}

public class Product
{
    public string name;
    public double price;
    public int stock;

    public Product(string name, double price, int stock)
    {
        if (string.IsNullOrEmpty(name) || price <= 0 || stock <= 0)
        {
            Console.WriteLine("Error Creating the product");
        }
        
        this.name = name;
        this.price = price;
        this.stock = stock;
    }

    public void UpdateStock(int newStock)
    {
        this.stock = newStock;
    }
}


