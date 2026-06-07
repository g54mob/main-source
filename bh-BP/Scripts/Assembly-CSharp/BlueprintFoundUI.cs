using I2.Loc;
using UnityEngine;
using UnityEngine.UI;

public class BlueprintFoundUI : OverlayUI
{
	public static BlueprintFoundUI I;

	public BlueprintFoundPage CurPage;

	[NamedArray(typeof(BlueprintFoundPage))]
	public GameObject[] Wrappers;

	[Header("Blueprint")]
	public Localize LocTitle;

	public Image ImgPickup;

	public BuildingInfoPanel InfoPanel;

	public PixelFontAutosizer BuildingDescSizer;

	[Header("Gear")]
	public GearUIItem[] GearItems;

	public Localize LocGearDesc;

	public LocalizationParamsManager ParamsGearDesc;

	public CoolButton BtnClose;

	public BuildingInfo TgtBuilding;

	protected override void Start()
	{
	}

	public override void Activate()
	{
	}

	public void ActivateBuilding(BuildingType bt)
	{
	}

	public void ActivateGear()
	{
	}

	protected override void OnEntryComplete()
	{
	}
}
