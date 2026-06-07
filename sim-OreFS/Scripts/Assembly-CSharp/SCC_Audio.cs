using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("BoneCracker Games/Simple Car Controller/SCC Audio")]
public class SCC_Audio : MonoBehaviour
{
	private SCC_Network net;

	private SCC_Drivetrain drivetrain;

	private SCC_InputProcessor inputProcessor;

	public AudioSource engineOnSource;

	public AudioSource engineOffSource;

	public float minimumVolume = 0.1f;

	public float maximumVolume = 1f;

	public float minimumPitch = 0.75f;

	public float maximumPitch = 1.25f;

	[Header("Brake Friction Sound")]
	[Tooltip("Fren sürtünme sesi için AudioSource (loop açık olmalı)")]
	public AudioSource handbrakeFrictionSource;

	[Tooltip("Sürtünme sesinin maksimum volume değeri")]
	public float frictionMaxVolume = 0.8f;

	[Tooltip("Sürtünme sesinin başlaması için minimum hız (km/h)")]
	public float frictionMinSpeed = 3f;

	[Tooltip("Sürtünme sesinin tam volume olacağı hız (km/h)")]
	public float frictionFullSpeed = 60f;

	[Tooltip("Normal frenin bu değeri geçince sürtünme sesi tetiklenir (0-1)")]
	public float brakeThresholdForFriction = 0.8f;

	[Header("Handbrake Engage Sound")]
	[Tooltip("El freni çekildiğinde çalan ses için AudioSource")]
	public AudioSource handbrakeEngageSource;

	[Tooltip("El freni çekildiğinde çalan AudioClip")]
	public AudioClip handbrakeEngageClip;

	[Tooltip("El freni ses volume")]
	public float handbrakeEngageVolume = 1f;

	[Tooltip("El freni aktif sayılması için input eşiği")]
	public float handbrakeEngageThreshold = 0.5f;

	private bool wasHandbrakeEngaged;

	[Header("Horn")]
	[Tooltip("Korna sesi için AudioSource (loop açık olmalı)")]
	public AudioSource hornSource;

	[Tooltip("Kısa korna AudioClip")]
	public AudioClip hornClip;

	[Tooltip("Uzun korna AudioClip (basılı tutunca)")]
	public AudioClip longHornClip;

	[Tooltip("Korna volume")]
	public float hornVolume = 1f;

	[Header("Enter / Exit")]
	[Tooltip("Biniş/iniş sesleri için AudioSource")]
	public AudioSource enterExitSource;

	[Tooltip("Araca biniş sesleri (random seçilir)")]
	public List<AudioClip> enterClips = new List<AudioClip>();

	[Tooltip("Araçtan iniş sesleri (random seçilir)")]
	public List<AudioClip> exitClips = new List<AudioClip>();

	[Tooltip("Enter/Exit ses volume")]
	public float enterExitVolume = 1f;

	[Header("Reverse Beep")]
	[Tooltip("Geri giderken bip sesi aktif mi")]
	public bool reverseBeepEnabled;

	[Tooltip("Geri giderken çalacak bip sesi için AudioSource")]
	public AudioSource reverseBeepSource;

	[Tooltip("Geri giderken çalacak bip AudioClip")]
	public AudioClip reverseBeepClip;

	[Tooltip("Bip sesi volume")]
	public float reverseBeepVolume = 1f;

	[Tooltip("Bip sesleri arasındaki süre (saniye)")]
	public float reverseBeepInterval = 0.8f;

	private float _reverseBeepTimer;

	private bool _isReversing;

	[Header("Ignition")]
	[Tooltip("Kontak acma sesi")]
	public AudioClip ignitionOnClip;

	[Tooltip("Kontak kapama sesi")]
	public AudioClip ignitionOffClip;

	[Tooltip("Kontak sesleri icin AudioSource")]
	public AudioSource ignitionSource;

	[Tooltip("Surucu indikten sonra motor kapanma gecikmesi (saniye)")]
	public float engineShutdownDelay = 1.5f;

	private bool engineRunning;

	private Coroutine shutdownCoroutine;

	private SCC_Network Net
	{
		get
		{
			if (net == null)
			{
				net = GetComponent<SCC_Network>();
			}
			return net;
		}
	}

	public SCC_Drivetrain Drivetrain
	{
		get
		{
			if (drivetrain == null)
			{
				drivetrain = GetComponent<SCC_Drivetrain>();
			}
			return drivetrain;
		}
	}

	public SCC_InputProcessor InputProcessor
	{
		get
		{
			if (inputProcessor == null)
			{
				inputProcessor = GetComponent<SCC_InputProcessor>();
			}
			return inputProcessor;
		}
	}

	public void StartEngine()
	{
		if (shutdownCoroutine != null)
		{
			StopCoroutine(shutdownCoroutine);
			shutdownCoroutine = null;
		}
		if (!engineRunning)
		{
			engineRunning = true;
			if (ignitionSource != null && ignitionOnClip != null)
			{
				ignitionSource.PlayOneShot(ignitionOnClip);
			}
		}
	}

	public void StopEngine()
	{
		if (engineRunning)
		{
			if (shutdownCoroutine != null)
			{
				StopCoroutine(shutdownCoroutine);
			}
			shutdownCoroutine = StartCoroutine(ShutdownRoutine());
		}
	}

	private IEnumerator ShutdownRoutine()
	{
		yield return new WaitForSeconds(engineShutdownDelay);
		engineRunning = false;
		if (ignitionSource != null && ignitionOffClip != null)
		{
			ignitionSource.PlayOneShot(ignitionOffClip);
		}
		SilenceEngine();
		shutdownCoroutine = null;
	}

	private void SilenceEngine()
	{
		if (engineOnSource != null)
		{
			engineOnSource.volume = 0f;
		}
		if (engineOffSource != null)
		{
			engineOffSource.volume = 0f;
		}
		if (handbrakeFrictionSource != null)
		{
			handbrakeFrictionSource.volume = 0f;
		}
	}

	public float PlayHorn()
	{
		if (hornSource == null || hornClip == null)
		{
			return -1f;
		}
		hornSource.clip = hornClip;
		hornSource.volume = hornVolume;
		hornSource.Play();
		return hornClip.length;
	}

	public float PlayLongHorn()
	{
		if (hornSource == null)
		{
			return -1f;
		}
		AudioClip audioClip = ((longHornClip != null) ? longHornClip : hornClip);
		if (audioClip == null)
		{
			return -1f;
		}
		hornSource.clip = audioClip;
		hornSource.volume = hornVolume;
		hornSource.Play();
		return audioClip.length;
	}

	public float GetHornClipLength()
	{
		if (!(hornClip != null))
		{
			return 0f;
		}
		return hornClip.length;
	}

	public float GetLongHornClipLength()
	{
		if (longHornClip != null)
		{
			return longHornClip.length;
		}
		if (hornClip != null)
		{
			return hornClip.length;
		}
		return 0f;
	}

	public void PlayEnterSound()
	{
		PlayRandomClip(enterClips);
	}

	public void PlayExitSound()
	{
		PlayRandomClip(exitClips);
	}

	private void PlayRandomClip(List<AudioClip> clips)
	{
		if (!(enterExitSource == null) && clips != null && clips.Count != 0)
		{
			AudioClip audioClip = clips[Random.Range(0, clips.Count)];
			if (!(audioClip == null))
			{
				enterExitSource.volume = enterExitVolume;
				enterExitSource.PlayOneShot(audioClip);
			}
		}
	}

	public void ForceIdleSnap()
	{
		if ((bool)engineOnSource && (bool)engineOffSource)
		{
			engineOnSource.volume = minimumVolume;
			engineOffSource.volume = maximumVolume;
			engineOnSource.pitch = minimumPitch;
			engineOffSource.pitch = minimumPitch;
		}
	}

	private void Update()
	{
		if (!Drivetrain || !engineOnSource || !engineOffSource)
		{
			return;
		}
		UpdateHandbrakeFriction();
		UpdateHandbrakeEngage();
		UpdateReverseBeep();
		if (!engineRunning)
		{
			SilenceEngine();
			return;
		}
		bool flag = false;
		if (Net != null)
		{
			if (!Net.HasDriverAll)
			{
				flag = true;
			}
			if (Net.IsControlLocked)
			{
				flag = true;
			}
		}
		if (flag)
		{
			ForceIdleSnap();
			return;
		}
		float num;
		float num2;
		float value;
		if (Net != null && !Net.isOwned)
		{
			num = Net.syncThrottleInput;
			num2 = Net.syncBrakeInput;
			value = Net.syncEngineRPM;
		}
		else
		{
			if (!InputProcessor)
			{
				return;
			}
			num = InputProcessor.inputs.throttleInput;
			num2 = InputProcessor.inputs.brakeInput;
			value = Drivetrain.currentEngineRPM;
		}
		bool flag2 = ((!(Net != null) || Net.isOwned) ? (Drivetrain.direction == 1) : (Net.syncDirection >= 0));
		float t = Mathf.Clamp01(flag2 ? num : num2);
		engineOnSource.volume = Mathf.Lerp(minimumVolume, maximumVolume, t);
		engineOffSource.volume = Mathf.Lerp(maximumVolume, 0f, t);
		float t2 = Mathf.InverseLerp(Drivetrain.minimumEngineRPM, Drivetrain.maximumEngineRPM, value);
		float pitch = Mathf.Lerp(minimumPitch, maximumPitch, t2);
		engineOnSource.pitch = pitch;
		engineOffSource.pitch = pitch;
	}

	private void UpdateHandbrakeFriction()
	{
		if (handbrakeFrictionSource == null)
		{
			return;
		}
		if (Net != null && Net.IsTravelActive)
		{
			if (handbrakeFrictionSource.isPlaying)
			{
				handbrakeFrictionSource.Stop();
			}
			handbrakeFrictionSource.volume = 0f;
			return;
		}
		float a;
		float num;
		float value;
		if (Net != null && !Net.isOwned)
		{
			a = Net.syncHandbrakeInput;
			num = Net.syncBrakeInput;
			value = Net.syncSpeed;
		}
		else
		{
			if (!InputProcessor)
			{
				handbrakeFrictionSource.volume = 0f;
				return;
			}
			a = InputProcessor.inputs.handbrakeInput;
			num = InputProcessor.inputs.brakeInput;
			value = Drivetrain.speed;
		}
		bool flag = ((!(Net != null) || Net.isOwned) ? (Drivetrain.direction == 1) : (Net.syncDirection >= 0));
		float b = 0f;
		if (flag && num >= brakeThresholdForFriction)
		{
			b = Mathf.InverseLerp(brakeThresholdForFriction, 1f, num);
		}
		float num2 = Mathf.Max(a, b);
		float num3 = Mathf.InverseLerp(frictionMinSpeed, frictionFullSpeed, value);
		float b2 = num2 * num3 * frictionMaxVolume;
		handbrakeFrictionSource.volume = Mathf.Lerp(handbrakeFrictionSource.volume, b2, Time.deltaTime * 10f);
		if (handbrakeFrictionSource.volume < 0.01f)
		{
			if (handbrakeFrictionSource.isPlaying)
			{
				handbrakeFrictionSource.Stop();
			}
		}
		else if (!handbrakeFrictionSource.isPlaying)
		{
			handbrakeFrictionSource.Play();
		}
	}

	private void UpdateHandbrakeEngage()
	{
		if (handbrakeEngageSource == null || handbrakeEngageClip == null)
		{
			return;
		}
		if (Net != null && Net.IsTravelActive)
		{
			wasHandbrakeEngaged = true;
			return;
		}
		if (Net != null && !Net.HasDriverAll)
		{
			wasHandbrakeEngaged = true;
			return;
		}
		float num;
		if (Net != null && !Net.isOwned)
		{
			num = Net.syncHandbrakeInput;
		}
		else
		{
			if (!InputProcessor)
			{
				return;
			}
			num = InputProcessor.inputs.handbrakeInput;
		}
		bool flag = num >= handbrakeEngageThreshold;
		if (flag && !wasHandbrakeEngaged)
		{
			handbrakeEngageSource.PlayOneShot(handbrakeEngageClip, handbrakeEngageVolume);
		}
		wasHandbrakeEngaged = flag;
	}

	private void UpdateReverseBeep()
	{
		if (!reverseBeepEnabled || reverseBeepSource == null || reverseBeepClip == null)
		{
			return;
		}
		if (!engineRunning || (Net != null && !Net.HasDriverAll))
		{
			_reverseBeepTimer = 0f;
			_isReversing = false;
			return;
		}
		float f;
		bool flag;
		if (Net != null && !Net.isOwned)
		{
			f = Net.syncSpeed;
			flag = Net.syncDirection >= 0;
		}
		else
		{
			f = Drivetrain.speed;
			flag = Drivetrain.direction == 1;
		}
		if (!flag && Mathf.Abs(f) > 1f)
		{
			_reverseBeepTimer += Time.deltaTime;
			if (!_isReversing || _reverseBeepTimer >= reverseBeepInterval)
			{
				reverseBeepSource.PlayOneShot(reverseBeepClip, reverseBeepVolume);
				_reverseBeepTimer = 0f;
			}
			_isReversing = true;
		}
		else
		{
			_reverseBeepTimer = 0f;
			_isReversing = false;
		}
	}
}
