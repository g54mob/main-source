using System;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public class IUtils : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal IUtils(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		~IUtils()
		{
		}

		public virtual void Dispose()
		{
		}

		public virtual void ShowOverlayWithWebPage(string url)
		{
		}
	}
}
