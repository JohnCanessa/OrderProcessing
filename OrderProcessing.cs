using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace MockDB
{
    /// <summary>
    /// The example in the article is an Order Processing class, 
    /// mimicking the order processing system. 
    /// The business logic in this class is to fetch an order from a database (by order Id), 
    /// adding 10% GST (Goods and Services Tax) on the amount, 
    /// and then saving it back to the database.
    /// </summary>
    public class OrderProcessing
    {

        // **** object responsible for database operation ****
        private IDBContext _dbContext;


        /// <summary>
        /// Reads the order from the database.
        /// Calculates and updates the Amount by the GST (10%).
        /// Saves the updated record in the database.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Order ProcessGSTForNextOrder(IDBContext dbContext, int orderId)
        {

            // **** ****
            _dbContext = dbContext;

            // **** get order by orderId ****
            var nextOrder = dbContext.GetNextOrderDetailFromDB(orderId);

            // **** calculate and update the order amount ****
            nextOrder.Amount = CalculateTotalAmountWithGST(nextOrder);

            // **** save the updated order in the database ****
            _dbContext.SaveOrder(nextOrder);

            // **** return the updated order ****
            return nextOrder;
        }


        /// <summary>
        /// This method calclates the updated amount for the specified order.
        /// The amount is incremented by 10%.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public decimal CalculateTotalAmountWithGST(Order order)
        {
            return order.Amount + ((order.Amount * 10) / 100);
        }
    }
}
