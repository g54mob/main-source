using MoreMountains.Feedbacks;
using UnityEngine;

public class Nighthorn : InteractorBase, DayNightCycle.IDaytimeSensitive
{
	public static Nighthorn instance;

	public GameObject nightCue;

	public GameObject harvestCue;

	public string autoCollectGoldTooltip;

	public string startNightTooltip;

	public string startPreFinalNightTooltip;

	public string startFinalNightTooltip;

	public MMF_Player onBlowFeedback;

	private TutorialManager tutorialManager;

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

	public bool AllCoinsHarvested
	{
		get
		{
			bool result = true;
			foreach (BuildingInteractor playerBuildingInteractor in TagManager.instance.playerBuildingInteractors)
			{
				if (playerBuildingInteractor.canBeHarvested)
				{
					result = false;
					break;
				}
			}
			foreach (Coin freeCoin in TagManager.instance.freeCoins)
			{
				if (freeCoin.IsFree)
				{
					result = false;
					break;
				}
			}
			return result;
		}
	}

	private void Awake()
	{
		instance = this;
	}

	public override string ReturnTooltip()
	{
		if (!AllCoinsHarvested)
		{
			return autoCollectGoldTooltip;
		}
		if (EnemySpawner.instance.PreFinalWaveComingUp)
		{
			return startPreFinalNightTooltip;
		}
		if (EnemySpawner.instance.FinalWaveComingUp(EnemySpawner.instance.Wavenumber))
		{
			return startFinalNightTooltip;
		}
		return startNightTooltip;
	}

	private void Start()
	{
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
		tutorialManager = TutorialManager.instance;
	}

	public override void InteractionBegin(PlayerInteraction player)
	{
		if ((bool)tutorialManager && !TutorialManager.AllowStartingTheNight)
		{
			return;
		}
		if (AllCoinsHarvested)
		{
			onBlowFeedback.PlayFeedbacks();
			DayNightCycle.Instance.SwitchToNight();
			return;
		}
		foreach (BuildingInteractor playerBuildingInteractor in TagManager.instance.playerBuildingInteractors)
		{
			playerBuildingInteractor.Harvest(player);
		}
		foreach (Coin freeCoin in TagManager.instance.freeCoins)
		{
			if (freeCoin.IsFree)
			{
				freeCoin.SetTarget(player);
			}
		}
		ActivateAndRefreshCues();
	}

	public void OnDawn_AfterSunrise()
	{
		base.gameObject.SetActive(value: true);
	}

	public void OnDusk()
	{
		base.gameObject.SetActive(value: false);
		DeactivateCues();
	}

	public override void Focus(PlayerInteraction player)
	{
		ActivateAndRefreshCues();
	}

	public override void Unfocus(PlayerInteraction player)
	{
		DeactivateCues();
		EnemySpawner.instance.EnemySpawnersHornUnFocussed();
	}

	public void OnDawn_BeforeSunrise()
	{
	}

	public void ActivateAndRefreshCues()
	{
		if (AllCoinsHarvested)
		{
			nightCue.SetActive(value: true);
			harvestCue.SetActive(value: false);
			EnemySpawner.instance.EnemySpawnersHornFocussed();
		}
		else
		{
			nightCue.SetActive(value: false);
			harvestCue.SetActive(value: true);
		}
	}

	public void DeactivateCues()
	{
		nightCue.SetActive(value: false);
		harvestCue.SetActive(value: false);
	}

	public void OnDuskEarly()
	{
	}
}
