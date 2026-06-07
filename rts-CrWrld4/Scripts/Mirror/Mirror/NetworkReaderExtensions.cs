using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Mirror
{
	public static class NetworkReaderExtensions
	{
		private static readonly UTF8Encoding encoding;

		public static byte ReadByte(this NetworkReader reader)
		{
			return 0;
		}

		public static sbyte ReadSByte(this NetworkReader reader)
		{
			return 0;
		}

		public static char ReadChar(this NetworkReader reader)
		{
			return '\0';
		}

		public static bool ReadBoolean(this NetworkReader reader)
		{
			return false;
		}

		public static short ReadInt16(this NetworkReader reader)
		{
			return 0;
		}

		public static ushort ReadUInt16(this NetworkReader reader)
		{
			return 0;
		}

		public static int ReadInt32(this NetworkReader reader)
		{
			return 0;
		}

		public static uint ReadUInt32(this NetworkReader reader)
		{
			return 0u;
		}

		public static long ReadInt64(this NetworkReader reader)
		{
			return 0L;
		}

		public static ulong ReadUInt64(this NetworkReader reader)
		{
			return 0uL;
		}

		public static float ReadSingle(this NetworkReader reader)
		{
			return 0f;
		}

		public static double ReadDouble(this NetworkReader reader)
		{
			return 0.0;
		}

		public static decimal ReadDecimal(this NetworkReader reader)
		{
			return default(decimal);
		}

		public static string ReadString(this NetworkReader reader)
		{
			return null;
		}

		public static byte[] ReadBytesAndSize(this NetworkReader reader)
		{
			return null;
		}

		public static ArraySegment<byte> ReadBytesAndSizeSegment(this NetworkReader reader)
		{
			return default(ArraySegment<byte>);
		}

		public static Vector2 ReadVector2(this NetworkReader reader)
		{
			return default(Vector2);
		}

		public static Vector3 ReadVector3(this NetworkReader reader)
		{
			return default(Vector3);
		}

		public static Vector4 ReadVector4(this NetworkReader reader)
		{
			return default(Vector4);
		}

		public static Vector2Int ReadVector2Int(this NetworkReader reader)
		{
			return default(Vector2Int);
		}

		public static Vector3Int ReadVector3Int(this NetworkReader reader)
		{
			return default(Vector3Int);
		}

		public static Color ReadColor(this NetworkReader reader)
		{
			return default(Color);
		}

		public static Color32 ReadColor32(this NetworkReader reader)
		{
			return default(Color32);
		}

		public static Quaternion ReadQuaternion(this NetworkReader reader)
		{
			return default(Quaternion);
		}

		public static Rect ReadRect(this NetworkReader reader)
		{
			return default(Rect);
		}

		public static Plane ReadPlane(this NetworkReader reader)
		{
			return default(Plane);
		}

		public static Ray ReadRay(this NetworkReader reader)
		{
			return default(Ray);
		}

		public static Matrix4x4 ReadMatrix4x4(this NetworkReader reader)
		{
			return default(Matrix4x4);
		}

		public static byte[] ReadBytes(this NetworkReader reader, int count)
		{
			return null;
		}

		public static Guid ReadGuid(this NetworkReader reader)
		{
			return default(Guid);
		}

		public static Transform ReadTransform(this NetworkReader reader)
		{
			return null;
		}

		public static GameObject ReadGameObject(this NetworkReader reader)
		{
			return null;
		}

		public static NetworkIdentity ReadNetworkIdentity(this NetworkReader reader)
		{
			return null;
		}

		public static NetworkBehaviour ReadNetworkBehaviour(this NetworkReader reader)
		{
			return null;
		}

		public static T ReadNetworkBehaviour<T>(this NetworkReader reader) where T : NetworkBehaviour
		{
			return null;
		}

		public static NetworkBehaviour.NetworkBehaviourSyncVar ReadNetworkBehaviourSyncVar(this NetworkReader reader)
		{
			return default(NetworkBehaviour.NetworkBehaviourSyncVar);
		}

		public static List<T> ReadList<T>(this NetworkReader reader)
		{
			return null;
		}

		public static T[] ReadArray<T>(this NetworkReader reader)
		{
			return null;
		}

		public static Uri ReadUri(this NetworkReader reader)
		{
			return null;
		}
	}
}
