using System;
using System.Collections.Generic;
using R3;
using UnityEngine;

public class PrefStructReactiveProperty<T> : ReactiveProperty<T> where T : struct
{
	private readonly string _prefKey;

	private readonly Func<T, string> _write;

	public PrefStructReactiveProperty(string prefKey, T defaultValue, Func<T, string> write, Func<string, T> read)
		: base(Get(prefKey, defaultValue, read), (IEqualityComparer<T>?)EqualityComparer<T>.Default, false)
	{
		_prefKey = prefKey;
		_write = write;
		OnValueChanged(CurrentValue);
	}

	protected override void OnValueChanging(ref T value)
	{
		PlayerPrefs.SetString(_prefKey, _write(value));
	}

	private static T Get(string key, T defaultValue, Func<string, T> read)
	{
		if (PlayerPrefs.HasKey(key))
		{
			return read(PlayerPrefs.GetString(key));
		}
		return defaultValue;
	}
}
