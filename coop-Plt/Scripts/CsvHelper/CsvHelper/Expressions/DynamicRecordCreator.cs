using System;
using System.Collections.Generic;
using System.Dynamic;

namespace CsvHelper.Expressions
{
	public class DynamicRecordCreator : RecordCreator
	{
		public DynamicRecordCreator(CsvReader reader)
			: base(reader)
		{
		}

		protected override Delegate CreateCreateRecordDelegate(Type recordType)
		{
			return new Func<object>(CreateDynamicRecord);
		}

		protected virtual dynamic CreateDynamicRecord()
		{
			ExpandoObject expandoObject = new ExpandoObject();
			IDictionary<string, object> dictionary = expandoObject;
			if (base.Reader.HeaderRecord != null)
			{
				for (int i = 0; i < base.Reader.HeaderRecord.Length; i++)
				{
					GetDynamicPropertyNameArgs args = new GetDynamicPropertyNameArgs(i, base.Reader.Context);
					string key = base.Reader.Configuration.GetDynamicPropertyName(args);
					base.Reader.TryGetField(i, out string field);
					dictionary.Add(key, field);
				}
			}
			else
			{
				for (int j = 0; j < base.Reader.Parser.Count; j++)
				{
					GetDynamicPropertyNameArgs args2 = new GetDynamicPropertyNameArgs(j, base.Reader.Context);
					string key2 = base.Reader.Configuration.GetDynamicPropertyName(args2);
					string field2 = base.Reader.GetField(j);
					dictionary.Add(key2, field2);
				}
			}
			return expandoObject;
		}
	}
}
