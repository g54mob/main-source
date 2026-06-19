using System;
using System.Collections.Generic;
using System.Linq;

public static class EnumUtils
{
	public static IEnumerable<T> GetValues<T>()
	{
		return Enum.GetValues(typeof(T)).Cast<T>();
	}

	public static int GetNumValues<T>()
	{
		return Enum.GetValues(typeof(T)).Cast<T>().Count();
	}

	public static T GetRandomElement<T>()
	{
		return ListUtil.GetRandomElement(Enum.GetValues(typeof(T)).Cast<T>().ToList());
	}
}
