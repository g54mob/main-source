using System;
using Loxodon.Framework.Commands;

namespace Loxodon.Framework.Binding.Parameters
{
	public class ParameterWrapCommand : ParameterWrapBase, ICommand
	{
		private readonly object _lock = new object();

		private readonly ICommand wrappedCommand;

		public event EventHandler CanExecuteChanged
		{
			add
			{
				lock (_lock)
				{
					wrappedCommand.CanExecuteChanged += value;
				}
			}
			remove
			{
				lock (_lock)
				{
					wrappedCommand.CanExecuteChanged -= value;
				}
			}
		}

		public ParameterWrapCommand(ICommand wrappedCommand, ICommandParameter commandParameter)
			: base(commandParameter)
		{
			if (wrappedCommand == null)
			{
				throw new ArgumentNullException("wrappedCommand");
			}
			this.wrappedCommand = wrappedCommand;
		}

		public bool CanExecute(object parameter)
		{
			return wrappedCommand.CanExecute(GetParameterValue());
		}

		public void Execute(object parameter)
		{
			object parameterValue = GetParameterValue();
			if (wrappedCommand.CanExecute(parameterValue))
			{
				wrappedCommand.Execute(parameterValue);
			}
		}
	}
	public class ParameterWrapCommand<T> : ICommand
	{
		private readonly object _lock = new object();

		private readonly ICommand<T> wrappedCommand;

		private readonly ICommandParameter<T> commandParameter;

		public event EventHandler CanExecuteChanged
		{
			add
			{
				lock (_lock)
				{
					wrappedCommand.CanExecuteChanged += value;
				}
			}
			remove
			{
				lock (_lock)
				{
					wrappedCommand.CanExecuteChanged -= value;
				}
			}
		}

		public ParameterWrapCommand(ICommand<T> wrappedCommand, ICommandParameter<T> commandParameter)
		{
			if (wrappedCommand == null)
			{
				throw new ArgumentNullException("wrappedCommand");
			}
			if (commandParameter == null)
			{
				throw new ArgumentNullException("commandParameter");
			}
			this.commandParameter = commandParameter;
			this.wrappedCommand = wrappedCommand;
		}

		public bool CanExecute(object parameter)
		{
			return wrappedCommand.CanExecute(commandParameter.GetValue());
		}

		public void Execute(object parameter)
		{
			T value = commandParameter.GetValue();
			if (wrappedCommand.CanExecute(value))
			{
				wrappedCommand.Execute(value);
			}
		}
	}
}
