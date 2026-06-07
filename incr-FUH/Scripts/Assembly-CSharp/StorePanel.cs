using System;

public class StorePanel : BaseBuildingPanel
{
	public ColumnController PanelColumn;

	public PanelTitle Title;

	public MixedRow StabilityRow;

	public MixedRow LevelRow;

	public MixedRow CloseOutputRow;

	public MixedRow ThrowOutputRow;

	public MixedRow CanCannonRow;

	public MixedRow CanMinigunRow;

	public MixedRow CanVacuumRow;

	public MixedRow CanMoreSpaceRow;

	public MixedRow CanScafoldingRow;

	public WorkerRow WorkerRow;

	public PanelButtonTooltip DestroyButton;

	private Store Building => (Store)PanelColumn.Buildings;

	private void Start()
	{
		Title.Initialize(base.gameObject, "Store");
		StabilityRow.Initialize(base.gameObject, MixedRow.StateEnum.NoButton, "Durability");
		LevelRow.Initialize(base.gameObject, MixedRow.StateEnum.Full, "Level");
		CloseOutputRow.Initialize(base.gameObject, MixedRow.StateEnum.Full, "Close");
		ThrowOutputRow.Initialize(base.gameObject, MixedRow.StateEnum.Full, "Throw");
		CanCannonRow.Initialize(base.gameObject, MixedRow.StateEnum.Full, "Cannon");
		CanMinigunRow.Initialize(base.gameObject, MixedRow.StateEnum.Full, "Minigun");
		CanVacuumRow.Initialize(base.gameObject, MixedRow.StateEnum.Full, "Vacuum");
		CanMoreSpaceRow.Initialize(base.gameObject, MixedRow.StateEnum.Full, "Space+");
		CanScafoldingRow.Initialize(base.gameObject, MixedRow.StateEnum.Full, "Scaffolding");
		WorkerRow.Initialize(base.gameObject, "Worker");
		DestroyButton.Initialize(base.gameObject);
		CloseOutputRow.gameObject.SetActive(value: false);
		Title.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Store", "", "Garbage Value: " + Building.GetGarbageSize() + "\nCloud Chance: " + BaseBuildingPanel.FormatPercentage(Building.GetCloudChance()), ""));
		LevelRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Store", Building.GetLevel() + "/10", (Building.GetLevel() == 2) ? "+1 output garbage value\nExtra floor\nEach worker multiply garbage output" : ((Building.GetLevel() == 4) ? "+1 output garbage value\nExtra floor\nEach worker multiply garbage output" : ((Building.GetLevel() == 6) ? "+1 output garbage value\nExtra floor\nEach worker multiply garbage output" : ((Building.GetLevel() == 8) ? "+1 output garbage value\nExtra floor\nEach worker multiply garbage output" : "+1 output garbage value"))), (Building.GetLevel() < 10) ? (Building.GetIncreaseLevelCost() + "$") : "Max"));
		StabilityRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update(PanelTitle.GetTitle("Durability", Building.GetGlobalInfo().StabilityLevel + 1), "", "Durability goes down on each use until the building is destroyed. Then gives:\n\n+" + BaseBuildingPanel.FormatPercentage(GameController.Instance.GetStabilityDestroyPercentage()) + " $ spent converted to garbage\n+1 Yellow shard\n+1 Output garbage\nIncreased durability", Building.GetGlobalInfo().GetMaxStability() - Building.GetStability() + "/" + Building.GetGlobalInfo().GetMaxStability() + " Durability"));
		ThrowOutputRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Throw", "", "Some output pipe will throw garbage.", Building.HasThrowOutputAttribute.IsEnabled ? "Max" : (Building.HasThrowOutputAttribute.GetCost() + "$")));
		CanCannonRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Cannon", "", "Get cannon blueprint for catapult.", Catapult.GlobalInfo.CanCannonAttribute.IsEnabled ? "Max" : (Catapult.GlobalInfo.CanCannonAttribute.GetCost() + "$")));
		CanMinigunRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Minigun", "", "Get minigun blueprint for catapult.", Catapult.GlobalInfo.CanMinigunAttribute.IsEnabled ? "Max" : (Catapult.GlobalInfo.CanMinigunAttribute.GetCost() + "$")));
		CanVacuumRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Vacuum", "", "Get vacuum blueprint.", GameController.GlobalInfo.CanVacuumAttribute.IsEnabled ? "Max" : (GameController.GlobalInfo.CanVacuumAttribute.GetCost() + "$")));
		CanMoreSpaceRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Space+", "", "Todo.", Store.GlobalInfo.CanMoreSpaceAttribute.IsEnabled ? "Max" : (Store.GlobalInfo.CanMoreSpaceAttribute.GetCost() + "$")));
		CanScafoldingRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Scaffolding", "", "Get scaffolding blueprint for rock.", Rock.GlobalInfo.CanScafoldingAttribute.IsEnabled ? "Max" : (Rock.GlobalInfo.CanScafoldingAttribute.GetCost() + "$")));
		WorkerRow.SetTooltip("Worker", "Add or remove peon worker to operate the building.");
		DestroyButton.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Destroy", "", "Destroy building and give back " + BaseBuildingPanel.FormatPercentage(GameController.Instance.GetManualDestroyPercentage()) + " of money spent in trash.", ""));
		CanMoreSpaceRow.gameObject.SetActive(value: false);
		LevelRow.ButtonPressEvent += LevelRowPress;
		ThrowOutputRow.ButtonPressEvent += ThrowOutputRowPress;
		CanCannonRow.ButtonPressEvent += CanCannonRowPress;
		CanMinigunRow.ButtonPressEvent += CanMinigunRowPress;
		CanVacuumRow.ButtonPressEvent += CanVacuumRowPress;
		CanMoreSpaceRow.ButtonPressEvent += CanMoreSpaceRowPress;
		CanScafoldingRow.ButtonPressEvent += CanScafoldingRowPress;
		WorkerRow.MinusPressEvent += UnreserveCharacter;
		WorkerRow.PlusPressEvent += ReserveCharacter;
	}

	private void Update()
	{
		if (Building == null)
		{
			WorldCanvasController.Instance.ClosePanel();
			return;
		}
		Title.UpdateTitleForLevel(Building.GetLevel());
		WorkerRow.SetValue(Building.Workers.Count + "/" + Building.GetMaximumWorker());
		StabilityRow.SetForStability(Building.GetStabilityPercentage());
		LevelRow.SetForLevelUp(Building);
		ThrowOutputRow.SetForUpgrade(Building, Building.HasThrowOutputAttribute);
		CanCannonRow.SetForUpgrade(Building, Catapult.GlobalInfo.CanCannonAttribute);
		CanMinigunRow.SetForUpgrade(Building, Catapult.GlobalInfo.CanMinigunAttribute);
		CanVacuumRow.SetForUpgrade(Building, GameController.GlobalInfo.CanVacuumAttribute);
		CanMoreSpaceRow.SetForUpgrade(Building, Store.GlobalInfo.CanMoreSpaceAttribute);
		CanScafoldingRow.SetForUpgrade(Building, Rock.GlobalInfo.CanScafoldingAttribute);
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

	public void CanCannonRowPress(object o, EventArgs e)
	{
		TryEnableAttribute(Catapult.GlobalInfo.CanCannonAttribute);
	}

	public void CanMinigunRowPress(object o, EventArgs e)
	{
		TryEnableAttribute(Catapult.GlobalInfo.CanMinigunAttribute);
	}

	public void CanVacuumRowPress(object o, EventArgs e)
	{
		TryEnableAttribute(GameController.GlobalInfo.CanVacuumAttribute);
	}

	public void CanMoreSpaceRowPress(object o, EventArgs e)
	{
		TryEnableAttribute(Store.GlobalInfo.CanMoreSpaceAttribute);
	}

	public void CanScafoldingRowPress(object o, EventArgs e)
	{
		TryEnableAttribute(Rock.GlobalInfo.CanScafoldingAttribute);
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
		GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ba_destroy_building_m);
		PanelColumn.DestroyBuilding(null, GameController.Instance.GetManualDestroyPercentage(), canOutputMedium: false);
		WorldCanvasController.Instance.ClosePanel();
	}
}
