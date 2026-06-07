using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace Noesis
{
	public class RoutedCommand : BaseComponent, ICommand
	{
		public string Name => null;

		public Type OwnerType => null;

		public InputGestureCollection InputGestures => null;

		public event System.EventHandler CanExecuteChanged
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

		internal new static RoutedCommand CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal RoutedCommand(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(RoutedCommand obj)
		{
			return default(HandleRef);
		}

		public void RaiseCanExecuteChanged()
		{
		}

		public RoutedCommand()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public RoutedCommand(string name, Type owner)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public RoutedCommand(string name, Type owner, InputGestureCollection inputGestures)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public bool CanExecute(object param, UIElement target)
		{
			return false;
		}

		public void Execute(object param, UIElement target)
		{
		}

		public bool CanExecute(object param)
		{
			return false;
		}

		public void Execute(object param)
		{
		}
	}
}
