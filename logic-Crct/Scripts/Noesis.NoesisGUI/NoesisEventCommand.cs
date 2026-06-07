using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using UnityEngine.Events;

[Serializable]
public class NoesisEventCommand : UnityEvent<object>, ICommand
{
	private object[] _canExecuteParam;

	public event EventHandler CanExecuteChanged
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public bool CanExecute(object parameter)
	{
		return false;
	}

	public void Execute(object parameter)
	{
	}

	public void RaiseCanExecuteChanged()
	{
	}
}
