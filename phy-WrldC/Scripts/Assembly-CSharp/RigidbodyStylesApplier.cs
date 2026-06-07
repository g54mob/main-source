public class RigidbodyStylesApplier : StylesApplierBase
{
	private RigidbodyAudioEffect rigidbodyAudio;

	private RigidbodyVisualEffect rigidbodyVisualEffect;

	public override void Initialize()
	{
		rigidbodyAudio = GetComponent<RigidbodyAudioEffect>();
		if (rigidbodyAudio == null)
		{
			rigidbodyAudio = base.gameObject.AddComponent<RigidbodyAudioEffect>();
		}
		rigidbodyVisualEffect = GetComponent<RigidbodyVisualEffect>();
		if (rigidbodyVisualEffect == null)
		{
			rigidbodyVisualEffect = base.gameObject.AddComponent<RigidbodyVisualEffect>();
		}
	}

	public override void UpdateStyles()
	{
		rigidbodyAudio.SetAudiosByGameStyleData(gameStylesData);
		rigidbodyVisualEffect.SetVisualEffectsByGameStyleData(gameStylesData);
	}

	public override void UpdateTexts()
	{
	}
}
