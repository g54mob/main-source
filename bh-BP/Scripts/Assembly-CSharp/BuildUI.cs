using System;
using I2.Loc;
using MEC;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildUI : OverlayUI
{
	public static BuildUI I;

	public BuildingCat TgtCat;

	public ScrollRect Scrl;

	public CoolButtonGroup BtnGrp;

	public RectTransform WrapperList;

	[NamedArray(typeof(BuildingCat))]
	public CoolButton[] CatBtns;

	[NamedArray(typeof(BuildingCat))]
	public Image[] CatNotifIcons;

	public GameObject WrapperListEmpty;

	public RectTransform WrapperHeaderCategories;

	public RectTransform WrapperHeaderGear;

	public SlidingPanel PanelDetails;

	public GameObject WrapperDetails;

	public Localize LocDetailsName;

	public Image ImgDetailsIcon;

	public PixelFontAutosizer DetailsDescAutosizer;

	public Localize LocDetailsDesc;

	public LocalizationParamsManager ParamsDetailsDesc;

	public TextMeshProUGUI TxtDetailsGoldCost;

	public ScalingUpgradeGroup ScalingUpgGrp;

	public GameObject WrapperDetailsBtns;

	public CoolButton BtnBuild;

	public CoolButton BtnClose;

	private bool _initedPools;

	public BuildItem PrefabItem;

	[NonSerialized]
	public ObjectPool<BuildItem> ItemPool;

	private BuildItem _selectedItem;

	public GridSection PrefabSection;

	[NonSerialized]
	public ObjectPool<GridSection> SectionPool;

	public BuildSectionHeader PrefabSectionHeader;

	[NonSerialized]
	public ObjectPool<BuildSectionHeader> SectionHeaderPool;

	private CoroutineHandle _curScrlAnim;

	private void Awake()
	{
	}

	protected override void Start()
	{
	}

	private void OnInputTypeChanged()
	{
	}

	private void InitPools()
	{
	}

	public override void Activate()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnResolutionChanged()
	{
	}

	public void RefreshNotifIcons()
	{
	}

	protected override void OnEntryComplete()
	{
	}

	protected override void MyUpdate()
	{
	}

	public override void Deactivate()
	{
	}

	private void OnGrpEntered(CoolButton btn)
	{
	}

	private void OnGrpNav(CoolButton btnPrev, CoolButton btnNext)
	{
	}

	public void HoverItem(BuildItem bItem)
	{
	}

	public BuildItem GetItemForBuilding(BuildingType bt)
	{
		return null;
	}

	private void OnGrpExited(CoolButton btn)
	{
	}

	private void OnResourceClicked()
	{
	}

	private void OnBattleUpgradeClicked()
	{
	}

	private void OnHousingClicked()
	{
	}

	public void SetCat(BuildingCat cat)
	{
	}

	private void RefreshList()
	{
	}

	public void SelectItem(BuildItem item)
	{
	}

	public override void OnUnderlayClicked()
	{
	}

	public override bool OnBPressed()
	{
		return false;
	}

	private void OnCloseClicked()
	{
	}

	private void OnBuildClicked()
	{
	}
}
