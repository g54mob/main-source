using System;
using System.Collections.Generic;

namespace Mirror.RemoteCalls
{
	public static class RemoteCallHelper
	{
		private static readonly Dictionary<int, Invoker> cmdHandlerDelegates;

		internal static int GetMethodHash(Type invokeClass, string methodName)
		{
			return 0;
		}

		internal static int RegisterDelegate(Type invokeClass, string cmdName, MirrorInvokeType invokerType, CmdDelegate func, bool cmdRequiresAuthority = true)
		{
			return 0;
		}

		private static bool CheckIfDeligateExists(Type invokeClass, MirrorInvokeType invokerType, CmdDelegate func, int cmdHash)
		{
			return false;
		}

		public static void RegisterCommandDelegate(Type invokeClass, string cmdName, CmdDelegate func, bool requiresAuthority)
		{
		}

		public static void RegisterRpcDelegate(Type invokeClass, string rpcName, CmdDelegate func)
		{
		}

		internal static void RemoveDelegate(int hash)
		{
		}

		public static bool GetInvokerForHash(int cmdHash, MirrorInvokeType invokeType, out Invoker invoker)
		{
			invoker = null;
			return false;
		}

		internal static bool InvokeHandlerDelegate(int cmdHash, MirrorInvokeType invokeType, NetworkReader reader, NetworkBehaviour invokingType, NetworkConnectionToClient senderConnection = null)
		{
			return false;
		}

		internal static CommandInfo GetCommandInfo(int cmdHash, NetworkBehaviour invokingType)
		{
			return default(CommandInfo);
		}

		public static CmdDelegate GetDelegate(int cmdHash)
		{
			return null;
		}
	}
}
