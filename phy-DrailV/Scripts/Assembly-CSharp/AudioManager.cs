using System.Collections;
using System.Collections.Generic;
using DV.Utils;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : SingletonBehaviour<AudioManager>
{
	public enum SnapshotSpace
	{
		Outside = 0,
		Tunnel = 1,
		Underwater = 2,
		Indoors = 3,
		Depot = 4
	}

	private const int INTERNAL_SNAPSHOT = 0;

	private const int EXTERNAL_SNAPSHOT = 1;

	public AudioMixer mix;

	[Header("Collisions")]
	public AudioClip[] collisionClips;

	public AudioMixerGroup collisionGroup;

	[Tooltip("Volume per relative velocity")]
	public float collisionVolumePerSpeed = 0.25f;

	[Header("Joints")]
	public AudioClip[] junctionJointClips;

	public AnimationCurve junctionSpeedToVolumeCurve;

	public float jointSpeedMult = 0.01f;

	public LayeredAudio jointAudio;

	public AudioMixerGroup railJointGroup;

	[Header("Rolling wheel noise")]
	public AudioClip[] rollingNoiseClips;

	public float rollingSpeedMult = 0.015f;

	public float rollingRandomPitchMin = 0.9f;

	public float rollingRandomPitchMax = 1.1f;

	public LayeredAudio rollingAudioDetailed;

	public LayeredAudio rollingAudioSimple;

	public AudioMixerGroup railWheelGroup;

	[Header("Squeal")]
	public LayeredAudio squealAudioDetailed;

	public LayeredAudio squealAudioSimple;

	public float squealRandomPitchMin = 0.9f;

	public float squealRandomPitchMax = 1.1f;

	[Header("Airflow")]
	public float airflowMult = 1f;

	public float exhaustMult = 1f;

	[Header("Reverb")]
	public AnimationCurve reverbCurve;

	[Header("Coupler")]
	public AudioClip[] couplingClips;

	public AudioClip[] uncouplingClips;

	[Header("Wind")]
	public LayeredAudio windAudio;

	[Header("Derail")]
	public AudioMixerGroup derailGroup;

	public AudioClip derailHitClip;

	[Header("Switch")]
	public AudioMixerGroup switchGroup;

	public AudioClip[] switchClips;

	public AudioClip[] switchForcedClips;

	[Header("Cargo load unload")]
	public AudioClip cargoLoadUnload;

	private SnapshotSpace _snapshotSpace;

	[Header("Water")]
	public AudioClip waterSplashHeavyClip;

	public AudioClip waterSplashLightClip;

	public AudioClip waterSplashHumanClip;

	public AudioClip waterSplashSwimoutClip;

	public AudioClip waterSplashItemClip;

	public AudioClip underwaterClip;

	[Space]
	private float _internality;

	public float snapshotTransitionTime = 0.2f;

	public AudioMixerSnapshot outdoors;

	public AudioMixerSnapshot cab;

	public AudioMixerSnapshot indoors;

	public AudioMixerSnapshot tunnel;

	public AudioMixerSnapshot tunnelCab;

	public AudioMixerSnapshot underwater;

	public AudioMixerSnapshot depot;

	public AudioMixerSnapshot depotCab;

	public AudioMixerGroup cabGroup;

	private Coroutine coro;

	public Dictionary<AudioClip, float> debouncedSoundPlayTimes = new Dictionary<AudioClip, float>();

	private AudioMixerSnapshot[] snapshots = new AudioMixerSnapshot[2];

	private float[] weights = new float[2] { -1f, -1f };

	public SnapshotSpace Snapshot
	{
		get
		{
			return _snapshotSpace;
		}
		set
		{
			if (_snapshotSpace != value)
			{
				_snapshotSpace = value;
				if (coro == null)
				{
					coro = StartCoroutine(UpdateSnapshotCoroutine());
				}
			}
		}
	}

	public float Internality
	{
		get
		{
			return _internality;
		}
		set
		{
			value = Mathf.Clamp01(value);
			if (value != _internality)
			{
				_internality = value;
				if (coro == null)
				{
					coro = StartCoroutine(UpdateSnapshotCoroutine());
				}
			}
		}
	}

	public new static string AllowAutoCreate()
	{
		return null;
	}

	private void Start()
	{
		if (rollingAudioDetailed == null || rollingAudioSimple == null || squealAudioDetailed == null || squealAudioSimple == null)
		{
			Debug.LogWarning("No rolling and squeal sounds were set for wheels, bogies will not have any sound", this);
		}
		GamePreferences.RegisterToPreferenceUpdated(Preferences.MasterVolumeLevel, OnVolumePreferenceChanged);
		if (!DevSceneUtil.IsGameScene())
		{
			OnVolumePreferenceChanged();
		}
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		if (!UnloadWatcher.isQuitting)
		{
			GamePreferences.UnregisterFromPreferenceUpdated(Preferences.MasterVolumeLevel, OnVolumePreferenceChanged);
		}
	}

	private IEnumerator UpdateSnapshotCoroutine()
	{
		for (float timer = snapshotTransitionTime; timer > 0f; timer -= Time.deltaTime)
		{
			yield return null;
			if (UpdateSnapshot())
			{
				timer = snapshotTransitionTime;
			}
		}
		coro = null;
	}

	private void OnVolumePreferenceChanged()
	{
		AudioListener.volume = GetTargetVolumeForCurrentPreferenceValue();
	}

	public static float GetTargetVolumeForCurrentPreferenceValue()
	{
		return Mathf.Clamp01(GamePreferences.Get<float>(Preferences.MasterVolumeLevel));
	}

	private static void AddSpatializerToSources(Transform root)
	{
	}

	public static LayeredAudio InstantiateLayeredAudio(LayeredAudio layeredAudio, Transform pivot, bool randomizeTime = true, float pitchMultMin = 1f, float pitchMultMax = 1f)
	{
		LayeredAudio layeredAudio2 = Object.Instantiate(layeredAudio, pivot);
		layeredAudio2.transform.localPosition = Vector3.zero;
		layeredAudio2.transform.localRotation = Quaternion.identity;
		layeredAudio2.randomizeStartTime = randomizeTime;
		AddSpatializerToSources(layeredAudio2.transform);
		layeredAudio2.Reset();
		layeredAudio2.PitchMultiply(Random.Range(pitchMultMin, pitchMultMax));
		return layeredAudio2;
	}

	public void FadeToSnapshot(AudioMixerSnapshot snapshot)
	{
		AudioMixerSnapshot[] array = new AudioMixerSnapshot[1] { snapshot };
		float[] array2 = new float[1] { 1f };
		mix.TransitionToSnapshots(array, array2, 1f);
	}

	private bool UpdateSnapshot()
	{
		AudioMixerSnapshot audioMixerSnapshot = null;
		AudioMixerSnapshot audioMixerSnapshot2 = null;
		bool result = false;
		switch (Snapshot)
		{
		case SnapshotSpace.Outside:
			audioMixerSnapshot = cab;
			audioMixerSnapshot2 = outdoors;
			break;
		case SnapshotSpace.Tunnel:
			audioMixerSnapshot = tunnelCab;
			audioMixerSnapshot2 = tunnel;
			break;
		case SnapshotSpace.Underwater:
			audioMixerSnapshot = underwater;
			audioMixerSnapshot2 = underwater;
			break;
		case SnapshotSpace.Indoors:
			audioMixerSnapshot = cab;
			audioMixerSnapshot2 = indoors;
			break;
		case SnapshotSpace.Depot:
			audioMixerSnapshot = depotCab;
			audioMixerSnapshot2 = depot;
			break;
		}
		if (!audioMixerSnapshot || !audioMixerSnapshot2)
		{
			return false;
		}
		if (snapshots[0] != audioMixerSnapshot || snapshots[1] != audioMixerSnapshot2)
		{
			snapshots[0] = audioMixerSnapshot;
			snapshots[1] = audioMixerSnapshot2;
			result = true;
		}
		if (weights[0] != Internality)
		{
			weights[0] = Internality;
			weights[1] = 1f - Internality;
			result = true;
		}
		mix.TransitionToSnapshots(snapshots, weights, snapshotTransitionTime);
		return result;
	}
}
