using System;
using System.Collections.Generic;
using System.Linq;

namespace CsvHelper.Expressions
{
	public class ExpandoObjectRecordWriter : RecordWriter
	{
		public ExpandoObjectRecordWriter(CsvWriter writer)
			: base(writer)
		{
		}

		protected override Action<T> CreateWriteDelegate<T>(T record)
		{
			return delegate(T r)
			{
				IEnumerable<KeyValuePair<string, object>> source = ((IDictionary<string, object>)(object)r).AsEnumerable();
				if (base.Writer.Configuration.DynamicPropertySort != null)
				{
					source = source.OrderBy((KeyValuePair<string, object> pair) => pair.Key, base.Writer.Configuration.DynamicPropertySort);
				}
				foreach (object item in source.Select((KeyValuePair<string, object> pair) => pair.Value))
				{
					base.Writer.WriteField(item);
				}
			};
		}
	}
}
