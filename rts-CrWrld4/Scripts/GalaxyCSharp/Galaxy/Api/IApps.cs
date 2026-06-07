using System;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public class IApps : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal IApps(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		~IApps()
		{
		}

		public virtual void Dispose()
		{
		}

		public virtual bool IsDlcInstalled(ulong productID)
		{
			return false;
		}

		public virtual string GetCurrentGameLanguage()
		{
			return null;
		}
	}
}
