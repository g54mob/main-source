using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public static AudioManager Singleton;

	[Header("Sound Settings")]
	public float sfxVolume = 1f;

	public float musicVolume = 1f;

	public float ambientVolume = 1f;

	public float sfx_Volume_Base;

	public float music_Volume_Base;

	public float ambient_Volume_Base;

	public float duckedVolumeMult = 1f;

	[Header("Sound Bank")]
	[Header("Ambient")]
	[SerializeField]
	private AudioSource source_Ambient;

	private bool isAmbientSourceFadingUpVolume;

	private const float AMBIENTSOURCE_VOLUME_MULT = 0.75f;

	private bool ambient_IsPaused;

	public List<AudioClip> ambientTracks;

	[Header("SFX")]
	public List<AudioClip> sfx_BerrySpawnPops;

	public List<AudioClip> sfx_Footsteps;

	public List<AudioClip> sfx_Footsteps_HardSurface;

	public List<AudioClip> sfx_CoinPickUps;

	public List<AudioClip> sfx_CoinImpacts;

	public AudioClip sfx_BerryImpact;

	public List<AudioClip> sfx_MilestoneImpacts;

	public List<AudioClip> sfx_StarOrbShatter;

	public AudioClip sfx_StarOrbCollect;

	public AudioClip sfx_WallBreaking;

	public AudioClip sfx_FullVacuumDing;

	public AudioClip sfx_StarOrbSpawn;

	public AudioClip sfx_UI_ButtonOver;

	public AudioClip sfx_UI_ButtonClick;

	public AudioClip sfx_UI_UnlockUpgrade;

	public AudioClip sfx_UI_CannotAfford;

	public AudioClip sfx_LevelingCultist;

	public AudioClip sfx_LevelingCultist_Belladonna;

	public AudioClip sfx_CannotUpgradeCultist;

	public AudioClip sfx_PinataBreak;

	public AudioClip sfx_NightTimeHeavyLever;

	public AudioClip sfx_TimeAlmostOverWarning;

	public AudioClip sfx_VacuumAirBlast;

	public AudioClip sfx_HoleGrowthVictoryRiff;

	public AudioClip sfx_PopGun_Fire;

	public AudioClip sfx_PopGun_DartImpact;

	public AudioClip sfx_Puzzle_Progress;

	public AudioClip sfx_Puzzle_Negative;

	public AudioClip sfx_Puzzle_SlidingSwitch;

	public AudioClip sfx_BlackStarOrb_SpookyRiff;

	public AudioClip sfx_BlackStarPuzzle_Solve;

	public AudioClip sfx_GoldenIdolCompleted;

	public List<AudioClip> sfx_ChainSawRevs;

	public List<AudioClip> sfx_BerrySquishes;

	public AudioClip sfx_MouseClick;

	public AudioClip sfx_MsRainbowMoved;

	public List<AudioClip> sfx_CoinsDropping;

	public AudioClip sfx_SpookyGlitchedAlarm;

	public AudioClip sfx_TvBwomp;

	public AudioClip sfx_RisingScaryNoise;

	public AudioClip sfx_HatchOpen;

	public AudioClip sfx_ChainsawThud;

	public AudioClip sfx_DistortedScream;

	public AudioClip sfx_GnomeMeme;

	[Header("Music")]
	public GameObject radioObject;

	public static int RADIO_CHANNEL_COUNT = 7;

	public List<AudioClip> radioChannel_8Bit;

	public List<AudioClip> radioChannel_BigBand;

	public List<AudioClip> radioChannel_BossaNova;

	public List<AudioClip> radioChannel_Quirky;

	public List<AudioClip> radioChannel_Disco;

	public List<AudioClip> radioChannel_DnB;

	public List<AudioClip> radioChannel_Funk;

	public List<AudioClip> radioChannel_Unlockables;

	public List<List<AudioClip>> radioChannels_Master;

	[Header("Cultists SFX")]
	public List<AudioClip> cultistNoises_Normal;

	public List<AudioClip> cultistNoises_Negative;

	public List<AudioClip> cultistNoises_Toots;

	[Header("Source Banks")]
	[Header("Unimportant Sources")]
	public List<AudioSource> unimportantSources;

	public int unimportantSource_CurrIndex;

	[Header("Priority Sources")]
	public List<AudioSource> prioritySources;

	public int prioritySource_CurrIndex;

	[SerializeField]
	private AudioSource source_UI_Misc;

	[SerializeField]
	private AudioSource source_UI_ConfirmDeny;

	[SerializeField]
	private AudioSource source_ShopMusic;

	[SerializeField]
	private AudioSource source_CoinSpawner_IncreasingPitch;

	[SerializeField]
	private AudioClip sfx_CoinSpawned;

	private int coinSpawner_PitchLevel;

	private int coinSpawner_PitchLevel_Max = 80;

	private float coinSpawner_PitchPerLevel = 0.025f;

	private float coinSpawner_PitchTimer_Curr;

	private float coinSpawner_PitchTimer_Max = 3f;

	private float berryImpact_Buffer_Max = 0.05f;

	private float berryImpact_Buffer_Curr;

	private float defaultUnimportantSourceRange = 20f;

	private Coroutine ambientMusicCoRoutine;

	public Action AudioLevelsChanged_Action;

	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
		if (!Singleton)
		{
			Singleton = this;
			InitializeRadioChannelMasterList();
		}
		else
		{
			UnityEngine.Object.Destroy(this);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void Start()
	{
		LoadAudioLevels();
	}

	private void Update()
	{
		HandleBerryImpactBuffer();
		HandleCoinSpawnPitchLevelReset();
		HandleAmbientSourceVolumeFadeIn();
		if (source_Ambient.isPlaying && (bool)GameManager.Singleton && GameManager.Singleton.gameState != GameManager.GameState.Playing && GameManager.Singleton.gameState != GameManager.GameState.Cutscene)
		{
			source_Ambient.Pause();
			ambient_IsPaused = true;
		}
		sfxVolume = sfx_Volume_Base * duckedVolumeMult;
		musicVolume = music_Volume_Base * duckedVolumeMult;
		ambientVolume = ambient_Volume_Base;
		HandleAudioRoundingIssues();
	}

	private void InitializeRadioChannelMasterList()
	{
		radioChannels_Master = new List<List<AudioClip>>();
		radioChannels_Master.Add(radioChannel_8Bit);
		radioChannels_Master.Add(radioChannel_BigBand);
		radioChannels_Master.Add(radioChannel_BossaNova);
		radioChannels_Master.Add(radioChannel_Disco);
		radioChannels_Master.Add(radioChannel_DnB);
		radioChannels_Master.Add(radioChannel_Funk);
		radioChannels_Master.Add(radioChannel_Quirky);
	}

	public void LoadAudioLevels()
	{
		sfx_Volume_Base = PlayerPrefs.GetFloat("sfxVolume", 0.5f);
		music_Volume_Base = PlayerPrefs.GetFloat("musicVolume", 0.5f);
		ambient_Volume_Base = PlayerPrefs.GetFloat("ambientVolume", 0.5f);
		AudioLevelsChanged_Action?.Invoke();
	}

	public IEnumerator PlaySfxOnDelay(AudioSource _source, AudioClip _clip, float _waitTime, float _volumeMulti = 1f)
	{
		yield return new WaitForSeconds(_waitTime);
		_source.PlayOneShot(_clip, sfxVolume * _volumeMulti);
	}

	public void PlayUnimportantSFX(AudioClip _clip, Vector3 _pos, Vector2 _randoPitchRange, float _volMod = 1f, float _customRange = -1f, float _customFloor = -1f)
	{
		try
		{
			if (GameManager.Singleton.audioduck_BlipsAndBloops)
			{
				_volMod *= 0.1f;
			}
		}
		catch
		{
		}
		unimportantSources[unimportantSource_CurrIndex].transform.position = _pos;
		if (_customRange <= 0f)
		{
			unimportantSources[unimportantSource_CurrIndex].maxDistance = defaultUnimportantSourceRange;
		}
		else
		{
			unimportantSources[unimportantSource_CurrIndex].maxDistance = _customRange;
		}
		if (_customFloor <= 0f)
		{
			unimportantSources[unimportantSource_CurrIndex].minDistance = 1f;
		}
		else
		{
			unimportantSources[unimportantSource_CurrIndex].minDistance = _customFloor;
		}
		unimportantSources[unimportantSource_CurrIndex].pitch = UnityEngine.Random.Range(_randoPitchRange.x, _randoPitchRange.y);
		unimportantSources[unimportantSource_CurrIndex].PlayOneShot(_clip, sfxVolume * _volMod);
		unimportantSource_CurrIndex = (unimportantSource_CurrIndex + 1) % unimportantSources.Count;
	}

	public void PlayPrioritySFX(AudioClip _clip, Vector3 _pos, Vector2 _randoPitchRange, float _volMod = 1f, float _customRange = -1f, float _customFloor = -1f)
	{
		prioritySources[prioritySource_CurrIndex].transform.position = _pos;
		if (_customRange <= 0f)
		{
			prioritySources[prioritySource_CurrIndex].maxDistance = defaultUnimportantSourceRange;
		}
		else
		{
			prioritySources[prioritySource_CurrIndex].maxDistance = _customRange;
		}
		if (_customFloor <= 0f)
		{
			prioritySources[prioritySource_CurrIndex].minDistance = 1f;
		}
		else
		{
			prioritySources[prioritySource_CurrIndex].minDistance = _customFloor;
		}
		prioritySources[prioritySource_CurrIndex].pitch = UnityEngine.Random.Range(_randoPitchRange.x, _randoPitchRange.y);
		prioritySources[prioritySource_CurrIndex].PlayOneShot(_clip, sfxVolume * _volMod);
		prioritySource_CurrIndex = (prioritySource_CurrIndex + 1) % prioritySources.Count;
	}

	public void PlayBerryImpactSFX(Vector3 _pos)
	{
		if (!(berryImpact_Buffer_Curr > 0f))
		{
			PlayUnimportantSFX(sfx_BerryImpact, _pos, new Vector2(0.7f, 1f), 1f, 4f);
			berryImpact_Buffer_Curr = berryImpact_Buffer_Max;
		}
	}

	public void PlayCoinImpactSFX(Vector3 _pos)
	{
		PlayUnimportantSFX(sfx_CoinImpacts[UnityEngine.Random.Range(0, sfx_CoinImpacts.Count)], _pos, new Vector2(-0.88f, 1.12f), 0.7f, 4f);
	}

	public void PlayCoinPickUpSFX(Vector3 _pos)
	{
		PlayUnimportantSFX(sfx_CoinPickUps[UnityEngine.Random.Range(0, sfx_CoinPickUps.Count)], _pos, new Vector2(0.9f, 1.1f), 2.5f, 7f);
	}

	public void PlayMilestoneImpactSFX(Vector3 _pos, float _additionalVolumeMult)
	{
		PlayUnimportantSFX(sfx_MilestoneImpacts[UnityEngine.Random.Range(0, sfx_MilestoneImpacts.Count)], _pos, new Vector2(0.95f, 1.1f), _additionalVolumeMult, 8f);
	}

	public void PlayBerrySpawnPopSFX(Vector3 _pos)
	{
		PlayUnimportantSFX(sfx_BerrySpawnPops[UnityEngine.Random.Range(0, sfx_BerrySpawnPops.Count)], _pos, new Vector2(0.98f, 1.15f), 1f, 4f);
	}

	public void PlayStarOrbShatterSFX(Vector3 _pos)
	{
		PlayUnimportantSFX(sfx_StarOrbShatter[UnityEngine.Random.Range(0, sfx_StarOrbShatter.Count)], _pos, new Vector2(0.85f, 1.05f), 0.85f, 6f, 3f);
	}

	public void PlayStarOrbCollectSFX(Vector3 _pos)
	{
		PlayUnimportantSFX(sfx_StarOrbCollect, _pos, new Vector2(0.95f, 1f), 1f, 25f, 8f);
	}

	public void PlayWallBreakingSFX(Vector3 _pos)
	{
		PlayPrioritySFX(sfx_WallBreaking, _pos, new Vector2(0.9f, 1.1f), 0.85f, 200f, 10f);
	}

	public void PlayVacuumFullDing(Vector3 _pos)
	{
		PlayPrioritySFX(sfx_FullVacuumDing, _pos, new Vector2(1f, 1f), 0.4f, 5f, 5f);
	}

	public void PlayStarPipeSpawnOrbSFX(Vector3 _pos)
	{
		PlayPrioritySFX(sfx_StarOrbSpawn, _pos, new Vector2(0.8f, 1.5f), 1f, 25f, 3f);
	}

	public void PlayUiSFX_ButtonOver()
	{
		source_UI_Misc.PlayOneShot(sfx_UI_ButtonOver, sfxVolume * 0.8f);
	}

	public void PlayUiSFX_Click()
	{
		source_UI_Misc.PlayOneShot(sfx_UI_ButtonClick, sfxVolume);
	}

	public void PlayUiSFX_UnlockUpgrade()
	{
		source_UI_ConfirmDeny.pitch = UnityEngine.Random.Range(0.95f, 1.05f);
		source_UI_ConfirmDeny.PlayOneShot(sfx_UI_UnlockUpgrade, sfxVolume * 0.6f);
	}

	public void PlayUiSFX_CannotAfford()
	{
		source_UI_ConfirmDeny.pitch = UnityEngine.Random.Range(0.95f, 1f);
		source_UI_ConfirmDeny.PlayOneShot(sfx_UI_CannotAfford, sfxVolume * 0.8f);
	}

	public void PlayNightTimeHeavyLeverSFX()
	{
		source_UI_Misc.PlayOneShot(sfx_NightTimeHeavyLever, sfxVolume * 0.75f);
	}

	public void PlayPuzzleSFX_Progress()
	{
		source_UI_Misc.PlayOneShot(sfx_Puzzle_Progress, sfxVolume * 0.6f);
	}

	public void PlayPuzzleSFX_Negative()
	{
		source_UI_Misc.PlayOneShot(sfx_Puzzle_Negative, sfxVolume * 0.6f);
	}

	public void PlayBlackStarPuzzle_Solved()
	{
		source_UI_Misc.PlayOneShot(sfx_BlackStarPuzzle_Solve, sfxVolume * 0.7f);
	}

	public void PlaySFX_BlackStarOrbSpookyRiff()
	{
		source_UI_Misc.PlayOneShot(sfx_BlackStarOrb_SpookyRiff, sfxVolume * 0.75f);
	}

	public void PlaySFX_GoldenIdolCompleted()
	{
		source_UI_Misc.PlayOneShot(sfx_GoldenIdolCompleted, sfxVolume * 0.8f);
	}

	public void PlayUpgradeCultistSFX(Vector3 _pos, bool _belladonna)
	{
		AudioClip clip = (_belladonna ? sfx_LevelingCultist_Belladonna : sfx_LevelingCultist);
		PlayPrioritySFX(clip, _pos, new Vector2(0.95f, 1.05f), 1f, 25f, 2f);
	}

	public void PlayCannotUpgradeCultistSFX(Vector3 _pos)
	{
		PlayPrioritySFX(sfx_CannotUpgradeCultist, _pos, new Vector2(0.95f, 1.05f), 0.65f, 10f, 2f);
	}

	public void PlayPinataBreakSFX(Vector3 _pos)
	{
		PlayUnimportantSFX(sfx_PinataBreak, _pos, new Vector2(0.95f, 1.05f), 1f, 30f, 10f);
	}

	public void PlaySFX_TimeAlmostUpWarning()
	{
		source_UI_ConfirmDeny.pitch = 1f;
		source_UI_ConfirmDeny.PlayOneShot(sfx_TimeAlmostOverWarning, sfxVolume * 1.75f);
	}

	public void PlaySFX_VacuumAirBlast(Vector3 _pos)
	{
		PlayPrioritySFX(sfx_VacuumAirBlast, _pos, new Vector2(0.95f, 1.05f), 1f, 5f, 1f);
	}

	public void PlaySFX_HoleGrowthVictoryRiff()
	{
		source_UI_ConfirmDeny.pitch = 1f;
		source_UI_ConfirmDeny.PlayOneShot(sfx_HoleGrowthVictoryRiff, sfxVolume * 1f);
	}

	public void PlaySFX_PopGun_Fire(Vector3 _pos)
	{
		PlayPrioritySFX(sfx_PopGun_Fire, _pos, new Vector2(1.15f, 1.25f), 0.8f, 5f, 1f);
	}

	public void PlaySFX_PopGun_DartImpact(Vector3 _pos)
	{
		PlayUnimportantSFX(sfx_PopGun_DartImpact, _pos, new Vector2(0.95f, 1.05f), 1f, 5f, 1f);
	}

	public void PlaySFX_ChainSawRev(Vector3 _pos)
	{
		PlayPrioritySFX(sfx_ChainSawRevs[UnityEngine.Random.Range(0, sfx_ChainSawRevs.Count)], _pos, new Vector2(0.95f, 1.05f), 1f, 15f, 3f);
	}

	public void PlaySFX_BerrySquish(Vector3 _pos)
	{
		PlayUnimportantSFX(sfx_BerrySquishes[UnityEngine.Random.Range(0, sfx_BerrySquishes.Count)], _pos, new Vector2(0.5f, 1f), 0.8f, 15f, 3f);
	}

	public void PlaySFX_MsRainbowMoveJitter(Vector3 _pos, float _VolumeMult = 1f)
	{
		PlayPrioritySFX(sfx_MsRainbowMoved, _pos, new Vector2(0.95f, 1.05f), 2f * _VolumeMult, 100f, 100f);
	}

	public void PlaySFX_GlitchedAlarm(float _volumeMult = 1f)
	{
		source_UI_Misc.pitch = 1f;
		source_UI_Misc.PlayOneShot(sfx_SpookyGlitchedAlarm, sfxVolume * _volumeMult);
	}

	public void PlaySFX_MouseClick()
	{
		source_UI_Misc.pitch = 1f;
		source_UI_Misc.PlayOneShot(sfx_MouseClick, sfxVolume * 1f);
	}

	private void HandleBerryImpactBuffer()
	{
		if (berryImpact_Buffer_Curr > 0f)
		{
			berryImpact_Buffer_Curr -= Time.deltaTime;
		}
	}

	public void PlaySFX_TvBwomp(Vector3 _pos)
	{
		PlayPrioritySFX(sfx_TvBwomp, _pos, new Vector2(0.95f, 1.05f), 1f, 30f, 30f);
	}

	public void PlaySFX_RisingSpookyShrillNoise(float _delay)
	{
		StartCoroutine(PlaySFX_RisingSpookyShrillNoise_Coroutine(_delay));
	}

	private IEnumerator PlaySFX_RisingSpookyShrillNoise_Coroutine(float _delay)
	{
		yield return new WaitForSeconds(_delay);
		source_UI_Misc.pitch = 1f;
		source_UI_Misc.PlayOneShot(sfx_RisingScaryNoise, sfxVolume * 1f);
	}

	public void PlaySFX_HatchOpen(Vector3 _pos)
	{
		PlayPrioritySFX(sfx_HatchOpen, _pos, new Vector2(1f, 1f), 1f, 30f, 30f);
	}

	public void PlaySFX_ChainsawThud(Vector3 _pos)
	{
		PlayPrioritySFX(sfx_ChainsawThud, _pos, new Vector2(1f, 1f), 1f, 30f, 30f);
	}

	public void PlaySFX_DistortedScream()
	{
		source_UI_Misc.pitch = 1f;
		source_UI_Misc.PlayOneShot(sfx_DistortedScream, sfxVolume * 1f);
	}

	public void PlayGnomeMemeSFX(Vector3 _pos)
	{
		PlayUnimportantSFX(sfx_GnomeMeme, _pos, new Vector2(0.98f, 1.1f), 1f, 4f);
	}

	public void PlayAmbientTrack(int _track, float _delay, bool _fadeIn, float _volMult = 1f)
	{
		try
		{
			if (ambientMusicCoRoutine != null)
			{
				StopCoroutine(ambientMusicCoRoutine);
			}
			StartCoroutine(WaitForDelayAndThenPlayAmbientTrack(_track, _delay, _fadeIn, _volMult));
			if (_fadeIn)
			{
				source_Ambient.volume = 0f;
			}
		}
		catch
		{
			Debug.Log("Failed to play Ambient Track. Ignoring!");
		}
	}

	public void PauseAmbientTrack()
	{
		source_Ambient.Pause();
	}

	public void UnPauseAmbientTrack()
	{
		source_Ambient.Play();
	}

	public void StopAmbientMusic()
	{
		source_Ambient.Stop();
	}

	private IEnumerator WaitForDelayAndThenPlayAmbientTrack(int _track, float _delay, bool _fadeIn, float _volMult = 1f)
	{
		yield return new WaitForSeconds(_delay);
		if ((bool)MainMenuManager.Singleton || GameManager.Singleton.gameState == GameManager.GameState.Playing || GameManager.Singleton.gameState == GameManager.GameState.Cutscene)
		{
			if (_fadeIn && ambient_Volume_Base < 0.05f)
			{
				_fadeIn = false;
			}
			if (_fadeIn)
			{
				source_Ambient.volume = 0f;
				isAmbientSourceFadingUpVolume = true;
			}
			else
			{
				source_Ambient.volume = ambientVolume * 0.75f * _volMult;
			}
			if (source_Ambient.clip != ambientTracks[_track])
			{
				source_Ambient.clip = ambientTracks[_track];
				source_Ambient.Play();
			}
			else if (ambient_IsPaused)
			{
				source_Ambient.UnPause();
			}
			else
			{
				source_Ambient.Play();
			}
		}
	}

	private void HandleAmbientSourceVolumeFadeIn()
	{
		if (isAmbientSourceFadingUpVolume)
		{
			if (source_Ambient.volume < 0.75f)
			{
				source_Ambient.volume += Time.deltaTime * 0.4f;
			}
			if (source_Ambient.volume >= 0.75f)
			{
				source_Ambient.volume = 0.75f;
				isAmbientSourceFadingUpVolume = false;
			}
		}
	}

	public void QuietDownAmbientPlayer(float _mult)
	{
		source_Ambient.volume = ambientVolume * 0.75f * _mult;
	}

	public void ResetQuietedAmbientPlayer()
	{
		source_Ambient.volume = ambientVolume * 0.75f;
	}

	public void PlayShopMusic()
	{
		source_ShopMusic.volume = musicVolume;
		source_ShopMusic.Play();
	}

	public void StopShopMusic()
	{
		source_ShopMusic.Stop();
	}

	public void PlayCoinSpawnSFX(Vector3 _pos)
	{
		source_CoinSpawner_IncreasingPitch.gameObject.transform.position = _pos;
		source_CoinSpawner_IncreasingPitch.pitch = 0.5f + (float)coinSpawner_PitchLevel * coinSpawner_PitchPerLevel;
		try
		{
			if (!GameManager.Singleton.audioduck_BlipsAndBloops)
			{
				source_CoinSpawner_IncreasingPitch.PlayOneShot(sfx_CoinSpawned, sfxVolume * 0.8f);
			}
		}
		catch
		{
		}
		coinSpawner_PitchLevel = Mathf.Clamp(coinSpawner_PitchLevel + 1, 0, coinSpawner_PitchLevel_Max);
		coinSpawner_PitchTimer_Curr = coinSpawner_PitchTimer_Max;
	}

	private void HandleCoinSpawnPitchLevelReset()
	{
		if (coinSpawner_PitchTimer_Curr > 0f)
		{
			coinSpawner_PitchTimer_Curr -= Time.deltaTime;
			if (coinSpawner_PitchTimer_Curr <= 0f)
			{
				coinSpawner_PitchLevel = 0;
			}
		}
	}

	public void PlayStarRoomAmbience()
	{
		PlayAmbientTrack(6, 2.5f, _fadeIn: true);
	}

	public void PlayCoinDummyDroppingSequence(Vector3 _pos, float _VolumeMult = 1f)
	{
		PlayPrioritySFX(sfx_CoinsDropping[0], _pos, new Vector2(0.95f, 1.05f), _VolumeMult, 100f, 100f);
		PlayPrioritySFX(sfx_CoinsDropping[1], _pos, new Vector2(0.95f, 1.05f), _VolumeMult, 100f, 100f);
	}

	public void ResetDuckedVolume()
	{
		duckedVolumeMult = 1f;
	}

	public void SetDuckedVolume(float _val)
	{
		duckedVolumeMult = _val;
	}

	private void HandleAudioRoundingIssues()
	{
		if (music_Volume_Base < 0.05f)
		{
			music_Volume_Base = 0f;
			musicVolume = 0f;
		}
		if (sfx_Volume_Base < 0.05f)
		{
			sfx_Volume_Base = 0f;
			sfxVolume = 0f;
		}
		if (ambient_Volume_Base < 0.05f)
		{
			ambient_Volume_Base = 0f;
			ambientVolume = 0f;
		}
	}
}
