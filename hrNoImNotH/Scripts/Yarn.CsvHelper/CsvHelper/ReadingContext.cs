using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace CsvHelper
{
	public class ReadingContext : IDisposable
	{
		private bool disposed;

		private readonly CsvHelper.Configuration.Configuration configuration;

		public StringBuilder RawRecordBuilder;

		public StringBuilder FieldBuilder;

		public RecordBuilder RecordBuilder;

		public Dictionary<string, List<int>> NamedIndexes;

		public Dictionary<string, (string, int)> NamedIndexCache;

		public Dictionary<Type, TypeConverterOptions> TypeConverterOptionsCache;

		public Dictionary<Type, Delegate> CreateRecordFuncs;

		public Dictionary<Type, Delegate> HydrateRecordActions;

		public MemberMapData ReusableMemberMapData;

		public TextReader Reader;

		public bool LeaveOpen;

		public char[] Buffer;

		public int BufferPosition;

		public int FieldStartPosition;

		public int FieldEndPosition;

		public int RawRecordStartPosition;

		public int RawRecordEndPosition;

		public int CharsRead;

		public long CharPosition;

		public long BytePosition;

		public bool IsFieldBad;

		public string[] Record;

		public int Row;

		public int RawRow;

		public bool HasBeenRead;

		public string[] HeaderRecord;

		public int CurrentIndex;

		public int ColumnCount;

		public IParserConfiguration ParserConfiguration => null;

		public IReaderConfiguration ReaderConfiguration => null;

		public string RawRecord => null;

		public string Field => null;

		public ReadingContext(TextReader reader, CsvHelper.Configuration.Configuration configuration, bool leaveOpen)
		{
		}

		public virtual void ClearCache(Caches cache)
		{
		}

		public virtual void Dispose()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}
	}
}
