using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableEnum : ScriptableObject
{
	private static bool _assetsAreLoaded;

	private static Dictionary<Type, List<ScriptableEnum>> _assetLists;

	private static Dictionary<Type, Dictionary<string, ScriptableEnum>> _assetsByName;

	public virtual void OnEnable()
	{
	}

	public virtual void OnDestroy()
	{
	}

	private static void EnsureInstancesAreLoaded()
	{
	}

	public static int GetCount(Type type)
	{
		return 0;
	}

	public static ScriptableEnum[] GetValues(Type type)
	{
		return null;
	}

	public static ScriptableEnum GetValue(Type type, int index)
	{
		return null;
	}

	public static ScriptableEnum GetValue(Type type, string name)
	{
		return null;
	}

	public static T[] GetValues<T>() where T : ScriptableEnum
	{
		return null;
	}

	public static int GetCount<T>() where T : ScriptableEnum
	{
		return 0;
	}

	public static T GetValue<T>(int index) where T : ScriptableEnum
	{
		return null;
	}

	public static T GetValue<T>(string name) where T : ScriptableEnum
	{
		return null;
	}
}
