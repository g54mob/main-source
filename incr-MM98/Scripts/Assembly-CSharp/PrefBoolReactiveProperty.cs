using System.Collections.Generic;
using R3;
using UnityEngine;

public class PrefBoolReactiveProperty : ReactiveProperty<bool>
{
	private readonly string _prefKey;

	public PrefBoolReactiveProperty(string prefKey, bool defaultValue)
		: base(PlayerPrefs.GetInt(prefKey, defaultValue ? 1 : 0) == 1, (IEqualityComparer<bool>?)EqualityComparer<bool>.Default, false)
	{
		_prefKey = prefKey;
		OnValueChanged(CurrentValue);
	}

	protected override void OnValueChanging(ref bool value)
	{
		PlayerPrefs.SetInt(_prefKey, value ? 1 : 0);
	}
}
