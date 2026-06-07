using System;
using TMPro;

public class HotAirStationPanel : BaseBuildingPanel
{
	public ColumnController PanelColumn;

	public PanelTitle Title;

	public MixedRow OverflowRow;

	public MixedRow StabilityRow;

	public MixedRow LevelRow;

	public MixedRow MoveLeftRow;

	public MixedRow ThrowOutputRow;

	public MixedRow AutoDeviceRow;

	public WorkerRow WorkerRow;

	public PanelButtonTooltip DestroyButton;

	private HotAirStation Building => (HotAirStation)PanelColumn.Buildings;

	private void Start()
	{
		Title.Initialize(base.gameObject, LanguageText.GetText("Hangar"));
		OverflowRow.Initialize(base.gameObject, MixedRow.StateEnum.NoButton, "Overflow!");
		StabilityRow.Initialize(base.gameObject, MixedRow.StateEnum.NoButton, "Durability");
		LevelRow.Initialize(base.gameObject, MixedRow.StateEnum.Full, "Level");
		MoveLeftRow.Initialize(base.gameObject, MixedRow.StateEnum.Full, "Move Left");
		ThrowOutputRow.Initialize(base.gameObject, MixedRow.StateEnum.Full, "Throw");
		AutoDeviceRow.Initialize(base.gameObject, MixedRow.StateEnum.NoValue, "Auto Dev.");
		WorkerRow.Initialize(base.gameObject, "Worker");
		DestroyButton.Initialize(base.gameObject);
		Title.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update(LanguageText.GetText("Hangar"), "Lvl " + Building.GetLevel() + "/10", GetTooltip(Building), ""));
		LevelRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Increase Level", "Lvl " + (Building.GetLevel() + 1), GetTooltip(Building, forNextLevel: true), (Building.GetLevel() < 10) ? (Building.GetIncreaseLevelCost().ToNumber() + "$") : "Max"));
		if (!CharDisplay.HasRelax)
		{
			StabilityRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update(PanelTitle.GetTitle("Durability", Building.GetGlobalInfo().StabilityLevel + 1), "", "Each working peon reduces durability by 1. At zero, building is destroyed and:\n\n+" + BaseBuildingPanel.FormatPercentage(GameController.Instance.GetStabilityDestroyPercentage()) + "$ spent turned to trash\n+" + Building.YellowShardCountWhenDurabilityDown() + " yellow" + DurabilityRedShardText() + " shard\n+" + 500 + " max durability\n+1 trash produced by all hangars", Building.GetGlobalInfo().GetMaxStability() - Building.GetStability() + "/" + Building.GetGlobalInfo().GetMaxStability() + " Durability"));
		}
		else
		{
			StabilityRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update(PanelTitle.GetTitle("Durability", Building.GetGlobalInfo().StabilityLevel + 1), "", "Each working peon reduces durability by 1. At zero:\n\n+" + Building.YellowShardCountWhenDurabilityDown() + " yellow" + DurabilityRedShardText() + " shard\n+" + 500 + " max durability\n+1 trash produced by all hangars", Building.GetGlobalInfo().GetMaxStability() - Building.GetStability() + "/" + Building.GetGlobalInfo().GetMaxStability() + " Durability"));
		}
		MoveLeftRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Move Left", Building.HasMoveLeftAttribute.Level + "/" + Building.HasMoveLeftAttribute.GetMaxLevel(), "Balloon will move more to the left.", Building.HasMoveLeftAttribute.IsMax ? "Max" : (Building.ReduceWithTrainingPeon(Building.HasMoveLeftAttribute.GetCost()).ToNumber() + "$")));
		ThrowOutputRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Throw", "", "Output pipe pointing up will throw trash into the hole.", Building.HasThrowOutputAttribute.IsEnabled ? "Max" : (Building.ReduceWithTrainingPeon(Building.HasThrowOutputAttribute.GetCost()).ToNumber() + "$")));
		AutoDeviceRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Auto Device", "", "If the device was executed once for any building of the same type, the device will run automatically.", Building.HasAutoDeviceAttribute.IsEnabled ? "Max" : (Building.ReduceWithTrainingPeon(Building.HasAutoDeviceAttribute.GetCost()).ToNumber() + "$")));
		WorkerRow.SetTooltip("Worker", "Add or remove peon worker to operate the building.\n\nEach worker will increase the speed of the balloon by 10%.");
		DestroyButton.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Destroy", "", "Destroy building and give back " + BaseBuildingPanel.FormatPercentage(GameController.Instance.GetManualDestroyPercentage()) + " of money spent in trash.", ""));
		OverflowRow.SetTooltip("Overflow", "Too much trash in front to continue the work.");
		LevelRow.ButtonPressEvent += LevelRowPress;
		MoveLeftRow.ButtonPressEvent += MoveLeftRowPress;
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
		LevelRow.SetForLevelUp(Building);
		if (Building.GetLevel() >= 6 && !HotAirStation.GlobalInfo.CanMoreBaloonAttribute.IsEnabled)
		{
			LevelRow.SetState(MixedRow.StateEnum.NoButton);
		}
		WorkerRow.SetValue(Building.Workers.Count + "/" + Building.GetMaximumWorker());
		StabilityRow.SetForStability(Building.GetStabilityPercentage());
		MoveLeftRow.SetForLevelUpgrade(Building, Building.HasMoveLeftAttribute);
		ThrowOutputRow.SetForUpgrade(Building, Building.HasThrowOutputAttribute);
		AutoDeviceRow.SetForUpgrade(Building, Building.HasAutoDeviceAttribute);
		SetPanelHeight();
		if (!FreezeScale)
		{
			PanelHelper.SetSize(this);
		}
	}

	public void LevelRowPress(object o, EventArgs e)
	{
		TryIncreaseLevel(Building);
	}

	public void MoveLeftRowPress(object o, EventArgs e)
	{
		TryEnableAttribute(Building, Building.HasMoveLeftAttribute);
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

	public static string GetTooltip(HotAirStation building, bool forNextLevel = false)
	{
		string text = "";
		if (!forNextLevel)
		{
			text = "Fly balloons, picking up trash and dropping it back into the hole.\n\n";
		}
		int num = ((!(building == null)) ? building.GetLevel() : 0);
		if (forNextLevel)
		{
			num++;
		}
		if (num == 0)
		{
			text = text + "Trash Produced: " + HotAirStation.GlobalInfo.GetDefaultOutputPerCycle() + " per worker\n";
			text = text + "Trash Value: " + HotAirStation.GlobalInfo.GetDefaultGarbageSize() + "$ per level\n";
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
			text = text + "+" + HotAirStation.GlobalInfo.GetDefaultGarbageSize() + "$ trash value\n";
			if (num == 3 || num == 5 || num == 7 || num == 9)
			{
				text += "+1 floor\n+1 max worker\n";
			}
			if (num == 7)
			{
				text += "Extra balloon needed\n";
			}
		}
		return text;
	}

	protected override int GetRowCount()
	{
		return 0 + (OverflowRow.gameObject.activeSelf ? 1 : 0) + (StabilityRow.gameObject.activeSelf ? 1 : 0) + (LevelRow.gameObject.activeSelf ? 1 : 0) + (MoveLeftRow.gameObject.activeSelf ? 1 : 0) + (ThrowOutputRow.gameObject.activeSelf ? 1 : 0) + (AutoDeviceRow.gameObject.activeSelf ? 1 : 0) + (WorkerRow.gameObject.activeSelf ? 1 : 0);
	}

	private string DurabilityRedShardText()
	{
		if (Building.GetGlobalInfo().TotalEvilCount > 0 && Building.GetGlobalInfo().EvilExplosionCount == 0 && Installation.CanGenerateEvilGarbage())
		{
			return ", +1 red";
		}
		return "";
	}
}
