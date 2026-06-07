using System;
using System.IO;

namespace Newtonsoft.Json.Bson
{
	public class BsonDataWriter : JsonWriter
	{
		private readonly Newtonsoft.Json.Bson.BsonBinaryWriter _writer;

		private Newtonsoft.Json.Bson.BsonToken _root;

		private Newtonsoft.Json.Bson.BsonToken _parent;

		private string _propertyName;

		public DateTimeKind DateTimeKindHandling
		{
			get
			{
				return default(DateTimeKind);
			}
			set
			{
			}
		}

		public BsonDataWriter(Stream stream)
		{
		}

		public BsonDataWriter(BinaryWriter writer)
		{
		}

		public override void Flush()
		{
		}

		protected override void WriteEnd(JsonToken token)
		{
		}

		public override void WriteComment(string text)
		{
		}

		public override void WriteStartConstructor(string name)
		{
		}

		public override void WriteRaw(string json)
		{
		}

		public override void WriteRawValue(string json)
		{
		}

		public override void WriteStartArray()
		{
		}

		public override void WriteStartObject()
		{
		}

		public override void WritePropertyName(string name)
		{
		}

		public override void Close()
		{
		}

		private void AddParent(Newtonsoft.Json.Bson.BsonToken container)
		{
		}

		private void RemoveParent()
		{
		}

		private void AddValue(object value, Newtonsoft.Json.Bson.BsonType type)
		{
		}

		internal void AddToken(Newtonsoft.Json.Bson.BsonToken token)
		{
		}

		public override void WriteValue(object value)
		{
		}

		public override void WriteNull()
		{
		}

		public override void WriteUndefined()
		{
		}

		public override void WriteValue(string value)
		{
		}

		public override void WriteValue(int value)
		{
		}

		public override void WriteValue(uint value)
		{
		}

		public override void WriteValue(long value)
		{
		}

		public override void WriteValue(ulong value)
		{
		}

		public override void WriteValue(float value)
		{
		}

		public override void WriteValue(double value)
		{
		}

		public override void WriteValue(bool value)
		{
		}

		public override void WriteValue(short value)
		{
		}

		public override void WriteValue(ushort value)
		{
		}

		public override void WriteValue(char value)
		{
		}

		public override void WriteValue(byte value)
		{
		}

		public override void WriteValue(sbyte value)
		{
		}

		public override void WriteValue(decimal value)
		{
		}

		public override void WriteValue(DateTime value)
		{
		}

		public override void WriteValue(byte[] value)
		{
		}

		public override void WriteValue(Guid value)
		{
		}

		public override void WriteValue(TimeSpan value)
		{
		}

		public override void WriteValue(Uri value)
		{
		}

		public void WriteObjectId(byte[] value)
		{
		}

		public void WriteRegex(string pattern, string options)
		{
		}
	}
}
