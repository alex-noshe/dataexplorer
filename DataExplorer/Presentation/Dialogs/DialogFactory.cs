﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Importers.CsvFile;

namespace DataExplorer.Presentation.Dialogs
{
    public class DialogFactory : IDialogFactory
    {
        public IDialog CreateImportCsvFileDialog()
        {
            return new ImportCsvFileDialog();
        }

        public IOpenFileDialog CreateOpenFileDialog()
        {
            return new OpenFileDialogWrapper();
        }
    }
}