using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public static class NoAllocHelpers
{
	private static readonly Dictionary<Type, Delegate> ExtractArrayFromListTDelegates = new Dictionary<Type, Delegate>();

	private static readonly Dictionary<Type, Delegate> ResizeListDelegates = new Dictionary<Type, Delegate>();

	public static T[] ExtractArrayFromListT<T>(List<T> list)
	{
		if (!ExtractArrayFromListTDelegates.TryGetValue(typeof(T), out var value))
		{
			MethodInfo method = Assembly.GetAssembly(typeof(Mesh)).GetType("UnityEngine.NoAllocHelpers").GetMethod("ExtractArrayFromListT", BindingFlags.Static | BindingFlags.Public)
				.MakeGenericMethod(typeof(T));
			Delegate obj = (ExtractArrayFromListTDelegates[typeof(T)] = Delegate.CreateDelegate(typeof(Func<List<T>, T[]>), method));
			value = obj;
		}
		return ((Func<List<T>, T[]>)value)(list);
	}

	public static void ResizeList<T>(List<T> list, int size)
	{
		if (!ResizeListDelegates.TryGetValue(typeof(T), out var value))
		{
			MethodInfo method = Assembly.GetAssembly(typeof(Mesh)).GetType("UnityEngine.NoAllocHelpers").GetMethod("ResizeList", BindingFlags.Static | BindingFlags.Public)
				.MakeGenericMethod(typeof(T));
			Delegate obj = (ResizeListDelegates[typeof(T)] = Delegate.CreateDelegate(typeof(Action<List<T>, int>), method));
			value = obj;
		}
		((Action<List<T>, int>)value)(list, size);
	}
}
