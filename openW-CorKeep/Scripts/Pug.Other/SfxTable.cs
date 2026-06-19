using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NaughtyAttributes;
using Pug.UnityExtensions;
using UnityEngine;

[CreateAssetMenu(menuName = "Pug/Audio/SfxTable", order = 3)]
public class SfxTable : ScriptableObject
{
	[Serializable]
	public class SFXInfo
	{
		public string id;

		public SFXInfoSettings settings;

		[ArrayElementTitle("sfx")]
		public List<SFXSound> sounds;

		public List<SFXSoundVariant> variants;
	}

	[Serializable]
	public class SFXSound
	{
		public SfxUnityInspectorFriendlyID sfx;

		[Min(0f)]
		public float volume = 1f;

		[Min(0f)]
		public float pitch = 1f;

		public float pitchDev;

		public float volumeDev;

		public bool randomStartTime;

		public AudioManager.MixerGroupEnum mixerGroup = AudioManager.MixerGroupEnum.EFFECTS;
	}

	[Serializable]
	public class SFXSoundVariant
	{
		public List<SFXSound> soundVariant;
	}

	[Serializable]
	public class SFXInfoSettings
	{
		public bool stackable;

		public bool ignoreAudioIfOutsideOfViewport;

		public bool dontUseSpatialSound;

		[HideIf("dontUseSpatialSound")]
		[AllowNesting]
		[Header("Leave MaxSpatialDistance as 0 to use default value of 16")]
		public float overrideMaxSpatialDistance;

		[HideIf("dontUseSpatialSound")]
		[AllowNesting]
		[Header("Leave MaxSpatialBlendDistance as 0 to use default value of 10")]
		public float overrideMaxSpatialBlendDistance;
	}

	private List<SfxTableElement> sfxTableElements;

	private Dictionary<int, SfxTableElement> sfxInfosDict;

	private static readonly Regex sWhitespace = new Regex("\\s+");

	public void Init()
	{
		sfxTableElements = new List<SfxTableElement>();
		SfxTableElement[] array = Resources.LoadAll<SfxTableElement>("SFXTableElements");
		foreach (SfxTableElement item in array)
		{
			sfxTableElements.Add(item);
		}
		sfxInfosDict = new Dictionary<int, SfxTableElement>();
		foreach (SfxTableElement sfxTableElement in sfxTableElements)
		{
			int key = Animator.StringToHash(sfxTableElement.name);
			sfxInfosDict.Add(key, sfxTableElement);
		}
	}

	public SfxTableElement GetSfxInfo(int id)
	{
		sfxInfosDict.TryGetValue(id, out var value);
		return value;
	}

	public bool SFXTableIDExists(int id)
	{
		return sfxInfosDict.ContainsKey(id);
	}

	public static string ReplaceWhitespace(string input, string replacement)
	{
		return sWhitespace.Replace(input, replacement);
	}
}
