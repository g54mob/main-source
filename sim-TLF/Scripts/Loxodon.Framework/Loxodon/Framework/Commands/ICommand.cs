using System;

namespace Loxodon.Framework.Commands
{
	public interface ICommand
	{
		event EventHandler CanExecuteChanged;

		bool CanExecute(object parameter);

		void Execute(object parameter);
	}
	public interface ICommand<T> : ICommand
	{
		bool CanExecute(T parameter);

		void Execute(T parameter);
	}
}
