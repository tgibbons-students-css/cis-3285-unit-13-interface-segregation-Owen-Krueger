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

            Console.WriteLine("=========CreateOrderSeparateServices=========");
            OrderController objectSep = CreateOrderSeparateServices();
            objectSep.CreateOrder(order);
            objectSep.DeleteOrder(order);

            Console.WriteLine("=========CreateOrderSingleService=========");
            OrderController objectSing = CreateOrderSingleService();
            objectSing.CreateOrder(order);
            objectSing.DeleteOrder(order);

            Console.WriteLine("=========CreateItemSeparateServices=========");
            ItemController itemSep = CreateItemSeparateServices();
            itemSep.CreateItem(item);
            itemSep.DeleteItem(item);

            Console.WriteLine("=========CreateItemSingleService=========");
            ItemController itemSing = CreateItemSingleService();
            itemSing.CreateItem(item);
            itemSing.DeleteItem(item);

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

        static OrderController CreateOrderSeparateServices()
        {
            var reader = new Reader<Order>();
            var saver = new Saver<Order>();
            var deleter = new Deleter<Order>();
            return new OrderController(reader, saver, deleter);
        }

        static OrderController CreateOrderSingleService()
        {
            var crud = new Crud<Order>();
            return new OrderController(crud, crud, crud);
        }

        static ItemController CreateItemSeparateServices()
        {
            var reader = new Reader<Item>();
            var saver = new Saver<Item>();
            var deleter = new Deleter<Item>();
            return new ItemController(reader, saver, deleter);
        }

        static ItemController CreateItemSingleService()
        {
            var crud = new Crud<Item>();
            return new ItemController(crud, crud, crud);
        }
    }
}
