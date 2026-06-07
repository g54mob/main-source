using System;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace Noesis
{
	public class CanExecuteRoutedEventArgs : RoutedEventArgs
	{
		private HandleRef swigCPtr;

		public ICommand Command => null;

		public object Parameter => null;

		public bool CanExecute
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool ContinueRouting
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		internal CanExecuteRoutedEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(CanExecuteRoutedEventArgs obj)
		{
			return default(HandleRef);
		}

		~CanExecuteRoutedEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		private object GetCommandHelper()
		{
			return null;
		}

		private object GetParameterHelper()
		{
			return null;
		}
	}
}
