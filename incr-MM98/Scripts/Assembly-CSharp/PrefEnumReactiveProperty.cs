using System;
using System.Collections.Generic;
using R3;
using UnityEngine;

public class PrefEnumReactiveProperty<T> : ReactiveProperty<T> where T : struct, Enum
{
	private readonly string _prefKey;

	public PrefEnumReactiveProperty(string prefKey, T defaultValue)
		: base(Get(prefKey, defaultValue), (IEqualityComparer<T>?)EqualityComparer<T>.Default, false)
	{
		_prefKey = prefKey;
		OnValueChanged(CurrentValue);
	}

	protected override void OnValueChanging(ref T value)
	{
		PlayerPrefs.SetInt(_prefKey, Convert.ToInt32(value));
	}

	private static T Get(string key, T defaultValue)
	{
		if (PlayerPrefs.HasKey(key))
		{
			return (T)Enum.ToObject(typeof(T), PlayerPrefs.GetInt(key));
		}
		return defaultValue;
	}
}
