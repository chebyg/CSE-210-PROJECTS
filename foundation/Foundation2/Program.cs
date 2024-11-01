using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation2 World!");
    }
}class Product
{
    private string name;
    private int productId;
    private decimal price;
    private int quantity;

    public Product(string name, int productId, decimal price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public decimal TotalCost()
    {
        return price * quantity;
    }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }
}

class Address
{
    private string streetAddress;
    private string city;
    private string stateProvince;
    private string country;

    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.stateProvince = stateProvince;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.ToLower() == "usa";
    }

    public string GetAddressString()
    {
        return $"{streetAddress}\n{city},{stateProvince} {country}";
    }
}

class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(List<Product> products, Customer customer)
    {
        this.products = products;
        this.customer = customer;
    }

    public decimal TotalPrice()
    {
        decimal total = 0;
        foreach (Product product in products)
        {
            total += product.TotalCost();
        }
        if (!customer.IsInUSA())
        {
            total += 35;
        }
        return total;
    }

    public string PackingLabel()
    {
        string packingLabel = "Packing Label:\n";
        foreach (Product product in products)
        {
            packingLabel += $"Name: {product.Name}\nProduct ID: {product.ProductId}\n";
        }
        return packingLabel;
    }

    public string ShippingLabel()
    {
        string shippingLabel = "Shipping Label:\n";
        shippingLabel += customer.GetName() + "\n" + customer.Address.GetAddressString();
        return shippingLabel;
    }
}


Now, let's create a program that creates two orders with 2-3 products each and calls the methods to get the packing label, shipping label, and total price of the order.

csharp
class Program
{
    static void Main(string[] args)
    {
        // Create products
        Product product1 = new Product("Product 1", 1, 10, 2);
        Product product2 = new Product("Product 2", 2, 20, 3);
        Product product3 = new Product("Product 3", 3, 30, 4);

        // Create customer address
        Address address = new Address("123 Main St", "Anytown", "CA", "USA");

        // Create customer
        Customer customer = new Customer("John Doe", address);

        // Create orders
        Order order1 = new Order(new List<Product> { product1, product2 }, customer);
        Order order2 = new Order(new List<Product> { product2, product3 }, customer);

        // Get packing label, shipping label, and total price for each order
        Console.WriteLine("Order 1:");
        Console.WriteLine(order1.PackingLabel());
        Console.WriteLine(order1.ShippingLabel());
        Console.WriteLine(order1.TotalPrice());

        Console.WriteLine("Order 2:");
        Console.WriteLine(order2.PackingLabel());
        Console.WriteLine(order2.ShippingLabel());
        Console.WriteLine(order2.TotalPrice());
    }
}
