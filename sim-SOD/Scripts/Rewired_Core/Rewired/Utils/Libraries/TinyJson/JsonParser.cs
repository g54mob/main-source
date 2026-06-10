using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Rewired.Utils.Libraries.TinyJson
{
	public static class JsonParser
	{
		[CustomObfuscation(rename = false)]
		internal static Stack<List<string>> splitArrayPool;

		private static StringBuilder LUZFkwSBqdalQTombiSYHBrCjjW;

		private static readonly Dictionary<Type, Dictionary<string, FieldInfo>> EyrFuTBlwPqekRcjxjyjgMSFtZSH;

		private static readonly Dictionary<Type, Dictionary<string, PropertyInfo>> acAWHcsMzhJGHkhfxAHBgNEkpKZ;

		[CompilerGenerated]
		private static Func<FieldInfo, bool> HMOMQkhRNslmnsRSdjdErMIPeq;

		[CompilerGenerated]
		private static Func<FieldInfo, string> rWTPQhLeNWbucoWbsCbtCauqryk;

		[CompilerGenerated]
		private static Func<PropertyInfo, bool> CjqRMztnLjKGLuXIZBgGKOaCzEa;

		[CompilerGenerated]
		private static Func<PropertyInfo, string> uZzfPxpvnPIxhwlzTQVUQsnLlYF;

		public static bool TryFromJson<T>(string json, out T value)
		{
			value = default(T);
			return false;
		}

		[CustomObfuscation(rename = false)]
		internal static bool TryFromJson<T>(string json, out T value, Type preferredAnonymousObjectType)
		{
			value = default(T);
			return false;
		}

		public static T FromJson<T>(string json)
		{
			return default(T);
		}

		[CustomObfuscation(rename = false)]
		internal static T FromJson<T>(string json, Type preferredAnonymousObjectType)
		{
			return default(T);
		}

		public static object FromJson(Type type, string json)
		{
			return null;
		}

		[CustomObfuscation(rename = false)]
		internal static object FromJson(Type type, string json, Type preferredAnonymousObjectType)
		{
			return null;
		}

		private static object SuNHtfdgCZbZwknVBgrtHbBNwBiB(Type P_0, string P_1, Type P_2, out bool P_3)
		{
			P_3 = default(bool);
			return null;
		}

		private static object BNgMYbDjvODvVBWAuFObxKYIbir(string P_0, Type P_1, out bool P_2)
		{
			P_2 = default(bool);
			return null;
		}

		private static object MDsonMjaGpHnYGVJWINRmpMeOkSy(Type P_0, string P_1, Type P_2)
		{
			return null;
		}

		private static int smWLyisYffuFyyCsSYDXpVpFVaN(bool P_0, int P_1, string P_2)
		{
			return 0;
		}

		private static List<string> VmIyTQnpBqGIdilOwHcEJnGlXTO(string P_0)
		{
			return null;
		}

		[CompilerGenerated]
		private static bool fwwNshoILenyhAvoNSWRzjPtwiK(FieldInfo P_0)
		{
			return false;
		}

		[CompilerGenerated]
		private static string FjTgspVwPrPAFuRSvBwWFWepHJfK(FieldInfo P_0)
		{
			return null;
		}

		[CompilerGenerated]
		private static bool fSmIhHzpMenDWEBRieHITdoCJNy(PropertyInfo P_0)
		{
			return false;
		}

		[CompilerGenerated]
		private static string dfjbjjcQYYLsTDCCanxSBbVbMmAt(PropertyInfo P_0)
		{
			return null;
		}
	}
}
