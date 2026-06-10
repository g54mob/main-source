using System;
using UnityEngine;
using UnityEngine.Localization;

[Serializable]
public struct PreferenceIconMapping
{
	public FishPreferenceType type;

	public Sprite icon;

	public LocalizedString text;
}
