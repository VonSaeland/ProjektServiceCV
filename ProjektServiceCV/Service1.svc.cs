using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ProjektServiceCV
{
    public class Service1 : IService1
    {
        //Ny go Bokdatabas!
        ItemsDBFileEntities ItemDB = new ItemsDBFileEntities();

        public List<Item> GetItemsList() //slänger in "Item" i en lista som sen returneras
        {
            return ItemDB.Item.ToList(); //returnera lista med Items 
        }

        public Item GetItemById(string id) //hitta ett item som har det id som ges utav användaren
        {
            int ItemId = Convert.ToInt32(id); //convertera ItemId till int

            return ItemDB.Item.SingleOrDefault(Item => Item.Id == ItemId); //returnera item där Item.Id är samma som ItemId
        }

        public void AddItem(string name)
        { 
            Item item = new Item { ItemName = name }; // säger att ItemName får värdet som name har
            ItemDB.Item.Add(item); //lägg till item i databas
            ItemDB.SaveChanges(); //spara andringar
        }

        public void UpdateItem(string id, string name) // samma som additem förutom att man kan ändra namnet
        {
            int itemId = Convert.ToInt32(id);

            Item item = ItemDB.Item.SingleOrDefault(b => b.Id == itemId);
            item.ItemName = name; //ändra namn
            ItemDB.SaveChanges();

        }

        public void DeleteItem(string id)
        {
            int itemId = Convert.ToInt32(id);

            Item item = ItemDB.Item.SingleOrDefault(b => b.Id == itemId);
            ItemDB.Item.Remove(item); //tabort item som håller IDt givet 
            ItemDB.SaveChanges();
        }
    }
}