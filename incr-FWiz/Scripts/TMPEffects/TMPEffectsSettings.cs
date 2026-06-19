using System;
using TMPEffects.Databases;
using TMPEffects.Databases.AnimationDatabase;
using TMPEffects.Databases.CommandDatabase;
using UnityEngine;

[Serializable]
[ExcludeFromPreset]
internal class TMPEffectsSettings : ScriptableObject
{
	private static TMPEffectsSettings instance;

	[SerializeField]
	private TMPAnimationDatabase defaultAnimationDatabase;

	[SerializeField]
	private TMPCommandDatabase defaultCommandDatabase;

	[SerializeField]
	private TMPKeywordDatabase defaultKeywordDatabase;

	[SerializeField]
	private TMPKeywordDatabase globalKeywordDatabase;

	public static TMPEffectsSettings Instance => null;

	public static TMPAnimationDatabase DefaultAnimationDatabase => null;

	public static TMPCommandDatabase DefaultCommandDatabase => null;

	public static TMPKeywordDatabase DefaultKeywordDatabase => null;

	public static TMPKeywordDatabase GlobalKeywordDatabase => null;
}
