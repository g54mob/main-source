using UnityEngine;

[RequireComponent(typeof(AnimatorTriggeredByButton))]
public class AnimatorByButtonAudioEffect : AudioEffectBase
{
	[SerializeField]
	private AudioClip isOnClip;

	[SerializeField]
	private AudioClip isOffClip;

	[SerializeField]
	private float playTime;

	private float volume;

	private float timeCounter;

	protected override void Initialize()
	{
		GetComponent<AnimatorTriggeredByButton>().OnButtonChangedEvent += OnButtonChangedHandler;
		volume = 0.4f;
		if (base.AudioSource != null)
		{
			base.AudioSource.volume = volume;
			base.AudioSource.priority = 128;
			base.AudioSource.loop = true;
		}
		timeCounter = 0f;
	}

	protected override void Update()
	{
		base.Update();
		if (base.AudioSource == null || base.AudioEffectsManager.IsAudioSourcesInPause || !base.AudioSource.isPlaying)
		{
			return;
		}
		base.AudioSource.transform.position = base.transform.position;
		if (playTime > 0f && timeCounter < playTime)
		{
			timeCounter += Time.deltaTime;
			if (timeCounter >= playTime)
			{
				base.AudioSource.Stop();
			}
		}
	}

	public override void SetAudiosByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetAudiosByGameStyleData(gameStylesData);
		isOnClip = gameStylesData.rigidbodyStylesData.motorClip;
		if (gameStylesData.volumeStylesData != null)
		{
			volume = gameStylesData.volumeStylesData.animatorByButton;
		}
	}

	private void OnButtonChangedHandler(bool isOn)
	{
		if (!(base.AudioSource == null))
		{
			base.AudioSource.Stop();
			if (isOn && isOnClip != null)
			{
				base.AudioSource.clip = isOnClip;
				base.AudioSource.volume = volume;
				base.AudioSource.Play();
				timeCounter = 0f;
			}
			else if (!isOn && isOffClip != null)
			{
				base.AudioSource.clip = isOffClip;
				base.AudioSource.volume = volume;
				base.AudioSource.Play();
				timeCounter = 0f;
			}
		}
	}
}
