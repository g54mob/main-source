using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

[CreateAssetMenu(menuName = "Pug/Audio/SfxTableElement", order = 3)]
public class SfxTableElement : ScriptableObject, ISerializationCallbackReceiver
{
	public SfxTable.SFXInfoSettings settings;

	[ArrayElementTitle("sfx")]
	public List<SfxTable.SFXSound> sounds;

	public List<SfxTable.SFXSoundVariant> variants;

	[Header("Debugging:")]
	public bool mute;

	public bool debugPrintVolume;

	public void OnBeforeSerialize()
	{
		SetDefaultValues();
	}

	public void OnAfterDeserialize()
	{
	}

	private void SetDefaultValues()
	{
		if (sounds != null)
		{
			for (int i = 0; i < sounds.Count; i++)
			{
				SfxTable.SFXSound sFXSound = sounds[i];
				if (sFXSound.volume <= 0f)
				{
					sFXSound.volume = 1f;
				}
				if (sFXSound.pitch <= 0f)
				{
					sFXSound.pitch = 1f;
				}
				if (sFXSound.mixerGroup == AudioManager.MixerGroupEnum.UI)
				{
					sFXSound.mixerGroup = AudioManager.MixerGroupEnum.EFFECTS;
				}
			}
		}
		if (variants == null)
		{
			return;
		}
		for (int j = 0; j < variants.Count; j++)
		{
			SfxTable.SFXSoundVariant sFXSoundVariant = variants[j];
			for (int k = 0; k < sFXSoundVariant.soundVariant.Count; k++)
			{
				SfxTable.SFXSound sFXSound2 = sFXSoundVariant.soundVariant[k];
				if (sFXSound2.volume <= 0f)
				{
					sFXSound2.volume = 1f;
				}
				if (sFXSound2.pitch <= 0f)
				{
					sFXSound2.pitch = 1f;
				}
				if (sFXSound2.mixerGroup == AudioManager.MixerGroupEnum.UI)
				{
					sFXSound2.mixerGroup = AudioManager.MixerGroupEnum.EFFECTS;
				}
			}
		}
	}
}
