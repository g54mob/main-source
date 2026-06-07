using System;

public class BuyBuildingPanel : BaseBuildingPanel
{
	public ColumnController PanelColumn;

	public PanelTitle Title;

	public MixedRow HouseRow;

	public MixedRow CatapultRow;

	public MixedRow TempleRow;

	public MixedRow HelicopterRow;

	public MixedRow DroneRow;

	public MixedRow ResearchRow;

	public MixedRow HotAirRow;

	public MixedRow TrainingRow;

	public MixedRow IndustryRow;

	public MixedRow PowerRow;

	public MixedRow CompressorRow;

	private bool _isFirstBuy = true;

	private void Start()
	{
		Title.Initialize(base.gameObject, LanguageText.GetText("Build Building"));
		HouseRow.Initialize(base.gameObject, MixedRow.StateEnum.NoValue, LanguageText.GetText("House"));
		CatapultRow.Initialize(base.gameObject, MixedRow.StateEnum.NoValue, LanguageText.GetText("Catapult"));
		TempleRow.Initialize(base.gameObject, MixedRow.StateEnum.NoValue, LanguageText.GetText("Temple"));
		HelicopterRow.Initialize(base.gameObject, MixedRow.StateEnum.NoValue, LanguageText.GetText("Helipad"));
		DroneRow.Initialize(base.gameObject, MixedRow.StateEnum.NoValue, LanguageText.GetText("Cloud Seeder"));
		ResearchRow.Initialize(base.gameObject, MixedRow.StateEnum.NoValue, LanguageText.GetText("Research Lab"));
		HotAirRow.Initialize(base.gameObject, MixedRow.StateEnum.NoValue, LanguageText.GetText("Hangar"));
		TrainingRow.Initialize(base.gameObject, MixedRow.StateEnum.NoValue, LanguageText.GetText("Training"));
		IndustryRow.Initialize(base.gameObject, MixedRow.StateEnum.NoValue, LanguageText.GetText("Factory"));
		PowerRow.Initialize(base.gameObject, MixedRow.StateEnum.NoValue, LanguageText.GetText("Power"));
		CompressorRow.Initialize(base.gameObject, MixedRow.StateEnum.NoValue, LanguageText.GetText("Compressor"));
		HouseRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update(LanguageText.GetText("House"), "", HousePanel.GetTooltip(null), GetNewBuildingCost(BaseBuilding.BuildingTypeEnum.House).ToNumber() + "$"));
		CatapultRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update(LanguageText.GetText("Catapult"), "", CatapultPanel.GetTooltip(null), GetNewBuildingCost(BaseBuilding.BuildingTypeEnum.Catapult).ToNumber() + "$"));
		TempleRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update(LanguageText.GetText("Temple"), "", TemplePanel.GetTooltip(null), GetNewBuildingCost(BaseBuilding.BuildingTypeEnum.Temple).ToNumber() + "$"));
		HelicopterRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update(LanguageText.GetText("Helipad"), "", HelicopterPanel.GetTooltip(null), GetNewBuildingCost(BaseBuilding.BuildingTypeEnum.Helicopter).ToNumber() + "$"));
		DroneRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update(LanguageText.GetText("Cloud Seeder"), "", DronePanel.GetTooltip(null), GetNewBuildingCost(BaseBuilding.BuildingTypeEnum.Drone).ToNumber() + "$"));
		ResearchRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update(LanguageText.GetText("Research Lab"), "", ResearchPanel.GetTooltip(null), GetNewBuildingCost(BaseBuilding.BuildingTypeEnum.Research).ToNumber() + "$"));
		HotAirRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update(LanguageText.GetText("Hangar"), "", HotAirStationPanel.GetTooltip(null), GetNewBuildingCost(BaseBuilding.BuildingTypeEnum.HotAirBaloon).ToNumber() + "$"));
		TrainingRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update(LanguageText.GetText("Training"), "", TrainingPanel.GetTooltip(null), GetNewBuildingCost(BaseBuilding.BuildingTypeEnum.Training).ToNumber() + "$"));
		IndustryRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update(LanguageText.GetText("Factory"), "", IndustryPanel.GetTooltip(null), GetNewBuildingCost(BaseBuilding.BuildingTypeEnum.Industry).ToNumber() + "$"));
		PowerRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update(LanguageText.GetText("Power"), "", PowerPanel.GetTooltip(null), GetNewBuildingCost(BaseBuilding.BuildingTypeEnum.Power).ToNumber() + "$"));
		CompressorRow.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update(LanguageText.GetText("Compressor"), "", CompressorPanel.GetTooltip(null), GetNewBuildingCost(BaseBuilding.BuildingTypeEnum.Compressor).ToNumber() + "$"));
		HouseRow.ButtonPressEvent += CreateHouse;
		CatapultRow.ButtonPressEvent += CreateCatapult;
		TempleRow.ButtonPressEvent += CreateTemple;
		HelicopterRow.ButtonPressEvent += CreateHelicopter;
		DroneRow.ButtonPressEvent += CreateDrone;
		ResearchRow.ButtonPressEvent += CreateResearch;
		HotAirRow.ButtonPressEvent += CreateHotAirStation;
		TrainingRow.ButtonPressEvent += CreateTraining;
		IndustryRow.ButtonPressEvent += CreateIndustry;
		PowerRow.ButtonPressEvent += CreatePower;
		CompressorRow.ButtonPressEvent += CreateCompressor;
	}

	private void Update()
	{
		HouseRow.gameObject.SetActive(House.GlobalInfo.LevelUpAttribute.IsEnabled && ColumnController.CountBuildingType(BaseBuilding.BuildingTypeEnum.House) < House.GlobalInfo.MaxBuilding());
		CatapultRow.gameObject.SetActive(Catapult.GlobalInfo.LevelUpAttribute.IsEnabled && ColumnController.CountBuildingType(BaseBuilding.BuildingTypeEnum.Catapult) < Catapult.GlobalInfo.MaxBuilding());
		TempleRow.gameObject.SetActive(Temple.GlobalInfo.LevelUpAttribute.IsEnabled && ColumnController.CountBuildingType(BaseBuilding.BuildingTypeEnum.Temple) < Temple.GlobalInfo.MaxBuilding());
		HelicopterRow.gameObject.SetActive(Helicopter.GlobalInfo.LevelUpAttribute.IsEnabled && ColumnController.CountBuildingType(BaseBuilding.BuildingTypeEnum.Helicopter) < Helicopter.GlobalInfo.MaxBuilding());
		DroneRow.gameObject.SetActive(Drone.GlobalInfo.LevelUpAttribute.IsEnabled && ColumnController.CountBuildingType(BaseBuilding.BuildingTypeEnum.Drone) < Drone.GlobalInfo.MaxBuilding());
		ResearchRow.gameObject.SetActive(Research.GlobalInfo.LevelUpAttribute.IsEnabled && ColumnController.CountBuildingType(BaseBuilding.BuildingTypeEnum.Research) < Research.GlobalInfo.MaxBuilding());
		HotAirRow.gameObject.SetActive(HotAirStation.GlobalInfo.LevelUpAttribute.IsEnabled && ColumnController.CountBuildingType(BaseBuilding.BuildingTypeEnum.HotAirBaloon) < HotAirStation.GlobalInfo.MaxBuilding());
		TrainingRow.gameObject.SetActive(Training.GlobalInfo.LevelUpAttribute.IsEnabled && ColumnController.CountBuildingType(BaseBuilding.BuildingTypeEnum.Training) < Training.GlobalInfo.MaxBuilding());
		IndustryRow.gameObject.SetActive(Industry.GlobalInfo.LevelUpAttribute.IsEnabled && ColumnController.CountBuildingType(BaseBuilding.BuildingTypeEnum.Industry) < Industry.GlobalInfo.MaxBuilding());
		PowerRow.gameObject.SetActive(Power.GlobalInfo.LevelUpAttribute.IsEnabled && ColumnController.CountBuildingType(BaseBuilding.BuildingTypeEnum.Power) < Power.GlobalInfo.MaxBuilding());
		CompressorRow.gameObject.SetActive(Compressor.GlobalInfo.LevelUpAttribute.IsEnabled && ColumnController.CountBuildingType(BaseBuilding.BuildingTypeEnum.Compressor) < Compressor.GlobalInfo.MaxBuilding());
		SetButtonCost(HouseRow, GetNewBuildingCost(BaseBuilding.BuildingTypeEnum.House));
		SetButtonCost(CatapultRow, GetNewBuildingCost(BaseBuilding.BuildingTypeEnum.Catapult));
		SetButtonCost(TempleRow, GetNewBuildingCost(BaseBuilding.BuildingTypeEnum.Temple));
		SetButtonCost(HelicopterRow, GetNewBuildingCost(BaseBuilding.BuildingTypeEnum.Helicopter));
		SetButtonCost(DroneRow, GetNewBuildingCost(BaseBuilding.BuildingTypeEnum.Drone));
		SetButtonCost(ResearchRow, GetNewBuildingCost(BaseBuilding.BuildingTypeEnum.Research));
		SetButtonCost(HotAirRow, GetNewBuildingCost(BaseBuilding.BuildingTypeEnum.HotAirBaloon));
		SetButtonCost(TrainingRow, GetNewBuildingCost(BaseBuilding.BuildingTypeEnum.Training));
		SetButtonCost(IndustryRow, GetNewBuildingCost(BaseBuilding.BuildingTypeEnum.Industry));
		SetButtonCost(PowerRow, GetNewBuildingCost(BaseBuilding.BuildingTypeEnum.Power));
		SetButtonCost(CompressorRow, GetNewBuildingCost(BaseBuilding.BuildingTypeEnum.Compressor));
		SetPanelHeight();
		if (!FreezeScale)
		{
			PanelHelper.SetSize(this);
		}
	}

	private void SetButtonCost(MixedRow row, int cost)
	{
		row.SetButton(cost.ToNumber() + "$");
		row.SetButtonColor(cost < GameController.Instance.Money.Amount);
	}

	private int GetNewBuildingCost(BaseBuilding.BuildingTypeEnum buildingType)
	{
		if (buildingType == BaseBuilding.BuildingTypeEnum.House)
		{
			return BaseBuilding.GetNewBuildingCost(PanelColumn.Distance, GameController.Instance.ColumnsController.GetBuildingCount(buildingType) == 0, isHouse: true);
		}
		return BaseBuilding.GetNewBuildingCost(PanelColumn.Distance, GameController.Instance.ColumnsController.GetBuildingCount(buildingType) == 0);
	}

	public void CreateHouse(object o, EventArgs e)
	{
		TryCreateBuilding(BaseBuilding.BuildingTypeEnum.House);
	}

	public void CreateCatapult(object o, EventArgs e)
	{
		TryCreateBuilding(BaseBuilding.BuildingTypeEnum.Catapult);
	}

	public void CreateCompressor(object o, EventArgs e)
	{
		TryCreateBuilding(BaseBuilding.BuildingTypeEnum.Compressor);
	}

	public void CreateHelicopter(object o, EventArgs e)
	{
		TryCreateBuilding(BaseBuilding.BuildingTypeEnum.Helicopter);
	}

	public void CreateDrone(object o, EventArgs e)
	{
		TryCreateBuilding(BaseBuilding.BuildingTypeEnum.Drone);
	}

	public void CreateTemple(object o, EventArgs e)
	{
		TryCreateBuilding(BaseBuilding.BuildingTypeEnum.Temple);
	}

	public void CreateResearch(object o, EventArgs e)
	{
		TryCreateBuilding(BaseBuilding.BuildingTypeEnum.Research);
	}

	public void CreateHotAirStation(object o, EventArgs e)
	{
		TryCreateBuilding(BaseBuilding.BuildingTypeEnum.HotAirBaloon);
	}

	public void CreateTraining(object o, EventArgs e)
	{
		TryCreateBuilding(BaseBuilding.BuildingTypeEnum.Training);
	}

	public void CreateIndustry(object o, EventArgs e)
	{
		TryCreateBuilding(BaseBuilding.BuildingTypeEnum.Industry);
	}

	public void CreatePower(object o, EventArgs e)
	{
		TryCreateBuilding(BaseBuilding.BuildingTypeEnum.Power);
	}

	public bool TryCreateBuilding(BaseBuilding.BuildingTypeEnum buildingType)
	{
		int newBuildingCost = GetNewBuildingCost(buildingType);
		if (GameController.Instance.Money.Amount >= newBuildingCost)
		{
			GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ba_build);
			if (buildingType == BaseBuilding.BuildingTypeEnum.Temple)
			{
				GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ga_signing);
			}
			GameController.Instance.GainMoney(-newBuildingCost);
			CreateBuilding(buildingType).AddSpentMoney(newBuildingCost);
			if (_isFirstBuy && buildingType == BaseBuilding.BuildingTypeEnum.Industry)
			{
				_isFirstBuy = false;
				TutorialController.Instance.EnablePart(4);
			}
			return true;
		}
		return false;
	}

	private BaseBuilding CreateBuilding(BaseBuilding.BuildingTypeEnum buildingType)
	{
		BaseBuilding result = PanelColumn.CreateFirstBuilding(buildingType);
		GameController.Instance.ColumnsController.VerifyAndAddNewcolumn();
		CameraController.Instance.QuickZoom();
		WorldCanvasController.Instance.ClosePanel();
		return result;
	}

	protected override int GetRowCount()
	{
		return 0 + (HouseRow.gameObject.activeSelf ? 1 : 0) + (CatapultRow.gameObject.activeSelf ? 1 : 0) + (TempleRow.gameObject.activeSelf ? 1 : 0) + (HelicopterRow.gameObject.activeSelf ? 1 : 0) + (DroneRow.gameObject.activeSelf ? 1 : 0) + (ResearchRow.gameObject.activeSelf ? 1 : 0) + (HotAirRow.gameObject.activeSelf ? 1 : 0) + (TrainingRow.gameObject.activeSelf ? 1 : 0) + (IndustryRow.gameObject.activeSelf ? 1 : 0) + (PowerRow.gameObject.activeSelf ? 1 : 0) + (CompressorRow.gameObject.activeSelf ? 1 : 0);
	}
}
