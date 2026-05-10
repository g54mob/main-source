using System;
using System.Collections.Generic;

namespace ExitGames.Client.Photon
{
	public class Protocol
	{
		internal static readonly Dictionary<Type, CustomType> TypeDict;

		internal static readonly Dictionary<byte, CustomType> CodeDict;

		private static IProtocol ProtocolDefault;

		private static readonly float[] memFloatBlock;

		private static readonly byte[] memDeserialize;

		public static bool TryRegisterType(Type type, byte typeCode, SerializeMethod serializeFunction, DeserializeMethod deserializeFunction)
		{
			return false;
		}

		public static bool TryRegisterType(Type type, byte typeCode, SerializeStreamMethod serializeFunction, DeserializeStreamMethod deserializeFunction)
		{
			return false;
		}

		[Obsolete]
		public static byte[] Serialize(object obj)
		{
			return null;
		}

		[Obsolete]
		public static object Deserialize(byte[] serializedData)
		{
			return null;
		}

		public static void Serialize(short value, byte[] target, ref int targetOffset)
		{
		}

		public static void Serialize(int value, byte[] target, ref int targetOffset)
		{
		}

		public static void Serialize(float value, byte[] target, ref int targetOffset)
		{
		}

		public static void Deserialize(out int value, byte[] source, ref int offset)
		{
			value = default(int);
		}

		public static void Deserialize(out short value, byte[] source, ref int offset)
		{
			value = default(short);
		}

		public static void Deserialize(out float value, byte[] source, ref int offset)
		{
			value = default(float);
		}
	}
}
