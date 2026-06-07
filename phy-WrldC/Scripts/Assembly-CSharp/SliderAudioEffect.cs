using UnityEngine;

[RequireComponent(typeof(SliderManager))]
public class SliderAudioEffect : UIAudioEffectBase
{
	[SerializeField]
	private bool shouldPlayAudio = true;

	[SerializeField]
	private AudioClip valueChangingClip;

	private SliderManager sliderManager;

	public AudioClip ValueChangingClip
	{
		set
		{
			valueChangingClip = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		sliderManager = GetComponent<SliderManager>();
		sliderManager.OnValueChangedEvent += ValueChangedHandler;
	}

	private void ValueChangedHandler(float newValue)
	{
		if (!(valueChangingClip == null) && shouldPlayAudio)
		{
			PlayAudio(valueChangingClip);
		}
	}
}
