using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;

namespace KitchenData
{
	public static class EnumHelpers
	{
		public static IEnumerable ListFromEnum<T>(Func<T, string> value_lookup = null) where T : Enum
		{
			if (value_lookup == null)
			{
				value_lookup = (T t) => t.ToString("D");
			}
			ValueDropdownList<T> valueDropdownList = new ValueDropdownList<T>();
			string[] names = Enum.GetNames(typeof(T));
			List<T> list = Enum.GetValues(typeof(T)).Cast<T>().ToList();
			for (int num = 0; num < names.Length; num++)
			{
				valueDropdownList.Add(names[num] + " (" + value_lookup(list[num]) + ")", list[num]);
			}
			return valueDropdownList;
		}
	}
}
