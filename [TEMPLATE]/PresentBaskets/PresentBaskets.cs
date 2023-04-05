using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    // *****************************************
    // DON'T CHANGE CLASS OR FUNCTION NAME
    // YOU CAN ADD FUNCTIONS IF YOU NEED TO
    // *****************************************
    public static class PresentBaskets
    {
        #region YOUR CODE IS HERE
        /// <summary>
        /// fill the 2 baskets with the most expensive collection of fruits.
        /// </summary>
        /// <param name="W1">weight of 1st basket</param>
        /// <param name="W2">weight of 2nd basket</param>
        /// <param name="items">Pair of weight (Key) & cost (Value) of each item</param>
        /// <returns>max total cost to fill two baskets</returns>
        static public double PreparePresentBaskets(int W1, int W2, KeyValuePair<int, int>[] items)
        {                                                              //        W    C
            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();
                                                                  //  cost/unit  #units
            KeyValuePair<double, int>[] cost_per_unit = new KeyValuePair<double, int>[items.Length];

            for (int i = 0; i < items.Length; i++)
            {
               
                //Console.WriteLine("items: " + items[i].Key + ": " + items[i].Value);

                if (items[i].Key == 0)
                    continue;

                cost_per_unit[i] = new KeyValuePair<double, int>((double)items[i].Value / items[i].Key, items[i].Key);
                //Console.WriteLine("cost_per_unit : " + cost_per_unit[i].Key.ToString() + ": " + cost_per_unit[i].Value.ToString());
            }
            Array.Sort(cost_per_unit, (a, b) => b.Key.CompareTo(a.Key));
            double totalCost = 0;

            //foreach (var item in cost_per_unit)
            //    Console.WriteLine(item.Key.ToString() + ": " + item.Value.ToString());

            for (int i = 0; i < cost_per_unit.Length; i++) 
            { 
                if(W1 == 0 && W2 == 0)
                    return totalCost;

                if (W1 >= cost_per_unit[i].Value)
                {
                    totalCost += cost_per_unit[i].Value * cost_per_unit[i].Key;
                    W1 -= cost_per_unit[i].Value;
                    //Console.WriteLine("W1 >= item.Value: W1 now = {0}", W1);
                    continue;

                }
                else if (W2 >= cost_per_unit[i].Value)
                {
                    totalCost += cost_per_unit[i].Value * cost_per_unit[i].Key;
                    W2 -= cost_per_unit[i].Value;
                    //Console.WriteLine("W2 >= item.Value: W2 now = " + W2);
                    continue;

                }
                else if(W1 < cost_per_unit[i].Value && W1 != 0)
                {
                    //Console.WriteLine("-------- OLD W1 < item.Value && W1 != 0: W1 now = {0} and  i = {2} and old weight is = {1} ", W1, i, cost_per_unit[i].Value);

                    totalCost += W1 * cost_per_unit[i].Key;     
                    cost_per_unit[i] = new KeyValuePair<double, int>(cost_per_unit[i].Key, cost_per_unit[i].Value - W1);
                    W1 = 0;
              
                    //Console.WriteLine("W1 < item.Value && W1 != 0: W1 now = {0} and  i = {2} and new weight is = {1} ", W1,i, cost_per_unit[i].Value);

                }
                else if(W2 < cost_per_unit[i].Value && W2 != 0)
                {
                    //Console.WriteLine("-------- OLD W2 < item.Value && W2 != 0: W1 now = {0} and  i = {2} and old weight is = {1} ", W2, i, cost_per_unit[i].Value);

                    totalCost += W2 * cost_per_unit[i].Key;             
                    cost_per_unit[i] = new KeyValuePair<double, int>(cost_per_unit[i].Key, cost_per_unit[i].Value - W2);

                    W2 = 0;
                    //Console.WriteLine("W2 < item.Value && W1 != 0: W2 now = {0} and  i = {2} and new weight is = {1} ", W2, i, cost_per_unit[i].Value);
                }


                if (W1 + W2 < cost_per_unit[i].Value)
                {
                    totalCost += (W1 + W2) * cost_per_unit[i].Key;
                    //W1 = 0; 
                    //W2 = 0;
                    //Console.WriteLine("W1 + W2 < item.Value: W1 now = {0}, W2 now = {1}", W1, W2);
                    return totalCost;
                }
                if (cost_per_unit[i].Value != 0)
                    i--;
            }
            return totalCost;
        }
        #endregion
    }
}
