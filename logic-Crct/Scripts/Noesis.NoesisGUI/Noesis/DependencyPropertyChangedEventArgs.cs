using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DependencyPropertyChangedEventArgs : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public object NewValue => null;

		public object OldValue => null;

		public DependencyProperty Property => null;

		internal DependencyPropertyChangedEventArgs(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(DependencyPropertyChangedEventArgs obj)
		{
			return default(HandleRef);
		}

		~DependencyPropertyChangedEventArgs()
		{
		}

		public virtual void Dispose()
		{
		}

		internal static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		private object GetValueHelper(object value)
		{
			return null;
		}

		private IntPtr GetNewValueHelper()
		{
			return (IntPtr)0;
		}

		private IntPtr GetOldValueHelper()
		{
			return (IntPtr)0;
		}

		private DependencyProperty GetPropertyHelper()
		{
			return null;
		}
	}
}
