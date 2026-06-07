using System;
using System.Collections;
using System.Dynamic;

namespace CsvHelper.Expressions
{
	public class DynamicRecordWriter : RecordWriter
	{
		private readonly Hashtable getters;

		public DynamicRecordWriter(CsvWriter writer)
			: base(null)
		{
		}

		protected override Action<T> CreateWriteDelegate<T>(T record)
		{
			return null;
		}

		private object GetValue(string name, IDynamicMetaObjectProvider target)
		{
			return null;
		}
	}
}
