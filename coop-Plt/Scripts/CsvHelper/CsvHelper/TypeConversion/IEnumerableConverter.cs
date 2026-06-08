using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public class IEnumerableConverter : DefaultTypeConverter
	{
		public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
		{
			if (!(value is IEnumerable enumerable))
			{
				return base.ConvertToString(value, row, memberMapData);
			}
			foreach (object item in enumerable)
			{
				row.WriteField(item.ToString());
			}
			return null;
		}

		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			List<string> list = new List<string>();
			if (memberMapData.IsNameSet || (row.Configuration.HasHeaderRecord && !memberMapData.IsIndexSet))
			{
				string field;
				for (int i = 0; row.TryGetField(memberMapData.Names.FirstOrDefault(), i, out field); i++)
				{
					list.Add(field);
				}
			}
			else
			{
				int num = ((memberMapData.IndexEnd < memberMapData.Index) ? (row.Parser.Count - 1) : memberMapData.IndexEnd);
				for (int j = memberMapData.Index; j <= num; j++)
				{
					if (row.TryGetField(j, out string field2))
					{
						list.Add(field2);
					}
				}
			}
			return list;
		}
	}
}
