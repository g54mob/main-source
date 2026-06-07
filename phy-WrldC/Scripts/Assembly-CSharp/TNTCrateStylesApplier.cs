using UnityEngine;

[RequireComponent(typeof(TNTCrate))]
public class TNTCrateStylesApplier : RigidbodyStylesApplier
{
	private TNTCrateAudioEffect tntCrateAudio;

	private ExplosionVisualEffect explosionVisualEffect;

	public override void Initialize()
	{
		base.Initialize();
		tntCrateAudio = GetComponent<TNTCrateAudioEffect>();
		if (tntCrateAudio == null)
		{
			RigidbodyAudioEffect component = GetComponent<RigidbodyAudioEffect>();
			if (component != null)
			{
				Object.Destroy(component);
			}
			tntCrateAudio = base.gameObject.AddComponent<TNTCrateAudioEffect>();
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
		tntCrateAudio.SetAudiosByGameStyleData(gameStylesData);
		explosionVisualEffect.SetVisualEffectsByGameStyleData(gameStylesData);
	}
}
