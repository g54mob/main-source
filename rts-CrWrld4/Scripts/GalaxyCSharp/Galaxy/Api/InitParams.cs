using System;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public class InitParams : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal InitParams(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		public InitParams(string _clientID, string _clientSecret)
		{
		}

		internal static HandleRef getCPtr(InitParams obj)
		{
			return default(HandleRef);
		}

		~InitParams()
		{
		}

		public virtual void Dispose()
		{
		}
	}
}
