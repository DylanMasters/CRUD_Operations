using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Operations
{
    class ProductRepository
    {
        public string connString;

        public ProductRepository(string _connectionString)
        {
            connString = _connectionString;
        }
        
    }
}
