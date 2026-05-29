using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using FishNet.Component.Transforming;
using FishNet.Connection;
using FishNet.Managing.Scened;
using FishNet.Managing.Server;
using FishNet.Object;
using FishNet.Transporting;
using UnityEngine;

namespace FishNet.Serializing.Generated
{
	[StructLayout((LayoutKind)3, CharSet = CharSet.Auto)]
	public static class GeneratedReaders___Internal
	{
		[RuntimeInitializeOnLoadMethod]
		private static void InitializeOnce()
		{
		}

		public static byte InstancedExtension___ReadByte(this Reader reader)
		{
			return 0;
		}

		public static sbyte InstancedExtension___ReadSByte(this Reader reader)
		{
			return 0;
		}

		public static char InstancedExtension___ReadChar(this Reader reader)
		{
			return '\0';
		}

		public static bool InstancedExtension___ReadBoolean(this Reader reader)
		{
			return false;
		}

		public static ushort InstancedExtension___ReadUInt16(this Reader reader)
		{
			return 0;
		}

		public static short InstancedExtension___ReadInt16(this Reader reader)
		{
			return 0;
		}

		public static uint InstancedExtension___ReadUInt32(this Reader reader, AutoPackType packType1 = AutoPackType.Packed)
		{
			return 0u;
		}

		public static int InstancedExtension___ReadInt32(this Reader reader, AutoPackType packType1 = AutoPackType.Packed)
		{
			return 0;
		}

		public static long InstancedExtension___ReadInt64(this Reader reader, AutoPackType packType1 = AutoPackType.Packed)
		{
			return 0L;
		}

		public static ulong InstancedExtension___ReadUInt64(this Reader reader, AutoPackType packType1 = AutoPackType.Packed)
		{
			return 0uL;
		}

		public static float InstancedExtension___ReadSingle(this Reader reader, AutoPackType packType1 = AutoPackType.Unpacked)
		{
			return 0f;
		}

		public static double InstancedExtension___ReadDouble(this Reader reader)
		{
			return 0.0;
		}

		public static decimal InstancedExtension___ReadDecimal(this Reader reader)
		{
			return default(decimal);
		}

		public static string InstancedExtension___ReadString(this Reader reader)
		{
			return null;
		}

		public static byte[] InstancedExtension___ReadBytesAndSizeAllocated(this Reader reader)
		{
			return null;
		}

		public static ArraySegment<byte> InstancedExtension___ReadArraySegmentAndSize(this Reader reader)
		{
			return default(ArraySegment<byte>);
		}

		public static Vector2 InstancedExtension___ReadVector2(this Reader reader)
		{
			return default(Vector2);
		}

		public static Vector3 InstancedExtension___ReadVector3(this Reader reader)
		{
			return default(Vector3);
		}

		public static Vector4 InstancedExtension___ReadVector4(this Reader reader)
		{
			return default(Vector4);
		}

		public static Vector2Int InstancedExtension___ReadVector2Int(this Reader reader, AutoPackType packType1 = AutoPackType.Packed)
		{
			return default(Vector2Int);
		}

		public static Vector3Int InstancedExtension___ReadVector3Int(this Reader reader, AutoPackType packType1 = AutoPackType.Packed)
		{
			return default(Vector3Int);
		}

		public static Color InstancedExtension___ReadColor(this Reader reader, AutoPackType packType1 = AutoPackType.Packed)
		{
			return default(Color);
		}

		public static Color32 InstancedExtension___ReadColor32(this Reader reader)
		{
			return default(Color32);
		}

		public static Quaternion InstancedExtension___ReadQuaternion(this Reader reader, AutoPackType packType1 = AutoPackType.Packed)
		{
			return default(Quaternion);
		}

		public static Rect InstancedExtension___ReadRect(this Reader reader)
		{
			return default(Rect);
		}

		public static Plane InstancedExtension___ReadPlane(this Reader reader)
		{
			return default(Plane);
		}

		public static Ray InstancedExtension___ReadRay(this Reader reader)
		{
			return default(Ray);
		}

		public static Ray2D InstancedExtension___ReadRay2D(this Reader reader)
		{
			return default(Ray2D);
		}

		public static Matrix4x4 InstancedExtension___ReadMatrix4x4(this Reader reader)
		{
			return default(Matrix4x4);
		}

		public static Guid InstancedExtension___ReadGuid(this Reader reader)
		{
			return default(Guid);
		}

		public static GameObject InstancedExtension___ReadGameObject(this Reader reader)
		{
			return null;
		}

		public static Transform InstancedExtension___ReadTransform(this Reader reader)
		{
			return null;
		}

		public static NetworkObject InstancedExtension___ReadNetworkObject(this Reader reader)
		{
			return null;
		}

		public static NetworkBehaviour InstancedExtension___ReadNetworkBehaviour(this Reader reader)
		{
			return null;
		}

		public static DateTime InstancedExtension___ReadDateTime(this Reader reader)
		{
			return default(DateTime);
		}

		public static Channel InstancedExtension___ReadChannel(this Reader reader)
		{
			return default(Channel);
		}

		public static NetworkConnection InstancedExtension___ReadNetworkConnection(this Reader reader)
		{
			return null;
		}

		public static ClientConnectionChangeBroadcast Read___FishNet_002EManaging_002EServer_002EClientConnectionChangeBroadcastFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return default(ClientConnectionChangeBroadcast);
		}

		public static ConnectedClientsBroadcast Read___FishNet_002EManaging_002EServer_002EConnectedClientsBroadcastFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return default(ConnectedClientsBroadcast);
		}

		public static List<int> Read___System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003EFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return null;
		}

		public static EmptyStartScenesBroadcast Read___FishNet_002EManaging_002EScened_002EEmptyStartScenesBroadcastFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return default(EmptyStartScenesBroadcast);
		}

		public static LoadScenesBroadcast Read___FishNet_002EManaging_002EScened_002ELoadScenesBroadcastFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return default(LoadScenesBroadcast);
		}

		public static LoadQueueData Read___FishNet_002EManaging_002EScened_002ELoadQueueDataFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return null;
		}

		public static SceneLoadData Read___FishNet_002EManaging_002EScened_002ESceneLoadDataFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return null;
		}

		public static SceneLookupData Read___FishNet_002EManaging_002EScened_002ESceneLookupDataFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return null;
		}

		public static SceneLookupData[] Read___FishNet_002EManaging_002EScened_002ESceneLookupData_005B_005DFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return null;
		}

		public static NetworkObject[] Read___FishNet_002EObject_002ENetworkObject_005B_005DFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return null;
		}

		public static ReplaceOption Read___FishNet_002EManaging_002EScened_002EReplaceOptionFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return default(ReplaceOption);
		}

		public static LoadParams Read___FishNet_002EManaging_002EScened_002ELoadParamsFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return null;
		}

		public static LoadOptions Read___FishNet_002EManaging_002EScened_002ELoadOptionsFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return null;
		}

		public static string[] Read___System_002EString_005B_005DFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return null;
		}

		public static UnloadScenesBroadcast Read___FishNet_002EManaging_002EScened_002EUnloadScenesBroadcastFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return default(UnloadScenesBroadcast);
		}

		public static UnloadQueueData Read___FishNet_002EManaging_002EScened_002EUnloadQueueDataFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return null;
		}

		public static SceneUnloadData Read___FishNet_002EManaging_002EScened_002ESceneUnloadDataFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return null;
		}

		public static UnloadParams Read___FishNet_002EManaging_002EScened_002EUnloadParamsFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return null;
		}

		public static UnloadOptions Read___FishNet_002EManaging_002EScened_002EUnloadOptionsFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return null;
		}

		public static UnloadOptions.ServerUnloadMode Read___FishNet_002EManaging_002EScened_002EUnloadOptions_002FServerUnloadModeFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return default(UnloadOptions.ServerUnloadMode);
		}

		public static ClientScenesLoadedBroadcast Read___FishNet_002EManaging_002EScened_002EClientScenesLoadedBroadcastFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return default(ClientScenesLoadedBroadcast);
		}

		public static SynchronizedProperty Read___FishNet_002EComponent_002ETransforming_002ESynchronizedPropertyFishNet_002ESerializing_002EGenerateds(Reader reader)
		{
			return default(SynchronizedProperty);
		}
	}
}
