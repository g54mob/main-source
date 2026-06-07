using System;
using System.Collections.Generic;
using System.IO;

namespace Newtonsoft.Json.Bson
{
	public class BsonDataReader : JsonReader
	{
		private enum BsonReaderState
		{
			Normal = 0,
			ReferenceStart = 1,
			ReferenceRef = 2,
			ReferenceId = 3,
			CodeWScopeStart = 4,
			CodeWScopeCode = 5,
			CodeWScopeScope = 6,
			CodeWScopeScopeObject = 7,
			CodeWScopeScopeEnd = 8
		}

		private class ContainerContext
		{
			public readonly Newtonsoft.Json.Bson.BsonType Type;

			public int Length;

			public int Position;

			public ContainerContext(Newtonsoft.Json.Bson.BsonType type)
			{
			}
		}

		private const int MaxCharBytesSize = 128;

		private static readonly byte[] SeqRange1;

		private static readonly byte[] SeqRange2;

		private static readonly byte[] SeqRange3;

		private static readonly byte[] SeqRange4;

		private readonly BinaryReader _reader;

		private readonly List<ContainerContext> _stack;

		private byte[] _byteBuffer;

		private char[] _charBuffer;

		private Newtonsoft.Json.Bson.BsonType _currentElementType;

		private BsonReaderState _bsonReaderState;

		private ContainerContext _currentContext;

		private bool _readRootValueAsArray;

		private bool _jsonNet35BinaryCompatibility;

		private DateTimeKind _dateTimeKindHandling;

		[Obsolete]
		public bool JsonNet35BinaryCompatibility
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool ReadRootValueAsArray
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

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

		public BsonDataReader(Stream stream)
		{
		}

		public BsonDataReader(BinaryReader reader)
		{
		}

		public BsonDataReader(Stream stream, bool readRootValueAsArray, DateTimeKind dateTimeKindHandling)
		{
		}

		public BsonDataReader(BinaryReader reader, bool readRootValueAsArray, DateTimeKind dateTimeKindHandling)
		{
		}

		private string ReadElement()
		{
			return null;
		}

		public override bool Read()
		{
			return false;
		}

		public override void Close()
		{
		}

		private bool ReadCodeWScope()
		{
			return false;
		}

		private bool ReadReference()
		{
			return false;
		}

		private bool ReadNormal()
		{
			return false;
		}

		private void PopContext()
		{
		}

		private void PushContext(ContainerContext newContext)
		{
		}

		private byte ReadByte()
		{
			return 0;
		}

		private void ReadType(Newtonsoft.Json.Bson.BsonType type)
		{
		}

		private byte[] ReadBinary(out BsonBinaryType binaryType)
		{
			binaryType = default(BsonBinaryType);
			return null;
		}

		private string ReadString()
		{
			return null;
		}

		private string ReadLengthString()
		{
			return null;
		}

		private string GetString(int length)
		{
			return null;
		}

		private int GetLastFullCharStop(int start)
		{
			return 0;
		}

		private int BytesInSequence(byte b)
		{
			return 0;
		}

		private void EnsureBuffers()
		{
		}

		private double ReadDouble()
		{
			return 0.0;
		}

		private int ReadInt32()
		{
			return 0;
		}

		private long ReadInt64()
		{
			return 0L;
		}

		private Newtonsoft.Json.Bson.BsonType ReadType()
		{
			return default(Newtonsoft.Json.Bson.BsonType);
		}

		private void MovePosition(int count)
		{
		}

		private byte[] ReadBytes(int count)
		{
			return null;
		}
	}
}
