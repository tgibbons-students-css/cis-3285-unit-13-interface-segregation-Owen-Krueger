using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CrudImplementations;
using Model;

namespace Chapter8Basis
{
    class Program
    {
        static void Main(string[] args)
        {

            Order order = new Order();
            order.id = Guid.NewGuid();
            order.product = "Amazon Echo";
            order.amount = 25;
            Console.WriteLine(order.ToString());

            Item item = new Item();
            item.itemId = Guid.NewGuid();
            item.product = "Amazon Echo";
            item.cost = 99.99;

            Console.WriteLine("=========CreateSeparateServices=========");
            OrderController sep = CreateSeparateServices();
            sep.CreateOrder(order);
            sep.DeleteOrder(order);

            Console.WriteLine("=========CreateSingleService=========");
            OrderController sing = CreateSingleService();
            sing.CreateOrder(order);
            sing.DeleteOrder(order);

            Console.WriteLine("=========GenericController<Order>=========");
            //Class acts as a factory to create a GenericController of the desired type
            GenericControllerCreation<Order> genericServiceCreation = new GenericControllerCreation<Order>();
            GenericController<Order> generic = genericServiceCreation.CreateGenericTEntityServices();
            generic.CreateEntity(order);

            Console.WriteLine("=========GenericController<Item>=========");
            //Class acts as a factory to create a GenericController of the desired type
            GenericControllerCreation<Item> genericItemServiceCreation = new GenericControllerCreation<Item>();
            GenericController<Item> genericItem = genericItemServiceCreation.CreateGenericTEntityServices();
            genericItem.CreateEntity(item);

            Console.WriteLine("Hit any key to quit");
            Console.ReadKey();
        }

        static OrderController CreateSeparateServices()
        {
            var reader = new Reader<Order>();
            var saver = new Saver<Order>();
            var deleter = new Deleter<Order>();
            return new OrderController(reader, saver, deleter);
        }

        static OrderController CreateSingleService()
        {
            var crud = new Crud<Order>();
            return new OrderController(crud, crud, crud);
        }        
    }
}
