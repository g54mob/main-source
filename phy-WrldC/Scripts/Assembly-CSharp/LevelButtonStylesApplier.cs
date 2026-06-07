using UnityEngine;

[RequireComponent(typeof(LevelButtonBase))]
public class LevelButtonStylesApplier : StylesApplierBase
{
	private LevelButtonAudioEffect levelButtonAudio;

	public override void Initialize()
	{
		levelButtonAudio = GetComponent<LevelButtonAudioEffect>();
		if (levelButtonAudio == null)
		{
			levelButtonAudio = base.gameObject.AddComponent<LevelButtonAudioEffect>();
		}
	}

	public override void UpdateStyles()
	{
		levelButtonAudio.SetAudiosByGameStyleData(gameStylesData);
	}

	public override void UpdateTexts()
	{
	}
}
