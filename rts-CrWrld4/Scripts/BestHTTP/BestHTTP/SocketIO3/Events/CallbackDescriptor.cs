using System;

namespace BestHTTP.SocketIO3.Events
{
	public struct CallbackDescriptor
	{
		public readonly Type[] ParamTypes;

		public readonly Action<object[]> Callback;

		public readonly bool Once;

		public CallbackDescriptor(Type[] paramTypes, Action<object[]> callback, bool once)
		{
			ParamTypes = null;
			Callback = null;
			Once = false;
		}
	}
}
