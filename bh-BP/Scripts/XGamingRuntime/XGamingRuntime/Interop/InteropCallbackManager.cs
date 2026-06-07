using System;
using System.Collections.Generic;

namespace XGamingRuntime.Interop
{
	public class InteropCallbackManager<TDelegate> where TDelegate : class
	{
		protected struct HandlerContext
		{
			public IntPtr Context;

			public TDelegate Callback;
		}

		protected readonly Dictionary<IntPtr, int> _contextToFunctionId;

		protected readonly Dictionary<int, HandlerContext> _functionIdToHandler;

		private int _availableContextId;

		internal IntPtr GetUniqueContext()
		{
			return (IntPtr)0;
		}

		internal void AddCallbackForId(int functionId, IntPtr context, TDelegate callback)
		{
		}

		internal void RemoveCallbackForId(int functionId)
		{
		}
	}
}
