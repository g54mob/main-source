using System;
using TMPro;

public class HousePanel : BaseBuildingPanel
{
	public ColumnController PanelColumn;

	public PanelTitle Title;

	public MixedRow StabilityRow;

	public MixedRow RowLevel;

	public MixedRow ThrowOutputRow;

	public MixedRow AutoDeviceRow;

	public PanelButtonTooltip DestroyButton;

	private House Building => (House)PanelColumn.Buildings;

	private void Start()
	{
		Title.Initialize(base.gameObject, LanguageText.GetText("House"));
		StabilityRow.Initialize(base.gameObject, MixedRow.StateEnum.NoButton, "Durability");
		RowLevel.Initialize(base.gameObject, MixedRow.StateEnum.Full, "Level");
		ThrowOutputRow.Initialize(base.gameObject, MixedRow.StateEnum.Full, "Throw");
		AutoDeviceRow.Initialize(base.gameObject, MixedRow.StateEnum.NoValue, "Auto Dev.");
		DestroyButton.Initialize(base.gameObject);
		Title.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update(LanguageText.GetText("House"), "Lvl " + Building.GetLevel() + "/10", GetTooltip(Building), ""));
		RowLevel.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Increase Level", "Lvl " + (Building.GetLevel() + 1), GetTooltip(Building, forNextLevel: true), (Building.GetLevel() < 10) ? (Building.GetIncreaseLevelCost().ToNumber() + "$") : "Max"));
		if (!CharDisplay.HasRelax)
		{
			StabilityRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update(PanelTitle.GetTitle("Durability", Building.GetGlobalInfo().StabilityLevel + 1), "", "Each working peon reduces durability by 1. At zero, building is destroyed and:\n\n+" + BaseBuildingPanel.FormatPercentage(GameController.Instance.GetStabilityDestroyPercentage()) + "$ spent turned to trash\n+" + Building.YellowShardCountWhenDurabilityDown() + " yellow" + DurabilityRedShardText() + " shard\n+" + 500 + " max durability\n+1 trash produced by all houses", Building.GetGlobalInfo().GetMaxStability() - Building.GetStability() + "/" + Building.GetGlobalInfo().GetMaxStability() + " Durability"));
		}
		else
		{
			StabilityRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update(PanelTitle.GetTitle("Durability", Building.GetGlobalInfo().StabilityLevel + 1), "", "Each working peon reduces durability by 1. At zero:\n\n+" + Building.YellowShardCountWhenDurabilityDown() + " yellow" + DurabilityRedShardText() + " shard\n+" + 500 + " max durability\n+1 trash produced by all houses", Building.GetGlobalInfo().GetMaxStability() - Building.GetStability() + "/" + Building.GetGlobalInfo().GetMaxStability() + " Durability"));
		}
		ThrowOutputRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Throw", "", "Output pipe pointing up will throw trash into the hole.", Building.HasThrowOutputAttribute.IsEnabled ? "Max" : (Building.ReduceWithTrainingPeon(Building.HasThrowOutputAttribute.GetCost()).ToNumber() + "$")));
		AutoDeviceRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Auto Device", "", "If the device was executed once for any building of the same type, the device will run automatically.", Building.HasAutoDeviceAttribute.IsEnabled ? "Max" : (Building.ReduceWithTrainingPeon(Building.HasAutoDeviceAttribute.GetCost()).ToNumber() + "$")));
		DestroyButton.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Destroy", "", "Destroy building and give back " + BaseBuildingPanel.FormatPercentage(GameController.Instance.GetManualDestroyPercentage()) + " of money spent in trash.", ""));
		RowLevel.ButtonPressEvent += RowLevelPress;
		ThrowOutputRow.ButtonPressEvent += ThrowOutputRowPress;
		AutoDeviceRow.ButtonPressEvent += AutoDeviceRowPress;
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
		RowLevel.SetForLevelUp(Building);
		ThrowOutputRow.SetForUpgrade(Building, Building.HasThrowOutputAttribute);
		AutoDeviceRow.SetForUpgrade(Building, Building.HasAutoDeviceAttribute);
		SetPanelHeight();
		if (!FreezeScale)
		{
			PanelHelper.SetSize(this);
		}
	}

	public void RowLevelPress(object o, EventArgs e)
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

	public void DestroyColumn()
	{
		if (ProcessDestroyColumn())
		{
			GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ba_destroy_building_m);
			PanelColumn.DestroyBuilding(null, GameController.Instance.GetManualDestroyPercentage(), canOutputMedium: false);
			WorldCanvasController.Instance.ClosePanel();
		}
	}

	public static string GetTooltip(House building, bool forNextLevel = false)
	{
		string text = "";
		if (!forNextLevel)
		{
			text = "Sad peon enter the house rest, get happy and produce trash.\n\n";
		}
		int num = ((!(building == null)) ? building.GetLevel() : 0);
		if (forNextLevel)
		{
			num++;
		}
		if (num == 0)
		{
			text = text + "+" + House.GlobalInfo.GetDefaultMaxPeonPerFloor() + " maximum peons\n";
			text = text + "Trash Produced: " + House.GlobalInfo.GetDefaultOutputPerCycle() + " per occupant\n";
			text = text + "Trash Value: " + House.GlobalInfo.GetDefaultGarbageSize() + "$ per level\n";
			text = text + "Cloud Rate: " + BaseBuildingPanel.FormatPercentage(GameController.Instance.GetCloudChance()) + " per occupant\n";
		}
		else if (!forNextLevel)
		{
			text = text + "Trash Produced: " + building.GetGarbageOutputCount() + "\n";
			text = text + "Trash Value: " + building.GetGarbageSize() + "$\n";
			text = text + "Cloud Rate: " + BaseBuildingPanel.FormatPercentage(building.GetCloudChance()) + "\n";
		}
		else
		{
			text = text + "+" + House.GlobalInfo.GetDefaultMaxPeonPerFloor() + " maximum peons\n";
			text = text + "+" + House.GlobalInfo.GetDefaultGarbageSize() + "$ trash value per occupant\n";
			if (num == 3 || num == 5 || num == 7 || num == 9)
			{
				text += "+1 floor\n+1 max occupant\n";
			}
		}
		return text;
	}

	protected override int GetRowCount()
	{
		return 0 + (StabilityRow.gameObject.activeSelf ? 1 : 0) + (RowLevel.gameObject.activeSelf ? 1 : 0) + (ThrowOutputRow.gameObject.activeSelf ? 1 : 0) + (AutoDeviceRow.gameObject.activeSelf ? 1 : 0);
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
