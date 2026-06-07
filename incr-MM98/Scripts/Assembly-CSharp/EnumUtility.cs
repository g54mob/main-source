using System;
using System.Collections.Generic;
using ZLinq;
using ZLinq.Linq;

public static class EnumUtility
{
	public static T GetRandom<T>() where T : Enum
	{
		Array values = Enum.GetValues(typeof(T));
		return (T)values.GetValue(BiteRandom.NextInt(0, values.Length));
	}

	public static T GetRandomSkipNone<T>() where T : Enum
	{
		Array values = Enum.GetValues(typeof(T));
		return (T)values.GetValue(BiteRandom.NextInt(1, values.Length));
	}

	public static IEnumerable<T> GetValues<T>() where T : Enum
	{
		foreach (T value in Enum.GetValues(typeof(T)))
		{
			yield return value;
		}
	}

	public static IEnumerable<T> GetValuesSkipNone<T>() where T : Enum
	{
		using ValueEnumerator<Skip<FromNonGenericEnumerable<T>, T>, T> valueEnumerator = Enum.GetValues(typeof(T)).AsValueEnumerable<T>().Skip(1)
			.GetEnumerator<Skip<FromNonGenericEnumerable<T>, T>, T>();
		while (valueEnumerator.MoveNext())
		{
			yield return valueEnumerator.Current;
		}
	}

	public static IEnumerable<T> GetValuesSkip<T>(params T[] skip) where T : Enum
	{
		using ValueEnumerator<Except<FromNonGenericEnumerable<T>, FromEnumerable<T>, T>, T> valueEnumerator = Enum.GetValues(typeof(T)).AsValueEnumerable<T>().Except(skip)
			.GetEnumerator<Except<FromNonGenericEnumerable<T>, FromEnumerable<T>, T>, T>();
		while (valueEnumerator.MoveNext())
		{
			yield return valueEnumerator.Current;
		}
	}
}
