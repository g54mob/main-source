using System.Collections.Generic;
using R3;
using UnityEngine;

public class PrefStringReactiveProperty : ReactiveProperty<string>
{
	private readonly string _prefKey;

	public PrefStringReactiveProperty(string prefKey, string defaultValue)
		: base(PlayerPrefs.GetString(prefKey, defaultValue), (IEqualityComparer<string>?)EqualityComparer<string>.Default, false)
	{
		_prefKey = prefKey;
		OnValueChanged(CurrentValue);
	}

	protected override void OnValueChanging(ref string value)
	{
		PlayerPrefs.SetString(_prefKey, value);
	}
}
