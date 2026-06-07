using System;
using System.Reflection;

namespace haxe.lang
{
	public class Runtime
	{
		public static readonly object undefined;

		public static object getField(HxObject obj, string field, int fieldHash, bool throwErrors)
		{
			return null;
		}

		public static double getField_f(HxObject obj, string field, int fieldHash, bool throwErrors)
		{
			return 0.0;
		}

		public static object setField(HxObject obj, string field, int fieldHash, object value)
		{
			return null;
		}

		public static double setField_f(HxObject obj, string field, int fieldHash, double value)
		{
			return 0.0;
		}

		public static object callField(HxObject obj, string field, int fieldHash, object[] args)
		{
			return null;
		}

		public static object closure(object obj, int hash, string field)
		{
			return null;
		}

		public static bool eq(object v1, object v2)
		{
			return false;
		}

		public static bool refEq(object v1, object v2)
		{
			return false;
		}

		public static double toDouble(object obj)
		{
			return 0.0;
		}

		public static int toInt(object obj)
		{
			return 0;
		}

		public static long toLong(object obj)
		{
			return 0L;
		}

		public static bool isInt(object obj)
		{
			return false;
		}

		public static bool isUInt(object obj)
		{
			return false;
		}

		public static int compare(object v1, object v2)
		{
			return 0;
		}

		public static object plus(object v1, object v2)
		{
			return null;
		}

		public static object slowGetField(object obj, string field, bool throwErrors)
		{
			return null;
		}

		public static bool slowHasField(object obj, string field)
		{
			return false;
		}

		public static object slowSetField(object obj, string field, object value)
		{
			return null;
		}

		public static object callMethod(object obj, MethodBase[] methods, int methodLength, object[] args)
		{
			return null;
		}

		public static object unbox(object dyn)
		{
			return null;
		}

		public static object mkNullable(object obj, System.Type nullable)
		{
			return null;
		}

		public static object slowCallField(object obj, string field, object[] args)
		{
			return null;
		}

		public static object callField(object obj, string field, int fieldHash, object[] args)
		{
			return null;
		}

		public static object getField(object obj, string field, int fieldHash, bool throwErrors)
		{
			return null;
		}

		public static double getField_f(object obj, string field, int fieldHash, bool throwErrors)
		{
			return 0.0;
		}

		public static object setField(object obj, string field, int fieldHash, object value)
		{
			return null;
		}

		public static double setField_f(object obj, string field, int fieldHash, double value)
		{
			return 0.0;
		}

		public static string toString(object obj)
		{
			return null;
		}

		public static bool typeEq(System.Type t1, System.Type t2)
		{
			return false;
		}

		public static string concat(string s1, string s2)
		{
			return null;
		}

		public static bool toBool(object dyn)
		{
			return false;
		}
	}
}
