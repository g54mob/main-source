using UnityEngine;

public class Curtain : MonoBehaviour
{
	public enum CurtainDir
	{
		Forward = 0,
		Reverse = 1
	}

	public enum CurtainCenter
	{
		Watch = 0,
		Screen = 1
	}

	public class CurtainStaterProp : StaterProp
	{
		private Curtain curtain;

		private CurtainDir dir;

		private CurtainCenter center;

		public override StaterVariant val
		{
			get
			{
				return curtain.oneBit.linedSettings.curtainSettings.t;
			}
			set
			{
				OneBit.CurtainSettings curtainSettings = curtain.oneBit.linedSettings.curtainSettings;
				curtainSettings.t = value.f;
				curtainSettings.reverse = dir == CurtainDir.Reverse;
				curtainSettings.worldCenter = curtain.watchHand.dialTransform.position;
				curtainSettings.useWorldCenter = center == CurtainCenter.Watch;
				curtainSettings.behindWatchHand = dir == CurtainDir.Forward;
				if (curtain.isShipOrOffice && curtain.watchHand != null && curtain.watchHand.host != null)
				{
					string enteringMomentId = curtain.watchHand.host.enteringMomentId;
					float b = ((!enteringMomentId.HasValue()) ? 1f : Story.it.GetMoment(enteringMomentId).dialT);
					curtain.watchHand.dial.dialT = Mathf.Lerp(1f, b, Mathf.Min(1f, value.f * 1.1f));
				}
			}
		}

		public CurtainStaterProp(Curtain curtain_, CurtainCenter center_ = CurtainCenter.Watch, CurtainDir dir_ = CurtainDir.Forward)
		{
			curtain = curtain_;
			dir = dir_;
			center = center_;
		}
	}

	public OneBit oneBit;

	public WatchHand watchHand;

	public SoundEnviron exploringSoundEnviron;

	public GameObject burstGo;

	public bool isShipOrOffice;

	[Space]
	public AudioClip acceptAudioClip;

	public AudioClip cancelAudioClip;

	public AudioClip chargingAudioClip;

	public AudioClip chargingFastAudioClip;

	public AudioClip pullCorpseAudioClip;

	public AudioClip postBookAudioClip;

	public AudioClip huntStartAudioClip;

	[Readonly]
	public AudioOneShot chargingAudioOneShot;

	private float clockPanicTime;

	public const float kDefaultEnterMomentChargingVolume = 0.5f;

	public const float kChargingAudioSecondsPerBeat = 0.6f;

	private CurtainStaterProp forwardCurtainStaterProp_;

	private CurtainStaterProp reverseCurtainStaterProp_;

	public bool chargingAudioDone
	{
		get
		{
			return chargingAudioOneShot == null || chargingAudioOneShot.done;
		}
	}

	public CurtainStaterProp forwardCurtainStaterProp
	{
		get
		{
			if (forwardCurtainStaterProp_ == null)
			{
				forwardCurtainStaterProp_ = new CurtainStaterProp(this);
			}
			return forwardCurtainStaterProp_;
		}
	}

	public CurtainStaterProp reverseCurtainStaterProp
	{
		get
		{
			if (reverseCurtainStaterProp_ == null)
			{
				reverseCurtainStaterProp_ = new CurtainStaterProp(this, CurtainCenter.Screen, CurtainDir.Reverse);
			}
			return reverseCurtainStaterProp_;
		}
	}

	private static float SnapToDiv(float t, int divs = 12)
	{
		float num = (float)Mathf.FloorToInt(t * (float)divs) / (float)divs;
		float num2 = num + 1f / (float)divs;
		float x = (t - num) / (num2 - num);
		return Mathf.Lerp(num, num2, Util.SmoothStepEdges(0.3f, 0.7f, x)) % 1f;
	}

	public void SetClockPanic(bool fast = false)
	{
		float num = ((!fast) ? 0.25f : 1f);
		clockPanicTime += Clock.play.deltaTime * num;
		watchHand.dial.hourT = 1f + -1.3f * clockPanicTime % -1f;
		watchHand.dial.minuteT = 2.3f * clockPanicTime % 1f;
		if (!fast)
		{
			watchHand.dial.hourT = SnapToDiv(watchHand.dial.hourT);
			watchHand.dial.minuteT = SnapToDiv(watchHand.dial.minuteT, 4);
		}
	}

	public void PlayChargingAudio(AudioClip clip, float soundEnvironFadeOutDuration)
	{
		if (chargingAudioOneShot != null)
		{
			chargingAudioOneShot.Stop(0.1f);
			chargingAudioOneShot = null;
		}
		chargingAudioOneShot = AudioOneShot.Play(clip, false, 0.5f);
		exploringSoundEnviron.FadeOut(soundEnvironFadeOutDuration);
	}

	public void StopChargingAudio(float duration = 0.1f)
	{
		if (chargingAudioOneShot != null)
		{
			chargingAudioOneShot.Stop(duration);
		}
	}
}
