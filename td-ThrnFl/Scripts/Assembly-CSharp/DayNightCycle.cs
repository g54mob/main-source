using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
	public interface IDaytimeSensitive
	{
		void OnDuskEarly();

		void OnDusk();

		void OnDawn_AfterSunrise();

		void OnDawn_BeforeSunrise();
	}

	public enum Timestate
	{
		Day = 0,
		Night = 1
	}

	private static DayNightCycle instance;

	public float sunriseTime = 2.5f;

	private Timestate currentTimestate;

	private float currentNightLength;

	private List<IDaytimeSensitive> daytimeSensitiveObjects = new List<IDaytimeSensitive>();

	private bool afterSunrise = true;

	private bool automatedDaytime;

	private float autoDayCycleLength;

	private float remainingAutoDayTime;

	private bool automatedNighttime;

	private float autoNightCycleLength;

	private float remainingAutoNightTime;

	private bool currentlySwitchingToDay;

	public static DayNightCycle Instance => instance;

	public Timestate CurrentTimestate => currentTimestate;

	public float CurrentNightLength => currentNightLength;

	public bool AfterSunrise => afterSunrise;

	public bool AutomatedDaytime => automatedDaytime;

	public float RemainingAutoDayTime => remainingAutoDayTime;

	public bool AutomatedNighttime => automatedNighttime;

	public float RemainingAutoNightTime => remainingAutoNightTime;

	public int CoinCountToBeHarvested
	{
		get
		{
			int num = 0;
			foreach (BuildingInteractor playerBuildingInteractor in TagManager.instance.playerBuildingInteractors)
			{
				if ((bool)playerBuildingInteractor.coinSpawner)
				{
					num += playerBuildingInteractor.coinSpawner.CoinsLeft;
				}
				if (playerBuildingInteractor.canBeHarvested)
				{
					num += playerBuildingInteractor.GoldIncome;
				}
			}
			return num;
		}
	}

	private void Awake()
	{
		if (instance != null)
		{
			UnityEngine.Object.Destroy(this);
		}
		else
		{
			instance = this;
		}
	}

	private void Update()
	{
		if (LocalGamestate.Instance.CurrentState != LocalGamestate.State.InMatch)
		{
			return;
		}
		if (currentTimestate == Timestate.Night)
		{
			currentNightLength += Time.deltaTime;
		}
		if (currentTimestate == Timestate.Night && (bool)TagManager.instance && (bool)EnemySpawner.instance && !EnemySpawner.instance.SpawningInProgress && EnemySpawner.instance.NumberOfEnemiesOnTheMap <= 0 && base.gameObject.activeInHierarchy)
		{
			StartCoroutine(SwitchToDayCoroutine());
		}
		if (TagManager.instance.CountObjectsWithTag(TagManager.ETag.CastleCenter) > 0 && automatedDaytime && currentTimestate == Timestate.Day)
		{
			remainingAutoDayTime -= Time.deltaTime;
			if (remainingAutoDayTime <= 0f)
			{
				remainingAutoDayTime = 0f;
				if (ChoiceManager.instance.ChoiceCoroutineWaiting)
				{
					ChoiceManager.instance.CancelChoice();
					UIFrameManager.instance.CloseAllFrames();
				}
				SwitchToNight();
			}
		}
		if (automatedNighttime && currentTimestate == Timestate.Night)
		{
			remainingAutoNightTime -= Time.deltaTime;
			if (remainingAutoNightTime <= 0f)
			{
				remainingAutoNightTime = 0f;
				StartCoroutine(SwitchToDayCoroutine());
			}
		}
	}

	private void DawnCallAfterSunrise()
	{
		afterSunrise = true;
		Hp.ReviveAllKnockedOutPlayerUnitsAndBuildings();
		for (int num = daytimeSensitiveObjects.Count - 1; num >= 0; num--)
		{
			try
			{
				if (daytimeSensitiveObjects[num] != null)
				{
					daytimeSensitiveObjects[num].OnDawn_AfterSunrise();
				}
				else
				{
					daytimeSensitiveObjects.RemoveAt(num);
				}
			}
			catch (Exception message)
			{
				Debug.LogError(message);
			}
		}
		ThronefallAudioManager.Oneshot(ThronefallAudioManager.AudioOneShot.BuildingRepair);
		LevelData levelDataForActiveScene = LevelProgressManager.instance.GetLevelDataForActiveScene();
		int networth = PlayerInteraction.instance.Networth;
		networth += TagManager.instance.freeCoins.Count;
		networth += CoinCountToBeHarvested;
		levelDataForActiveScene.dayToDayNetworth.Add(networth);
		PlayerInteraction component = TagManager.instance.Players[0].GetComponent<PlayerInteraction>();
		foreach (Coin freeCoin in TagManager.instance.freeCoins)
		{
			if (freeCoin.IsFree)
			{
				freeCoin.SetTarget(component);
			}
		}
	}

	private void DawnCallBeforeSunrise()
	{
		remainingAutoDayTime = autoDayCycleLength;
		afterSunrise = false;
		for (int num = daytimeSensitiveObjects.Count - 1; num >= 0; num--)
		{
			try
			{
				if (daytimeSensitiveObjects[num] != null)
				{
					daytimeSensitiveObjects[num].OnDawn_BeforeSunrise();
				}
				else
				{
					daytimeSensitiveObjects.RemoveAt(num);
				}
			}
			catch (Exception message)
			{
				Debug.LogError(message);
			}
		}
		ThronefallAudioManager.Oneshot(ThronefallAudioManager.AudioOneShot.NightSurvived);
	}

	private void DuskCall()
	{
		remainingAutoNightTime = autoNightCycleLength;
		afterSunrise = false;
		currentNightLength = 0f;
		List<TagManager.ETag> list = new List<TagManager.ETag>();
		List<TagManager.ETag> list2 = new List<TagManager.ETag>();
		list.Add(TagManager.ETag.PlayerOwned);
		list2.Add(TagManager.ETag.AUTO_NoReviveNextMorning);
		Hp.SetAllUnitsWithTagInvulnerable(list, list2, _invulnerable: false);
		for (int num = daytimeSensitiveObjects.Count - 1; num >= 0; num--)
		{
			try
			{
				if (daytimeSensitiveObjects[num] != null)
				{
					daytimeSensitiveObjects[num].OnDuskEarly();
				}
				else
				{
					daytimeSensitiveObjects.RemoveAt(num);
				}
			}
			catch (Exception message)
			{
				Debug.LogError(message);
			}
		}
		for (int num2 = daytimeSensitiveObjects.Count - 1; num2 >= 0; num2--)
		{
			try
			{
				if (daytimeSensitiveObjects[num2] != null)
				{
					daytimeSensitiveObjects[num2].OnDusk();
				}
				else
				{
					daytimeSensitiveObjects.RemoveAt(num2);
				}
			}
			catch (Exception message2)
			{
				Debug.LogError(message2);
			}
		}
	}

	public void ToggleDaytime()
	{
		if (currentTimestate == Timestate.Day)
		{
			currentTimestate = Timestate.Night;
			DuskCall();
		}
		else
		{
			currentTimestate = Timestate.Day;
			DawnCallBeforeSunrise();
			DawnCallAfterSunrise();
		}
	}

	private IEnumerator SwitchToDayCoroutine()
	{
		if (currentlySwitchingToDay)
		{
			yield break;
		}
		currentlySwitchingToDay = true;
		if (currentTimestate == Timestate.Night)
		{
			currentTimestate = Timestate.Day;
			DawnCallBeforeSunrise();
			yield return new WaitForSeconds(sunriseTime);
			DawnCallAfterSunrise();
			if (EnemySpawner.instance.Wavenumber >= EnemySpawner.instance.waves.Count - 1)
			{
				LocalGamestate.Instance.SetState(LocalGamestate.State.AfterMatchVictory);
			}
		}
		currentlySwitchingToDay = false;
	}

	public void SwitchToNight()
	{
		if (currentTimestate != Timestate.Night)
		{
			currentTimestate = Timestate.Night;
			DuskCall();
		}
	}

	public void SwithToDay()
	{
		if (currentTimestate != Timestate.Day)
		{
			StartCoroutine(SwitchToDayCoroutine());
		}
	}

	public void RegisterDaytimeSensitiveObject(IDaytimeSensitive obj)
	{
		daytimeSensitiveObjects.Add(obj);
	}

	public void UnregisterDaytimeSensitiveObject(IDaytimeSensitive obj)
	{
		daytimeSensitiveObjects.Remove(obj);
	}

	public void SetToAutoDayLength(float cycleLength)
	{
		autoDayCycleLength = cycleLength;
		remainingAutoDayTime = cycleLength;
		automatedDaytime = true;
	}

	public void SetToAutoNightLength(float cycleLength)
	{
		autoNightCycleLength = cycleLength;
		remainingAutoNightTime = cycleLength;
		automatedNighttime = true;
	}
}
