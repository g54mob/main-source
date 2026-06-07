using System;
using System.Text;

namespace AltSerialize
{
	public static class Serializer
	{
		private static ByteSerializer _serializer = new ByteSerializer();

		public static SerializeFlags DefaultSerializeFlags
		{
			get
			{
				return _serializer.DefaultSerializeFlags;
			}
			set
			{
				_serializer.DefaultSerializeFlags = value;
			}
		}

		public static Encoding DefaultEncoding
		{
			get
			{
				return _serializer.DefaultEncoding;
			}
			set
			{
				_serializer.DefaultEncoding = value;
			}
		}

		public static byte[] Serialize(object anObject, bool networkMode = false)
		{
			_serializer.NetworkMode = networkMode;
			return _serializer.Serialize(anObject);
		}

		public static byte[] Serialize(object anObject, Type objectType)
		{
			_serializer.NetworkMode = false;
			return _serializer.Serialize(anObject, objectType);
		}

		public static object Deserialize(byte[] bytes, Type objectType)
		{
			return _serializer.Deserialize(bytes, objectType);
		}

		public static object Deserialize(byte[] bytes, int convertFloats = -1)
		{
			_serializer.ConvertFloats = convertFloats;
			return _serializer.Deserialize(bytes);
		}

		public static void CacheObject(object cachedObject)
		{
			_serializer.CacheObject(cachedObject);
		}
	}
}
