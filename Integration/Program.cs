using Integration.Common;
using Integration.Service;

namespace Integration;

public abstract class Program
{
    // public static void Main(string[] args)
    // {
    //     var service = new ItemIntegrationService();

    //     ThreadPool.QueueUserWorkItem(_ => service.SaveItem("a"));
    //     ThreadPool.QueueUserWorkItem(_ => service.SaveItem("b"));
    //     ThreadPool.QueueUserWorkItem(_ => service.SaveItem("c"));

    //     Thread.Sleep(500);

    //     ThreadPool.QueueUserWorkItem(_ => service.SaveItem("a"));
    //     ThreadPool.QueueUserWorkItem(_ => service.SaveItem("b"));
    //     ThreadPool.QueueUserWorkItem(_ => service.SaveItem("c"));

    //     Thread.Sleep(5000);

    //     Console.WriteLine("Everything recorded:");

    //     service.GetAllItems().ForEach(Console.WriteLine);

    //     Console.ReadLine();
    // }

    public static void Main(string[] args)
    {
        ItemIntegrationService service = new ItemIntegrationService();

        List<Item> items = new List<Item>
            {
                new Item { Content = "a" },
                new Item { Content = "b" },
                new Item { Content = "c" },
                new Item { Content = "a" },
                new Item { Content = "b" },
                new Item { Content = "c" },
                new Item { Content = "a" },
                new Item { Content = "b" },
                new Item { Content = "c" },
                new Item { Content = "a" },
                new Item { Content = "b" },
                new Item { Content = "c" },
                new Item { Content = "a" },
                new Item { Content = "b" },
                new Item { Content = "c" },
                new Item { Content = "a" },
                new Item { Content = "b" },
                new Item { Content = "c" }

            };

        Parallel.ForEach(items, item =>
        {
            if (service.SaveItem(item.Content).Success)
            {
                Console.WriteLine($"Added item with content: {item.Content}");
            }
            else
            {
                Console.WriteLine($"Failed to add item with content: {item.Content} because it already exists.");
            }
        });
    }
}