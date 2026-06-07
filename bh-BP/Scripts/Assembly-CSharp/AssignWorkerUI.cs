using System;
using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class AssignWorkerUI : OverlayUI
{
	public static AssignWorkerUI I;

	public Localize LocTitle;

	[NamedArray(typeof(AssignWorkerPage))]
	public GameObject[] Wrappers;

	public CoolButton BtnClose;

	public Image ImgCurWorker;

	public Localize LocCurWorker;

	public CoolButton BtnCurWorker;

	public GameObject WrapperMainDefault;

	public Localize LocDesc;

	public LocalizationParamsManager ParamsDesc;

	public GameObject WrapperMainWarRoom;

	public Localize LocWarRoomProgress;

	public Image ImgWarRoomLvl;

	public GameObject WrapperWarRoomInProgress;

	public Image WarRoomProgressBar;

	public TextMeshProUGUI TxtWarRoomProgressBar;

	public GameObject WrapperWarRoomComplete;

	public CoolButton BtnWarRoomCollect;

	public LocalizationParamsManager ParamsWarRoomCollect;

	public CoolButton BtnUpgrade;

	public CoolButton BtnAlt;

	public Localize LocBtnAlt;

	public CoolSelectableWrapper WrapperSelectionGrid;

	public GridLayoutGroup SelectionGrid;

	public CoolButtonGroup SelectionGrp;

	public SerializedObjectPool<AssignWorkerItem> ItemPool;

	[NonSerialized]
	public CharMetaInst PendingSelectedChar;

	public SerializedObjectPool<WarRoomSelectLvlItem> SelectLvlPool;

	public CoolSelectableWrapper WrapperSelectLvl;

	public GameObject WrapperNoLevels;

	public Image ImgRerollWorker;

	public CoolButton BtnReroll;

	public LocalizationParamsManager ParamsNumToReroll;

	public TextMeshProUGUI TxtRerollCost;

	public LocalizationParamsManager ParamsRerollsRemaining;

	public GameObject WrapperRerollCurUpgrades;

	public GameObject WrapperRerollNewUpgrades;

	private List<HarvestUpgradeType> _availHarvestUpgs;

	private Cost _harvestRerollCost;

	public HarvestDisplayItem[] HarvestDisplayItems;

	[FormerlySerializedAs("HarvestBtns")]
	public HarvestUpgradeBtn[] HarvestUpgradeBtns;

	private bool _isRerolling;

	private int _numUpgradesToReroll;

	private int _totalUpgradesToReroll;

	public AssignWorkerPage CurPage;

	public BuildingObj TgtBuilding;

	private void Awake()
	{
	}

	protected override void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public void Activate(BuildingObj tgt)
	{
	}

	public override void Activate()
	{
	}

	protected override void MyUpdate()
	{
	}

	public void SetPage(AssignWorkerPage pg)
	{
	}

	public void SelectItem(AssignWorkerItem item)
	{
	}

	private void SetRerollingActive(bool isOn)
	{
	}

	public void SelectLevel(WarRoomSelectLvlItem lvlItem)
	{
	}

	private void RefreshWarRoomProgress()
	{
	}

	private void OnCurWorkerClicked()
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

	private void OnAltClicked()
	{
	}

	private void OnResolutionChanged()
	{
	}

	private void OnWarRoomCollectClicked()
	{
	}

	private void OnRerollClicked()
	{
	}

	public void SelectHarvestUpgrade(HarvestUpgradeType ht)
	{
	}
}
