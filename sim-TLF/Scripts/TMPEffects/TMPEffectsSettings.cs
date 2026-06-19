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

	public static TMPEffectsSettings Instance
	{
		get
		{
			if (instance == null)
			{
				instance = Resources.Load<TMPEffectsSettings>("TMPEffects Settings");
				if (instance == null)
				{
					Debug.LogError("Could not load TMPEffectsSettings. You must import it and rebuild in order for TMPEffects to work properly.");
				}
			}
			return instance;
		}
	}

	public static TMPAnimationDatabase DefaultAnimationDatabase => Instance?.defaultAnimationDatabase;

	public static TMPCommandDatabase DefaultCommandDatabase => Instance?.defaultCommandDatabase;

	public static TMPKeywordDatabase DefaultKeywordDatabase => Instance?.defaultKeywordDatabase;

	public static TMPKeywordDatabase GlobalKeywordDatabase => Instance?.globalKeywordDatabase;
}
