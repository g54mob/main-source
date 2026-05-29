using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public static class URPUtility
{
	private static Dictionary<Type, Dictionary<string, FieldInfo>> s_FieldLUT;

	private static Dictionary<Type, string> s_TypeNameLUT;

	public static ScriptableRendererFeature ssao => null;

	public static bool ssaoEnabled
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static float ssaoDirectLightingStrength
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public static float ssaoRadius
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public static float ssaoIntensity
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public static ScriptableRendererFeature decals => null;

	public static float decalsMaxDrawDistance
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	private static float GetSettingsFloat(ScriptableRendererFeature feature, string settingsName, string memberName)
	{
		return 0f;
	}

	private static void SetSettingsFloat(ScriptableRendererFeature feature, string settingsName, string memberName, float value)
	{
	}

	private static FieldInfo GetField(Type type, string fieldName)
	{
		return null;
	}

	public static ScriptableRendererFeature GetRendererFeature(string typeName)
	{
		return null;
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	private static void RuntimeInitializeOnLoadMethod()
	{
	}
}
