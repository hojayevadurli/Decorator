

using System;
using System.Collections.Generic;
using System.Linq;

public class Inventory
{
     struct itemInfo
    {
        public double price;
        public int amount;

        public itemInfo(double price, int amount)
        {
            this.price = price;
            this.amount = amount;
        }
    }
    private Dictionary<string, itemInfo> Daily { get; set; }
    private Dictionary<string, itemInfo> Master { get; set; }

    private double TotalSales { get; set; }
    public Inventory()
    {

        Daily = new Dictionary<string, itemInfo>();
        Daily.Add("wheatbread", new itemInfo(2.25, 50));
        Daily.Add("whitebread", new itemInfo(2.0, 50));
        Daily.Add("ryebread", new itemInfo(2.5, 50));
        Daily.Add("pbjserving", new itemInfo(.75, 10));
        Daily.Add("bltserving", new itemInfo(2.50, 10));
        Daily.Add("chickenserving", new itemInfo(2, 10));
        Daily.Add("bacon", new itemInfo(.75, 4000));
        Daily.Add("ham", new itemInfo(.60, 4000));
        Daily.Add("cheese", new itemInfo(.75, 4000));
        Daily.Add("mayo", new itemInfo(0.0, 4000));
        Daily.Add("mustard", new itemInfo(0.0, 4000));
        Daily.Add("bbqsauce", new itemInfo(0.0, 4000));
        Daily.Add("tomato", new itemInfo(.25, 4000));
        Daily.Add("lettuce", new itemInfo(.25, 4000));

        Master = new Dictionary<string, itemInfo>();
        Master.Add("wheatbread", new itemInfo(2.25, 50));
        Master.Add("whitebread", new itemInfo(2.0, 50));
        Master.Add("ryebread", new itemInfo(2.5, 50));
        Master.Add("pbjserving", new itemInfo(.75, 10));
        Master.Add("bltserving", new itemInfo(2.50, 10));
        Master.Add("chickenserving", new itemInfo(2, 10));
        Master.Add("bacon", new itemInfo(.75, 4000));
        Master.Add("ham", new itemInfo(.60, 4000));
        Master.Add("cheese", new itemInfo(.75, 4000));
        Master.Add("mayo", new itemInfo(0.0, 4000));
        Master.Add("mustard", new itemInfo(0.0, 4000));
        Master.Add("bbqsauce", new itemInfo(0.0, 4000));
        Master.Add("tomato", new itemInfo(.25, 4000));
        Master.Add("lettuce", new itemInfo(.25, 4000));



    }

    public void subtractfrominventory(int numberofitemstosubtract, string name)
    {
        int currentStock = Daily[name].amount;
        int newStock = currentStock - numberofitemstosubtract;
        double price = Master[name].price;
        if (currentStock==0 ||newStock < 0)
        {
            
            Console.WriteLine("I dont have that many!");
            return;
        }

        
        Daily.Remove(name);
        Daily.Add(name, new itemInfo(price, newStock));

    }

    private void AddToInventory(int numberofitemstoAdd, string name)
    {
        int currentStock = Daily[name].amount;
        int newStock = currentStock + numberofitemstoAdd;
        double price = Master[name].price;
        if (newStock > Master[name].amount)
        {
            newStock = Master[name].amount;

        }

        Daily.Remove(name);
        Daily.Add(name, new itemInfo(price, newStock));
        Console.WriteLine(name +" was restocked");

    }

    public void Reconcile()
    {
        foreach(var itemname in Daily.Keys.ToList())
        {
            int dailyVal = Daily[itemname].amount;
            int masterVal = Master[itemname].amount;
            int difference = masterVal - dailyVal;
            if(difference != 0)
            {
                AddToInventory(difference, itemname);
                AddRevenueSales(difference, itemname);
            }
           

        }
        
    }
     public void AddRevenueSales(int numberofItemsSold, string name)
    {

        TotalSales += (numberofItemsSold * Master[name].price);

        Console.WriteLine("Current revenue: " + TotalSales);

    }


}



