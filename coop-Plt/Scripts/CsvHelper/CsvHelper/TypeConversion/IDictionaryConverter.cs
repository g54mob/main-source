using System.Collections;
using System.Collections.Generic;
using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public class IDictionaryConverter : DefaultTypeConverter
	{
		public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
		{
			if (!(value is IDictionary dictionary))
			{
				return base.ConvertToString(value, row, memberMapData);
			}
			foreach (DictionaryEntry item in dictionary)
			{
				row.WriteField(item.Value);
			}
			return null;
		}

		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			int num = ((memberMapData.IndexEnd < memberMapData.Index) ? (row.Parser.Count - 1) : memberMapData.IndexEnd);
			for (int i = memberMapData.Index; i <= num; i++)
			{
				if (row.TryGetField(i, out string field))
				{
					dictionary.Add(row.HeaderRecord[i], field);
				}
			}
			return dictionary;
		}
	}
}
