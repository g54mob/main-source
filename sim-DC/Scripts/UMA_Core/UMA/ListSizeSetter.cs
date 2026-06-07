using System;
using System.Collections.Generic;
using System.Reflection;

namespace UMA
{
	public static class ListSizeSetter
	{
		private const string FieldName = "_size";

		private const BindingFlags GetFieldFlags = BindingFlags.Instance | BindingFlags.NonPublic;

		private static readonly Dictionary<Type, FieldInfo> itemsFields;

		public static void SetActiveSize<TElement>(this List<TElement> list, int size)
		{
		}
	}
}
