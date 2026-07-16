using System;
using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PostcardMenu : Menu
{
	[Header("UI Elements")]
	[SerializeField]
	private TextMeshProUGUI _headerTxt;

	[SerializeField]
	private Image weightBarImg;

	[SerializeField]
	private Image trainNameImg;

	[SerializeField]
	private Image weightSticker;

	[SerializeField]
	private TextMeshProUGUI weightTxt;

	[Header("Buttons")]
	[SerializeField]
	private Button moduleStatsLeftButton;

	[SerializeField]
	private Button moduleStatsRightButton;

	[SerializeField]
	private Button newUnlocksLeftButton;

	[SerializeField]
	private Button newUnlocksRightButton;

	[SerializeField]
	private Button returnToHubButton;

	[Header("Content Holders")]
	[SerializeField]
	private Transform _statsHolder;

	[SerializeField]
	private Transform _moduleStatsHolder;

	[SerializeField]
	private Transform _newUnlocksHolder;

	[Header("Prefabs")]
	[SerializeField]
	private GameObject _statGo;

	[SerializeField]
	private GameObject _moduleStatGo;

	[SerializeField]
	private GameObject _newUnlockGo;

	[Header("Other")]
	[SerializeField]
	private SerializedDictionary<TrainType, Sprite> trainNames;

	[SerializeField]
	private Animator polaroidAnim;

	[NonSerialized]
	public bool killerFound;

	private List<NewUnlock> _newUnlocks;

	private List<PostcardModuleStat> currentModuleStats;

	private List<PostcardNewUnlock> currentNewUnlocks;

	private List<PostcardStat> currentStats;

	private int moduleCount;

	private List<Module> modules;

	private int moduleStatsPage;

	private int newUnlocksPage;

	private List<int> _revealedUnlockPages;

	private bool weightBarReady;

	private float targetWeightFillAmount;

	public override void Init()
	{
		base.Init();
		_newUnlocks = new List<NewUnlock>();
		currentModuleStats = new List<PostcardModuleStat>();
		currentNewUnlocks = new List<PostcardNewUnlock>();
		currentStats = new List<PostcardStat>();
		modules = new List<Module>();
		_revealedUnlockPages = new List<int>();
		moduleStatsRightButton.onClick.AddListener(delegate
		{
			ModuleStatsRight();
		});
		moduleStatsLeftButton.onClick.AddListener(delegate
		{
			ModuleStatsLeft();
		});
		newUnlocksRightButton.onClick.AddListener(delegate
		{
			NewUnlocksRight();
		});
		newUnlocksLeftButton.onClick.AddListener(delegate
		{
			NewUnlocksLeft();
		});
		returnToHubButton.onClick.AddListener(delegate
		{
			GameManager.Instance.StartNewGame();
		});
	}

	private new void Awake()
	{
		base.Awake();
		if (Train.Instance.currentTrain == null)
		{
			trainNameImg.sprite = trainNames[TrainType.Regular];
		}
		else
		{
			trainNameImg.sprite = trainNames[Train.Instance.currentTrain.trainType];
		}
		if (Train.Instance.HealthComponent.HealthCurrent > 0f)
		{
			_headerTxt.text = "I made it through " + ZoneManager.Instance.CurrentZone.Definition.DisplayName;
		}
		else
		{
			_headerTxt.text = "I didn't make it... Sending love from " + ZoneManager.Instance.CurrentZone.Definition.DisplayName;
		}
	}

	public void Initialize()
	{
		GetAllModules();
		DisplayStats();
		DisplayModuleStats(0);
		AddNewUnlocksFromMilestones();
		if (newUnlocksPage * 6 + 12 - _newUnlocks.Count < 6)
		{
			newUnlocksRightButton.interactable = true;
		}
		DisplayNewUnlocks(0);
		_revealedUnlockPages.Add(0);
		weightBarImg.fillAmount = 0f;
		targetWeightFillAmount = DifficultyManager.Instance.CurrentWeight / DifficultyManager.Instance.MaxWeight;
	}

	public void Animate()
	{
		StartCoroutine(DisplayStatValues());
		weightBarReady = true;
	}

	private void Update()
	{
		EventSystemAutoSelect.CheckAndSelectClosest();
		if (weightBarReady)
		{
			if (weightBarImg.fillAmount < targetWeightFillAmount)
			{
				weightBarImg.fillAmount += Time.unscaledDeltaTime / 3f;
				return;
			}
			weightBarImg.fillAmount = targetWeightFillAmount;
			weightBarReady = false;
			weightSticker.enabled = true;
			weightTxt.text = DifficultyManager.Instance.CurrentWeight.ToString();
			float width = weightBarImg.rectTransform.rect.width;
			float x = targetWeightFillAmount * width - width / 2f;
			weightSticker.rectTransform.localPosition = new Vector3(x, weightSticker.rectTransform.localPosition.y, 0f);
		}
	}

	private void GetAllModules()
	{
		if (modules == null)
		{
			modules = new List<Module>();
		}
		foreach (Module module in Train.Instance.Modules)
		{
			if (!(module is ModuleFurnace) && !(module is ModuleDirectionLever))
			{
				modules.Add(module);
				moduleCount++;
			}
		}
		if (moduleStatsPage * 4 + 8 - moduleCount < 4)
		{
			moduleStatsRightButton.interactable = true;
		}
	}

	public void AddNewUnlock(Sprite icon, string enhancementType, string name, Rarity rarity, Enhancement enh = null)
	{
		if (_newUnlocks == null)
		{
			_newUnlocks = new List<NewUnlock>();
		}
		NewUnlock item = new NewUnlock(icon, enhancementType, name, rarity, enh);
		_newUnlocks.Add(item);
	}

	private void AddNewUnlocksFromMilestones()
	{
		if (GameManager.Instance.isDemo || MilestoneManager.Instance.currentRunUnlocks.Count == 0)
		{
			return;
		}
		foreach (Milestone currentRunUnlock in MilestoneManager.Instance.currentRunUnlocks)
		{
			AddNewUnlock(currentRunUnlock.Unlock.Icon, currentRunUnlock.Unlock.GetEnhancementSimplified(), currentRunUnlock.Unlock.Name, currentRunUnlock.Unlock.Rarity, currentRunUnlock.Unlock);
		}
	}

	private void DisplayModuleStats(int page)
	{
		if (currentModuleStats.Count > 0)
		{
			foreach (PostcardModuleStat currentModuleStat in currentModuleStats)
			{
				UnityEngine.Object.Destroy(currentModuleStat.gameObject);
			}
			currentModuleStats.Clear();
		}
		for (int i = page * 4; i < page * 4 + 4 && modules.Count > i; i++)
		{
			PostcardModuleStat component = UnityEngine.Object.Instantiate(_moduleStatGo, _moduleStatsHolder).GetComponent<PostcardModuleStat>();
			component.SetupStat(modules[i]);
			currentModuleStats.Add(component);
		}
	}

	private void DisplayNewUnlocks(int page)
	{
		if (currentNewUnlocks.Count > 0)
		{
			foreach (PostcardNewUnlock currentNewUnlock in currentNewUnlocks)
			{
				UnityEngine.Object.Destroy(currentNewUnlock.gameObject);
			}
			currentNewUnlocks.Clear();
		}
		if (_newUnlocks.Count > 0)
		{
			for (int i = page * 6; i < page * 6 + 6 && _newUnlocks.Count > i; i++)
			{
				PostcardNewUnlock component = UnityEngine.Object.Instantiate(_newUnlockGo, _newUnlocksHolder).GetComponent<PostcardNewUnlock>();
				component.SetupNewUnlock(_newUnlocks[i].Icon, _newUnlocks[i].Type, _newUnlocks[i].Name, _newUnlocks[i].Rarity, _revealedUnlockPages.Contains(page), _newUnlocks[i].Enhancement);
				currentNewUnlocks.Add(component);
			}
		}
		else
		{
			newUnlocksRightButton.interactable = false;
		}
	}

	private void DisplayStats()
	{
		AddNewStat("Run Time", (int)(GameManager.Instance.playtimeInRun / 60f), "min");
		AddNewStat("Enemies Defeated", GameManager.Instance.TotalKillsInRun);
		AddNewStat("Damage Dealt", (int)Mathf.Abs(GameManager.Instance.TotalDamageInRun));
		AddNewStat("Accuracy", (int)Mathf.Abs(GameManager.Instance.CannonMissPercent), "%");
		AddNewStat("Damage Mitigated", (int)Mathf.Abs(GameManager.Instance.TotalDamageMitigatedInRun));
		AddNewStat("Damage Taken", (int)Mathf.Abs(GameManager.Instance.TotalDamageTakenInRun));
		AddNewStat("Damage Repaired", (int)Mathf.Abs(GameManager.Instance.TotalDamageRepairedInRun));
		AddNewStat("Modules Activated", Mathf.Abs(GameManager.Instance.TotalModulesActivated));
		AddNewStat("Distance Traveled", (int)(GameManager.Instance.TotalKilometersTraveled / 10f), "km");
		AddNewStat("Enhancements Collected", GameManager.Instance.TotalEnhancementsCollected);
	}

	private IEnumerator DisplayStatValues()
	{
		foreach (PostcardStat stat in currentStats)
		{
			yield return new WaitForSecondsRealtime(0.25f);
			stat.DisplayValue();
		}
	}

	private void AddNewStat(string name, float value, string unitOfMeasurement = "")
	{
		PostcardStat component = UnityEngine.Object.Instantiate(_statGo, _statsHolder).GetComponent<PostcardStat>();
		component.SetupStat(name, value, unitOfMeasurement);
		currentStats.Add(component);
	}

	private void ModuleStatsRight()
	{
		moduleStatsPage++;
		DisplayModuleStats(moduleStatsPage);
		moduleStatsLeftButton.interactable = true;
		if (moduleStatsPage * 4 + 8 - moduleCount >= 4)
		{
			moduleStatsRightButton.interactable = false;
		}
	}

	private void ModuleStatsLeft()
	{
		moduleStatsPage--;
		DisplayModuleStats(moduleStatsPage);
		moduleStatsRightButton.interactable = true;
		if (moduleStatsPage == 0)
		{
			moduleStatsLeftButton.interactable = false;
		}
	}

	private void NewUnlocksLeft()
	{
		newUnlocksPage--;
		DisplayNewUnlocks(newUnlocksPage);
		newUnlocksRightButton.interactable = true;
		if (newUnlocksPage == 0)
		{
			newUnlocksLeftButton.interactable = false;
		}
		if (!_revealedUnlockPages.Contains(newUnlocksPage))
		{
			_revealedUnlockPages.Add(newUnlocksPage);
		}
	}

	private void NewUnlocksRight()
	{
		newUnlocksPage++;
		DisplayNewUnlocks(newUnlocksPage);
		newUnlocksLeftButton.interactable = true;
		if (newUnlocksPage * 6 + 12 - _newUnlocks.Count >= 6)
		{
			newUnlocksRightButton.interactable = false;
		}
		if (!_revealedUnlockPages.Contains(newUnlocksPage))
		{
			_revealedUnlockPages.Add(newUnlocksPage);
		}
	}

	public void RevealPolaroid()
	{
		if (killerFound)
		{
			polaroidAnim.Play("PolaroidRevealKiller");
		}
		else
		{
			polaroidAnim.Play("PolaroidRevealUnknown");
		}
	}
}
