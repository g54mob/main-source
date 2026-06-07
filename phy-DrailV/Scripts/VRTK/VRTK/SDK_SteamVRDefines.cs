using System;
using System.Reflection;

namespace VRTK
{
	public static class SDK_SteamVRDefines
	{
		public const string ScriptingDefineSymbol = "VRTK_DEFINE_SDK_STEAMVR";

		private const string BuildTargetGroupName = "Standalone";

		[SDK_ScriptingDefineSymbolPredicate("VRTK_DEFINE_SDK_STEAMVR", "Standalone")]
		[SDK_ScriptingDefineSymbolPredicate("VRTK_DEFINE_STEAMVR_PLUGIN_1_2_2_OR_NEWER", "Standalone")]
		private static bool IsPluginVersion122OrNewer()
		{
			Type typeUnknownAssembly = VRTK_SharedMethods.GetTypeUnknownAssembly("SteamVR_ControllerManager");
			if (typeUnknownAssembly == null)
			{
				return false;
			}
			return typeUnknownAssembly.GetMethod("SetUniqueObject", BindingFlags.Instance | BindingFlags.NonPublic) != null;
		}

		[SDK_ScriptingDefineSymbolPredicate("VRTK_DEFINE_SDK_STEAMVR", "Standalone")]
		[SDK_ScriptingDefineSymbolPredicate("VRTK_DEFINE_STEAMVR_PLUGIN_1_2_1_OR_NEWER", "Standalone")]
		private static bool IsPluginVersion121OrNewer()
		{
			Type typeUnknownAssembly = VRTK_SharedMethods.GetTypeUnknownAssembly("SteamVR_Events");
			if (typeUnknownAssembly == null)
			{
				return false;
			}
			MethodInfo method = typeUnknownAssembly.GetMethod("System", BindingFlags.Static | BindingFlags.Public);
			if (method == null)
			{
				return false;
			}
			ParameterInfo[] parameters = method.GetParameters();
			if (parameters.Length != 1)
			{
				return false;
			}
			return parameters[0].ParameterType == VRTK_SharedMethods.GetTypeUnknownAssembly("Valve.VR.EVREventType");
		}

		[SDK_ScriptingDefineSymbolPredicate("VRTK_DEFINE_SDK_STEAMVR", "Standalone")]
		[SDK_ScriptingDefineSymbolPredicate("VRTK_DEFINE_STEAMVR_PLUGIN_1_2_0", "Standalone")]
		private static bool IsPluginVersion120()
		{
			Type typeUnknownAssembly = VRTK_SharedMethods.GetTypeUnknownAssembly("SteamVR_Events");
			if (typeUnknownAssembly == null)
			{
				return false;
			}
			MethodInfo method = typeUnknownAssembly.GetMethod("System", BindingFlags.Static | BindingFlags.Public);
			if (method == null)
			{
				return false;
			}
			ParameterInfo[] parameters = method.GetParameters();
			if (parameters.Length != 1)
			{
				return false;
			}
			return parameters[0].ParameterType == typeof(string);
		}

		[SDK_ScriptingDefineSymbolPredicate("VRTK_DEFINE_SDK_STEAMVR", "Standalone")]
		[SDK_ScriptingDefineSymbolPredicate("VRTK_DEFINE_STEAMVR_PLUGIN_1_1_1_OR_OLDER", "Standalone")]
		private static bool IsPluginVersion111OrOlder()
		{
			Type typeUnknownAssembly = VRTK_SharedMethods.GetTypeUnknownAssembly("SteamVR_Utils");
			if (typeUnknownAssembly == null)
			{
				return false;
			}
			Type nestedType = VRTK_SharedMethods.GetNestedType(typeUnknownAssembly, "Event");
			if (nestedType == null)
			{
				return false;
			}
			return nestedType.GetMethod("Listen", BindingFlags.Static | BindingFlags.Public) != null;
		}
	}
}
