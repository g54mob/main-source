using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace CsvHelper
{
	public class WritingContext : IDisposable
	{
		private bool disposed;

		private TextWriter writer;

		private CsvHelper.Configuration.Configuration configuration;

		public Dictionary<int, Delegate> TypeActions { get; }

		public Dictionary<Type, TypeConverterOptions> TypeConverterOptionsCache { get; }

		public MemberMapData ReusableMemberMapData { get; set; }

		public virtual IWriterConfiguration WriterConfiguration => null;

		public virtual ISerializerConfiguration SerializerConfiguration => null;

		public virtual TextWriter Writer => null;

		public virtual bool LeaveOpen { get; set; }

		public virtual int Row { get; set; }

		public virtual List<string> Record { get; }

		public virtual bool HasHeaderBeenWritten { get; set; }

		public virtual bool HasRecordBeenWritten { get; set; }

		public WritingContext(TextWriter writer, CsvHelper.Configuration.Configuration configuration, bool leaveOpen)
		{
		}

		public void ClearCache(Caches cache)
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
