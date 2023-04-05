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
                if (items[i].Key == 0)
                    continue;
                cost_per_unit[i] = new KeyValuePair<double, int>((double)items[i].Value / items[i].Key, items[i].Key);
            }

            Array.Sort(cost_per_unit, (a, b) => b.Key.CompareTo(a.Key));
            double totalCost = 0;

            for (int i = 0; i < cost_per_unit.Length; i++) 
            { 
                if(W1 == 0 && W2 == 0)
                    return totalCost;

                if (W1 >= cost_per_unit[i].Value)
                {
                    totalCost += cost_per_unit[i].Value * cost_per_unit[i].Key;
                    W1 -= cost_per_unit[i].Value;
                    continue;
                }
                else if (W2 >= cost_per_unit[i].Value)
                {
                    totalCost += cost_per_unit[i].Value * cost_per_unit[i].Key;
                    W2 -= cost_per_unit[i].Value;
                    continue;
                }
                else if(W1 < cost_per_unit[i].Value && W1 != 0)
                {
                    totalCost += W1 * cost_per_unit[i].Key;     
                    cost_per_unit[i] = new KeyValuePair<double, int>(cost_per_unit[i].Key, cost_per_unit[i].Value - W1);
                    W1 = 0;
                }
                else if(W2 < cost_per_unit[i].Value && W2 != 0)
                {
                    totalCost += W2 * cost_per_unit[i].Key;             
                    cost_per_unit[i] = new KeyValuePair<double, int>(cost_per_unit[i].Key, cost_per_unit[i].Value - W2);
                    W2 = 0;
                }

                if (W1 + W2 < cost_per_unit[i].Value)
                {
                    totalCost += (W1 + W2) * cost_per_unit[i].Key;
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
