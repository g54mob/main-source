using UnityEngine;

[RequireComponent(typeof(Wheel))]
public class WheelAudioEffect : AudioEffectBase
{
	[SerializeField]
	private AudioClip frictionClip;

	private Wheel wheel;

	private float frictionVolume;

	protected override void Initialize()
	{
		wheel = GetComponent<Wheel>();
		base.gameObject.GetBlockView().BlockDestroyedEvent += OnBlockDestroyedHandler;
		frictionVolume = 0.2f;
		if (base.AudioSource != null)
		{
			base.AudioSource.volume = frictionVolume;
			base.AudioSource.priority = 128;
			base.AudioSource.loop = true;
		}
	}

	protected override void Update()
	{
		base.Update();
		if (base.AudioSource == null || base.AudioEffectsManager.IsAudioSourcesInPause)
		{
			return;
		}
		if (!wheel.IsWheelMotorActived)
		{
			if (base.AudioSource.isPlaying)
			{
				base.AudioSource.Stop();
			}
			return;
		}
		base.AudioSource.transform.position = base.transform.position;
		if (wheel.WheelMotor.IsGrounded)
		{
			base.AudioSource.volume = Mathf.InverseLerp(0f, 6000f, wheel.WheelMotor.RPM) * frictionVolume;
			if (!base.AudioSource.isPlaying)
			{
				base.AudioSource.clip = frictionClip;
				base.AudioSource.Play();
			}
		}
		else if (base.AudioSource.isPlaying)
		{
			base.AudioSource.Stop();
		}
	}

	public override void SetAudiosByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetAudiosByGameStyleData(gameStylesData);
		frictionClip = gameStylesData.componentStylesData.wheelFrictionClip;
		if (gameStylesData.volumeStylesData != null)
		{
			frictionVolume = gameStylesData.volumeStylesData.wheelFriction;
		}
	}

	private void OnBlockDestroyedHandler()
	{
		RecycleAudioSource();
	}
}
