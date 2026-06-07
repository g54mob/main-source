using UnityEngine;

public class BlockBodyStylesApplier : RigidbodyStylesApplier
{
	private BlockBodyAudioEffect blockBodyAudio;

	private BlockBodyVisualEffect blockBodyVisualEffect;

	public override void Initialize()
	{
		base.Initialize();
		blockBodyAudio = GetComponent<BlockBodyAudioEffect>();
		if (blockBodyAudio == null)
		{
			RigidbodyAudioEffect component = GetComponent<RigidbodyAudioEffect>();
			if (component != null)
			{
				Object.Destroy(component);
			}
			blockBodyAudio = base.gameObject.AddComponent<BlockBodyAudioEffect>();
		}
		blockBodyVisualEffect = GetComponent<BlockBodyVisualEffect>();
		if (blockBodyVisualEffect == null)
		{
			RigidbodyVisualEffect component2 = GetComponent<RigidbodyVisualEffect>();
			if (component2 != null)
			{
				Object.Destroy(component2);
			}
			blockBodyVisualEffect = base.gameObject.AddComponent<BlockBodyVisualEffect>();
		}
	}

	public override void UpdateStyles()
	{
		base.UpdateStyles();
		blockBodyAudio.SetAudiosByGameStyleData(gameStylesData);
		blockBodyVisualEffect.SetVisualEffectsByGameStyleData(gameStylesData);
	}

	public override void UpdateTexts()
	{
		base.UpdateTexts();
	}
}
