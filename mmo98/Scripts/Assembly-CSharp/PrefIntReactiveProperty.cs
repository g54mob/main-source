using System.Collections.Generic;
using R3;
using UnityEngine;

public class PrefIntReactiveProperty : ReactiveProperty<int>
{
	private readonly string _prefKey;

	public PrefIntReactiveProperty(string prefKey, int defaultValue)
		: base(PlayerPrefs.GetInt(prefKey, defaultValue), (IEqualityComparer<int>?)EqualityComparer<int>.Default, false)
	{
		_prefKey = prefKey;
		OnValueChanged(CurrentValue);
	}

	protected override void OnValueChanging(ref int value)
	{
		PlayerPrefs.SetInt(_prefKey, value);
	}
}
