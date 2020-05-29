using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using homework5;

namespace homework5
{
    class Customer
    {
        private String CustomerName { get; set; }
        private String CustomerAddress { get; set; }
        public int CustomerID { get; set; }
        private int CustomerPhoneNumber { get; set; }

        public Customer(string customerName, string customerAddress, int customerID, int customerPhoneNumber)
        {
            this.CustomerName = customerName;
            this.CustomerAddress = customerAddress;
            this.CustomerID = customerID;
            this.CustomerPhoneNumber = customerPhoneNumber;
        }

        public override string ToString()
        {
            return "Customer Name:" + CustomerName + " CustomerAddress: " + CustomerAddress + " CustomerID:" + CustomerID + " CustomerPhoneNumber: " + CustomerPhoneNumber;
        }
        public override int GetHashCode()
        {
            return CustomerPhoneNumber;
        }
    }
}
class Order
{
    public int OrderID { get; set; }
    public int Quantity { get; set; }
    public DateTime RequiredDate { get; set; }
    public Product product1;
    public Customer customer1;
    public Order()
    {
    }
    public override string ToString()
    {
        return " OrderID:" + OrderID + " CustomerID:" + customer1.CustomerID + " Product:" + product1.ProductName + " Quantity:" + Quantity + " RequiredDate:" + RequiredDate;
    }

    public override bool Equals(object obj)
    {
        Order order1 = obj as Order;
        return (order1 != null && order1.OrderID == OrderID && order1.product1 == product1 && order1.Quantity == Quantity && order1.customer1 == customer1 && order1.RequiredDate == RequiredDate);
    }

    public override int GetHashCode()
    {
        return OrderID + customer1.CustomerID;
    }
}
class OrderService
{
    public static int count = 1;
    public static int countOrder = 1;
    public static object _lock = new object();
    List<Product> productList = new List<Product>();
    List<Order> orderList = new List<Order>();
    public double getRandomID()
    {
        lock (_lock)
        {
            if (count >= 10000)
            {
                count = 1;
            }
            var number = Double.Parse(DateTime.Now.ToString("yyMMddHHmmss" + count));
            count++;
            return number;
        }

    }
    public void addProduct(Product products)
    {
        this.productList.Add(products);
    }
    public void deleteProduct()
    {
        try
        {
            Console.WriteLine("delete？(input the ID)");
            double k = double.Parse(Console.ReadLine());
            productList.RemoveAll(s => (s.ProductID == k));
        }
        catch (Exception)
        {
            throw new SystemException();
        }
    }
    public void deleteOrder()
    {
        try
        {
            Console.WriteLine("delete？(input the OrderID)");
            double k = double.Parse(Console.ReadLine());
            orderList.RemoveAll(s => (s.OrderID == k));
        }
        catch (Exception)
        {
            throw new SystemException();
        }
    }
    public void printProductList(OrderService orderService)
    {
        foreach (Product i in orderService.productList)
        {
            Console.WriteLine(i);
        }
    }

    public void printOrder()
    {
        foreach (Order o in this.orderList)
        {
            Console.WriteLine(o);
        }
    }
    public void addOrder(Order order, Customer customer)
    {
        order.customer1 = customer;
        while (true)
        {
            foreach (Product i in this.productList)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("which one do you want to buy？(input the ID)");
            double n = Double.Parse(Console.ReadLine());
            foreach (Product i in this.productList)
            {
                if (i.ProductID == n)
                {
                    Console.WriteLine("how much?");
                    int k = int.Parse(Console.ReadLine());
                    Console.WriteLine("are you sure？(Y/N)");
                    Console.WriteLine(i);
                    String anwser = Console.ReadLine();
                    if (anwser == "Y")
                    {
                        order.product1 = i;
                        order.Quantity = k;
                        order.OrderID = countOrder;
                        order.RequiredDate = DateTime.Now;
                        countOrder++;
                        orderList.Add(order);
                    }
                }

            }
            break;
        }
    }
    public void sumOrderList()
    {
        double sum = 0;
        foreach (Order o in orderList)
        {
            sum += o.product1.ProductPrice * o.Quantity;
            o.product1.ProductQuantity = o.product1.ProductQuantity - o.Quantity;
        }
        Console.WriteLine("total" + sum);
    }
}
class Product
{
    public double ProductID { get; set; }
    public String ProductName { get; set; }
    public Double ProductPrice { get; set; }
    public int ProductQuantity { get; set; }

    public Product(double productID, string productName, double productPrice, int productQuantity)
    {
        ProductID = productID;
        ProductName = productName;
        ProductPrice = productPrice;
        ProductQuantity = productQuantity;
    }
    public Product()
    {

    }
    public Product createProduct()
    {
        return new Product();
    }

    public override string ToString()
    {
        return "ID: " + ProductID + " Name: " + ProductName + " Price: " + ProductPrice + " Quantity: " + ProductQuantity;
    }

    public override bool Equals(object obj)
    {
        return obj is Product product &&
               ProductID == product.ProductID &&
               ProductName == product.ProductName &&
               ProductPrice == product.ProductPrice &&
               ProductQuantity == product.ProductQuantity;
    }
    public override int GetHashCode()
    {
        var hashCode = -2027619230;
        hashCode = hashCode * -1521134295 + ProductID.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ProductName);
        hashCode = hashCode * -1521134295 + ProductPrice.GetHashCode();
        hashCode = hashCode * -1521134295 + ProductQuantity.GetHashCode();
        return hashCode;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Customer customer = new Customer("WenHong", "China", 1234, 15236975);
        OrderService orderService = new OrderService();
        Product product1 = new Product(orderService.getRandomID(), "Apple", 3, 5);
        Product product2 = new Product(orderService.getRandomID(), "banana", 4, 2);
        Product product3 = new Product(orderService.getRandomID(), "coconut", 8, 8);
        Product product4 = new Product(orderService.getRandomID(), "pineapple", 2, 3);
        orderService.addProduct(product1);
        orderService.addProduct(product2);
        orderService.addProduct(product3);
        orderService.addProduct(product4);
        while (true)
        {
            Console.WriteLine("1.add item");
            Console.WriteLine("2.view item");
            Console.WriteLine("3.add order");
            Console.WriteLine("4.view order");
            Console.WriteLine("5.bill");
            Console.WriteLine("6.delete item");
            Console.WriteLine("7.delete order");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("item name:");
                    String productName = Console.ReadLine();
                    Console.WriteLine("price:");
                    double productPrice = double.Parse(Console.ReadLine());
                    Console.WriteLine("how much");
                    int productQuantity = int.Parse(Console.ReadLine());
                    Product product = new Product(orderService.getRandomID(), productName, productPrice, productQuantity);
                    orderService.addProduct(product);

                    break;
                case 2:
                    orderService.printProductList(orderService);
                    break;
                case 3:
                    Order order = new Order();
                    orderService.addOrder(order, customer);
                    break;
                case 4:
                    orderService.printOrder();
                    break;
                case 5:
                    orderService.sumOrderList();
                    break;
                case 6:
                    orderService.deleteProduct();
                    break;
                case 7:
                    orderService.deleteOrder();
                    break;
            }
        }
    }
}

