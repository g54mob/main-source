using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class ThronefallAudioManager : MonoBehaviour
{
	public class OneshotSource
	{
		public AudioSource aSource;

		public bool available = true;

		public OneshotSource(AudioSource audioSource)
		{
			aSource = audioSource;
		}
	}

	public enum AudioOneShot
	{
		BuildingBuild = 0,
		BuildingUpgrade = 1,
		CoinslotFill = 2,
		CoinslotInteractionStart = 3,
		LastCoinslotFill = 4,
		CoinFillCancel = 5,
		NightSurvived = 6,
		BuildingRepair = 7,
		EismolochAppear = 8,
		EismolochSpawn = 9,
		ButtonSelect = 10,
		ButtonApply = 11,
		ButtonApplyHero = 12,
		CoinCollect = 13,
		BuildingStandardProjectile = 14,
		BallistaProjectile = 15,
		PlayerSwordBigHit = 16,
		EnemySpawn = 17,
		ShowWaveCount = 18,
		CloseWaveCount = 19,
		ShowTooltip = 20,
		None = 21,
		PlayerLightningWandActive = 22,
		PlayerTrapPlace = 23,
		PlayerTrapHit = 24,
		PlayerPotionHit = 25,
		PlayerPotionActive = 26,
		PlayerAxeActive = 27,
		BloodwandActive = 28
	}

	private static ThronefallAudioManager instance;

	public readonly float oneshotAudioPoolSize = 15f;

	public readonly float onshotAudioPoolRecycleTick = 0.3f;

	private float oneshotSourceRecycleClock;

	private List<OneshotSource> oneshotSourcePool = new List<OneshotSource>();

	private OneshotSource bufferOneshotSource;

	public AudioSet audioContent;

	public AudioMixerGroup mgMusic;

	public AudioMixerGroup mgSFX;

	public AudioMixerGroup mgEnvironment;

	[HideInInspector]
	public UnityEvent onBuildingBuild = new UnityEvent();

	private bool muted;

	private float coinslotFillPitch = 1f;

	private float coinslotFillPitchIncrease = 0.025f;

	private OneshotSource coinslotFillBackground;

	private float coinslotFillBackgroundClock;

	private float coinslotTotalFillTime = 1f;

	public static ThronefallAudioManager Instance => instance;

	private void Awake()
	{
		if (instance != null)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		instance = this;
		Object.DontDestroyOnLoad(base.gameObject);
		AudioSource audioSource = null;
		for (int i = 0; (float)i < oneshotAudioPoolSize; i++)
		{
			audioSource = new GameObject("Oneshot Source " + i).AddComponent<AudioSource>();
			audioSource.transform.SetParent(base.transform);
			audioSource.rolloffMode = AudioRolloffMode.Linear;
			audioSource.minDistance = 1f;
			audioSource.maxDistance = 80f;
			audioSource.spatialBlend = 0f;
			oneshotSourcePool.Add(new OneshotSource(audioSource));
		}
	}

	private void Update()
	{
		oneshotSourceRecycleClock += Time.unscaledDeltaTime;
		if (oneshotSourceRecycleClock > onshotAudioPoolRecycleTick)
		{
			RecycleOneshotSources();
		}
		if (coinslotFillBackground != null)
		{
			coinslotFillBackgroundClock += Time.deltaTime;
			coinslotFillBackground.aSource.pitch = Mathf.Lerp(0.75f, 1f, coinslotFillBackgroundClock / coinslotTotalFillTime);
		}
	}

	private void ProcessOneShotEvent(AudioOneShot oneshot, bool worldspace = false, Vector3 position = default(Vector3))
	{
		if (!muted)
		{
			switch (oneshot)
			{
			case AudioOneShot.CoinslotInteractionStart:
				coinslotFillPitch = 1f;
				PlaySoundAsOneShot(audioContent.CoinslotInteractionStart);
				StopCoinfillBackground();
				coinslotFillBackground = PlaySoundAsOneShot(audioContent.PayBackground, 0.2f, 0.75f);
				break;
			case AudioOneShot.CoinslotFill:
				PlaySoundAsOneShot(audioContent.CoinslotFill, 1f, coinslotFillPitch);
				coinslotFillPitch += coinslotFillPitchIncrease;
				break;
			case AudioOneShot.LastCoinslotFill:
				PlaySoundAsOneShot(audioContent.LastCoinslotFill);
				StopCoinfillBackground();
				break;
			case AudioOneShot.CoinFillCancel:
				StopCoinfillBackground();
				break;
			case AudioOneShot.BuildingBuild:
				onBuildingBuild.Invoke();
				PlaySoundAsOneShot(audioContent.BuildingBuild, 1f, Random.Range(0.9f, 1.1f));
				break;
			case AudioOneShot.BuildingUpgrade:
				PlaySoundAsOneShot(audioContent.BuildingUpgrade);
				break;
			case AudioOneShot.NightSurvived:
				PlaySoundAsOneShot(audioContent.NightSurvived, 0.8f, 1f, null, 0);
				break;
			case AudioOneShot.BuildingRepair:
				PlaySoundAsOneShot(audioContent.BuildingRepair);
				break;
			case AudioOneShot.EismolochAppear:
				PlaySoundAsOneShot(audioContent.EismolochAppear.clips[Random.Range(0, audioContent.EismolochAppear.clips.Length)]);
				break;
			case AudioOneShot.EismolochSpawn:
				PlaySoundAsOneShot(audioContent.EismolochSpawnUnits.clips[Random.Range(0, audioContent.EismolochSpawnUnits.clips.Length)], 1f, 1f, null, 0);
				break;
			case AudioOneShot.ButtonSelect:
				PlaySoundAsOneShot(audioContent.ButtonSelect.GetRandomClip());
				break;
			case AudioOneShot.ButtonApply:
				PlaySoundAsOneShot(audioContent.ButtonApply.GetRandomClip());
				break;
			case AudioOneShot.ButtonApplyHero:
				PlaySoundAsOneShot(audioContent.ButtonApplyHero.GetRandomClip());
				break;
			case AudioOneShot.CoinCollect:
				PlaySoundAsOneShot(audioContent.CoinCollect.GetRandomClip(), 1f, Random.Range(0.9f, 1.1f));
				break;
			case AudioOneShot.BuildingStandardProjectile:
				PlaySoundAsOneShot(audioContent.TowerShot.GetRandomClip(), 0.5f, Random.Range(0.95f, 1.05f), null, 50, worldspace: true, position);
				break;
			case AudioOneShot.BallistaProjectile:
				PlaySoundAsOneShot(audioContent.BallistaShot.GetRandomClip(), 1f, 1f, null, 30, worldspace: true, position);
				break;
			case AudioOneShot.PlayerSwordBigHit:
				PlaySoundAsOneShot(audioContent.PlayerSwordBigHit, 1f, 1f, null, 1);
				break;
			case AudioOneShot.EnemySpawn:
				PlaySoundAsOneShot(audioContent.EnemySpawn, 0.85f, Random.Range(0.95f, 1.05f), null, 140, worldspace: true, position);
				break;
			case AudioOneShot.ShowWaveCount:
				PlaySoundAsOneShot(audioContent.ShowWaveCount, 0.5f);
				break;
			case AudioOneShot.CloseWaveCount:
				PlaySoundAsOneShot(audioContent.CloseWaveCount);
				break;
			case AudioOneShot.ShowTooltip:
				PlaySoundAsOneShot(audioContent.ShowTooltip, 0.3f);
				break;
			case AudioOneShot.PlayerLightningWandActive:
				PlaySoundAsOneShot(audioContent.PlayerLightningWandActiveAbility, 0.6f, 1f, null, 1, worldspace: true, position);
				break;
			case AudioOneShot.PlayerTrapPlace:
				PlaySoundAsOneShot(audioContent.PlayerTrapPlace, 0.2f, Random.Range(0.95f, 1.05f), null, 1, worldspace: true, position);
				break;
			case AudioOneShot.PlayerTrapHit:
				PlaySoundAsOneShot(audioContent.PlayerTrapHit, 0.6f, Random.Range(0.95f, 1.05f), null, 1, worldspace: true, position);
				break;
			case AudioOneShot.PlayerPotionHit:
				PlaySoundAsOneShot(audioContent.PlayerPotionHit, 0.75f, Random.Range(0.95f, 1.05f), null, 1, worldspace: true, position);
				break;
			case AudioOneShot.PlayerPotionActive:
				PlaySoundAsOneShot(audioContent.PlayerPotionActive, 0.75f, Random.Range(0.95f, 1.05f), null, 1);
				break;
			case AudioOneShot.PlayerAxeActive:
				PlaySoundAsOneShot(audioContent.PlayerAxeActive, 0.7f, Random.Range(0.975f, 1.025f), null, 1);
				break;
			case AudioOneShot.BloodwandActive:
				PlaySoundAsOneShot(audioContent.PlayerBloodwandActive, 0.4f, Random.Range(0.975f, 1.025f), null, 1);
				break;
			case AudioOneShot.None:
				break;
			}
		}
	}

	public OneshotSource PlaySoundAsOneShot(AudioClip clip, float volume = 1f, float pitch = 1f, AudioMixerGroup mixerGroup = null, int priority = 128, bool worldspace = false, Vector3 position = default(Vector3))
	{
		if (mixerGroup == null)
		{
			mixerGroup = mgSFX;
		}
		bufferOneshotSource = GetFreeOneshotSource();
		if (bufferOneshotSource == null)
		{
			return null;
		}
		if (worldspace)
		{
			bufferOneshotSource.aSource.transform.position = position;
			bufferOneshotSource.aSource.spatialBlend = 1f;
		}
		else
		{
			bufferOneshotSource.aSource.spatialBlend = 0f;
		}
		bufferOneshotSource.aSource.volume = volume;
		bufferOneshotSource.aSource.pitch = pitch;
		bufferOneshotSource.aSource.outputAudioMixerGroup = mixerGroup;
		bufferOneshotSource.aSource.priority = priority;
		bufferOneshotSource.aSource.PlayOneShot(clip);
		bufferOneshotSource.available = false;
		return bufferOneshotSource;
	}

	public OneshotSource PlaySoundAsOneShot(AudioSet.ClipArray clips, float volume = 1f, float pitch = 1f, AudioMixerGroup mixerGroup = null, int priority = 128, bool worldspace = false, Vector3 position = default(Vector3))
	{
		if (clips == null)
		{
			return null;
		}
		if (clips.clips.Length == 0)
		{
			return null;
		}
		if (mixerGroup == null)
		{
			mixerGroup = mgSFX;
		}
		bufferOneshotSource = GetFreeOneshotSource();
		if (bufferOneshotSource == null)
		{
			return null;
		}
		if (worldspace)
		{
			bufferOneshotSource.aSource.transform.position = position;
			bufferOneshotSource.aSource.spatialBlend = 1f;
		}
		else
		{
			bufferOneshotSource.aSource.spatialBlend = 0f;
		}
		bufferOneshotSource.aSource.volume = volume;
		bufferOneshotSource.aSource.pitch = pitch;
		bufferOneshotSource.aSource.outputAudioMixerGroup = mixerGroup;
		bufferOneshotSource.aSource.priority = priority;
		bufferOneshotSource.aSource.PlayOneShot(clips.clips[Random.Range(0, clips.clips.Length)]);
		bufferOneshotSource.available = false;
		return bufferOneshotSource;
	}

	private OneshotSource GetFreeOneshotSource()
	{
		foreach (OneshotSource item in oneshotSourcePool)
		{
			if (item.available)
			{
				return item;
			}
		}
		return oneshotSourcePool[0];
	}

	private void RecycleOneshotSources()
	{
		foreach (OneshotSource item in oneshotSourcePool)
		{
			if (!item.aSource.isPlaying)
			{
				item.available = true;
			}
		}
		oneshotSourceRecycleClock = 0f;
	}

	private void StopCoinfillBackground()
	{
		if (coinslotFillBackground != null)
		{
			coinslotFillBackground.available = true;
			coinslotFillBackground.aSource.Stop();
			coinslotFillBackground = null;
			coinslotFillBackgroundClock = 0f;
		}
	}

	public void MakeSureCoinFillSoundIsNotPlayingAnymore()
	{
		StopCoinfillBackground();
	}

	public static void Oneshot(AudioOneShot oneshot)
	{
		if (instance != null)
		{
			instance.ProcessOneShotEvent(oneshot);
		}
		else
		{
			Debug.LogError("No Audio Manager");
		}
	}

	public static void WorldSpaceOneShot(AudioOneShot oneshot, Vector3 position)
	{
		if (instance != null)
		{
			instance.ProcessOneShotEvent(oneshot, worldspace: true, position);
		}
		else
		{
			Debug.LogError("No Audio Manager");
		}
	}

	public static void Mute()
	{
		instance.muted = true;
	}

	public static void Unmute()
	{
		instance.muted = false;
	}

	public static void SetCoinDisplayFillTime(float time)
	{
		instance.coinslotTotalFillTime = time;
	}
}
