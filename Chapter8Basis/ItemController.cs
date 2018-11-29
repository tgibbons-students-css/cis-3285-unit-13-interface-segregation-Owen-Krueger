using CrudInterfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter8Basis
{
    class ItemController
    {
        private readonly IRead<Item> reader;
        private readonly ISave<Item> saver;
        private readonly IDelete<Item> deleter;

        public ItemController(IRead<Item> itemReader, ISave<Item> itemSaver, IDelete<Item> itemDeleter)
        {
            reader = itemReader;
            saver = itemSaver;
            deleter = itemDeleter;
        }

        public void CreateItem(Item item)
        {
            saver.Save(item);
            Console.WriteLine("CreateItem: Saving Item of " + item.product);
        }

        public Item GetSingleItem(Guid identity)
        {
            Item ord = reader.ReadOne(identity);
            Console.WriteLine("GetSingleItem: Saving Item of " + ord.product);
            return ord;
        }

        public void UpdateItem(Item item)
        {
            saver.Save(item);
            Console.WriteLine("UpdateItem: Saving Item of " + item.product);
        }

        public void DeleteItem(Item item)
        {
            deleter.Delete(item);
            Console.WriteLine("DeleteItem: Delete Item of " + item.product);
        }
    }
}