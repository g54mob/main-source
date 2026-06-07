using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class CassettesManager : MonoBehaviour
{
	public static CassettesManager Singleton;

	public const float DUCKEDVOLUMEMULT_WHENPLAYINGCASSETTE = 0.08f;

	public bool tapeIsPlaying;

	public int lastTapeindexPlayed;

	private AudioSource currentPlayingAudioSource;

	[Header("Audio Sources")]
	[SerializeField]
	private List<AudioSource> cassette_AudioSources;

	[Header("Tape States")]
	public bool tapeCollected_1;

	public bool tapeCollected_2;

	public bool tapeCollected_3;

	public bool tapeCollected_4;

	public bool tapeCollected_5;

	public bool tapeCollected_6;

	public bool tapeCollected_7;

	public bool tapeCollected_8;

	public bool tapeCollected_9;

	public bool tapeCollected_10;

	public bool tapeCollected_11;

	public bool tapeCollected_12;

	public bool tapeCollected_13;

	[Header("Collected Usables")]
	[SerializeField]
	private GameObject tapeUsable_Collected_01;

	[SerializeField]
	private GameObject tapeUsable_Collected_02;

	[SerializeField]
	private GameObject tapeUsable_Collected_03;

	[SerializeField]
	private GameObject tapeUsable_Collected_04;

	[SerializeField]
	private GameObject tapeUsable_Collected_05;

	[SerializeField]
	private GameObject tapeUsable_Collected_06;

	[SerializeField]
	private GameObject tapeUsable_Collected_07;

	[SerializeField]
	private GameObject tapeUsable_Collected_08;

	[SerializeField]
	private GameObject tapeUsable_Collected_09;

	[SerializeField]
	private GameObject tapeUsable_Collected_10;

	[SerializeField]
	private GameObject tapeUsable_Collected_11;

	[SerializeField]
	private GameObject tapeUsable_Collected_12;

	[SerializeField]
	private GameObject tapeUsable_Collected_13;

	[Header("InWorld Usables")]
	[SerializeField]
	private GameObject tapeUsable_InWorld_01;

	[SerializeField]
	private GameObject tapeUsable_InWorld_02;

	[SerializeField]
	private GameObject tapeUsable_InWorld_03;

	[SerializeField]
	private GameObject tapeUsable_InWorld_04;

	[SerializeField]
	private GameObject tapeUsable_InWorld_05;

	[SerializeField]
	private GameObject tapeUsable_InWorld_06;

	[SerializeField]
	private GameObject tapeUsable_InWorld_07;

	[SerializeField]
	private GameObject tapeUsable_InWorld_08;

	[SerializeField]
	private GameObject tapeUsable_InWorld_09;

	[SerializeField]
	private GameObject tapeUsable_InWorld_10;

	[SerializeField]
	private GameObject tapeUsable_InWorld_11;

	[SerializeField]
	private GameObject tapeUsable_InWorld_12;

	[SerializeField]
	private GameObject tapeUsable_InWorld_13;

	[Header("Ghosts")]
	[SerializeField]
	private List<GameObject> cassetteGhosts;

	[Header("Misc")]
	[SerializeField]
	private GameObject lastTapeParticles;

	private void Awake()
	{
		if ((bool)Singleton)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			Singleton = this;
		}
	}

	private void Start()
	{
		GameManager singleton = GameManager.Singleton;
		singleton.OnRoundStart_Action = (Action)Delegate.Combine(singleton.OnRoundStart_Action, new Action(OnRoundStart));
		PuzzleManager singleton2 = PuzzleManager.Singleton;
		singleton2.Action_BlackStars_OnChanged = (Action)Delegate.Combine(singleton2.Action_BlackStars_OnChanged, new Action(CheckCassetteRequirements));
		tapeUsable_InWorld_13.SetActive(value: false);
	}

	private void OnDestroy()
	{
		GameManager singleton = GameManager.Singleton;
		singleton.OnRoundStart_Action = (Action)Delegate.Remove(singleton.OnRoundStart_Action, new Action(OnRoundStart));
		PuzzleManager singleton2 = PuzzleManager.Singleton;
		singleton2.Action_BlackStars_OnChanged = (Action)Delegate.Remove(singleton2.Action_BlackStars_OnChanged, new Action(CheckCassetteRequirements));
	}

	private void OnRoundStart()
	{
		CheckCassetteRequirements();
		CassetteAchievementChecks();
	}

	private void Update()
	{
		if (tapeIsPlaying)
		{
			if (!currentPlayingAudioSource.isPlaying)
			{
				tapeIsPlaying = false;
				AudioManager.Singleton.ResetQuietedAmbientPlayer();
				AudioManager.Singleton.ResetDuckedVolume();
				if (cassette_AudioSources.IndexOf(currentPlayingAudioSource) == 12)
				{
					SetWeHaveListenedToTheConfession();
				}
				CassetteAchievementChecks();
			}
		}
		else if (lastTapeindexPlayed == 13 && !PlayerStats.Singleton.hasListenedToConfession)
		{
			SetWeHaveListenedToTheConfession();
		}
		HandleParticlesOnLastTape();
	}

	private void SetWeHaveListenedToTheConfession()
	{
		GameManager.Singleton.HideAllAdditionalMsRainbowPoses();
		PlayerStats.Singleton.hasListenedToConfession = true;
		PcManager.Singleton.disk_Burned.SetActive(value: true);
		PcManager.Singleton.burned_MsRainbow.SetActive(value: true);
		AudioManager.Singleton.PlaySFX_MsRainbowMoveJitter(PcManager.Singleton.burned_MsRainbow.transform.position);
		VcrIntroManager.Singleton.StartGlitchedOutBlackStarOrbEffect(3f);
	}

	public void PlayCassette(int _index)
	{
		StopAllTapes();
		cassette_AudioSources[_index - 1].Play();
		AudioManager.Singleton.QuietDownAmbientPlayer(0.08f);
		AudioManager.Singleton.SetDuckedVolume(0.08f);
		tapeIsPlaying = true;
		currentPlayingAudioSource = cassette_AudioSources[_index - 1];
		lastTapeindexPlayed = _index;
	}

	public void StopAllTapes()
	{
		bool flag = false;
		foreach (AudioSource cassette_AudioSource in cassette_AudioSources)
		{
			if (cassette_AudioSource.isPlaying)
			{
				flag = true;
				cassette_AudioSource.Stop();
			}
		}
		if (flag)
		{
			AudioManager.Singleton.ResetQuietedAmbientPlayer();
			AudioManager.Singleton.ResetDuckedVolume();
		}
		if (lastTapeindexPlayed == 13 && !PlayerStats.Singleton.hasListenedToConfession)
		{
			SetWeHaveListenedToTheConfession();
		}
	}

	public void PickedUpTape(int _index)
	{
		switch (_index)
		{
		case 1:
			tapeCollected_1 = true;
			break;
		case 2:
			tapeCollected_2 = true;
			break;
		case 3:
			tapeCollected_3 = true;
			break;
		case 4:
			tapeCollected_4 = true;
			break;
		case 5:
			tapeCollected_5 = true;
			break;
		case 6:
			tapeCollected_6 = true;
			break;
		case 7:
			tapeCollected_7 = true;
			break;
		case 8:
			tapeCollected_8 = true;
			break;
		case 9:
			tapeCollected_9 = true;
			break;
		case 10:
			tapeCollected_10 = true;
			break;
		case 11:
			tapeCollected_11 = true;
			break;
		case 12:
			tapeCollected_12 = true;
			break;
		case 13:
			tapeCollected_13 = true;
			break;
		}
		CheckCassetteRequirements();
		try
		{
			if (LocalizationSettings.SelectedLocale.Identifier.Code != "en")
			{
				AudioManager.Singleton.PlayPuzzleSFX_Progress();
			}
			else
			{
				PlayCassette(_index);
			}
		}
		catch
		{
			Debug.Log("Failed to play Cassette. check index?");
		}
	}

	public void CheckCassetteRequirements()
	{
		Debug.Log("CHECKING CASSETTE REQUIREMENTS!");
		if (tapeCollected_1)
		{
			tapeUsable_Collected_01.gameObject.SetActive(value: true);
			tapeUsable_InWorld_01.gameObject.SetActive(value: false);
			cassetteGhosts[1].SetActive(value: false);
		}
		else
		{
			tapeUsable_Collected_01.gameObject.SetActive(value: false);
			tapeUsable_InWorld_01.gameObject.SetActive(value: true);
			cassetteGhosts[1].SetActive(value: true);
		}
		if (tapeCollected_2)
		{
			tapeUsable_Collected_02.gameObject.SetActive(value: true);
			tapeUsable_InWorld_02.gameObject.SetActive(value: false);
			cassetteGhosts[2].SetActive(value: false);
		}
		else
		{
			tapeUsable_Collected_02.gameObject.SetActive(value: false);
			cassetteGhosts[2].SetActive(value: true);
			if (PuzzleManager.Singleton.blackStarPuzzleScripts[2].puzzleCompleted)
			{
				tapeUsable_InWorld_02.gameObject.SetActive(value: true);
			}
			else
			{
				tapeUsable_InWorld_02.gameObject.SetActive(value: false);
			}
		}
		if (tapeCollected_3)
		{
			tapeUsable_Collected_03.gameObject.SetActive(value: true);
			tapeUsable_InWorld_03.gameObject.SetActive(value: false);
			cassetteGhosts[3].SetActive(value: false);
		}
		else
		{
			tapeUsable_Collected_03.gameObject.SetActive(value: false);
			tapeUsable_InWorld_03.gameObject.SetActive(value: true);
			cassetteGhosts[3].SetActive(value: true);
		}
		if (tapeCollected_4)
		{
			tapeUsable_Collected_04.gameObject.SetActive(value: true);
			tapeUsable_InWorld_04.gameObject.SetActive(value: false);
			cassetteGhosts[4].SetActive(value: false);
		}
		else
		{
			tapeUsable_Collected_04.gameObject.SetActive(value: false);
			tapeUsable_InWorld_04.gameObject.SetActive(value: true);
			cassetteGhosts[4].SetActive(value: true);
		}
		if (tapeCollected_5)
		{
			tapeUsable_Collected_05.gameObject.SetActive(value: true);
			tapeUsable_InWorld_05.gameObject.SetActive(value: false);
			cassetteGhosts[5].SetActive(value: false);
		}
		else
		{
			tapeUsable_Collected_05.gameObject.SetActive(value: false);
			cassetteGhosts[5].SetActive(value: true);
			if (PuzzleManager.Singleton.blackStarPuzzleScripts[3].puzzleCompleted && PuzzleManager.Singleton.blackStarPuzzleScripts[4].puzzleCompleted)
			{
				tapeUsable_InWorld_05.gameObject.SetActive(value: true);
			}
			else
			{
				tapeUsable_InWorld_05.gameObject.SetActive(value: false);
			}
		}
		if (tapeCollected_6)
		{
			tapeUsable_Collected_06.gameObject.SetActive(value: true);
			tapeUsable_InWorld_06.gameObject.SetActive(value: false);
			cassetteGhosts[6].SetActive(value: false);
		}
		else
		{
			tapeUsable_Collected_06.gameObject.SetActive(value: false);
			cassetteGhosts[6].SetActive(value: true);
			if (PuzzleManager.Singleton.blackStarPuzzleScripts[4].puzzleCompleted)
			{
				tapeUsable_InWorld_06.gameObject.SetActive(value: true);
			}
			else
			{
				tapeUsable_InWorld_06.gameObject.SetActive(value: false);
			}
		}
		if (tapeCollected_7)
		{
			tapeUsable_Collected_07.gameObject.SetActive(value: true);
			tapeUsable_InWorld_07.gameObject.SetActive(value: false);
			cassetteGhosts[7].SetActive(value: false);
		}
		else
		{
			tapeUsable_Collected_07.gameObject.SetActive(value: false);
			cassetteGhosts[7].SetActive(value: true);
			if (PuzzleManager.Singleton.blackStarPuzzleScripts[1].puzzleCompleted)
			{
				tapeUsable_InWorld_07.gameObject.SetActive(value: true);
			}
			else
			{
				tapeUsable_InWorld_07.gameObject.SetActive(value: false);
			}
		}
		if (tapeCollected_8)
		{
			tapeUsable_Collected_08.gameObject.SetActive(value: true);
			tapeUsable_InWorld_08.gameObject.SetActive(value: false);
			cassetteGhosts[8].SetActive(value: false);
		}
		else
		{
			tapeUsable_Collected_08.gameObject.SetActive(value: false);
			cassetteGhosts[8].SetActive(value: true);
			if (PuzzleManager.Singleton.blackStarPuzzleScripts[6].puzzleCompleted)
			{
				tapeUsable_InWorld_08.gameObject.SetActive(value: true);
			}
			else
			{
				tapeUsable_InWorld_08.gameObject.SetActive(value: false);
			}
		}
		if (tapeCollected_9)
		{
			tapeUsable_Collected_09.gameObject.SetActive(value: true);
			tapeUsable_InWorld_09.gameObject.SetActive(value: false);
			cassetteGhosts[9].SetActive(value: false);
		}
		else
		{
			tapeUsable_Collected_09.gameObject.SetActive(value: false);
			cassetteGhosts[9].SetActive(value: true);
			if (PuzzleManager.Singleton.blackStarPuzzleScripts[2].puzzleCompleted)
			{
				tapeUsable_InWorld_09.gameObject.SetActive(value: true);
			}
			else
			{
				tapeUsable_InWorld_09.gameObject.SetActive(value: false);
			}
		}
		if (tapeCollected_10)
		{
			tapeUsable_Collected_10.gameObject.SetActive(value: true);
			tapeUsable_InWorld_10.gameObject.SetActive(value: false);
			cassetteGhosts[10].SetActive(value: false);
		}
		else
		{
			tapeUsable_Collected_10.gameObject.SetActive(value: false);
			cassetteGhosts[10].SetActive(value: true);
			if (PuzzleManager.Singleton.blackStarPuzzleScripts[5].puzzleCompleted)
			{
				tapeUsable_InWorld_10.gameObject.SetActive(value: true);
			}
			else
			{
				tapeUsable_InWorld_10.gameObject.SetActive(value: false);
			}
		}
		if (tapeCollected_11)
		{
			tapeUsable_Collected_11.gameObject.SetActive(value: true);
			tapeUsable_InWorld_11.gameObject.SetActive(value: false);
			cassetteGhosts[11].SetActive(value: false);
		}
		else
		{
			tapeUsable_Collected_11.gameObject.SetActive(value: false);
			tapeUsable_InWorld_11.gameObject.SetActive(value: true);
			cassetteGhosts[11].SetActive(value: true);
		}
		if (tapeCollected_12)
		{
			tapeUsable_Collected_12.gameObject.SetActive(value: true);
			tapeUsable_InWorld_12.gameObject.SetActive(value: false);
			cassetteGhosts[12].SetActive(value: false);
		}
		else
		{
			tapeUsable_Collected_12.gameObject.SetActive(value: false);
			tapeUsable_InWorld_12.gameObject.SetActive(value: true);
			cassetteGhosts[12].SetActive(value: true);
		}
		if (tapeCollected_13)
		{
			tapeUsable_Collected_13.gameObject.SetActive(value: true);
			tapeUsable_InWorld_13.gameObject.SetActive(value: false);
			cassetteGhosts[13].SetActive(value: false);
			return;
		}
		cassetteGhosts[13].SetActive(value: true);
		tapeUsable_Collected_13.gameObject.SetActive(value: false);
		if (PlayerStats.Singleton.hasOpenedTrash)
		{
			tapeUsable_InWorld_13.gameObject.SetActive(value: true);
		}
		else
		{
			tapeUsable_InWorld_13.gameObject.SetActive(value: false);
		}
	}

	public void CassetteAchievementChecks()
	{
		int num = 0;
		if (tapeCollected_1)
		{
			num++;
		}
		if (tapeCollected_2)
		{
			num++;
		}
		if (tapeCollected_3)
		{
			num++;
		}
		if (tapeCollected_4)
		{
			num++;
		}
		if (tapeCollected_5)
		{
			num++;
		}
		if (tapeCollected_6)
		{
			num++;
		}
		if (tapeCollected_7)
		{
			num++;
		}
		if (tapeCollected_8)
		{
			num++;
		}
		if (tapeCollected_9)
		{
			num++;
		}
		if (tapeCollected_10)
		{
			num++;
		}
		if (tapeCollected_11)
		{
			num++;
		}
		if (tapeCollected_12)
		{
			num++;
		}
		if (tapeCollected_13)
		{
			num++;
		}
		if (num > 0 && !AchievementHelper.IsAchievementUnlocked("ACH_Cassettes1"))
		{
			AchievementHelper.UnlockAchievement("ACH_Cassettes1");
		}
		if (num == 13 && !AchievementHelper.IsAchievementUnlocked("ACH_Cassettes_All"))
		{
			AchievementHelper.UnlockAchievement("ACH_Cassettes_All");
			MenuToGameBridger.Singleton.HundoPercentCompletionAchievementCheck();
		}
	}

	private void HandleParticlesOnLastTape()
	{
		try
		{
			if (tapeUsable_Collected_13.activeSelf)
			{
				lastTapeParticles.SetActive(!PlayerStats.Singleton.hasListenedToConfession && !tapeIsPlaying);
			}
		}
		catch
		{
			Debug.Log("Ran into an issue trying to display particles, ignoring!");
		}
	}
}
