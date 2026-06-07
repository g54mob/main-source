using UnityEngine;

public class EnderClick : MonoBehaviour
{
	public OneBit oneBit;

	public AudioClip clickAudioClip;

	public float initialDelay;

	private AudioSource clickAudioSource0;

	private AudioSource clickAudioSource1;

	private float delayCountdown;

	public const float kChargeDuration = 10f;

	private const float kUnchargeDuration = 1f;

	private const float kChargeStepCount = 10f;

	private float chargingT_;

	private float prevChargingT_;

	public float chargingT
	{
		get
		{
			return chargingT_;
		}
		set
		{
			prevChargingT_ = chargingT_;
			chargingT_ = value;
			float num = chargingT_ * 10f;
			oneBit.linedSettings.shipEnderT = (Mathf.Floor(num) + Util.SmoothStepEdges(0f, 0.2f, num % 1f)) / 10f;
			float f = prevChargingT_ * 10f;
			if (Mathf.Ceil(num) != Mathf.Ceil(f))
			{
				if (!clickAudioSource0.isPlaying)
				{
					clickAudioSource0.Play();
				}
				else
				{
					clickAudioSource1.Play();
				}
			}
		}
	}

	public bool done
	{
		get
		{
			return chargingT >= 1f;
		}
	}

	private void Start()
	{
		clickAudioSource0 = base.gameObject.AddComponent<AudioSource>();
		clickAudioSource0.playOnAwake = false;
		clickAudioSource0.clip = clickAudioClip;
		clickAudioSource1 = base.gameObject.AddComponent<AudioSource>();
		clickAudioSource1.playOnAwake = false;
		clickAudioSource1.clip = clickAudioClip;
		Clear();
	}

	public void Charge()
	{
		if (delayCountdown > 0f)
		{
			delayCountdown = Mathf.Max(0f, delayCountdown - Clock.play.deltaTime);
		}
		else
		{
			chargingT = Mathf.Min(1f, chargingT + Clock.play.deltaTime / 10f);
		}
	}

	public void Uncharge()
	{
		chargingT = Mathf.Max(0f, chargingT - Clock.play.deltaTime / 1f);
		delayCountdown = initialDelay;
	}

	public void Clear()
	{
		chargingT = 0f;
		delayCountdown = initialDelay;
	}
}
