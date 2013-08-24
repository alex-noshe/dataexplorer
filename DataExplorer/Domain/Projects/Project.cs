﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Sources;

namespace DataExplorer.Domain.Projects
{
    public class Project
    {
        public List<ISource> Sources { get; set; }

        public List<Column> Columns { get; set; }

        public List<Row> Rows { get; set; }

        public IScatterPlot ScatterPlot  { get; set; }
    }
}
