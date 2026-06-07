using UnityEngine;

[RequireComponent(typeof(LandMine))]
public class LandMineStylesApplier : RigidbodyStylesApplier
{
	private LandMineAudioEffect landMineAudio;

	private ExplosionVisualEffect explosionVisualEffect;

	public override void Initialize()
	{
		base.Initialize();
		landMineAudio = GetComponent<LandMineAudioEffect>();
		if (landMineAudio == null)
		{
			RigidbodyAudioEffect component = GetComponent<RigidbodyAudioEffect>();
			if (component != null)
			{
				Object.Destroy(component);
			}
			landMineAudio = base.gameObject.AddComponent<LandMineAudioEffect>();
		}
		explosionVisualEffect = GetComponent<ExplosionVisualEffect>();
		if (explosionVisualEffect == null)
		{
			explosionVisualEffect = base.gameObject.AddComponent<ExplosionVisualEffect>();
		}
	}

	public override void UpdateStyles()
	{
		base.UpdateStyles();
		landMineAudio.SetAudiosByGameStyleData(gameStylesData);
		explosionVisualEffect.SetVisualEffectsByGameStyleData(gameStylesData);
	}
}
