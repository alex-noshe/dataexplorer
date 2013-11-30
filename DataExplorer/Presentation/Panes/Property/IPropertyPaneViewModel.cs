﻿using System.Collections.Generic;
using DataExplorer.Application.Rows;

namespace DataExplorer.Presentation.Panes.Property
{
    public interface IPropertyPaneViewModel
    {
        IEnumerable<IPropertyViewModel> Properties { get; }

        void Handle(SelectedRowsChangedEvent args);
    }
}