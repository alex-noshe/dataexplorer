﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Persistence.Columns
{
    public interface IColumnRepository
    {
        List<Column> GetAll();
        Column Get(int id);
        void Add(Column column);
    }
}
