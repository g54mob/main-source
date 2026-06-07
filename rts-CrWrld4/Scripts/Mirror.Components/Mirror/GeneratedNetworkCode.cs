using System.Runtime.InteropServices;
using Mirror.Discovery;
using UnityEngine;

namespace Mirror
{
	[StructLayout((LayoutKind)3, CharSet = CharSet.Auto)]
	public static class GeneratedNetworkCode
	{
		public static ReadyMessage _Read_Mirror_002EReadyMessage(NetworkReader reader)
		{
			return default(ReadyMessage);
		}

		public static void _Write_Mirror_002EReadyMessage(NetworkWriter writer, ReadyMessage value)
		{
		}

		public static NotReadyMessage _Read_Mirror_002ENotReadyMessage(NetworkReader reader)
		{
			return default(NotReadyMessage);
		}

		public static void _Write_Mirror_002ENotReadyMessage(NetworkWriter writer, NotReadyMessage value)
		{
		}

		public static AddPlayerMessage _Read_Mirror_002EAddPlayerMessage(NetworkReader reader)
		{
			return default(AddPlayerMessage);
		}

		public static void _Write_Mirror_002EAddPlayerMessage(NetworkWriter writer, AddPlayerMessage value)
		{
		}

		public static SceneMessage _Read_Mirror_002ESceneMessage(NetworkReader reader)
		{
			return default(SceneMessage);
		}

		public static SceneOperation _Read_Mirror_002ESceneOperation(NetworkReader reader)
		{
			return default(SceneOperation);
		}

		public static void _Write_Mirror_002ESceneMessage(NetworkWriter writer, SceneMessage value)
		{
		}

		public static void _Write_Mirror_002ESceneOperation(NetworkWriter writer, SceneOperation value)
		{
		}

		public static CommandMessage _Read_Mirror_002ECommandMessage(NetworkReader reader)
		{
			return default(CommandMessage);
		}

		public static void _Write_Mirror_002ECommandMessage(NetworkWriter writer, CommandMessage value)
		{
		}

		public static RpcMessage _Read_Mirror_002ERpcMessage(NetworkReader reader)
		{
			return default(RpcMessage);
		}

		public static void _Write_Mirror_002ERpcMessage(NetworkWriter writer, RpcMessage value)
		{
		}

		public static SpawnMessage _Read_Mirror_002ESpawnMessage(NetworkReader reader)
		{
			return default(SpawnMessage);
		}

		public static void _Write_Mirror_002ESpawnMessage(NetworkWriter writer, SpawnMessage value)
		{
		}

		public static ObjectSpawnStartedMessage _Read_Mirror_002EObjectSpawnStartedMessage(NetworkReader reader)
		{
			return default(ObjectSpawnStartedMessage);
		}

		public static void _Write_Mirror_002EObjectSpawnStartedMessage(NetworkWriter writer, ObjectSpawnStartedMessage value)
		{
		}

		public static ObjectSpawnFinishedMessage _Read_Mirror_002EObjectSpawnFinishedMessage(NetworkReader reader)
		{
			return default(ObjectSpawnFinishedMessage);
		}

		public static void _Write_Mirror_002EObjectSpawnFinishedMessage(NetworkWriter writer, ObjectSpawnFinishedMessage value)
		{
		}

		public static ObjectDestroyMessage _Read_Mirror_002EObjectDestroyMessage(NetworkReader reader)
		{
			return default(ObjectDestroyMessage);
		}

		public static void _Write_Mirror_002EObjectDestroyMessage(NetworkWriter writer, ObjectDestroyMessage value)
		{
		}

		public static ObjectHideMessage _Read_Mirror_002EObjectHideMessage(NetworkReader reader)
		{
			return default(ObjectHideMessage);
		}

		public static void _Write_Mirror_002EObjectHideMessage(NetworkWriter writer, ObjectHideMessage value)
		{
		}

		public static UpdateVarsMessage _Read_Mirror_002EUpdateVarsMessage(NetworkReader reader)
		{
			return default(UpdateVarsMessage);
		}

		public static void _Write_Mirror_002EUpdateVarsMessage(NetworkWriter writer, UpdateVarsMessage value)
		{
		}

		public static NetworkPingMessage _Read_Mirror_002ENetworkPingMessage(NetworkReader reader)
		{
			return default(NetworkPingMessage);
		}

		public static void _Write_Mirror_002ENetworkPingMessage(NetworkWriter writer, NetworkPingMessage value)
		{
		}

		public static NetworkPongMessage _Read_Mirror_002ENetworkPongMessage(NetworkReader reader)
		{
			return default(NetworkPongMessage);
		}

		public static void _Write_Mirror_002ENetworkPongMessage(NetworkWriter writer, NetworkPongMessage value)
		{
		}

		public static ServerRequest _Read_Mirror_002EDiscovery_002EServerRequest(NetworkReader reader)
		{
			return default(ServerRequest);
		}

		public static void _Write_Mirror_002EDiscovery_002EServerRequest(NetworkWriter writer, ServerRequest value)
		{
		}

		public static ServerResponse _Read_Mirror_002EDiscovery_002EServerResponse(NetworkReader reader)
		{
			return default(ServerResponse);
		}

		public static void _Write_Mirror_002EDiscovery_002EServerResponse(NetworkWriter writer, ServerResponse value)
		{
		}

		[RuntimeInitializeOnLoadMethod]
		public static void InitReadWriters()
		{
		}
	}
}
