using System;

namespace BestHTTP.SocketIO3
{
	public struct EmitBuilder
	{
		private Socket socket;

		internal bool isVolatile;

		internal int id;

		internal EmitBuilder(Socket s)
		{
			socket = null;
			isVolatile = false;
			id = 0;
		}

		public EmitBuilder ExpectAcknowledgement(Action callback)
		{
			return default(EmitBuilder);
		}

		public EmitBuilder ExpectAcknowledgement<T>(Action<T> callback)
		{
			return default(EmitBuilder);
		}

		public EmitBuilder Volatile()
		{
			return default(EmitBuilder);
		}

		public Socket Emit(string eventName, params object[] args)
		{
			return null;
		}
	}
}
