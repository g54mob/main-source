using System;
using TMPro;

public class CatapultPanel : BaseBuildingPanel
{
	public ColumnController PanelColumn;

	public PanelTitle Title;

	public MixedRow StabilityRow;

	public MixedRow LevelRow;

	public MixedRow LVacuumRow;

	public MixedRow RVacuumRow;

	public MixedRow MoreStorageRow;

	public MixedRow ThrowMoreRow;

	public MixedRow BanPeonRow;

	public WorkerRow WorkerRow;

	public PanelButtonTooltip DestroyButton;

	private Catapult Building => (Catapult)PanelColumn.Buildings;

	private void Start()
	{
		Title.Initialize(base.gameObject, "Catapult");
		StabilityRow.Initialize(base.gameObject, MixedRow.StateEnum.NoButton, "Durability");
		LevelRow.Initialize(base.gameObject, MixedRow.StateEnum.Full, "Level");
		LVacuumRow.Initialize(base.gameObject, MixedRow.StateEnum.NoValue, "L. Vacuum");
		RVacuumRow.Initialize(base.gameObject, MixedRow.StateEnum.NoValue, "R. Vacuum");
		MoreStorageRow.Initialize(base.gameObject, MixedRow.StateEnum.NoValue, "Storage+");
		ThrowMoreRow.Initialize(base.gameObject, MixedRow.StateEnum.NoValue, "Throw+");
		BanPeonRow.Initialize(base.gameObject, MixedRow.StateEnum.NoValue, "Peon Drop");
		WorkerRow.Initialize(base.gameObject, "Worker");
		DestroyButton.Initialize(base.gameObject);
		Title.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Catapult", "Lvl " + Building.GetLevel() + "/10", GetTooltip(Building), ""));
		LevelRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Increase Level", "Lvl " + (Building.GetLevel() + 1), GetTooltip(Building, forNextLevel: true), (Building.GetLevel() < 10) ? (Building.GetIncreaseLevelCost().ToNumber() + "$") : "Max"));
		if (!CharDisplay.HasRelax)
		{
			StabilityRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update(PanelTitle.GetTitle("Durability", Building.GetGlobalInfo().StabilityLevel + 1), "", "Each working peon reduces durability by 1. At zero, building is destroyed and:\n\n+" + BaseBuildingPanel.FormatPercentage(GameController.Instance.GetStabilityDestroyPercentage()) + "$ spent turned to trash\n+" + Building.YellowShardCountWhenDurabilityDown() + " yellow shard\n+" + 500 + " max durability\n+1 trash thrown by all catapults", Building.GetGlobalInfo().GetMaxStability() - Building.GetStability() + "/" + Building.GetGlobalInfo().GetMaxStability() + " Durability"));
		}
		else
		{
			StabilityRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update(PanelTitle.GetTitle("Durability", Building.GetGlobalInfo().StabilityLevel + 1), "", "Each working peon reduces durability by 1. At zero:\n\n+" + Building.YellowShardCountWhenDurabilityDown() + " yellow shard\n+" + 500 + " max durability\n+1 trash thrown by all catapults", Building.GetGlobalInfo().GetMaxStability() - Building.GetStability() + "/" + Building.GetGlobalInfo().GetMaxStability() + " Durability"));
		}
		LVacuumRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Left Vacuum", "<--", "Add a vacuum to the left that will automatically bring trash in and put it in storage. A new worker is needed to operate both vacuum.", Building.HasLeftVacuumAttribute.IsMax ? "Max" : (Building.ReduceWithTrainingPeon(Building.HasLeftVacuumAttribute.GetCost()).ToNumber() + "$")));
		RVacuumRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Right Vacuum", "-->", "Add a vacuum to the right that will automatically bring trash in and put it in storage. A new worker is needed to operate both vacuum.", Building.HasRightVacuumAttribute.IsMax ? "Max" : (Building.ReduceWithTrainingPeon(Building.HasRightVacuumAttribute.GetCost()).ToNumber() + "$")));
		MoreStorageRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Storage+", Building.HasMoreStorageAttribute.Level + "/" + Building.HasMoreStorageAttribute.GetMaxLevel(), "+" + Catapult.GlobalInfo.GetMoreStorageValue() + " max storage", Building.HasMoreStorageAttribute.IsMax ? "Max" : (Building.ReduceWithTrainingPeon(Building.HasMoreStorageAttribute.GetCost()).ToNumber() + "$")));
		ThrowMoreRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Throw+", "", "+1 trash thrown per worker", Building.HasThrowMoreAttribute.IsMax ? "Max" : (Building.ReduceWithTrainingPeon(Building.HasThrowMoreAttribute.GetCost()).ToNumber() + "$")));
		BanPeonRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Status: ", Building.IsBanPeonDrop() ? "Prevent" : "Allow", "Allow or prevent outside peon from dropping trash into the catapult storage.", ""));
		WorkerRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Worker", "", "Add or remove peon worker to operate the building.\n\nEach worker will throw " + Building.GetLauncherAmount() + " trash." + ((Building.HasLeftVacuumAttribute.IsEnabled || Building.HasRightVacuumAttribute.IsEnabled) ? "\nSecond worker will operate the vacuum." : ""), ""));
		DestroyButton.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Destroy", "", "Destroy building and give back " + BaseBuildingPanel.FormatPercentage(GameController.Instance.GetManualDestroyPercentage()) + " of money spent in trash.", ""));
		LevelRow.ButtonPressEvent += LevelRowPress;
		LVacuumRow.ButtonPressEvent += LVacuumRowPress;
		RVacuumRow.ButtonPressEvent += RVacuumRowPress;
		MoreStorageRow.ButtonPressEvent += MoreStorageRowPress;
		ThrowMoreRow.ButtonPressEvent += ThrowMoreRowPress;
		BanPeonRow.ButtonPressEvent += BanPeonRowPress;
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
		Title.UpdateTitleForLevel(Building.GetLevel());
		StabilityRow.SetForStability(Building.GetStabilityPercentage());
		LevelRow.SetForLevelUp(Building);
		LVacuumRow.SetForLevelUpgrade(Building, Building.HasLeftVacuumAttribute);
		RVacuumRow.SetForLevelUpgrade(Building, Building.HasRightVacuumAttribute);
		MoreStorageRow.SetForLevelUpgrade(Building, Building.HasMoreStorageAttribute);
		ThrowMoreRow.SetForLevelUpgrade(Building, Building.HasThrowMoreAttribute);
		if (Building.GetLevel() >= 8 && !Catapult.GlobalInfo.CanMinigunAttribute.IsEnabled)
		{
			LevelRow.SetState(MixedRow.StateEnum.NoButton);
		}
		else if (Building.GetLevel() >= 4 && !Catapult.GlobalInfo.CanCannonAttribute.IsEnabled)
		{
			LevelRow.SetState(MixedRow.StateEnum.NoButton);
		}
		if (Building.IsBanPeonDrop())
		{
			BanPeonRow.SetButton("Prevent");
		}
		else
		{
			BanPeonRow.SetButton("Allow");
		}
		WorkerRow.SetValue(Building.Workers.Count + "/" + Building.GetMaximumWorker());
		if (!FreezeScale)
		{
			PanelHelper.SetSize(this);
		}
	}

	public void LevelRowPress(object o, EventArgs e)
	{
		TryIncreaseLevel(Building);
	}

	public void LVacuumRowPress(object o, EventArgs e)
	{
		if (TryEnableAttribute(Building, Building.HasLeftVacuumAttribute))
		{
			Building.SetDisplay();
		}
	}

	public void RVacuumRowPress(object o, EventArgs e)
	{
		if (TryEnableAttribute(Building, Building.HasRightVacuumAttribute))
		{
			Building.SetDisplay();
		}
	}

	public void MoreStorageRowPress(object o, EventArgs e)
	{
		TryEnableAttribute(Building, Building.HasMoreStorageAttribute);
	}

	public void ThrowMoreRowPress(object o, EventArgs e)
	{
		TryEnableAttribute(Building, Building.HasThrowMoreAttribute);
	}

	public void BanPeonRowPress(object o, EventArgs e)
	{
		if (Building.IsBanPeonDrop())
		{
			Building.BandPeonDrop(mustBand: false);
		}
		else
		{
			Building.BandPeonDrop(mustBand: true);
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

	public static string GetTooltip(Catapult building, bool forNextLevel = false)
	{
		string text = "";
		if (!forNextLevel)
		{
			text = "Peon will drop trash in storage. Workers will throw the trash into the hole.\n\n";
		}
		int num = ((!(building == null)) ? building.GetLevel() : 0);
		if (forNextLevel)
		{
			num++;
		}
		if (num == 0)
		{
			text = text + "Max Storage: " + Catapult.GlobalInfo.StoragePerLevel() + " per level\n";
			text = ((Catapult.GlobalInfo.GetExtraTrashThrowned() != 0) ? (text + "Throw: 1 trash per level for each worker + " + Catapult.GlobalInfo.GetExtraTrashThrowned() + "\n") : (text + "Throw: 1 trash per level for each worker\n"));
		}
		else if (!forNextLevel)
		{
			text = text + "Storage: " + building.GetAmountStored() + "/" + building.GetMaximumStorage() + "\n";
			text = text + "Throw: " + building.GetLauncherAmount() + " trash per worker\n";
		}
		else
		{
			text = text + "+" + Catapult.GlobalInfo.StoragePerLevel() + " max storage\n";
			text += "+1 thrown trash per worker\n";
			if (num == 3 || num == 5 || num == 7 || num == 9)
			{
				text += "+1 floor\n+1 max worker\n";
			}
			if (num == 5 || num == 7)
			{
				text += "Cannon needed\n";
			}
			if (num == 9)
			{
				text += "Minigun needed\n";
			}
		}
		return text;
	}
}
