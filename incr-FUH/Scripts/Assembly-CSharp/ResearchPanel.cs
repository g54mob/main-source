using System;
using TMPro;

public class ResearchPanel : BaseBuildingPanel
{
	public ColumnController PanelColumn;

	public PanelTitle Title;

	public MixedRow OverflowRow;

	public MixedRow StabilityRow;

	public MixedRow LevelRow;

	public MixedRow ThrowOutputRow;

	public MixedRow AutoDeviceRow;

	public WorkerRow WorkerRow;

	public PanelButtonTooltip DestroyButton;

	private Research Building => (Research)PanelColumn.Buildings;

	private void Start()
	{
		Title.Initialize(base.gameObject, "Research Lab");
		OverflowRow.Initialize(base.gameObject, MixedRow.StateEnum.NoButton, "Overflow!");
		StabilityRow.Initialize(base.gameObject, MixedRow.StateEnum.NoButton, "Durability");
		LevelRow.Initialize(base.gameObject, MixedRow.StateEnum.Full, "Level");
		ThrowOutputRow.Initialize(base.gameObject, MixedRow.StateEnum.NoValue, "Throw");
		AutoDeviceRow.Initialize(base.gameObject, MixedRow.StateEnum.NoValue, "Auto Dev.");
		WorkerRow.Initialize(base.gameObject, "Worker");
		DestroyButton.Initialize(base.gameObject);
		Title.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update(LanguageText.GetText("Research Lab"), "Lvl " + Building.GetLevel() + "/10", GetTooltip(Building), ""));
		LevelRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Increase Level", "Lvl " + (Building.GetLevel() + 1), GetTooltip(Building, forNextLevel: true), (Building.GetLevel() < 10) ? (Building.GetIncreaseLevelCost().ToNumber() + "$") : "Max"));
		if (!CharDisplay.HasRelax)
		{
			StabilityRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update(PanelTitle.GetTitle("Durability", Building.GetGlobalInfo().StabilityLevel + 1), "", "Each working peon reduces durability by 1. At zero, building is destroyed and:\n\n+" + BaseBuildingPanel.FormatPercentage(GameController.Instance.GetStabilityDestroyPercentage()) + "$ spent turned to trash\n+" + Building.YellowShardCountWhenDurabilityDown() + " yellow" + DurabilityRedShardText() + " shard\n+" + 500 + " max durability\n+1 RP for all research labs", Building.GetGlobalInfo().GetMaxStability() - Building.GetStability() + "/" + Building.GetGlobalInfo().GetMaxStability() + " Durability"));
		}
		else
		{
			StabilityRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update(PanelTitle.GetTitle("Durability", Building.GetGlobalInfo().StabilityLevel + 1), "", "Each working peon reduces durability by 1. At zero:\n\n+" + Building.YellowShardCountWhenDurabilityDown() + " yellow" + DurabilityRedShardText() + " shard\n+" + 500 + " max durability\n+1 RP for all research labs", Building.GetGlobalInfo().GetMaxStability() - Building.GetStability() + "/" + Building.GetGlobalInfo().GetMaxStability() + " Durability"));
		}
		ThrowOutputRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Throw", "", "Output pipe pointing up will throw trash into the hole.", Building.HasThrowOutputAttribute.IsEnabled ? "Max" : (Building.ReduceWithTrainingPeon(Building.HasThrowOutputAttribute.GetCost()).ToNumber() + "$")));
		AutoDeviceRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Auto Device", "", "If the device was executed once for any building of the same type, the device will run automatically.", Building.HasAutoDeviceAttribute.IsEnabled ? "Max" : (Building.ReduceWithTrainingPeon(Building.HasAutoDeviceAttribute.GetCost()).ToNumber() + "$")));
		WorkerRow.SetTooltip("Worker", "Add or remove peon worker to operate the building.\n\n+1 RP per worker");
		DestroyButton.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Destroy", "", "Destroy building and give back " + BaseBuildingPanel.FormatPercentage(GameController.Instance.GetManualDestroyPercentage()) + " of money spent in trash.", ""));
		OverflowRow.SetTooltip("Overflow", "Too much trash in front to continue the work.");
		LevelRow.ButtonPressEvent += LevelRowPress;
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

	public static string GetTooltip(Research building, bool forNextLevel = false)
	{
		string text = "";
		if (!forNextLevel)
		{
			text = "Peon will do research and generate RP (research point).\n\n";
		}
		int num = ((!(building == null)) ? building.GetLevel() : 0);
		if (forNextLevel)
		{
			num++;
		}
		if (num == 0)
		{
			text = text + "RP Gained: " + Research.GlobalInfo.GetRPGenerated() + " per worker\n";
			text = text + "Trash Produced: " + Research.GlobalInfo.GetDefaultOutputPerCycle() + " per worker\n";
			text = text + "Trash Value: " + Research.GlobalInfo.GetDefaultGarbageSize() + "$ per level\n";
			text = text + "Cloud Rate: " + BaseBuildingPanel.FormatPercentage(GameController.Instance.GetCloudChance()) + " per worker\n";
		}
		else if (!forNextLevel)
		{
			text = text + "RP Gained: " + building.GetRPPRoduce() + "\n";
			text = text + "Trash Produced: " + building.GetGarbageOutputCount() + " per worker\n";
			text = text + "Trash Value: " + building.GetGarbageSize() + "$\n";
			text = text + "Cloud Rate: " + BaseBuildingPanel.FormatPercentage(building.GetCloudChance()) + "\n";
		}
		else
		{
			text = text + "+" + Research.GlobalInfo.GetDefaultGarbageSize() + "$ trash value\n";
			if (num == 3 || num == 5 || num == 7 || num == 9)
			{
				text += "+1 floor\n+1 max worker\n";
			}
			if (num == 5 || num == 9)
			{
				text += "Extra drone needed\n";
			}
		}
		return text;
	}

	protected override int GetRowCount()
	{
		return 0 + (OverflowRow.gameObject.activeSelf ? 1 : 0) + (StabilityRow.gameObject.activeSelf ? 1 : 0) + (LevelRow.gameObject.activeSelf ? 1 : 0) + (ThrowOutputRow.gameObject.activeSelf ? 1 : 0) + (AutoDeviceRow.gameObject.activeSelf ? 1 : 0) + (WorkerRow.gameObject.activeSelf ? 1 : 0);
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
