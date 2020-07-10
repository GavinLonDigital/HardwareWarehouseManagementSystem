using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManagementSystemAPI
{
     public interface IEntityPrimaryProperties
     {
        int Id { get; set; }
        string Name { get; set; }
        string Type { get; set; }
        
     }
}
