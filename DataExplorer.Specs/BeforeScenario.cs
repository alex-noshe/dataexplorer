﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application;
using DataExplorer.Application.Application;
using DataExplorer.Infrastructure.Importers.CsvFile;
using DataExplorer.Infrastructure.Serialization;
using DataExplorer.Persistence;
using DataExplorer.Persistence.Columns;
using DataExplorer.Persistence.Rows;
using DataExplorer.Persistence.Views;
using DataExplorer.Presentation.Importers.CsvFile;
using DataExplorer.Presentation.Shell.MainMenu.FileMenu;
using DataExplorer.Presentation.Shell.MainWindow;
using Moq;
using Ninject;
using TechTalk.SpecFlow;
using Ninject.Extensions.Conventions;

namespace DataExplorer.Specs
{
    [Binding]
    public class BeforeScenario
    {
        private readonly Context _context;

        public BeforeScenario(Context context)
        {
            _context = context;
        }

        [BeforeScenario]
        public void ExecuteBeforeScenario()
        {
            // TODO: Eliminate this duplication
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetAssembly(typeof(MainWindowViewModel)));
            kernel.Bind(p => p.From(Assembly.GetAssembly(typeof(MainWindowViewModel)))
                .SelectAllClasses()
                .BindAllInterfaces()
                .Configure(c => c.InSingletonScope()));
            kernel.Load(Assembly.GetAssembly(typeof(Context)));
            kernel.Bind(p => p.FromThisAssembly()
                .SelectAllClasses()
                .BindAllInterfaces()
                .Configure(c => c.InSingletonScope()));

            _context.MockApplicationService = new Mock<IApplicationService>();
            kernel.Rebind<IApplicationService>().ToConstant(_context.MockApplicationService.Object);

            _context.MockSerializationService = new Mock<ISerializationService>();
            kernel.Rebind<ISerializationService>().ToConstant(_context.MockSerializationService.Object);

            _context.MockCsvFileParser = new Mock<ICsvFileParser>();
            kernel.Rebind<ICsvFileParser>().ToConstant(_context.MockCsvFileParser.Object);
            
            _context.MainWindowViewModel = kernel.Get<MainWindowViewModel>();
            _context.FileMenuViewModel = kernel.Get<IFileMenuViewModel>();
            _context.CsvFileImportViewModel = kernel.Get<ICsvFileImportViewModel>();

            _context.DataContext = kernel.Get<IDataContext>();
        }
    }
}
