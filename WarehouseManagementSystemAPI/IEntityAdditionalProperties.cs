using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManagementSystemAPI
{
    public interface IEntityAdditionalProperties
    {
        int Quantity { get; set; }
        decimal UnitValue { get; set; }

    }
}
