using System;
using TMPro;

public class PowerPanel : BaseBuildingPanel
{
	public ColumnController PanelColumn;

	public PanelTitle Title;

	public MixedRow OverflowRow;

	public MixedRow StabilityRow;

	public MixedRow LevelRow;

	public MixedRow ThrowOutputRow;

	public MixedRow AutoDeviceRow;

	public MixedRow IncreaseRangeRow;

	public WorkerRow AddStabilityStopRow;

	public WorkerRow AddMoreCloudRow;

	public WorkerRow AddOutputWeightRow;

	public WorkerRow AddOutputAmountRow;

	public WorkerRow AddStabilityDownRow;

	public WorkerRow AddMoreRPTPRow;

	public WorkerRow WorkerRow;

	public PanelButtonTooltip DestroyButton;

	private int _section1UnlockLevel = 2;

	private int _section2UnlockLevel = 4;

	private int _section3UnlockLevel = 6;

	private Power Building => (Power)PanelColumn.Buildings;

	private void Start()
	{
		Title.Initialize(base.gameObject, "Power");
		OverflowRow.Initialize(base.gameObject, MixedRow.StateEnum.NoButton, "Overflow!");
		StabilityRow.Initialize(base.gameObject, MixedRow.StateEnum.NoButton, "Durability");
		LevelRow.Initialize(base.gameObject, MixedRow.StateEnum.Full, "Level");
		ThrowOutputRow.Initialize(base.gameObject, MixedRow.StateEnum.Full, "Throw");
		AutoDeviceRow.Initialize(base.gameObject, MixedRow.StateEnum.NoValue, "Auto Dev.");
		IncreaseRangeRow.Initialize(base.gameObject, MixedRow.StateEnum.Full, "Range+");
		AddOutputWeightRow.Initialize(base.gameObject, "+Value");
		AddOutputAmountRow.Initialize(base.gameObject, "+Amount");
		AddStabilityDownRow.Initialize(base.gameObject, "-Durab.");
		AddStabilityStopRow.Initialize(base.gameObject, "+Solidity");
		AddMoreCloudRow.Initialize(base.gameObject, "+Cloud");
		AddMoreRPTPRow.Initialize(base.gameObject, "+Point");
		WorkerRow.Initialize(base.gameObject, "Worker");
		DestroyButton.Initialize(base.gameObject);
		Title.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Power", "Lvl " + Building.GetLevel() + "/10", GetTooltip(Building), ""));
		LevelRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Increase Level", "Lvl " + (Building.GetLevel() + 1), GetTooltip(Building, forNextLevel: true), (Building.GetLevel() < 10) ? (Building.GetIncreaseLevelCost().ToNumber() + "$") : "Max"));
		if (!CharDisplay.HasRelax)
		{
			StabilityRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update(PanelTitle.GetTitle("Durability", Building.GetGlobalInfo().StabilityLevel + 1), "", "Each working peon reduces durability by 1. At zero, building is destroyed and:\n\n+" + BaseBuildingPanel.FormatPercentage(GameController.Instance.GetStabilityDestroyPercentage()) + "$ spent turned to trash\n+" + Building.YellowShardCountWhenDurabilityDown() + " yellow shard\n+" + 500 + " max durability\n+1 trash produced by all power buildings", Building.GetGlobalInfo().GetMaxStability() - Building.GetStability() + "/" + Building.GetGlobalInfo().GetMaxStability() + " Durability"));
		}
		else
		{
			StabilityRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update(PanelTitle.GetTitle("Durability", Building.GetGlobalInfo().StabilityLevel + 1), "", "Each working peon reduces durability by 1. At zero:\n\n+" + Building.YellowShardCountWhenDurabilityDown() + " yellow shard\n+" + 500 + " max durability\n+1 trash produced by all power buildings", Building.GetGlobalInfo().GetMaxStability() - Building.GetStability() + "/" + Building.GetGlobalInfo().GetMaxStability() + " Durability"));
		}
		ThrowOutputRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Throw", "", "Output pipe pointing up will throw trash into the hole.", Building.HasThrowOutputAttribute.IsEnabled ? "Max" : (Building.ReduceWithTrainingPeon(Building.HasThrowOutputAttribute.GetCost()).ToNumber() + "$")));
		AutoDeviceRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Auto Device", "", "If the device was executed once for any building of the same type, the device will run automatically.", Building.HasAutoDeviceAttribute.IsEnabled ? "Max" : (Building.ReduceWithTrainingPeon(Building.HasAutoDeviceAttribute.GetCost()).ToNumber() + "$")));
		IncreaseRangeRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Range+", "", "Increase the range.", Building.HasIncreaseRangeAttribute.IsEnabled ? "Max" : (Building.ReduceWithTrainingPeon(Building.HasIncreaseRangeAttribute.GetCost()).ToNumber() + "$")));
		AddOutputWeightRow.SetTooltip("+Value", "Assign worker to boost surounding building.\n\nUnlocked at level " + (_section1UnlockLevel + 1) + "\n+" + BaseBuildingPanel.FormatPercentage(0.5f) + " trash value");
		AddOutputAmountRow.SetTooltip("+Amount", "Assign worker to boost surounding building.\n\nUnlocked at level " + (_section1UnlockLevel + 1) + "\n+" + 1 + " trash output");
		AddStabilityDownRow.SetTooltip("-Durab.", "Assign worker to boost surounding building.\n\nUnlocked at level " + (_section2UnlockLevel + 1) + "\n+" + BaseBuildingPanel.FormatPercentage(0.5f) + " durability loss");
		AddStabilityStopRow.SetTooltip("+Solidity", "Assign worker to boost surounding building.\n\nStop durability loss");
		AddMoreCloudRow.SetTooltip("+Cloud", "Assign worker to boost surounding building.\n\n+" + BaseBuildingPanel.FormatPercentage(0.25f) + " cloud rate");
		AddMoreRPTPRow.SetTooltip("+Point", "Assign worker to boost surounding building.\n\nUnlocked at level " + (_section3UnlockLevel + 1) + "\n+1 to gained RP or TP");
		WorkerRow.SetTooltip("Worker", "Add or remove peon worker to operate the building.");
		DestroyButton.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Destroy", "", "Destroy building and give back " + BaseBuildingPanel.FormatPercentage(GameController.Instance.GetManualDestroyPercentage()) + " of money spent in trash.", ""));
		OverflowRow.SetTooltip("Overflow", "Too much trash in front to continue the work.");
		LevelRow.ButtonPressEvent += LevelRowPress;
		ThrowOutputRow.ButtonPressEvent += ThrowOutputRowPress;
		AutoDeviceRow.ButtonPressEvent += AutoDeviceRowPress;
		IncreaseRangeRow.ButtonPressEvent += IncreaseRangeRowPress;
		AddOutputWeightRow.MinusPressEvent += delegate
		{
			AddRemovePowerWorker(Power.PowerIncreaseType.OutputWeight, toAdd: false);
		};
		AddOutputWeightRow.PlusPressEvent += delegate
		{
			AddRemovePowerWorker(Power.PowerIncreaseType.OutputWeight, toAdd: true);
		};
		AddOutputAmountRow.MinusPressEvent += delegate
		{
			AddRemovePowerWorker(Power.PowerIncreaseType.OutputAmount, toAdd: false);
		};
		AddOutputAmountRow.PlusPressEvent += delegate
		{
			AddRemovePowerWorker(Power.PowerIncreaseType.OutputAmount, toAdd: true);
		};
		AddStabilityDownRow.MinusPressEvent += delegate
		{
			AddRemovePowerWorker(Power.PowerIncreaseType.StabilityDown, toAdd: false);
		};
		AddStabilityDownRow.PlusPressEvent += delegate
		{
			AddRemovePowerWorker(Power.PowerIncreaseType.StabilityDown, toAdd: true);
		};
		AddStabilityStopRow.MinusPressEvent += delegate
		{
			AddRemovePowerWorker(Power.PowerIncreaseType.StabilityStop, toAdd: false);
		};
		AddStabilityStopRow.PlusPressEvent += delegate
		{
			AddRemovePowerWorker(Power.PowerIncreaseType.StabilityStop, toAdd: true);
		};
		AddMoreCloudRow.MinusPressEvent += delegate
		{
			AddRemovePowerWorker(Power.PowerIncreaseType.MoreCloud, toAdd: false);
		};
		AddMoreCloudRow.PlusPressEvent += delegate
		{
			AddRemovePowerWorker(Power.PowerIncreaseType.MoreCloud, toAdd: true);
		};
		AddMoreRPTPRow.MinusPressEvent += delegate
		{
			AddRemovePowerWorker(Power.PowerIncreaseType.MoreRP_TP, toAdd: false);
		};
		AddMoreRPTPRow.PlusPressEvent += delegate
		{
			AddRemovePowerWorker(Power.PowerIncreaseType.MoreRP_TP, toAdd: true);
		};
		WorkerRow.MinusPressEvent += UnreserveCharacter;
		WorkerRow.PlusPressEvent += ReserveCharacter;
		_deleteButtonText = DestroyButton.transform.Find("ButtonText").GetComponent<TMP_Text>();
	}

	private void Update()
	{
		if (Building == null)
		{
			WorldCanvasController.Instance.ClosePanel();
			return;
		}
		OverflowRow.gameObject.SetActive(Building.GarbageCounter.IsOverLimit);
		Title.UpdateTitleForLevel(Building.GetLevel());
		AddOutputWeightRow.SetValue(Building.GetPowerLevel(Power.PowerIncreaseType.OutputWeight).ToString());
		AddOutputAmountRow.SetValue(Building.GetPowerLevel(Power.PowerIncreaseType.OutputAmount).ToString());
		AddStabilityDownRow.SetValue(Building.GetPowerLevel(Power.PowerIncreaseType.StabilityDown).ToString());
		AddStabilityStopRow.SetValue(Building.GetPowerLevel(Power.PowerIncreaseType.StabilityStop).ToString());
		AddMoreCloudRow.SetValue(Building.GetPowerLevel(Power.PowerIncreaseType.MoreCloud).ToString());
		AddMoreRPTPRow.SetValue(Building.GetPowerLevel(Power.PowerIncreaseType.MoreRP_TP).ToString());
		WorkerRow.SetValue(Building.Workers.Count + "/" + Building.GetMaximumWorker());
		if (Building.GetLevel() <= _section1UnlockLevel)
		{
			AddOutputWeightRow.HideButton();
			AddOutputAmountRow.HideButton();
		}
		else
		{
			AddOutputWeightRow.ShowButton();
			AddOutputAmountRow.ShowButton();
		}
		if (Building.GetLevel() <= _section2UnlockLevel)
		{
			AddStabilityDownRow.HideButton();
		}
		else
		{
			AddStabilityDownRow.ShowButton();
		}
		if (Building.GetLevel() <= _section3UnlockLevel)
		{
			AddMoreRPTPRow.HideButton();
		}
		else
		{
			AddMoreRPTPRow.ShowButton();
		}
		StabilityRow.SetForStability(Building.GetStabilityPercentage());
		LevelRow.SetForLevelUp(Building);
		ThrowOutputRow.SetForUpgrade(Building, Building.HasThrowOutputAttribute);
		AutoDeviceRow.SetForUpgrade(Building, Building.HasAutoDeviceAttribute);
		if (Power.GlobalInfo.CanHaveMoreRangeAttribute.IsEnabled)
		{
			IncreaseRangeRow.gameObject.SetActive(value: true);
			IncreaseRangeRow.SetForUpgrade(Building, Building.HasIncreaseRangeAttribute);
		}
		else
		{
			IncreaseRangeRow.gameObject.SetActive(value: false);
		}
		if (!FreezeScale)
		{
			PanelHelper.SetSize(this);
		}
	}

	public void LevelRowPress(object o, EventArgs e)
	{
		TryIncreaseLevel(Building);
	}

	public void ThrowOutputRowPress(object o, EventArgs e)
	{
		TryEnableAttribute(Building, Building.HasThrowOutputAttribute);
	}

	public void AutoDeviceRowPress(object o, EventArgs e)
	{
		TryEnableAttribute(Building, Building.HasAutoDeviceAttribute);
	}

	public void IncreaseRangeRowPress(object o, EventArgs e)
	{
		if (TryEnableAttribute(Building, Building.HasIncreaseRangeAttribute))
		{
			GameController.Instance.ColumnsController.UpdateColumnUpdatedByPower();
		}
	}

	public void ReserveCharacter(object o, EventArgs e)
	{
		CharV2 charV = GameController.Instance.PeonController.FindWorkerForJob(Building);
		if (charV != null && Building.AddWorker(charV))
		{
			GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ba_worker_add);
		}
	}

	public void UnreserveCharacter(object o, EventArgs e)
	{
		if (Building.RemoveOneWorker())
		{
			GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ba_worker_remove);
		}
	}

	public void DestroyColumn()
	{
		if (ProcessDestroyColumn())
		{
			GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ba_destroy_building_m);
			PanelColumn.DestroyBuilding(null, GameController.Instance.GetManualDestroyPercentage(), canOutputMedium: false);
			WorldCanvasController.Instance.ClosePanel();
		}
	}

	private void AddRemovePowerWorker(Power.PowerIncreaseType type, bool toAdd)
	{
		if (toAdd)
		{
			if (Building.AddPowerWorker(type))
			{
				GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ba_worker_add);
			}
		}
		else if (Building.RemovePowerWorker(type))
		{
			GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ba_worker_remove);
		}
	}

	public static string GetTooltip(Power building, bool forNextLevel = false)
	{
		string text = "";
		if (!forNextLevel)
		{
			text = "Assign workers to different boosts to improve surrounding buildings.\n\n";
		}
		int num = ((!(building == null)) ? building.GetLevel() : 0);
		if (forNextLevel)
		{
			num++;
		}
		if (num == 0)
		{
			text = text + "Trash Produced: " + Power.GlobalInfo.GetDefaultOutputPerCycle() + " per worker\n";
			text = text + "Trash Value: " + Power.GlobalInfo.GetDefaultGarbageSize() + "$ per level\n";
			text = text + "Cloud Rate: " + BaseBuildingPanel.FormatPercentage(GameController.Instance.GetCloudChance()) + " per worker\n";
		}
		else if (!forNextLevel)
		{
			text = text + "Trash Produced: " + building.GetGarbageOutputCount() + " per worker\n";
			text = text + "Trash Value: " + building.GetGarbageSize() + "$\n";
			text = text + "Cloud Rate: " + BaseBuildingPanel.FormatPercentage(building.GetCloudChance()) + "\n";
		}
		else
		{
			text = text + "+" + Power.GlobalInfo.GetDefaultGarbageSize() + "$ trash value\n";
			if (num == 3 || num == 5 || num == 7 || num == 9)
			{
				text += "+1 floor\n+1 max worker\n";
			}
		}
		return text;
	}
}
