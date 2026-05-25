using System;
using TMPro;

public class CompressorPanel : BaseBuildingPanel
{
	public ColumnController PanelColumn;

	public PanelTitle Title;

	public MixedRow OverflowRow;

	public MixedRow StabilityRow;

	public MixedRow LevelRow;

	public MixedRow CatchRow;

	public MixedRow ThrowOutputRow;

	public MixedRow AutoDeviceRow;

	public MixedRow LVacuumRow;

	public MixedRow RVacuumRow;

	public MixedRow MoreStorageRow;

	public MixedRow BanPeonRow;

	public WorkerRow WorkerRow;

	public PanelButtonTooltip DestroyButton;

	private Compressor Building => (Compressor)PanelColumn.Buildings;

	private void Start()
	{
		Title.Initialize(base.gameObject, "Compressor");
		OverflowRow.Initialize(base.gameObject, MixedRow.StateEnum.NoButton, "Overflow!");
		StabilityRow.Initialize(base.gameObject, MixedRow.StateEnum.NoButton, "Durability");
		LevelRow.Initialize(base.gameObject, MixedRow.StateEnum.Full, "Level");
		CatchRow.Initialize(base.gameObject, MixedRow.StateEnum.Full, "Capture");
		ThrowOutputRow.Initialize(base.gameObject, MixedRow.StateEnum.Full, "Throw");
		AutoDeviceRow.Initialize(base.gameObject, MixedRow.StateEnum.NoValue, "Auto Dev.");
		LVacuumRow.Initialize(base.gameObject, MixedRow.StateEnum.Full, "L. Vacuum");
		RVacuumRow.Initialize(base.gameObject, MixedRow.StateEnum.Full, "R. Vacuum");
		MoreStorageRow.Initialize(base.gameObject, MixedRow.StateEnum.Full, "Storage+");
		BanPeonRow.Initialize(base.gameObject, MixedRow.StateEnum.NoValue, "Peon Drop");
		WorkerRow.Initialize(base.gameObject, "Worker");
		DestroyButton.Initialize(base.gameObject);
		Title.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Compressor", "Lvl " + Building.GetLevel() + "/10", GetTooltip(Building), ""));
		LevelRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Increase Level", "Lvl " + (Building.GetLevel() + 1), GetTooltip(Building, forNextLevel: true), (Building.GetLevel() < 10) ? (Building.GetIncreaseLevelCost().ToNumber() + "$") : "Max"));
		if (!CharDisplay.HasRelax)
		{
			StabilityRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update(PanelTitle.GetTitle("Durability", Building.GetGlobalInfo().StabilityLevel + 1), "", "Each working peon reduces durability by 1. At zero, building is destroyed and:\n\n+" + BaseBuildingPanel.FormatPercentage(GameController.Instance.GetStabilityDestroyPercentage()) + "$ spent turned to trash\n+" + Building.YellowShardCountWhenDurabilityDown() + " yellow shard\n+" + 500 + " max durability\n+" + BaseBuildingPanel.FormatPercentage(Compressor.GlobalInfo.ADDED_STABILITY_PERC) + " to compressed trash value for all compressors", Building.GetGlobalInfo().GetMaxStability() - Building.GetStability() + "/" + Building.GetGlobalInfo().GetMaxStability() + " Durability"));
		}
		else
		{
			StabilityRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update(PanelTitle.GetTitle("Durability", Building.GetGlobalInfo().StabilityLevel + 1), "", "Each working peon reduces durability by 1. At zero:\n\n+" + Building.YellowShardCountWhenDurabilityDown() + " yellow shard\n+" + 500 + " max durability\n+" + BaseBuildingPanel.FormatPercentage(Compressor.GlobalInfo.ADDED_STABILITY_PERC) + " to compressed trash value for all compressors", Building.GetGlobalInfo().GetMaxStability() - Building.GetStability() + "/" + Building.GetGlobalInfo().GetMaxStability() + " Durability"));
		}
		CatchRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Capture", "", "Catch flying trash being thrown from the left.", Building.HasCatchAttribute.IsEnabled ? "Max" : (Building.ReduceWithTrainingPeon(Building.HasCatchAttribute.GetCost()).ToNumber() + "$")));
		ThrowOutputRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Throw", "", "Output pipe pointing up will throw trash into the hole.", Building.HasThrowOutputAttribute.IsEnabled ? "Max" : (Building.ReduceWithTrainingPeon(Building.HasThrowOutputAttribute.GetCost()).ToNumber() + "$")));
		AutoDeviceRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Auto Device", "", "If the device was executed once for any building of the same type, the device will run automatically.", Building.HasAutoDeviceAttribute.IsEnabled ? "Max" : (Building.ReduceWithTrainingPeon(Building.HasAutoDeviceAttribute.GetCost()).ToNumber() + "$")));
		LVacuumRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Left Vacuum", "<--", "Add a vacuum to the left that will automatically bring trash in and put it in storage. A new worker is needed to operate both vacuum.", Building.HasLeftVacuumAttribute.IsMax ? "Max" : (Building.ReduceWithTrainingPeon(Building.HasLeftVacuumAttribute.GetCost()).ToNumber() + "$")));
		RVacuumRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Right Vacuum", "-->", "Add a vacuum to the right that will automatically bring trash in and put it in storage. A new worker is needed to operate both vacuum.", Building.HasRightVacuumAttribute.IsMax ? "Max" : (Building.ReduceWithTrainingPeon(Building.HasRightVacuumAttribute.GetCost()).ToNumber() + "$")));
		MoreStorageRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Storage+", Building.HasMoreStorageAttribute.Level + "/" + Building.HasMoreStorageAttribute.GetMaxLevel(), "+" + Compressor.GlobalInfo.GetMoreStorageValue() + " max storage", Building.HasMoreStorageAttribute.IsMax ? "Max" : (Building.ReduceWithTrainingPeon(Building.HasMoreStorageAttribute.GetCost()).ToNumber() + "$")));
		BanPeonRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Status: ", Building.IsBanPeonDrop() ? "Prevent" : "Allow", "Allow or prevent outside peon from dropping trash into the catapult storage.", ""));
		WorkerRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Worker", "", "Add or remove peon worker to operate the building." + ((Building.HasLeftVacuumAttribute.IsEnabled || Building.HasRightVacuumAttribute.IsEnabled) ? " Second worker will operate the vacuum." : ("\n\nEach worker will\n+1 compressed trash\n-1 Durability\n+" + Compressor.GlobalInfo.GetDefaultOutputPerCycle() + " output trash\n+" + BaseBuildingPanel.FormatPercentage(GameController.Instance.GetCloudChance()) + " cloud produced")), ""));
		DestroyButton.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Destroy", "", "Destroy building and give back " + BaseBuildingPanel.FormatPercentage(GameController.Instance.GetManualDestroyPercentage()) + " of money spent in trash.", ""));
		OverflowRow.SetTooltip("Overflow", "Too much trash in front to continue the work.");
		LevelRow.ButtonPressEvent += LevelRowPress;
		CatchRow.ButtonPressEvent += CatchRowPress;
		ThrowOutputRow.ButtonPressEvent += ThrowOutputRowPress;
		AutoDeviceRow.ButtonPressEvent += AutoDeviceRowPress;
		LVacuumRow.ButtonPressEvent += LVacuumRowPress;
		RVacuumRow.ButtonPressEvent += RVacuumRowPress;
		MoreStorageRow.ButtonPressEvent += MoreStorageRowPress;
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
		OverflowRow.gameObject.SetActive(Building.GarbageCounter.IsOverLimit);
		Title.UpdateTitleForLevel(Building.GetLevel());
		WorkerRow.SetValue(Building.Workers.Count + "/" + Building.GetMaximumWorker());
		StabilityRow.SetForStability(Building.GetStabilityPercentage());
		LevelRow.SetForLevelUp(Building);
		CatchRow.SetForUpgrade(Building, Building.HasCatchAttribute);
		ThrowOutputRow.SetForUpgrade(Building, Building.HasThrowOutputAttribute);
		AutoDeviceRow.SetForUpgrade(Building, Building.HasAutoDeviceAttribute);
		LVacuumRow.SetForLevelUpgrade(Building, Building.HasLeftVacuumAttribute);
		RVacuumRow.SetForLevelUpgrade(Building, Building.HasRightVacuumAttribute);
		MoreStorageRow.SetForLevelUpgrade(Building, Building.HasMoreStorageAttribute);
		if (Building.IsBanPeonDrop())
		{
			BanPeonRow.SetButton("Prevent");
		}
		else
		{
			BanPeonRow.SetButton("Allow");
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

	public void CatchRowPress(object o, EventArgs e)
	{
		TryEnableAttribute(Building, Building.HasCatchAttribute);
	}

	public void ThrowOutputRowPress(object o, EventArgs e)
	{
		TryEnableAttribute(Building, Building.HasThrowOutputAttribute);
	}

	public void AutoDeviceRowPress(object o, EventArgs e)
	{
		TryEnableAttribute(Building, Building.HasAutoDeviceAttribute);
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

	public void CanCaptureFlyingRowPress(object o, EventArgs e)
	{
		TryEnableAttribute(Compressor.GlobalInfo.CanCaptureFlyingAttribute);
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

	public static string GetTooltip(Compressor building, bool forNextLevel = false)
	{
		string text = "";
		if (Compressor.GlobalInfo.CanCompressFromCompressorAttribute.IsEnabled)
		{
			if (!forNextLevel)
			{
				text = "Take " + Compressor.GlobalInfo.GetInputAmount() + " trash and produce a bigger one with more value.\n\n";
			}
		}
		else if (!forNextLevel)
		{
			text = "Take " + Compressor.GlobalInfo.GetInputAmount() + " trash, that was not compressed, and produce a bigger one with more value.\n\n";
		}
		int num = ((!(building == null)) ? building.GetLevel() : 0);
		if (forNextLevel)
		{
			num++;
		}
		if (num == 0)
		{
			text = text + "Trash Produced: " + Compressor.GlobalInfo.GetDefaultOutputPerCycle() + " per worker\n";
			text = text + "Trash Value: " + Compressor.GlobalInfo.GetDefaultGarbageSize() + "$ per level\n";
			text = text + "Cloud Rate: " + BaseBuildingPanel.FormatPercentage(GameController.Instance.GetCloudChance()) + " per worker\n";
		}
		else if (!forNextLevel)
		{
			text = text + "Compress: " + building.GetCompressedCount() + " trash\n";
			text = text + "Compress: +" + BaseBuildingPanel.FormatPercentage(building.GetWeightBoost()) + " value\n";
			text = text + "Trash Produced: " + building.GetGarbageOutputCount() + "\n";
			text = text + "Trash Value: " + building.GetGarbageSize() + "$\n";
			text = text + "Cloud Rate: " + BaseBuildingPanel.FormatPercentage(building.GetCloudChance()) + "\n";
		}
		else
		{
			text = text + "+" + Compressor.GlobalInfo.GetDefaultGarbageSize() + "$ trash value\n";
			if (num == 3 || num == 5 || num == 7 || num == 9)
			{
				text += "+1 floor\n+1 max worker\n";
			}
		}
		return text;
	}
}
