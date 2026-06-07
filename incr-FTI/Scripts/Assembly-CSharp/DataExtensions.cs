using System.Collections.Generic;
using FullSerializer;
using UnityEngine;

public static class DataExtensions
{
	public static bool TryAsString(this fsData data, out string s)
	{
		if (data.IsString)
		{
			s = data.AsString;
			return true;
		}
		s = null;
		return false;
	}

	public static bool TryAsLong(this fsData data, out long i)
	{
		if (data.IsInt64)
		{
			i = data.AsInt64;
			return true;
		}
		i = 0L;
		return false;
	}

	public static bool TryAsInt(this fsData data, out int i)
	{
		if (data.IsInt64)
		{
			i = (int)data.AsInt64;
			return true;
		}
		i = 0;
		return false;
	}

	public static bool TryAsBool(this fsData data, out bool b)
	{
		if (data.IsBool)
		{
			b = data.AsBool;
			return true;
		}
		b = false;
		return false;
	}

	public static bool TryAsDouble(this fsData data, out double f)
	{
		if (data.IsDouble)
		{
			f = data.AsDouble;
			return true;
		}
		f = 0.0;
		return false;
	}

	public static bool TryAsList(this fsData data, out List<fsData> result)
	{
		if (data.IsList)
		{
			result = data.AsList;
			return true;
		}
		Debug.LogError("Not a list");
		result = null;
		return false;
	}

	public static bool TryAsDictionary(this fsData data, out Dictionary<string, fsData> result)
	{
		if (data.IsDictionary)
		{
			result = data.AsDictionary;
			return true;
		}
		Debug.LogError("Not a dictionary");
		result = null;
		return false;
	}
}
