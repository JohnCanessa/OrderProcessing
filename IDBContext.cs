using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockDB
{

    /// <summary>
    /// Methods to be mocked.
    /// </summary>
    public interface IDBContext
    {
        // **** method to be mocked ****
        Order GetNextOrderDetailFromDB(int orderID);

        // **** method to be mocked ****
        void SaveOrder(Order nextOrder);
    }
}
