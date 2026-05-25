using System;
using TMPro;

public class TrainingPanel : BaseBuildingPanel
{
	public ColumnController PanelColumn;

	public PanelTitle Title;

	public MixedRow OverflowRow;

	public MixedRow StabilityRow;

	public MixedRow LevelRow;

	public MixedRow CarryRow;

	public MixedRow SpeedRow;

	public MixedRow MiningRow;

	public MixedRow ReduceCostRow;

	public MixedRow ThrowOutputRow;

	public MixedRow AutoDeviceRow;

	public WorkerRow WorkerRow;

	public PanelButtonTooltip DestroyButton;

	private int _carryUnlockLevel = 2;

	private int _miningUnlockLevel = 4;

	private int _reduceCostUnlockLevel = 6;

	private Training Building => (Training)PanelColumn.Buildings;

	private void Start()
	{
		Title.Initialize(base.gameObject, "Training");
		OverflowRow.Initialize(base.gameObject, MixedRow.StateEnum.NoButton, "Overflow!");
		StabilityRow.Initialize(base.gameObject, MixedRow.StateEnum.NoButton, "Durability");
		LevelRow.Initialize(base.gameObject, MixedRow.StateEnum.Full, "Level");
		CarryRow.Initialize(base.gameObject, MixedRow.StateEnum.Full, "Carry");
		SpeedRow.Initialize(base.gameObject, MixedRow.StateEnum.Full, "Speed");
		MiningRow.Initialize(base.gameObject, MixedRow.StateEnum.Full, "Mining");
		ReduceCostRow.Initialize(base.gameObject, MixedRow.StateEnum.Full, "Rebate");
		ThrowOutputRow.Initialize(base.gameObject, MixedRow.StateEnum.Full, "Throw");
		AutoDeviceRow.Initialize(base.gameObject, MixedRow.StateEnum.NoValue, "Auto Dev.");
		WorkerRow.Initialize(base.gameObject, "Worker");
		DestroyButton.Initialize(base.gameObject);
		Title.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Training", "Lvl " + Building.GetLevel() + "/10", GetTooltip(Building), ""));
		LevelRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Increase Level", "Lvl " + (Building.GetLevel() + 1), GetTooltip(Building, forNextLevel: true), (Building.GetLevel() < 10) ? (Building.GetIncreaseLevelCost().ToNumber() + "$") : "Max"));
		if (!CharDisplay.HasRelax)
		{
			StabilityRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update(PanelTitle.GetTitle("Durability", Building.GetGlobalInfo().StabilityLevel + 1), "", "Each working peon reduces durability by 1. At zero, building is destroyed and:\n\n+" + BaseBuildingPanel.FormatPercentage(GameController.Instance.GetStabilityDestroyPercentage()) + "$ spent turned to trash\n+" + Building.YellowShardCountWhenDurabilityDown() + " yellow shard\n+" + 500 + " max durability\n+1 TP for all training buildings", Building.GetGlobalInfo().GetMaxStability() - Building.GetStability() + "/" + Building.GetGlobalInfo().GetMaxStability() + " Durability"));
		}
		else
		{
			StabilityRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update(PanelTitle.GetTitle("Durability", Building.GetGlobalInfo().StabilityLevel + 1), "", "Each working peon reduces durability by 1. At zero:\n\n+" + Building.YellowShardCountWhenDurabilityDown() + " yellow shard\n+" + 500 + " max durability\n+1 TP for all training buildings", Building.GetGlobalInfo().GetMaxStability() - Building.GetStability() + "/" + Building.GetGlobalInfo().GetMaxStability() + " Durability"));
		}
		ThrowOutputRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Throw", "", "Output pipe pointing up will throw trash into the hole.", Building.HasThrowOutputAttribute.IsEnabled ? "Max" : (Building.ReduceWithTrainingPeon(Building.HasThrowOutputAttribute.GetCost()).ToNumber() + "$")));
		AutoDeviceRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Auto Device", "", "If the device was executed once for any building of the same type, the device will run automatically.", Building.HasAutoDeviceAttribute.IsEnabled ? "Max" : (Building.ReduceWithTrainingPeon(Building.HasAutoDeviceAttribute.GetCost()).ToNumber() + "$")));
		SpeedRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Speed", Training.GlobalInfo.SpeedAttribute.Level + "/" + Building.GetMaxTrainingLevel(), "Assign workers to train.\n\n+10% peon walking speed when happy", Training.GlobalInfo.SpeedAttribute.Amount + "/" + Training.GlobalInfo.SpeedAttribute.GetCost()));
		CarryRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Carry", Training.GlobalInfo.CarryAttribute.Level + "/" + Building.GetMaxTrainingLevel(), "Assign workers to train.\n\nUnlocked at level " + (_carryUnlockLevel + 1) + "\n+1 peon carry limit", Training.GlobalInfo.CarryAttribute.Amount + "/" + Training.GlobalInfo.CarryAttribute.GetCost()));
		MiningRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Mining", Training.GlobalInfo.MiningAttribute.Level + "/" + Building.GetMaxTrainingLevel(), "Assign workers to train.\n\nUnlocked at level " + (_miningUnlockLevel + 1) + "\n+1 peon mining power", Training.GlobalInfo.MiningAttribute.Amount + "/" + Training.GlobalInfo.MiningAttribute.GetCost()));
		ReduceCostRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Rebate", Training.GlobalInfo.ReduceCostAttribute.Level + "/" + Building.GetMaxTrainingLevel(), "Assign workers to train.\n\nUnlocked at level " + (_reduceCostUnlockLevel + 1) + "\n+1% building upgrade cost reduction per peon in building", Training.GlobalInfo.ReduceCostAttribute.Amount + "/" + Training.GlobalInfo.ReduceCostAttribute.GetCost()));
		WorkerRow.SetTooltip("Worker", "Add or remove peon worker to operate the building.");
		DestroyButton.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Destroy", "", "Destroy building and give back " + BaseBuildingPanel.FormatPercentage(GameController.Instance.GetManualDestroyPercentage()) + " of money spent in trash.", ""));
		OverflowRow.SetTooltip("Overflow", "Too much trash in front to continue the work.");
		LevelRow.ButtonPressEvent += LevelRowPress;
		CarryRow.ButtonPressEvent += CarryRowPress;
		SpeedRow.ButtonPressEvent += SpeedRowPress;
		MiningRow.ButtonPressEvent += MiningRowPress;
		ReduceCostRow.ButtonPressEvent += ReduceCostRowPress;
		ThrowOutputRow.ButtonPressEvent += ThrowOutputRowPress;
		AutoDeviceRow.ButtonPressEvent += AutoDeviceRowPress;
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
		WorkerRow.SetValue(Building.Workers.Count + "/" + Building.GetMaximumWorker());
		StabilityRow.SetForStability(Building.GetStabilityPercentage());
		LevelRow.SetForLevelUp(Building);
		SpeedRow.SetForTraining("Speed", Training.GlobalInfo.SpeedAttribute, Building.CurrentTraining == Training.TrainingEnum.Speed, Building.IsMaxTraining(Training.TrainingEnum.Speed));
		CarryRow.SetForTraining("Carry", Training.GlobalInfo.CarryAttribute, Building.CurrentTraining == Training.TrainingEnum.Carry, Building.IsMaxTraining(Training.TrainingEnum.Carry));
		MiningRow.SetForTraining("Mining", Training.GlobalInfo.MiningAttribute, Building.CurrentTraining == Training.TrainingEnum.Mining, Building.IsMaxTraining(Training.TrainingEnum.Mining));
		ReduceCostRow.SetForTraining("Rebate", Training.GlobalInfo.ReduceCostAttribute, Building.CurrentTraining == Training.TrainingEnum.ReduceCost, Building.IsMaxTraining(Training.TrainingEnum.ReduceCost));
		if (Building.GetLevel() <= _carryUnlockLevel)
		{
			CarryRow.SetState(MixedRow.StateEnum.NoButton);
		}
		if (Building.GetLevel() <= _miningUnlockLevel)
		{
			MiningRow.SetState(MixedRow.StateEnum.NoButton);
		}
		if (Building.GetLevel() <= _reduceCostUnlockLevel)
		{
			ReduceCostRow.SetState(MixedRow.StateEnum.NoButton);
		}
		ThrowOutputRow.SetForUpgrade(Building, Building.HasThrowOutputAttribute);
		AutoDeviceRow.SetForUpgrade(Building, Building.HasAutoDeviceAttribute);
		if (!FreezeScale)
		{
			PanelHelper.SetSize(this);
		}
	}

	public void LevelRowPress(object o, EventArgs e)
	{
		TryIncreaseLevel(Building);
	}

	public void CarryRowPress(object o, EventArgs e)
	{
		Building.ToggleTraining(Training.TrainingEnum.Carry);
	}

	public void SpeedRowPress(object o, EventArgs e)
	{
		Building.ToggleTraining(Training.TrainingEnum.Speed);
	}

	public void MiningRowPress(object o, EventArgs e)
	{
		Building.ToggleTraining(Training.TrainingEnum.Mining);
	}

	public void ReduceCostRowPress(object o, EventArgs e)
	{
		Building.ToggleTraining(Training.TrainingEnum.ReduceCost);
	}

	public void ThrowOutputRowPress(object o, EventArgs e)
	{
		TryEnableAttribute(Building, Building.HasThrowOutputAttribute);
	}

	public void AutoDeviceRowPress(object o, EventArgs e)
	{
		TryEnableAttribute(Building, Building.HasAutoDeviceAttribute);
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

	public static string GetTooltip(Training building, bool forNextLevel = false)
	{
		string text = "";
		if (!forNextLevel)
		{
			text = "Assign workers to different tasks to improve peons' abilities.\n\n";
		}
		int num = ((!(building == null)) ? building.GetLevel() : 0);
		if (forNextLevel)
		{
			num++;
		}
		if (num == 0)
		{
			text = text + "Training Point: " + Training.GlobalInfo.GetTPPerWorker() + " per worker\n";
			text = text + "Trash Produced: " + Training.GlobalInfo.GetDefaultOutputPerCycle() + " per worker\n";
			text = text + "Trash Value: " + Training.GlobalInfo.GetDefaultGarbageSize() + "$ per level\n";
			text = text + "Cloud Rate: " + BaseBuildingPanel.FormatPercentage(GameController.Instance.GetCloudChance()) + " per worker\n";
		}
		else if (!forNextLevel)
		{
			text = text + "Training Point: " + building.GetTPGained() + "\n";
			text = text + "Trash Produced: " + building.GetGarbageOutputCount() + " per worker\n";
			text = text + "Trash Value: " + building.GetGarbageSize() + "$\n";
			text = text + "Cloud Rate: " + BaseBuildingPanel.FormatPercentage(building.GetCloudChance()) + "\n";
		}
		else
		{
			text = text + "+" + Training.GlobalInfo.GetDefaultGarbageSize() + "$ trash value\n";
			if (num == 3 || num == 5 || num == 7 || num == 9)
			{
				text += "+1 floor\n+1 max worker\n";
			}
		}
		return text;
	}
}
