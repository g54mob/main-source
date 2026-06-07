using UnityEngine;

public class WorldCanvasController : MonoBehaviour
{
	public BuyBuildingPanel BuyBuildingPanel;

	public CatapultPanel CatapultPanel;

	public CharacterPanel CharacterPanel;

	public HelicopterPanel HelicopterPanel;

	public DronePanel DronePanel;

	public HousePanel HousePanel;

	public TemplePanel TemplePanel;

	public ResearchPanel ResearchPanel;

	public HotAirStationPanel HotAirStationPanel;

	public StorePanel StorePanel;

	public TrainingPanel TrainingPanel;

	public IndustryPanel IndustryPanel;

	public PowerPanel PowerPanel;

	public RockPanel RockPanel;

	public CompressorPanel CompressorPanel;

	public StatuePanel StatuePanel;

	public static WorldCanvasController Instance;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		ClosePanel();
	}

	public void OpenCharacterPanel(Vector3 signLocation)
	{
		ClosePanel();
		MovePanel(CharacterPanel, new Vector3(signLocation.x, CharacterPanel.transform.position.y, CharacterPanel.transform.position.z));
		CharacterPanel.gameObject.SetActive(value: true);
		PanelHelper.SetSize(CharacterPanel);
		CharacterPanel.DoShowAnimation();
	}

	public void OpenColumnPanel(ColumnController column)
	{
		BaseBuildingPanel baseBuildingPanel = null;
		switch (column.GetBuildingType())
		{
		case BaseBuilding.BuildingTypeEnum.None:
			BuyBuildingPanel.PanelColumn = column;
			baseBuildingPanel = BuyBuildingPanel;
			break;
		case BaseBuilding.BuildingTypeEnum.Catapult:
			CatapultPanel.PanelColumn = column;
			baseBuildingPanel = CatapultPanel;
			break;
		case BaseBuilding.BuildingTypeEnum.Helicopter:
			HelicopterPanel.PanelColumn = column;
			baseBuildingPanel = HelicopterPanel;
			break;
		case BaseBuilding.BuildingTypeEnum.Drone:
			DronePanel.PanelColumn = column;
			baseBuildingPanel = DronePanel;
			break;
		case BaseBuilding.BuildingTypeEnum.House:
			HousePanel.PanelColumn = column;
			baseBuildingPanel = HousePanel;
			break;
		case BaseBuilding.BuildingTypeEnum.Temple:
			TemplePanel.PanelColumn = column;
			baseBuildingPanel = TemplePanel;
			break;
		case BaseBuilding.BuildingTypeEnum.Research:
			ResearchPanel.PanelColumn = column;
			baseBuildingPanel = ResearchPanel;
			break;
		case BaseBuilding.BuildingTypeEnum.HotAirBaloon:
			HotAirStationPanel.PanelColumn = column;
			baseBuildingPanel = HotAirStationPanel;
			break;
		case BaseBuilding.BuildingTypeEnum.Store:
			StorePanel.PanelColumn = column;
			baseBuildingPanel = StorePanel;
			break;
		case BaseBuilding.BuildingTypeEnum.Training:
			TrainingPanel.PanelColumn = column;
			baseBuildingPanel = TrainingPanel;
			break;
		case BaseBuilding.BuildingTypeEnum.Industry:
			IndustryPanel.PanelColumn = column;
			baseBuildingPanel = IndustryPanel;
			break;
		case BaseBuilding.BuildingTypeEnum.Power:
			PowerPanel.PanelColumn = column;
			baseBuildingPanel = PowerPanel;
			break;
		case BaseBuilding.BuildingTypeEnum.Rock:
			RockPanel.PanelColumn = column;
			baseBuildingPanel = RockPanel;
			break;
		case BaseBuilding.BuildingTypeEnum.Compressor:
			CompressorPanel.PanelColumn = column;
			baseBuildingPanel = CompressorPanel;
			break;
		}
		if (baseBuildingPanel.gameObject.activeSelf)
		{
			ClosePanel();
			return;
		}
		ClosePanel();
		if (baseBuildingPanel != null)
		{
			GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_button1_click);
			MovePanel(baseBuildingPanel, new Vector3(column.transform.position.x, baseBuildingPanel.transform.position.y, baseBuildingPanel.transform.position.z));
			baseBuildingPanel.gameObject.SetActive(value: true);
			PanelHelper.SetSize(baseBuildingPanel);
			baseBuildingPanel.DoShowAnimation();
		}
	}

	public void OpenStatuePanel(Sign sign)
	{
		BaseBuildingPanel statuePanel = StatuePanel;
		if (statuePanel.gameObject.activeSelf)
		{
			ClosePanel();
			return;
		}
		ClosePanel();
		if (statuePanel != null)
		{
			GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_button1_click);
			MovePanel(statuePanel, new Vector3(sign.transform.position.x, statuePanel.transform.position.y, statuePanel.transform.position.z));
			statuePanel.gameObject.SetActive(value: true);
			PanelHelper.SetSize(statuePanel);
			statuePanel.DoShowAnimation();
		}
	}

	private void MovePanel(BaseBuildingPanel panel, Vector3 pos)
	{
		RectTransform component = panel.GetComponent<RectTransform>();
		panel.transform.position = pos;
		Vector3[] array = new Vector3[4];
		component.GetWorldCorners(array);
		Vector3 vector = Camera.main.ScreenToWorldPoint(Vector3.zero);
		Vector3 vector2 = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
		_ = ref array[2];
		_ = ref array[0];
		Vector3 position = panel.transform.position;
		if (array[0].x < vector.x)
		{
			position.x += vector.x - array[0].x;
		}
		else if (array[2].x > vector2.x)
		{
			position.x -= array[2].x - vector2.x;
		}
		panel.transform.position = position;
	}

	public void ClosePanel()
	{
		BuyBuildingPanel.gameObject.SetActive(value: false);
		CatapultPanel.gameObject.SetActive(value: false);
		CharacterPanel.gameObject.SetActive(value: false);
		HelicopterPanel.gameObject.SetActive(value: false);
		DronePanel.gameObject.SetActive(value: false);
		HousePanel.gameObject.SetActive(value: false);
		TemplePanel.gameObject.SetActive(value: false);
		ResearchPanel.gameObject.SetActive(value: false);
		HotAirStationPanel.gameObject.SetActive(value: false);
		StorePanel.gameObject.SetActive(value: false);
		TrainingPanel.gameObject.SetActive(value: false);
		IndustryPanel.gameObject.SetActive(value: false);
		PowerPanel.gameObject.SetActive(value: false);
		RockPanel.gameObject.SetActive(value: false);
		CompressorPanel.gameObject.SetActive(value: false);
		StatuePanel.gameObject.SetActive(value: false);
		TooltipPanel.Instance.HideTooltip();
		Sign.PreventEvent = false;
	}
}
