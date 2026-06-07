using System;
using System.IO;
using System.Text;

namespace AltSerialize
{
	public class ByteSerializer
	{
		private AltSerializer _AltSerializer;

		private MemoryStream _MemStream;

		private SerializeFlags _defaultSerializeFlags = SerializeFlags.All;

		public SerializeFlags DefaultSerializeFlags
		{
			get
			{
				return _defaultSerializeFlags;
			}
			set
			{
				_defaultSerializeFlags = value;
			}
		}

		public bool NetworkMode
		{
			get
			{
				return _AltSerializer.NetworkMode;
			}
			set
			{
				_AltSerializer.NetworkMode = value;
			}
		}

		public int ConvertFloats
		{
			get
			{
				return _AltSerializer.ConvertFloats;
			}
			set
			{
				_AltSerializer.ConvertFloats = value;
			}
		}

		public Encoding DefaultEncoding
		{
			get
			{
				return _AltSerializer.Encoding;
			}
			set
			{
				_AltSerializer.Encoding = value;
			}
		}

		public ByteSerializer()
		{
			_AltSerializer = new AltSerializer();
			_MemStream = new MemoryStream();
		}

		private void InitSerializer(SerializeFlags flags)
		{
			_AltSerializer.Stream = _MemStream;
			_AltSerializer.SerializePropertyNames = (flags & SerializeFlags.SerializePropertyNames) != 0;
			_AltSerializer.CacheEnabled = (flags & SerializeFlags.SerializationCache) != 0;
			_AltSerializer.SerializeProperties = (flags & SerializeFlags.SerializeProperties) != 0;
		}

		public byte[] Serialize(object anObject)
		{
			lock (_AltSerializer)
			{
				InitSerializer(DefaultSerializeFlags);
				_AltSerializer.Reset();
				AltSerializer.DepthCounter = 0;
				_AltSerializer.Serialize(anObject, 0);
				byte[] result = _MemStream.ToArray();
				_MemStream.Position = 0L;
				_MemStream.SetLength(0L);
				_AltSerializer.Reset();
				return result;
			}
		}

		public byte[] Serialize(object anObject, Type objectType)
		{
			lock (_AltSerializer)
			{
				InitSerializer(DefaultSerializeFlags);
				_AltSerializer.Reset();
				AltSerializer.DepthCounter = 0;
				_AltSerializer.Serialize(anObject, objectType, 0);
				byte[] array = new byte[_MemStream.Position];
				_MemStream.Position = 0L;
				_MemStream.Read(array, 0, array.Length);
				_MemStream.SetLength(0L);
				_AltSerializer.Reset();
				return array;
			}
		}

		public object Deserialize(byte[] bytes, Type objectType)
		{
			lock (_AltSerializer)
			{
				InitSerializer(DefaultSerializeFlags);
				MemoryStream memoryStream = new MemoryStream(bytes);
				_AltSerializer.Reset();
				_AltSerializer.Stream = memoryStream;
				object result = _AltSerializer.Deserialize(objectType, -1);
				_AltSerializer.Stream = _MemStream;
				memoryStream.Dispose();
				return result;
			}
		}

		public object Deserialize(byte[] bytes, Type objectType, SerializeFlags flags)
		{
			lock (_AltSerializer)
			{
				InitSerializer(flags);
				MemoryStream memoryStream = new MemoryStream(bytes);
				_AltSerializer.Reset();
				_AltSerializer.Stream = memoryStream;
				object result = _AltSerializer.Deserialize(objectType, -1);
				_AltSerializer.Stream = _MemStream;
				memoryStream.Dispose();
				return result;
			}
		}

		public object Deserialize(byte[] bytes)
		{
			lock (_AltSerializer)
			{
				InitSerializer(DefaultSerializeFlags);
				MemoryStream memoryStream = new MemoryStream(bytes);
				_AltSerializer.Reset();
				_AltSerializer.Stream = memoryStream;
				object result = _AltSerializer.Deserialize();
				_AltSerializer.Stream = _MemStream;
				memoryStream.Dispose();
				return result;
			}
		}

		public void CacheObject(object cachedObject)
		{
			_AltSerializer.CacheObject(cachedObject);
		}
	}
}
