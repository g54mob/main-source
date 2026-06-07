using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorTransitionAudioEffect : AudioEffectBase
{
	[SerializeField]
	private AudioClip transitionClip;

	[SerializeField]
	private AudioClip endTransitionClip;

	[SerializeField]
	private int layerIndex;

	private Animator animator;

	private AudioEffectData endTransitionAudioData;

	private float transitionVolume;

	protected override void Initialize()
	{
		animator = GetComponent<Animator>();
		transitionVolume = 0.4f;
		if (base.AudioSource != null)
		{
			base.AudioSource.volume = transitionVolume;
			base.AudioSource.priority = 128;
			base.AudioSource.loop = true;
		}
		endTransitionAudioData = new AudioEffectData
		{
			AudioClip = endTransitionClip,
			LoudnessIntensity = AudioEffectData.Loudness.Medium,
			Volume = 0.5f,
			Priority = 128
		};
	}

	protected override void Update()
	{
		base.Update();
		if (base.AudioSource == null || base.AudioEffectsManager.IsAudioSourcesInPause)
		{
			return;
		}
		base.AudioSource.transform.position = base.transform.position;
		if (animator.IsInTransition(layerIndex))
		{
			if (!base.AudioSource.isPlaying)
			{
				base.AudioSource.clip = transitionClip;
				base.AudioSource.volume = transitionVolume;
				base.AudioSource.Play();
			}
		}
		else if (base.AudioSource.isPlaying)
		{
			base.AudioSource.Stop();
			if (endTransitionClip != null)
			{
				PlayOnceEffect(endTransitionAudioData, base.transform.position);
			}
		}
	}

	public override void SetAudiosByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetAudiosByGameStyleData(gameStylesData);
		transitionClip = gameStylesData.rigidbodyStylesData.motorClip;
		endTransitionClip = gameStylesData.rigidbodyStylesData.endCourseClip;
		if (endTransitionAudioData != null)
		{
			endTransitionAudioData.AudioClip = endTransitionClip;
		}
		if (gameStylesData.volumeStylesData != null)
		{
			transitionVolume = gameStylesData.volumeStylesData.animatorTransitionMoving;
			if (endTransitionAudioData != null)
			{
				endTransitionAudioData.Volume = gameStylesData.volumeStylesData.animatorTransitionEnd;
			}
		}
	}
}
