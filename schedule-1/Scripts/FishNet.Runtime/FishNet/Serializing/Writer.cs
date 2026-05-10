using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Serializing.Helping;
using FishNet.Transporting;
using FishNet.Utility.Performance;
using UnityEngine;

namespace FishNet.Serializing
{
	public class Writer
	{
		public int Position;

		public int Length;

		public NetworkManager NetworkManager;

		private byte[] _buffer;

		internal const byte REPLICATE_DEFAULT_BYTE = 0;

		internal const byte REPLICATE_DUPLICATE_BYTE = 1;

		internal const byte REPLICATE_UNIQUE_BYTE = 2;

		internal const byte REPLICATE_REPEATING_BYTE = 3;

		internal const byte REPLICATE_ALL_DEFAULT_BYTE = 4;

		public const int UNSET_COLLECTION_SIZE_VALUE = -1;

		public int Capacity => 0;

		public override string ToString()
		{
			return null;
		}

		public void Reset(NetworkManager manager = null)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public void WriteDictionary<TKey, TValue>(Dictionary<TKey, TValue> dict)
		{
		}

		public void EnsureBufferCapacity(int count)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void EnsureBufferLength(int count)
		{
		}

		public byte[] GetBuffer()
		{
			return null;
		}

		public ArraySegment<byte> GetArraySegment()
		{
			return default(ArraySegment<byte>);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Reserve(int count)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		internal void WriteLength(int length)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		internal void WritePacketId(PacketId pid)
		{
		}

		[CodegenExclude]
		public void FastInsertByte(byte value, int index)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteByte(byte value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public void WriteBytes(byte[] value, int offset, int count)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public void WriteBytesAndSize(byte[] value, int offset, int count)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteBytesAndSize(byte[] value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteSByte(sbyte value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteChar(char value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteBoolean(bool value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUInt16(ushort value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteInt16(short value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteInt32(int value, AutoPackType packType = AutoPackType.Packed)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUInt32(uint value, AutoPackType packType = AutoPackType.Packed)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteInt64(long value, AutoPackType packType = AutoPackType.Packed)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUInt64(ulong value, AutoPackType packType = AutoPackType.Packed)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteSingle(float value, AutoPackType packType = AutoPackType.Unpacked)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteDouble(double value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteDecimal(decimal value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteString(string value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteArraySegmentAndSize(ArraySegment<byte> value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public void WriteArraySegment(ArraySegment<byte> value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteVector2(Vector2 value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteVector3(Vector3 value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteVector4(Vector4 value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteVector2Int(Vector2Int value, AutoPackType packType = AutoPackType.Packed)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteVector3Int(Vector3Int value, AutoPackType packType = AutoPackType.Packed)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteColor(Color value, AutoPackType packType = AutoPackType.Packed)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteColor32(Color32 value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteQuaternion(Quaternion value, AutoPackType packType = AutoPackType.Packed)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteRect(Rect value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WritePlane(Plane value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteRay(Ray value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteRay2D(Ray2D value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteMatrix4x4(Matrix4x4 value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteGuidAllocated(Guid value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public void WriteTickUnpacked(uint value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteGameObject(GameObject go)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteTransform(Transform t)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteNetworkObject(NetworkObject nob)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public void WriteNetworkObjectId(NetworkObject nob)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		internal void WriteNetworkObject(NetworkObject nob, bool forSpawn)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		internal void WriteNetworkObjectForDespawn(NetworkObject nob, DespawnType dt)
		{
		}

		[CodegenExclude]
		public void WriteNetworkObjectId(int objectId)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		internal void WriteNetworkObjectForSpawn(NetworkObject nob)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteNetworkBehaviour(NetworkBehaviour nb)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public void WriteNetworkBehaviourId(NetworkBehaviour nb)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteDateTime(DateTime dt)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteChannel(Channel channel)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteNetworkConnection(NetworkConnection connection)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public void WriteNetworkConnectionId(short id)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public void WriteListCache<T>(ListCache<T> lc)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public void WriteList<T>(List<T> value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		internal void WriteStateUpdatePacket(uint lastPacketTick)
		{
		}

		[CodegenExclude]
		public ulong ZigZagEncode(ulong value)
		{
			return 0uL;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public void WritePackedWhole(ulong value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public void WriteList<T>(List<T> value, int offset, int count)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public void WriteList<T>(List<T> value, int offset)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		internal void WriteReplicate<T>(List<T> values, int offset)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public void WriteArray<T>(T[] value, int offset, int count)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public void WriteArray<T>(T[] value, int offset)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public void WriteArray<T>(T[] value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenExclude]
		public void Write<T>(T value)
		{
		}

		private void LogError(string msg)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static bool IsAutoPackType<T>(out AutoPackType packType)
		{
			packType = default(AutoPackType);
			return false;
		}

		internal static bool IsAutoPackType(Type type, out AutoPackType packType)
		{
			packType = default(AutoPackType);
			return false;
		}
	}
}
