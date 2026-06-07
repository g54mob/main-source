using System;
using System.Collections.Generic;

public abstract class AGATMonoFilter : AGATFilter
{
	private static Dictionary<string, Type> __filterTypesForNames = new Dictionary<string, Type>();

	private static Dictionary<Type, string> __filterNamesForTypes = new Dictionary<Type, string>();

	private static string[] __allFilterNames;

	public abstract void ProcessChunk(float[] data, int fromIndex, int length, int stride);

	public abstract AGATMonoFilter GetMultiChannelWrapper<T>(int nbOfChannels) where T : AGATMonoFilter;

	protected static void RegisterMonoFilter(string filterName, Type filterType)
	{
		__filterTypesForNames.Add(filterName, filterType);
		__filterNamesForTypes.Add(filterType, filterName);
		if (__allFilterNames != null)
		{
			__allFilterNames = null;
		}
	}

	public static string FilterNameForType(Type t)
	{
		if (!__filterNamesForTypes.ContainsKey(t))
		{
			return null;
		}
		return __filterNamesForTypes[t];
	}

	public static Type FilterTyperForName(string filterName)
	{
		if (!__filterTypesForNames.ContainsKey(filterName))
		{
			return null;
		}
		return __filterTypesForNames[filterName];
	}

	public static string[] GetAllFilterNames()
	{
		if (__allFilterNames == null)
		{
			__allFilterNames = new string[__filterTypesForNames.Count];
			__filterTypesForNames.Keys.CopyTo(__allFilterNames, 0);
		}
		return __allFilterNames;
	}
}
