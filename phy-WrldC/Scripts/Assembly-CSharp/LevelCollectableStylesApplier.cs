using UnityEngine;

[RequireComponent(typeof(LevelCollectable))]
public class LevelCollectableStylesApplier : StylesApplierBase
{
	private LevelCollectableAudioEffect levelCollectableAudioEffect;

	private LevelCollectableVisualEffect levelCollectableVisualEffect;

	public override void Initialize()
	{
		levelCollectableAudioEffect = GetComponent<LevelCollectableAudioEffect>();
		if (levelCollectableAudioEffect == null)
		{
			levelCollectableAudioEffect = base.gameObject.AddComponent<LevelCollectableAudioEffect>();
		}
		levelCollectableVisualEffect = GetComponent<LevelCollectableVisualEffect>();
		if (levelCollectableVisualEffect == null)
		{
			levelCollectableVisualEffect = base.gameObject.AddComponent<LevelCollectableVisualEffect>();
		}
	}

	public override void UpdateStyles()
	{
		levelCollectableAudioEffect.SetAudiosByGameStyleData(gameStylesData);
		levelCollectableVisualEffect.SetVisualEffectsByGameStyleData(gameStylesData);
	}

	public override void UpdateTexts()
	{
	}
}
