﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation;
using Ninject;

namespace DataExplorer.Application.Core.Commands
{
    public class CommandBus : ICommandBus
    {
        public static IKernel Kernel;
        private readonly ICommandLogger _logger;
        private readonly IExceptionDialogService _dialogService;

        public CommandBus(
            ICommandLogger logger, 
            IExceptionDialogService dialogService)
        {
            _logger = logger;
            _dialogService = dialogService;
        }

        public void Execute(ICommand command)
        {
            try
            {
                _logger.LogExecuting(command);

                var handlerType = typeof(ICommandHandler<>)
                    .MakeGenericType(command.GetType());

                dynamic handler = Kernel.Get(handlerType);

                handler.Execute((dynamic)command);

                _logger.LogExecuted(command);
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);

                _dialogService.Show(ex);
            }
        }
    }
}
