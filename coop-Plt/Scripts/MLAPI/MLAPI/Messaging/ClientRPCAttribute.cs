using System;

namespace MLAPI.Messaging
{
	[AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
	public class ClientRPCAttribute : RPCAttribute
	{
	}
}
