using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class HitTestResult : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public DependencyObject VisualHit => null;

		internal HitTestResult(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(HitTestResult obj)
		{
			return default(HandleRef);
		}

		~HitTestResult()
		{
		}

		public virtual void Dispose()
		{
		}

		public HitTestResult()
		{
		}

		private DependencyObject GetVisualHit()
		{
			return null;
		}
	}
}
