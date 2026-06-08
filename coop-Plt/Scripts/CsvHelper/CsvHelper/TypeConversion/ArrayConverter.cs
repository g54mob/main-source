using System;
using System.Collections.Generic;
using System.Linq;
using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	public class ArrayConverter : IEnumerableConverter
	{
		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			Type elementType = memberMapData.Member.MemberType().GetElementType();
			Array array;
			if (memberMapData.IsNameSet || (row.Configuration.HasHeaderRecord && !memberMapData.IsIndexSet))
			{
				List<object> list = new List<object>();
				object field;
				for (int i = 0; row.TryGetField(elementType, memberMapData.Names.FirstOrDefault(), i, out field); i++)
				{
					list.Add(field);
				}
				array = (Array)ObjectResolver.Current.Resolve(memberMapData.Member.MemberType(), list.Count);
				for (int j = 0; j < list.Count; j++)
				{
					array.SetValue(list[j], j);
				}
			}
			else
			{
				int num = ((memberMapData.IndexEnd < memberMapData.Index) ? (row.Parser.Count - 1) : memberMapData.IndexEnd);
				int num2 = num - memberMapData.Index + 1;
				array = (Array)ObjectResolver.Current.Resolve(memberMapData.Member.MemberType(), num2);
				int num3 = 0;
				for (int k = memberMapData.Index; k <= num; k++)
				{
					array.SetValue(row.GetField(elementType, k), num3);
					num3++;
				}
			}
			return array;
		}
	}
}
