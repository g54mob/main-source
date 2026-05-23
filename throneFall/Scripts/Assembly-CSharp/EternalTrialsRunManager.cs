using System;
using System.IO;
using UnityEngine;

public class EternalTrialsRunManager : MonoBehaviour
{
	public static readonly string[] mapRotation = new string[9] { "Nordfels", "Durststein", "Frostsee", "Uferwind", "Sturmklamm", "Wildbach", "Moorweg", "Freifort", "Totend" };

	public const int STAGE_SCORE_MULTIPLIER = 1000;

	private static EternalTrialsRun currentRun;

	private static EternalTrialsRun lastDiscardedRun;

	private static int freshRunSeed = 0;

	private static string SavePath => Application.persistentDataPath + "/EternalTrials_V4.json";

	public static EternalTrialsRun CurrentRun
	{
		get
		{
			if (currentRun == null)
			{
				currentRun = TryLoadRun();
			}
			if (currentRun == null)
			{
				CreateFreshRun();
			}
			return currentRun;
		}
	}

	public static EternalTrialsRun LastDiscardedRun => lastDiscardedRun;

	public static bool HasOngoingRun
	{
		get
		{
			if (CurrentRun.stage > 0 || CurrentRun.inGame)
			{
				return !CurrentRun.runComplete;
			}
			return false;
		}
	}

	public static void SaveRun(EternalTrialsRun runToSave)
	{
		try
		{
			CurrentRun.LoadoutToStringsForSaving();
			string contents = JsonUtility.ToJson(runToSave);
			File.WriteAllText(SavePath, contents);
		}
		catch
		{
			Debug.LogError("There has been an error while trying to save the Eternal Trials run config.");
		}
	}

	public static EternalTrialsRun TryLoadRun()
	{
		freshRunSeed = PlayerPrefs.GetInt("EternalTrials_FreshRunSeed");
		if (freshRunSeed == 0)
		{
			GenerateNewFreshRunSeed();
		}
		try
		{
			if (File.Exists(SavePath))
			{
				EternalTrialsRun eternalTrialsRun = JsonUtility.FromJson<EternalTrialsRun>(File.ReadAllText(SavePath));
				eternalTrialsRun.SavedStringsToLoadout();
				Debug.Log("Eternal Trials run loaded.");
				return eternalTrialsRun;
			}
			return null;
		}
		catch
		{
			Debug.Log("There has been an error while trying to load the Eternal Trials Run.");
			return null;
		}
	}

	public static void GenerateNewFreshRunSeed()
	{
		freshRunSeed = new System.Random().Next(int.MinValue, int.MaxValue);
		PlayerPrefs.SetInt("EternalTrials_FreshRunSeed", freshRunSeed);
	}

	public static void DiscardActiveRun()
	{
		if (HasOngoingRun)
		{
			lastDiscardedRun = CurrentRun;
		}
	}

	public static void TurnLastDiscardedRunIntoCurrentRun()
	{
		if ((!(SceneTransitionManager.instance != null) || !SceneTransitionManager.instance.SceneTransitionIsRunning) && lastDiscardedRun != null)
		{
			currentRun = lastDiscardedRun;
		}
	}

	public static void OnVictory()
	{
		string text = "";
		CurrentRun.stage++;
		AchievementManager.UnlockEternalTrialsAchievementForBeating(CurrentRun.stage);
		for (int i = 0; i < mapRotation.Length; i++)
		{
			if (mapRotation[i] == CurrentRun.currentMap)
			{
				int num = i + 1;
				if (num >= mapRotation.Length)
				{
					num = 0;
				}
				text = mapRotation[num];
			}
		}
		if (text.Length <= 0)
		{
			Debug.Log("Current map not found in map rotation. Loading first map in rotation");
			text = mapRotation[0];
		}
		CurrentRun.currentMap = text;
		CurrentRun.currentStageSeed = new System.Random().Next(int.MinValue, int.MaxValue);
		CurrentRun.inGame = false;
		CurrentRun.inNight = false;
		SaveRun(CurrentRun);
		GenerateNewFreshRunSeed();
	}

	public static void OnDefeat()
	{
		CurrentRun.runComplete = true;
		CurrentRun.inGame = false;
		CurrentRun.inNight = false;
		SaveRun(CurrentRun);
		GenerateNewFreshRunSeed();
	}

	public static void LoadNextMap(EternalTrialsRun etRun = null)
	{
		if (etRun == null)
		{
			etRun = CurrentRun;
		}
		for (int num = PerkManager.instance.CurrentlyEquipped.Count - 1; num >= 0; num--)
		{
			PerkManager.SetEquipped(PerkManager.instance.CurrentlyEquipped[num], _equipped: false);
		}
		foreach (EquippablePerk acquiredPerk in etRun.acquiredPerks)
		{
			if (acquiredPerk as EquippablePerk != null)
			{
				if (!etRun.disabledPerks.Contains(acquiredPerk as EquippablePerk))
				{
					PerkManager.SetEquipped(acquiredPerk, _equipped: true);
				}
			}
			else
			{
				PerkManager.SetEquipped(acquiredPerk, _equipped: true);
			}
		}
		PerkManager.SetEquipped(etRun.currentWeapon, _equipped: true);
		SceneTransitionManager.instance.TransitionFromNullToLevel(etRun.currentMap);
	}

	public static void CreateFreshRun()
	{
		currentRun = new EternalTrialsRun(mapRotation[0], freshRunSeed);
	}

	public static MapChoice[] GetMapChoices()
	{
		System.Random random = new System.Random(CurrentRun.currentStageSeed);
		MapChoice[] array = new MapChoice[3];
		string[] array2 = (string[])mapRotation.Clone();
		array2.ETShuffle(random);
		for (int i = 0; i < array.Length; i++)
		{
			if (i < array2.Length)
			{
				array[i] = MapChoice.GenerateNewMapChoice(2, array2[i], random, i);
			}
			else
			{
				array[i] = MapChoice.GenerateNewMapChoice(2, mapRotation[random.Next(0, mapRotation.Length)], random, i);
			}
		}
		return array;
	}

	public static void ConfirmChoice(MapChoice choice)
	{
		CurrentRun.currentMap = choice.mapName;
		CurrentRun.acquiredPerks.AddRange(choice.containedPerks);
		CurrentRun.currentWeapon = choice.containedWeapon;
		CurrentRun.inGame = true;
		CurrentRun.currentStageSeed += choice.id;
		SaveRun(CurrentRun);
		GenerateNewFreshRunSeed();
	}

	public static void AddScore(int amount)
	{
		CurrentRun.score += amount;
		SaveRun(CurrentRun);
	}
}
