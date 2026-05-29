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
	public static class GeneratedWriters___Internal
	{
		[RuntimeInitializeOnLoadMethod]
		private static void InitializeOnce()
		{
		}

		public static void InstancedExtension___WriteByte(this Writer writer, byte value1)
		{
		}

		public static void InstancedExtension___WriteBytesAndSize(this Writer writer, byte[] value1)
		{
		}

		public static void InstancedExtension___WriteSByte(this Writer writer, sbyte value1)
		{
		}

		public static void InstancedExtension___WriteChar(this Writer writer, char value1)
		{
		}

		public static void InstancedExtension___WriteBoolean(this Writer writer, bool value1)
		{
		}

		public static void InstancedExtension___WriteUInt16(this Writer writer, ushort value1)
		{
		}

		public static void InstancedExtension___WriteInt16(this Writer writer, short value1)
		{
		}

		public static void InstancedExtension___WriteInt32(this Writer writer, int value1, AutoPackType packType2 = AutoPackType.Packed)
		{
		}

		public static void InstancedExtension___WriteUInt32(this Writer writer, uint value1, AutoPackType packType2 = AutoPackType.Packed)
		{
		}

		public static void InstancedExtension___WriteInt64(this Writer writer, long value1, AutoPackType packType2 = AutoPackType.Packed)
		{
		}

		public static void InstancedExtension___WriteUInt64(this Writer writer, ulong value1, AutoPackType packType2 = AutoPackType.Packed)
		{
		}

		public static void InstancedExtension___WriteSingle(this Writer writer, float value1, AutoPackType packType2 = AutoPackType.Unpacked)
		{
		}

		public static void InstancedExtension___WriteDouble(this Writer writer, double value1)
		{
		}

		public static void InstancedExtension___WriteDecimal(this Writer writer, decimal value1)
		{
		}

		public static void InstancedExtension___WriteString(this Writer writer, string value1)
		{
		}

		public static void InstancedExtension___WriteArraySegmentAndSize(this Writer writer, ArraySegment<byte> value1)
		{
		}

		public static void InstancedExtension___WriteVector2(this Writer writer, Vector2 value1)
		{
		}

		public static void InstancedExtension___WriteVector3(this Writer writer, Vector3 value1)
		{
		}

		public static void InstancedExtension___WriteVector4(this Writer writer, Vector4 value1)
		{
		}

		public static void InstancedExtension___WriteVector2Int(this Writer writer, Vector2Int value1, AutoPackType packType2 = AutoPackType.Packed)
		{
		}

		public static void InstancedExtension___WriteVector3Int(this Writer writer, Vector3Int value1, AutoPackType packType2 = AutoPackType.Packed)
		{
		}

		public static void InstancedExtension___WriteColor(this Writer writer, Color value1, AutoPackType packType2 = AutoPackType.Packed)
		{
		}

		public static void InstancedExtension___WriteColor32(this Writer writer, Color32 value1)
		{
		}

		public static void InstancedExtension___WriteQuaternion(this Writer writer, Quaternion value1, AutoPackType packType2 = AutoPackType.Packed)
		{
		}

		public static void InstancedExtension___WriteRect(this Writer writer, Rect value1)
		{
		}

		public static void InstancedExtension___WritePlane(this Writer writer, Plane value1)
		{
		}

		public static void InstancedExtension___WriteRay(this Writer writer, Ray value1)
		{
		}

		public static void InstancedExtension___WriteRay2D(this Writer writer, Ray2D value1)
		{
		}

		public static void InstancedExtension___WriteMatrix4x4(this Writer writer, Matrix4x4 value1)
		{
		}

		public static void InstancedExtension___WriteGuidAllocated(this Writer writer, Guid value1)
		{
		}

		public static void InstancedExtension___WriteGameObject(this Writer writer, GameObject go1)
		{
		}

		public static void InstancedExtension___WriteTransform(this Writer writer, Transform t1)
		{
		}

		public static void InstancedExtension___WriteNetworkObject(this Writer writer, NetworkObject nob1)
		{
		}

		public static void InstancedExtension___WriteNetworkBehaviour(this Writer writer, NetworkBehaviour nb1)
		{
		}

		public static void InstancedExtension___WriteDateTime(this Writer writer, DateTime dt1)
		{
		}

		public static void InstancedExtension___WriteChannel(this Writer writer, Channel channel1)
		{
		}

		public static void InstancedExtension___WriteNetworkConnection(this Writer writer, NetworkConnection connection1)
		{
		}

		public static void Write___FishNet_002EManaging_002EServer_002EClientConnectionChangeBroadcastFishNet_002ESerializing_002EGenerated(this Writer writer, ClientConnectionChangeBroadcast value)
		{
		}

		public static void Write___FishNet_002EManaging_002EServer_002EConnectedClientsBroadcastFishNet_002ESerializing_002EGenerated(this Writer writer, ConnectedClientsBroadcast value)
		{
		}

		public static void Write___System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003EFishNet_002ESerializing_002EGenerated(this Writer writer, List<int> value)
		{
		}

		public static void Write___FishNet_002EManaging_002EScened_002EEmptyStartScenesBroadcastFishNet_002ESerializing_002EGenerated(this Writer writer, EmptyStartScenesBroadcast value)
		{
		}

		public static void Write___FishNet_002EManaging_002EScened_002ELoadScenesBroadcastFishNet_002ESerializing_002EGenerated(this Writer writer, LoadScenesBroadcast value)
		{
		}

		public static void Write___FishNet_002EManaging_002EScened_002ELoadQueueDataFishNet_002ESerializing_002EGenerated(this Writer writer, LoadQueueData value)
		{
		}

		public static void Write___FishNet_002EManaging_002EScened_002ESceneLoadDataFishNet_002ESerializing_002EGenerated(this Writer writer, SceneLoadData value)
		{
		}

		public static void Write___FishNet_002EManaging_002EScened_002ESceneLookupDataFishNet_002ESerializing_002EGenerated(this Writer writer, SceneLookupData value)
		{
		}

		public static void Write___FishNet_002EManaging_002EScened_002ESceneLookupData_005B_005DFishNet_002ESerializing_002EGenerated(this Writer writer, SceneLookupData[] value)
		{
		}

		public static void Write___FishNet_002EObject_002ENetworkObject_005B_005DFishNet_002ESerializing_002EGenerated(this Writer writer, NetworkObject[] value)
		{
		}

		public static void Write___FishNet_002EManaging_002EScened_002EReplaceOptionFishNet_002ESerializing_002EGenerated(this Writer writer, ReplaceOption value)
		{
		}

		public static void Write___FishNet_002EManaging_002EScened_002ELoadParamsFishNet_002ESerializing_002EGenerated(this Writer writer, LoadParams value)
		{
		}

		public static void Write___FishNet_002EManaging_002EScened_002ELoadOptionsFishNet_002ESerializing_002EGenerated(this Writer writer, LoadOptions value)
		{
		}

		public static void Write___System_002EString_005B_005DFishNet_002ESerializing_002EGenerated(this Writer writer, string[] value)
		{
		}

		public static void Write___FishNet_002EManaging_002EScened_002EUnloadScenesBroadcastFishNet_002ESerializing_002EGenerated(this Writer writer, UnloadScenesBroadcast value)
		{
		}

		public static void Write___FishNet_002EManaging_002EScened_002EUnloadQueueDataFishNet_002ESerializing_002EGenerated(this Writer writer, UnloadQueueData value)
		{
		}

		public static void Write___FishNet_002EManaging_002EScened_002ESceneUnloadDataFishNet_002ESerializing_002EGenerated(this Writer writer, SceneUnloadData value)
		{
		}

		public static void Write___FishNet_002EManaging_002EScened_002EUnloadParamsFishNet_002ESerializing_002EGenerated(this Writer writer, UnloadParams value)
		{
		}

		public static void Write___FishNet_002EManaging_002EScened_002EUnloadOptionsFishNet_002ESerializing_002EGenerated(this Writer writer, UnloadOptions value)
		{
		}

		public static void Write___FishNet_002EManaging_002EScened_002EUnloadOptions_002FServerUnloadModeFishNet_002ESerializing_002EGenerated(this Writer writer, UnloadOptions.ServerUnloadMode value)
		{
		}

		public static void Write___FishNet_002EManaging_002EScened_002EClientScenesLoadedBroadcastFishNet_002ESerializing_002EGenerated(this Writer writer, ClientScenesLoadedBroadcast value)
		{
		}

		public static void Write___FishNet_002EComponent_002ETransforming_002ESynchronizedPropertyFishNet_002ESerializing_002EGenerated(this Writer writer, SynchronizedProperty value)
		{
		}
	}
}
