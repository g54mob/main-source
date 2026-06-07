using System;
using System.Collections.Generic;
using System.Reflection;

namespace SQLite
{
	public static class Orm
	{
		public const int DefaultMaxStringLength = 140;

		public const string ImplicitPkName = "Id";

		public const string ImplicitIndexSuffix = "Id";

		public static Type GetType(object obj)
		{
			return null;
		}

		public static string SqlDecl(TableMapping.Column p, bool storeDateTimeAsTicks, bool storeTimeSpanAsTicks)
		{
			return null;
		}

		public static string SqlType(TableMapping.Column p, bool storeDateTimeAsTicks, bool storeTimeSpanAsTicks)
		{
			return null;
		}

		public static bool IsPK(MemberInfo p)
		{
			return false;
		}

		public static string Collation(MemberInfo p)
		{
			return null;
		}

		public static bool IsAutoInc(MemberInfo p)
		{
			return false;
		}

		public static FieldInfo GetField(TypeInfo t, string name)
		{
			return null;
		}

		public static PropertyInfo GetProperty(TypeInfo t, string name)
		{
			return null;
		}

		public static object InflateAttribute(CustomAttributeData x)
		{
			return null;
		}

		public static IEnumerable<IndexedAttribute> GetIndices(MemberInfo p)
		{
			return null;
		}

		public static int? MaxStringLength(MemberInfo p)
		{
			return null;
		}

		public static int? MaxStringLength(PropertyInfo p)
		{
			return null;
		}

		public static bool IsMarkedNotNull(MemberInfo p)
		{
			return false;
		}
	}
}
