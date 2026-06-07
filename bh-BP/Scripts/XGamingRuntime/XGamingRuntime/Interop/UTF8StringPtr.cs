using System;

namespace XGamingRuntime.Interop
{
	internal struct UTF8StringPtr
	{
		private IntPtr pointer;

		internal UTF8StringPtr(string str, DisposableCollection disposableCollection)
		{
			pointer = (IntPtr)0;
		}

		internal string GetString()
		{
			return null;
		}

		internal IntPtr ToPointer()
		{
			return (IntPtr)0;
		}
	}
}
