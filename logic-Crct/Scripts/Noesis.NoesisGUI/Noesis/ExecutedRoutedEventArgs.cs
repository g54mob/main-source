using System;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace Noesis
{
	public class ExecutedRoutedEventArgs : RoutedEventArgs
	{
		private HandleRef swigCPtr;

		public ICommand Command => null;

		public object Parameter => null;

		internal ExecutedRoutedEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ExecutedRoutedEventArgs obj)
		{
			return default(HandleRef);
		}

		~ExecutedRoutedEventArgs()
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
