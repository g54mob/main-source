using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Mirror
{
	public static class NetworkWriterExtensions
	{
		private static readonly UTF8Encoding encoding;

		private static readonly byte[] stringBuffer;

		public static void WriteByte(this NetworkWriter writer, byte value)
		{
		}

		public static void WriteSByte(this NetworkWriter writer, sbyte value)
		{
		}

		public static void WriteChar(this NetworkWriter writer, char value)
		{
		}

		public static void WriteBoolean(this NetworkWriter writer, bool value)
		{
		}

		public static void WriteUInt16(this NetworkWriter writer, ushort value)
		{
		}

		public static void WriteInt16(this NetworkWriter writer, short value)
		{
		}

		public static void WriteUInt32(this NetworkWriter writer, uint value)
		{
		}

		public static void WriteInt32(this NetworkWriter writer, int value)
		{
		}

		public static void WriteUInt64(this NetworkWriter writer, ulong value)
		{
		}

		public static void WriteInt64(this NetworkWriter writer, long value)
		{
		}

		public static void WriteSingle(this NetworkWriter writer, float value)
		{
		}

		public static void WriteDouble(this NetworkWriter writer, double value)
		{
		}

		public static void WriteDecimal(this NetworkWriter writer, decimal value)
		{
		}

		public static void WriteString(this NetworkWriter writer, string value)
		{
		}

		public static void WriteBytesAndSize(this NetworkWriter writer, byte[] buffer, int offset, int count)
		{
		}

		public static void WriteBytesAndSize(this NetworkWriter writer, byte[] buffer)
		{
		}

		public static void WriteBytesAndSizeSegment(this NetworkWriter writer, ArraySegment<byte> buffer)
		{
		}

		public static void WriteVector2(this NetworkWriter writer, Vector2 value)
		{
		}

		public static void WriteVector3(this NetworkWriter writer, Vector3 value)
		{
		}

		public static void WriteVector4(this NetworkWriter writer, Vector4 value)
		{
		}

		public static void WriteVector2Int(this NetworkWriter writer, Vector2Int value)
		{
		}

		public static void WriteVector3Int(this NetworkWriter writer, Vector3Int value)
		{
		}

		public static void WriteColor(this NetworkWriter writer, Color value)
		{
		}

		public static void WriteColor32(this NetworkWriter writer, Color32 value)
		{
		}

		public static void WriteQuaternion(this NetworkWriter writer, Quaternion value)
		{
		}

		public static void WriteRect(this NetworkWriter writer, Rect value)
		{
		}

		public static void WritePlane(this NetworkWriter writer, Plane value)
		{
		}

		public static void WriteRay(this NetworkWriter writer, Ray value)
		{
		}

		public static void WriteMatrix4x4(this NetworkWriter writer, Matrix4x4 value)
		{
		}

		public static void WriteGuid(this NetworkWriter writer, Guid value)
		{
		}

		public static void WriteNetworkIdentity(this NetworkWriter writer, NetworkIdentity value)
		{
		}

		public static void WriteNetworkBehaviour(this NetworkWriter writer, NetworkBehaviour value)
		{
		}

		public static void WriteTransform(this NetworkWriter writer, Transform value)
		{
		}

		public static void WriteGameObject(this NetworkWriter writer, GameObject value)
		{
		}

		public static void WriteUri(this NetworkWriter writer, Uri uri)
		{
		}

		public static void WriteList<T>(this NetworkWriter writer, List<T> list)
		{
		}

		public static void WriteArray<T>(this NetworkWriter writer, T[] array)
		{
		}

		public static void WriteArraySegment<T>(this NetworkWriter writer, ArraySegment<T> segment)
		{
		}
	}
}
