using System;
using System.Collections.Generic;
using System.Reflection;

namespace UMA
{
	public static class ListBackingArrayGetter
	{
		private const string FieldName = "_items";

		private const BindingFlags GetFieldFlags = BindingFlags.Instance | BindingFlags.NonPublic;

		private static readonly Dictionary<Type, FieldInfo> itemsFields;

		public static TElement[] GetBackingArray<TElement>(this List<TElement> list)
		{
			return null;
		}
	}
}
