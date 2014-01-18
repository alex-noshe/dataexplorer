﻿using System.Collections.Generic;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Presentation.Views.ScatterPlots.Grid.Factories.FloatGridLines
{
    public interface IFloatGridLineFactory
    {
        IEnumerable<AxisGridLine> Create(AxisMap map, double lower, double upper);
    }
}