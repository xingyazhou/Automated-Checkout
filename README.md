# Project : Automated Checkout System
An automated checkout system prototype for a store
## Introduction 

A store has the following products 
| Item        | Id          | Price        |
| :---        |    :----:   |      :---    |
| Toothpaste  | 1           | 24.95Kr      |
| Cheese      | 2           | 59.00Kr/kg   |
| Bread       | 3           | 11.95Kr     |
| Coffee      | 4           | 22.49Kr     |
| Appels      | 5           | 32.95Kr/kg  |
| Flour       |6            | 11.95Kr     |
| Ground      | 7           | 93.00Kr/kg  |
| Milk        |8            | 9.32Kr      |

There is an automated checkout where each item is entered by its item identification and when all items have been entered it is possible to get the total cost for the items. There are however some special offers that needs to be taken into the account when calculating the total sum. The special offers are as follows:

*	Buy two packs of coffee for 40kr.
*	Buy three packs of toothpaste and pay for two.
*	Shop other items for over 150kr and you can buy appels for the price of 16.95Kr/kg

The task is as follows. Write a class named “Checkout” that has three methods
*	AddItem(itemId : int) is called each time an item that does not have a price per weight is entered into the checkout.
*	AddItem(itemId : int, weight : double) is called each time an item that does have a price per weight is entered into the checkout. 
*	Sum() : double is called only when all items has been checked into the checkout. It returns the total sum for all items accounting for the special offers.
