using System;
using System.Reflection;

namespace VRTK
{
	public static class SDK_OculusDefines
	{
		public const string ScriptingDefineSymbol = "VRTK_DEFINE_SDK_OCULUS";

		public const string AvatarScriptingDefineSymbol = "VRTK_DEFINE_SDK_OCULUS_AVATAR";

		[SDK_ScriptingDefineSymbolPredicate("VRTK_DEFINE_SDK_OCULUS", "Standalone")]
		[SDK_ScriptingDefineSymbolPredicate("VRTK_DEFINE_SDK_OCULUS", "Android")]
		[SDK_ScriptingDefineSymbolPredicate("VRTK_DEFINE_OCULUS_UTILITIES_1_12_0_OR_NEWER", "Standalone")]
		[SDK_ScriptingDefineSymbolPredicate("VRTK_DEFINE_OCULUS_UTILITIES_1_12_0_OR_NEWER", "Android")]
		private static bool IsUtilitiesVersion1120OrNewer()
		{
			Version oculusWrapperVersion = GetOculusWrapperVersion();
			if (oculusWrapperVersion != null)
			{
				return oculusWrapperVersion >= new Version(1, 12, 0);
			}
			return false;
		}

		[SDK_ScriptingDefineSymbolPredicate("VRTK_DEFINE_SDK_OCULUS", "Standalone")]
		[SDK_ScriptingDefineSymbolPredicate("VRTK_DEFINE_SDK_OCULUS", "Android")]
		[SDK_ScriptingDefineSymbolPredicate("VRTK_DEFINE_OCULUS_UTILITIES_1_11_0_OR_OLDER", "Standalone")]
		[SDK_ScriptingDefineSymbolPredicate("VRTK_DEFINE_OCULUS_UTILITIES_1_11_0_OR_OLDER", "Android")]
		private static bool IsUtilitiesVersion1110OrOlder()
		{
			Version oculusWrapperVersion = GetOculusWrapperVersion();
			if (oculusWrapperVersion != null)
			{
				return oculusWrapperVersion < new Version(1, 12, 0);
			}
			return false;
		}

		[SDK_ScriptingDefineSymbolPredicate("VRTK_DEFINE_SDK_OCULUS_AVATAR", "Standalone")]
		[SDK_ScriptingDefineSymbolPredicate("VRTK_DEFINE_SDK_OCULUS_AVATAR", "Android")]
		private static bool IsAvatarAvailable()
		{
			if (IsUtilitiesVersion1120OrNewer() || IsUtilitiesVersion1110OrOlder())
			{
				return VRTK_SharedMethods.GetTypeUnknownAssembly("OvrAvatar") != null;
			}
			return false;
		}

		private static Version GetOculusWrapperVersion()
		{
			Type typeUnknownAssembly = VRTK_SharedMethods.GetTypeUnknownAssembly("OVRPlugin");
			if (typeUnknownAssembly == null)
			{
				return null;
			}
			FieldInfo field = typeUnknownAssembly.GetField("wrapperVersion", BindingFlags.Static | BindingFlags.Public);
			if (field == null)
			{
				return null;
			}
			return (Version)field.GetValue(null);
		}
	}
}
