using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class TraversalRequest : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public FocusNavigationDirection FocusNavigationDirection => default(FocusNavigationDirection);

		public bool Wrapped
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		internal TraversalRequest(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(TraversalRequest obj)
		{
			return default(HandleRef);
		}

		~TraversalRequest()
		{
		}

		public virtual void Dispose()
		{
		}

		public TraversalRequest(FocusNavigationDirection direction)
		{
		}
	}
}
