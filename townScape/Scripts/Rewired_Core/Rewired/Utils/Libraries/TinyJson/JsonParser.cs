using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Rewired.Utils.Libraries.TinyJson
{
	public static class JsonParser
	{
		[CustomObfuscation]
		internal static Stack<List<string>> splitArrayPool;

		private static StringBuilder CsowlXmujNTjOTfwhmDabPgfdfE;

		private static readonly Dictionary<Type, Dictionary<string, FieldInfo>> XUeEcFLMtYzwmcjtTLBxqzGdDYK;

		private static readonly Dictionary<Type, Dictionary<string, PropertyInfo>> jxFGcqFWwTbCEFsfrtxlDWqBHvRm;

		[CompilerGenerated]
		private static Func<FieldInfo, bool> GUtEutEEzltmqOpNYrKXdcztHioU;

		[CompilerGenerated]
		private static Func<FieldInfo, string> eeshfSnjdakpwyldchITaKDVJgk;

		[CompilerGenerated]
		private static Func<PropertyInfo, bool> PMFgKODWxLTyBmECZLlgueLpCWy;

		[CompilerGenerated]
		private static Func<PropertyInfo, string> nuYGPCFnTpnRxsxtFFfaweJivfP;

		public static bool TryFromJson<T>(string json, out T value)
		{
			value = default(T);
			return false;
		}

		[CustomObfuscation]
		internal static bool TryFromJson<T>(string json, out T value, Type preferredAnonymousObjectType)
		{
			value = default(T);
			return false;
		}

		public static T FromJson<T>(string json)
		{
			return default(T);
		}

		[CustomObfuscation]
		internal static T FromJson<T>(string json, Type preferredAnonymousObjectType)
		{
			return default(T);
		}

		public static object FromJson(Type type, string json)
		{
			return null;
		}

		[CustomObfuscation]
		internal static object FromJson(Type type, string json, Type preferredAnonymousObjectType)
		{
			return null;
		}

		private static object PZyVgAVdofGGymDBDoKZZlkcaFme(Type P_0, string P_1, Type P_2, out bool P_3)
		{
			P_3 = default(bool);
			return null;
		}

		private static object QsDmUQpPHqoOLVAIyxeNRatjirb(string P_0, Type P_1, out bool P_2)
		{
			P_2 = default(bool);
			return null;
		}

		private static object RvDFTlVLwNiFWBLNYaxzHSxDejU(Type P_0, string P_1, Type P_2)
		{
			return null;
		}

		private static int fktYhLWKkNvtiaViUNppDIOeITB(bool P_0, int P_1, string P_2)
		{
			return 0;
		}

		private static List<string> EBnpvnPxmWRGhoKukZAetjHWZxK(string P_0)
		{
			return null;
		}

		[CompilerGenerated]
		private static bool ySBtvKQKzAnuxEbkRGfpCNuCaeAH(FieldInfo P_0)
		{
			return false;
		}

		[CompilerGenerated]
		private static string OcoCCYhovPFTFfuMtTJyapRCaBng(FieldInfo P_0)
		{
			return null;
		}

		[CompilerGenerated]
		private static bool wQFauacPHCseOvYJoMDkRhXfAPcI(PropertyInfo P_0)
		{
			return false;
		}

		[CompilerGenerated]
		private static string sTALLOqogaleHGEAkUMcPiubsDI(PropertyInfo P_0)
		{
			return null;
		}
	}
}
