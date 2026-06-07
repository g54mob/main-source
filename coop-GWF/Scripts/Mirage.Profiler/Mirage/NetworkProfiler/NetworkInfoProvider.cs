using System.Text.RegularExpressions;
using Mirror;
using Mirror.RemoteCalls;

namespace Mirage.NetworkProfiler
{
	public class NetworkInfoProvider : INetworkInfoProvider
	{
		private static class MirrorMethodNameTrimmer
		{
			private static readonly Regex regex1 = new Regex("^InvokeUserCode_", RegexOptions.Compiled);

			private static readonly Regex regex2 = new Regex("__[A-Z][\\w`]*$", RegexOptions.Compiled);

			public static string FixMethodName(string methodName)
			{
				methodName = regex1.Replace(methodName, "");
				methodName = regex2.Replace(methodName, "");
				return methodName;
			}
		}

		public uint? GetNetId(NetworkDiagnostics.MessageInfo info)
		{
			NetworkMessage message = info.message;
			if (!(message is CommandMessage commandMessage))
			{
				if (!(message is RpcMessage rpcMessage))
				{
					if (!(message is SpawnMessage spawnMessage))
					{
						if (!(message is ChangeOwnerMessage changeOwnerMessage))
						{
							if (!(message is ObjectDestroyMessage objectDestroyMessage))
							{
								if (!(message is ObjectHideMessage objectHideMessage))
								{
									if (message is EntityStateMessage entityStateMessage)
									{
										return entityStateMessage.netId;
									}
									return null;
								}
								return objectHideMessage.netId;
							}
							return objectDestroyMessage.netId;
						}
						return changeOwnerMessage.netId;
					}
					return spawnMessage.netId;
				}
				return rpcMessage.netId;
			}
			return commandMessage.netId;
		}

		public NetworkIdentity GetNetworkIdentity(uint? netId)
		{
			if (!netId.HasValue)
			{
				return null;
			}
			if (NetworkServer.active)
			{
				NetworkServer.spawned.TryGetValue(netId.Value, out var value);
				return value;
			}
			if (NetworkClient.active)
			{
				NetworkClient.spawned.TryGetValue(netId.Value, out var value2);
				return value2;
			}
			return null;
		}

		public string GetRpcName(NetworkDiagnostics.MessageInfo info)
		{
			NetworkMessage message = info.message;
			if (!(message is CommandMessage commandMessage))
			{
				if (message is RpcMessage rpcMessage)
				{
					return GetRpcName(rpcMessage.netId, rpcMessage.componentIndex, rpcMessage.functionHash);
				}
				return string.Empty;
			}
			return GetRpcName(commandMessage.netId, commandMessage.componentIndex, commandMessage.functionHash);
		}

		private string GetRpcName(uint netId, int componentIndex, ushort functionIndex)
		{
			RemoteCallDelegate remoteCallDelegate = RemoteProcedureCalls.GetDelegate(functionIndex);
			if (remoteCallDelegate != null)
			{
				string text = MirrorMethodNameTrimmer.FixMethodName(remoteCallDelegate.Method.Name);
				return remoteCallDelegate.Method.DeclaringType?.FullName + "." + text;
			}
			return string.Empty;
		}
	}
}
