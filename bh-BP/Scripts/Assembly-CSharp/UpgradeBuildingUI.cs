using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeBuildingUI : OverlayUI
{
	public static UpgradeBuildingUI I;

	public Image ImgPreview;

	public LocalizationParamsManager ParamsNextLvl;

	public Localize LocDesc;

	public RectTransform XfmDesc;

	public LocalizationParamsManager ParamsDesc;

	public ScalingUpgradeGroup ScalingUpgGrp;

	public ColoredGraphic ColoredUpgText;

	public RectTransform XfmUpgLabel;

	public ColoredGraphic ColoredUpgCost;

	public TextMeshProUGUI TxtUpgCost;

	public Localize LocUpgCost;

	public LocalizationParamsManager ParamsUpgCost;

	public GameObject WrapperElevator;

	public GearUIItem[] Gears;

	public Localize LocGearProgress;

	public LocalizationParamsManager ParamsGearProgress;

	private bool _canAffordElevator;

	public GameObject WrapperPreview;

	public Image ImgPreviewPrev;

	public Image ImgPreviewNext;

	public CoolButton BtnUpgrade;

	public CoolButton BtnClose;

	private BuildingObj _tgtBuilding;

	private void Awake()
	{
	}

	public override void Deactivate()
	{
	}

	public void Activate(BuildingObj b)
	{
	}

	public void ActivateElevator()
	{
	}

	private void OnUpgradeClicked()
	{
	}

	private void OnCloseClicked()
	{
	}

	public override void OnUnderlayClicked()
	{
	}

	public override bool OnBPressed()
	{
		return false;
	}
}
