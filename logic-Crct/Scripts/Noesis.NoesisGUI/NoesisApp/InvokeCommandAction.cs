using System.Windows.Input;
using Noesis;

namespace NoesisApp
{
	public class InvokeCommandAction : TriggerAction<DependencyObject>
	{
		public static readonly DependencyProperty CommandProperty;

		public static readonly DependencyProperty CommandParameterProperty;

		private string _commandName;

		public string CommandName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ICommand Command
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public object CommandParameter
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public new InvokeCommandAction Clone()
		{
			return null;
		}

		public new InvokeCommandAction CloneCurrentValue()
		{
			return null;
		}

		protected override void Invoke(object parameter)
		{
		}

		private ICommand ResolveCommand()
		{
			return null;
		}
	}
}
