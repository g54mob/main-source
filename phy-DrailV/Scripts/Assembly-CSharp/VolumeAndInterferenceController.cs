using System;
using DV;
using UnityEngine;

public class VolumeAndInterferenceController : MonoBehaviour
{
	public const float DEFAULT_VOLUME = 0.4f;

	public Action<float> SignalChanged;

	public Action<float> VolumeChanged;

	private const float INTERFERENCE_VOLUME_THRESHOLD = 0.01f;

	private const float INTERFERENCE_SIGNAL_THRESHOLD = 0.7f;

	private const string TUNNEL_NAME_END = "tunnel";

	private const string DEBUG_SIGNAL_BLOCKER_NAME = "signal blocker";

	private const float RECALCULATE_SIGNAL_DELAY = 1f;

	public AudioSource musicAudioSource;

	public AudioSource interferenceAudioSource;

	[Range(0f, 2f)]
	public float interferenceSoundVolumeMultiplier = 1f;

	public float signalSmoothTime = 0.3f;

	[Header("Signal blocking multipliers")]
	private const float ANTENNA_SIGNAL_BOOST_RETRACTED = 0.67f;

	private const float ANTENNA_SIGNAL_BOOST_EXTENDED = 1.33f;

	public Vector2 antennaBoostRange = new Vector2(0.67f, 1.33f);

	public float blockFactorTunnel = 0.9f;

	public float blockFactorTerrain = 0.8f;

	public float blockFactorOther = 0.45f;

	public float blockFactorDebug = 1f;

	private float volume;

	private float prevVolume = -1f;

	private bool useSignalLoss = true;

	private float signalSmoothVel;

	private int terrainLayer;

	private float signalStrength;

	private float antennaBoost = 0.67f;

	private ConeSampler sampler;

	private void Awake()
	{
		terrainLayer = LayerMask.NameToLayer("Terrain");
		GameObject gameObject = new GameObject("boombox signal sampler");
		gameObject.transform.SetParent(base.transform);
		gameObject.transform.localPosition = Vector3.up * 0.4f;
		gameObject.transform.LookAt(gameObject.transform.position + Vector3.up);
		sampler = gameObject.AddComponent<ConeSampler>();
		sampler.useCustomHitWeightFunction = true;
		sampler.weightFunction = GetSignalBlockingMultiplier;
		sampler.coneAngle = 85f;
		sampler.maxDistance = 10f;
		sampler.sampleLayers = LayerMask.GetMask("Terrain", "Default");
		sampler.timingMode = ConeSampler.TimingMode.OneSampleEveryNFrames;
		sampler.timingRate = 3;
		sampler.sampleBufferSize = 30;
		sampler.enabled = false;
		OnPowerAndModeChanged(isOn: false, isRadio: false);
		OnVolumeChanged(0.4f);
		OnSignalLossPreferenceUpdated();
		SetupListeners(on: true);
	}

	private void OnDestroy()
	{
		SetupListeners(on: false);
	}

	private void OnDisable()
	{
		if (!UnloadWatcher.isUnloading)
		{
			OnRadioStoppedPlaying();
		}
	}

	public float GetVolume()
	{
		return volume;
	}

	public float GetAntennaControlValue()
	{
		return Mathf.InverseLerp(antennaBoostRange.x, antennaBoostRange.y, antennaBoost);
	}

	public void OnPowerAndModeChanged(bool isOn, bool isRadio)
	{
		if (isOn && isRadio)
		{
			OnRadioStartedPlaying();
		}
		else
		{
			OnRadioStoppedPlaying();
		}
		base.enabled = isOn;
	}

	public void OnRadioStartedPlaying()
	{
		sampler.enabled = true;
		interferenceAudioSource.Play();
	}

	public void OnRadioStoppedPlaying()
	{
		sampler.enabled = false;
		interferenceAudioSource.Pause();
		signalStrength = 0f;
	}

	public void OnAntennaChanged(float antennaValue)
	{
		antennaBoost = Mathf.Lerp(antennaBoostRange.x, antennaBoostRange.y, antennaValue);
	}

	public void OnVolumeChanged(float volume)
	{
		this.volume = Mathf.Clamp01(volume);
		if (prevVolume != this.volume)
		{
			prevVolume = this.volume;
			VolumeChanged?.Invoke(this.volume);
		}
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			GamePreferences.RegisterToPreferenceUpdated(Preferences.RadioSignalLoss, OnSignalLossPreferenceUpdated);
		}
		else
		{
			GamePreferences.UnregisterFromPreferenceUpdated(Preferences.RadioSignalLoss, OnSignalLossPreferenceUpdated);
		}
	}

	private void OnSignalLossPreferenceUpdated()
	{
		useSignalLoss = GamePreferences.Get<bool>(Preferences.RadioSignalLoss);
	}

	private void Update()
	{
		if (TimeUtil.IsFlowing)
		{
			float num = (useSignalLoss ? Mathf.Clamp01(Mathf.Max(0f, 1f - sampler.average) * antennaBoost) : 1f);
			if (Mathf.Abs(num - signalStrength) > 0.001f)
			{
				signalStrength = Mathf.SmoothDamp(signalStrength, num, ref signalSmoothVel, signalSmoothTime);
				SignalChanged?.Invoke(signalStrength);
			}
			ApplySignalAndVolumeToAudio();
		}
	}

	private float GetSignalBlockingMultiplier(RaycastHit hit)
	{
		if (hit.collider.gameObject.layer == terrainLayer)
		{
			return blockFactorTerrain;
		}
		if (hit.collider.name.EndsWith("tunnel"))
		{
			return blockFactorTunnel;
		}
		if (hit.collider.name.ToLowerInvariant().Contains("signal blocker"))
		{
			return blockFactorDebug;
		}
		return blockFactorOther;
	}

	private void ApplySignalAndVolumeToAudio()
	{
		if (!interferenceAudioSource.isPlaying)
		{
			musicAudioSource.volume = volume;
			return;
		}
		float num = volume * signalStrength;
		float num2 = Mathf.Clamp01(volume * (1f - signalStrength / 0.7f) * interferenceSoundVolumeMultiplier);
		if (num2 < 0.01f)
		{
			num2 = 0f;
		}
		musicAudioSource.volume = num;
		interferenceAudioSource.volume = num2;
	}
}
