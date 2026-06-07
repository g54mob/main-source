using System.Collections.Generic;
using R3;
using UnityEngine;

public class PrefFloatReactiveProperty : ReactiveProperty<float>
{
	private readonly string _prefKey;

	public PrefFloatReactiveProperty(string prefKey, float defaultValue)
		: base(PlayerPrefs.GetFloat(prefKey, defaultValue), (IEqualityComparer<float>?)EqualityComparer<float>.Default, false)
	{
		_prefKey = prefKey;
		OnValueChanged(CurrentValue);
	}

	protected override void OnValueChanging(ref float value)
	{
		PlayerPrefs.SetFloat(_prefKey, value);
	}
}
