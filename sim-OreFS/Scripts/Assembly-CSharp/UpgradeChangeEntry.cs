using System;
using UnityEngine;

[Serializable]
public class UpgradeChangeEntry
{
	[Tooltip("Localization key for the change text")]
	public string textKey;

	[Tooltip("Old value (before upgrade)")]
	public string oldValue;

	[Tooltip("New value (after upgrade)")]
	public string newValue;
}
