﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.Renderers
{
    public class ScatterPlotYAxisLabelRenderer : IScatterPlotYAxisLabelRenderer
    {
        public CanvasYAxisLabel Render(Size controlSize, string text)
        {
            var label = new CanvasYAxisLabel();
            
            label.X = 10;

            label.Y = controlSize.Height / 2;

            label.Text = text;

            return label;
        }
    }
}
