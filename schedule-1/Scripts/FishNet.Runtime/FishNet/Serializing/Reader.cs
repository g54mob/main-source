using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Prediction;
using FishNet.Serializing.Helping;
using FishNet.Transporting;
using FishNet.Utility.Performance;
using UnityEngine;

namespace FishNet.Serializing
{
	public class Reader
	{
		public enum DataSource
		{
			Unset = 0,
			Server = 1,
			Client = 2
		}

		public DataSource Source;

		public NetworkManager NetworkManager;

		public int Position;

		private byte[] _buffer;

		public int Capacity => 0;

		public int Offset { get; private set; }

		public int Length { get; private set; }

		public int Remaining => 0;

		public NetworkConnection NetworkConnection { get; private set; }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Reader(byte[] bytes, NetworkManager networkManager, NetworkConnection networkConnection = null, DataSource source = DataSource.Unset)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Reader(ArraySegment<byte> segment, NetworkManager networkManager, NetworkConnection networkConnection = null, DataSource source = DataSource.Unset)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public string RemainingToString()
		{
			return null;
		}

		public ArraySegment<byte> GetRemainingData()
		{
			return default(ArraySegment<byte>);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Initialize(ArraySegment<byte> segment, NetworkManager networkManager, DataSource source = DataSource.Unset)
		{
		}

		internal void Initialize(ArraySegment<byte> segment, NetworkManager networkManager, NetworkConnection networkConnection = null, DataSource source = DataSource.Unset)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Initialize(byte[] bytes, NetworkManager networkManager, DataSource source = DataSource.Unset)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Initialize(byte[] bytes, NetworkManager networkManager, NetworkConnection networkConnection = null, DataSource source = DataSource.Unset)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Obsolete("Use ReadDictionaryAllocated.")]
		[CodegenExclude]
		public Dictionary<TKey, TValue> ReadDictionary<TKey, TValue>()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public Dictionary<TKey, TValue> ReadDictionaryAllocated<TKey, TValue>()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		internal int ReadLength()
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		internal PacketId ReadPacketId()
		{
			return default(PacketId);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		internal PacketId PeekPacketId()
		{
			return default(PacketId);
		}

		internal byte PeekByte()
		{
			return 0;
		}

		[CodegenExclude]
		public void Skip(int value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public void Clear()
		{
		}

		public ArraySegment<byte> GetArraySegmentBuffer()
		{
			return default(ArraySegment<byte>);
		}

		public byte[] GetByteBuffer()
		{
			return null;
		}

		public byte[] GetByteBufferAllocated()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void BlockCopy(ref byte[] target, int targetOffset, int count)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte ReadByte()
		{
			return 0;
		}

		[CodegenExclude]
		public void ReadBytes(ref byte[] buffer, int count)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public ArraySegment<byte> ReadArraySegment(int count)
		{
			return default(ArraySegment<byte>);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public sbyte ReadSByte()
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public char ReadChar()
		{
			return '\0';
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool ReadBoolean()
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ushort ReadUInt16()
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public short ReadInt16()
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint ReadUInt32(AutoPackType packType = AutoPackType.Packed)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int ReadInt32(AutoPackType packType = AutoPackType.Packed)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public long ReadInt64(AutoPackType packType = AutoPackType.Packed)
		{
			return 0L;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ulong ReadUInt64(AutoPackType packType = AutoPackType.Packed)
		{
			return 0uL;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float ReadSingle(AutoPackType packType = AutoPackType.Unpacked)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double ReadDouble()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public decimal ReadDecimal()
		{
			return default(decimal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ReadString()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte[] ReadBytesAndSizeAllocated()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public int ReadBytesAndSize(ref byte[] target)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ArraySegment<byte> ReadArraySegmentAndSize()
		{
			return default(ArraySegment<byte>);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector2 ReadVector2()
		{
			return default(Vector2);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector3 ReadVector3()
		{
			return default(Vector3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector4 ReadVector4()
		{
			return default(Vector4);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector2Int ReadVector2Int(AutoPackType packType = AutoPackType.Packed)
		{
			return default(Vector2Int);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector3Int ReadVector3Int(AutoPackType packType = AutoPackType.Packed)
		{
			return default(Vector3Int);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Color ReadColor(AutoPackType packType = AutoPackType.Packed)
		{
			return default(Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Color32 ReadColor32()
		{
			return default(Color32);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Quaternion ReadQuaternion(AutoPackType packType = AutoPackType.Packed)
		{
			return default(Quaternion);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Rect ReadRect()
		{
			return default(Rect);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Plane ReadPlane()
		{
			return default(Plane);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Ray ReadRay()
		{
			return default(Ray);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Ray2D ReadRay2D()
		{
			return default(Ray2D);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Matrix4x4 ReadMatrix4x4()
		{
			return default(Matrix4x4);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public byte[] ReadBytesAllocated(int count)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Guid ReadGuid()
		{
			return default(Guid);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public uint ReadTickUnpacked()
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public GameObject ReadGameObject()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Transform ReadTransform()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public NetworkObject ReadNetworkObject()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public NetworkObject ReadNetworkObject(out int objectOrPrefabId, HashSet<int> readSpawningObjects = null)
		{
			objectOrPrefabId = default(int);
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public int ReadNetworkObjectId()
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		internal int ReadNetworkObjectForSpawn(out sbyte initializeOrder, out ushort collectionid, out bool spawned)
		{
			initializeOrder = default(sbyte);
			collectionid = default(ushort);
			spawned = default(bool);
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		internal int ReadNetworkObjectForDepawn(out DespawnType dt)
		{
			dt = default(DespawnType);
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		internal byte ReadNetworkBehaviourId(out int objectId)
		{
			objectId = default(int);
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public NetworkBehaviour ReadNetworkBehaviour(out int objectId, out byte componentIndex, HashSet<int> readSpawningObjects = null)
		{
			objectId = default(int);
			componentIndex = default(byte);
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public NetworkBehaviour ReadNetworkBehaviour()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public DateTime ReadDateTime()
		{
			return default(DateTime);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Channel ReadChannel()
		{
			return default(Channel);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public int ReadNetworkConnectionId()
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public NetworkConnection ReadNetworkConnection()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool CheckAllocationAttack(int size)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		internal void ReadStateUpdatePacket(out uint clientTick)
		{
			clientTick = default(uint);
		}

		public ulong ZigZagDecode(ulong value)
		{
			return 0uL;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public ulong ReadPackedWhole()
		{
			return 0uL;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		internal int ReadReplicate<T>(ref T[] collection, uint tick) where T : IReplicateData
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public ListCache<T> ReadListCacheAllocated<T>()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public int ReadListCache<T>(ref ListCache<T> listCache)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public List<T> ReadListAllocated<T>()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public int ReadList<T>(ref List<T> collection, bool allowNullification = false)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public T[] ReadArrayAllocated<T>()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public int ReadArray<T>(ref T[] collection)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public T Read<T>()
		{
			return default(T);
		}

		private void LogWarning(string msg)
		{
		}

		private void LogError(string msg)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal bool IsAutoPackType<T>(out AutoPackType packType)
		{
			packType = default(AutoPackType);
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal bool IsAutoPackType(Type type, out AutoPackType packType)
		{
			packType = default(AutoPackType);
			return false;
		}
	}
}
