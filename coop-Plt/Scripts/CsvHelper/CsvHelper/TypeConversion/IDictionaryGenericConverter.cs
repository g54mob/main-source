using System;
using System.Collections;
using System.Collections.Generic;
using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public class IDictionaryGenericConverter : IDictionaryConverter
	{
		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			Type type = memberMapData.Member.MemberType().GetGenericArguments()[0];
			Type type2 = memberMapData.Member.MemberType().GetGenericArguments()[1];
			Type typeFromHandle = typeof(Dictionary<, >);
			typeFromHandle = typeFromHandle.MakeGenericType(type, type2);
			IDictionary dictionary = (IDictionary)ObjectResolver.Current.Resolve(typeFromHandle);
			int num = ((memberMapData.IndexEnd < memberMapData.Index) ? (row.Parser.Count - 1) : memberMapData.IndexEnd);
			for (int i = memberMapData.Index; i <= num; i++)
			{
				object field = row.GetField(type2, i);
				dictionary.Add(row.HeaderRecord[i], field);
			}
			return dictionary;
		}
	}
}
