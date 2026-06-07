using System.Collections;
using UnityEngine;

public class LocalMatchSaveLoad : MonoBehaviour, DayNightCycle.IDaytimeSensitive
{
	private static bool currentlyLoadingMatch;

	public bool disableAutomaticSaveLoading;

	private SaveLoadEntity[] allSaveLoadEntities;

	public static bool CurrentlyLoadingMatch => currentlyLoadingMatch;

	private void Awake()
	{
		if (!disableAutomaticSaveLoading)
		{
			allSaveLoadEntities = Object.FindObjectsOfType<SaveLoadEntity>(includeInactive: true);
			TryLoad();
		}
	}

	private void Start()
	{
		if (!disableAutomaticSaveLoading)
		{
			DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
			if (LocalGamestate.SelectedGameMode == LocalGamestate.GameMode.EternalTrial && EternalTrialsRunManager.CurrentRun.inNight)
			{
				LocalGamestate.Instance.SetState(LocalGamestate.State.AfterMatchDefeat);
			}
		}
	}

	[ContextMenu("SAVE")]
	private void Save()
	{
		if (LocalGamestate.Instance.CurrentState != LocalGamestate.State.InMatch || EnemySpawner.instance.Wavenumber >= EnemySpawner.instance.waves.Count - 1)
		{
			return;
		}
		MatchSaveLoadHandler.InitializeCurrentSave();
		if (LocalGamestate.SelectedGameMode == LocalGamestate.GameMode.EternalTrial)
		{
			MatchSaveLoadHandler.CurrentSave.etSeed = EternalTrialsRunManager.CurrentRun.currentStageSeed;
		}
		SaveLoadEntity[] array = allSaveLoadEntities;
		foreach (SaveLoadEntity saveLoadEntity in array)
		{
			if (!(saveLoadEntity == null))
			{
				saveLoadEntity.ExecuteSave();
			}
		}
		MatchSaveLoadHandler.SaveRun();
	}

	private void TryLoad()
	{
		if (!MatchSaveLoadHandler.IsLoadingPermitted)
		{
			return;
		}
		currentlyLoadingMatch = true;
		SaveLoadEntity[] array = allSaveLoadEntities;
		foreach (SaveLoadEntity saveLoadEntity in array)
		{
			if (!(saveLoadEntity == null))
			{
				saveLoadEntity.ExecuteBeforeMainLoadPass();
			}
		}
		array = allSaveLoadEntities;
		foreach (SaveLoadEntity saveLoadEntity2 in array)
		{
			if (!(saveLoadEntity2 == null))
			{
				saveLoadEntity2.ExecuteLoad();
			}
		}
		array = allSaveLoadEntities;
		foreach (SaveLoadEntity saveLoadEntity3 in array)
		{
			if (!(saveLoadEntity3 == null))
			{
				saveLoadEntity3.ExecuteAfterMainLoadPass();
			}
		}
		StartCoroutine(SetLoadStatWithDelay());
	}

	private IEnumerator SetLoadStatWithDelay()
	{
		yield return null;
		yield return null;
		yield return null;
		yield return null;
		yield return null;
		currentlyLoadingMatch = false;
	}

	private IEnumerator TriggerDelayedSave()
	{
		yield return null;
		yield return null;
		yield return null;
		yield return null;
		Save();
	}

	public void OnDawn_AfterSunrise()
	{
		StartCoroutine(TriggerDelayedSave());
	}

	public void OnDawn_BeforeSunrise()
	{
		if (LocalGamestate.SelectedGameMode == LocalGamestate.GameMode.EternalTrial)
		{
			EternalTrialsRunManager.CurrentRun.inNight = false;
			EternalTrialsRunManager.SaveRun(EternalTrialsRunManager.CurrentRun);
		}
	}

	public void OnDusk()
	{
		if (LocalGamestate.SelectedGameMode == LocalGamestate.GameMode.EternalTrial)
		{
			EternalTrialsRunManager.CurrentRun.inNight = true;
			EternalTrialsRunManager.SaveRun(EternalTrialsRunManager.CurrentRun);
		}
	}

	public void OnDuskEarly()
	{
	}
}
