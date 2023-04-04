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

            SortedDictionary<double, int> cost_per_unit = new SortedDictionary<double, int>();

            for (int i = 0; i < items.Length; i++)
                cost_per_unit.Add(items[i].Value / items[i].Key, items[i].Key);

            double totalCost = 0;

            foreach (var item in cost_per_unit)
            {
                if(W1 >= item.Value)
                {
                    totalCost += item.Value * item.Key;
                    W1 -= item.Value;
                }
                else if (W2 >= item.Value)
                {
                    totalCost += item.Value * item.Key;
                    W2 -= item.Value;
                }
                
            }
            return totalCost;
        }
        #endregion
    }
}
