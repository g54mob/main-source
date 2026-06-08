using System;
using System.Collections;
using System.Linq;
using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public class CollectionGenericConverter : IEnumerableConverter
	{
		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			IList list = (IList)ObjectResolver.Current.Resolve(memberMapData.Member.MemberType());
			Type type = memberMapData.Member.MemberType().GetGenericArguments()[0];
			if (memberMapData.IsNameSet || (row.Configuration.HasHeaderRecord && !memberMapData.IsIndexSet))
			{
				object field;
				for (int i = 0; row.TryGetField(type, memberMapData.Names.FirstOrDefault(), i, out field); i++)
				{
					list.Add(field);
				}
			}
			else
			{
				int num = ((memberMapData.IndexEnd < memberMapData.Index) ? (row.Parser.Count - 1) : memberMapData.IndexEnd);
				for (int j = memberMapData.Index; j <= num; j++)
				{
					object field2 = row.GetField(type, j);
					list.Add(field2);
				}
			}
			return list;
		}
	}
}
