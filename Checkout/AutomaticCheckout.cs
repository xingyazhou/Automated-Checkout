﻿using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Checkout
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Toothpaste 1
            // Cheese 2
            // Bread 3
            // Coffee 4
            // Apples 5
            // Flour 6
            // Groud Beef 7
            // Milk 8

            // Test Case 1
            //Console.WriteLine("Hello, world!");
            AutoCheckout check = new AutoCheckout();

            // buy three packs of toothpaste, special offer should be used
            check.AddItem(1);
            check.AddItem(1);
            check.AddItem(1);
            // buy two packs of coffee, special offer should be used
            check.AddItem(4);
            check.AddItem(4);
            // buy 2.5kg Groud Beef
            check.AddItem(7, 2.5);
            // buy 2.7kg Apples, if other iterm > 150 kr, special offers should be used
            check.AddItem(5, 2.7);

            double s = check.Sum();
            //Console.WriteLine("value = {0}", s);

            // Assert.Equal(expected: 368.165, actual: s);

        }
    }

    class Product
    {
        public virtual double totalprice(double price, double quantity)
        {
            return (price * quantity);
        }
        public virtual double totalprice(double price, int quantity)
        {
            return (price * quantity);
        }
    }

    class Toothpaste : Product
    {
        public override double totalprice(double price, int quantity)
        {
            return (price * (quantity - quantity / 3));
        }
    }

    class Coffee : Product
    {
        public override double totalprice(double price, int quantity)
        {
            return (40 * (quantity / 2) + price * (quantity % 2));
        }
    }

    public class AutoCheckout
    {

        public Hashtable PRICETABLE = new Hashtable();
        public AutoCheckout()
        {
            PRICETABLE.Add(1, 24.95);
            PRICETABLE.Add(2, 59.00);
            PRICETABLE.Add(3, 11.95);
            PRICETABLE.Add(4, 22.49);
            PRICETABLE.Add(5, 32.95);
            PRICETABLE.Add(6, 11.95);
            PRICETABLE.Add(7, 93.00);
            PRICETABLE.Add(8, 9.32);
        }

        public Hashtable shoppinglist1 = new Hashtable();
        public Hashtable shoppinglist2 = new Hashtable();

        public double sum = 0;
        public void AddItem(int itemId)
        {
            if (shoppinglist1.ContainsKey(itemId))
            {
                shoppinglist1[itemId] = (int)shoppinglist1[itemId] + 1;
            }
            else
            {
                shoppinglist1.Add(itemId, 1);
            }
        }

        public void AddItem(int itemId, double weight)
        {
            if (shoppinglist2.ContainsKey(itemId))
            {
                shoppinglist2[itemId] = (double)shoppinglist2[itemId] + weight;
            }
            else
            {
                shoppinglist2.Add(itemId, weight);
            }
        }

        public double Sum()
        {
            double appleweight = 0;
            Product p = new Product();

            //Special offer for Toothpaste: Buy three packs of toothpaste and pay for two
            if (shoppinglist1.ContainsKey(1))
            {
                Toothpaste t = new Toothpaste();
                sum = sum + t.totalprice((double)PRICETABLE[1], (int)shoppinglist1[1]);
                shoppinglist1.Remove(1);
            }

            //Special offer for Coffee: Buy two packs of coffee for 40kr
            if (shoppinglist1.ContainsKey(4))
            {
                Coffee c = new Coffee();
                sum = sum + c.totalprice((double)PRICETABLE[4], (int)shoppinglist1[4]);
                shoppinglist1.Remove(4);
            }

            ICollection key1 = shoppinglist1.Keys;
            foreach (int k1 in key1)
            {
                sum = sum + p.totalprice((double)PRICETABLE[k1], (int)shoppinglist1[k1]);
            }

            //Remove Apples from shoppinglist2 if existed
            if (shoppinglist2.ContainsKey(5))
            {
                appleweight = (double)shoppinglist2[5];
                shoppinglist2.Remove(5);
            }

            ICollection key2 = shoppinglist2.Keys;
            foreach (int k2 in key2)
            {
                sum = sum + p.totalprice((double)PRICETABLE[k2], (double)shoppinglist2[k2]);
            }

            //Special offer for apples: Shop other items for over 150kr and you can buy apples for the price of 16.95kr/kg
            if (appleweight != 0)
            {
                if (sum > 150)
                {
                    sum = sum + p.totalprice(16.95, appleweight);
                }
                else
                {
                    sum = sum + p.totalprice((double)PRICETABLE[5], appleweight);
                }
            }
            return sum;
        }
    }
}
