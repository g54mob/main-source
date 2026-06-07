using System;
using I2.Loc;
using UnityEngine;
using UnityEngine.UI;

public class CharSelectUI : OverlayUI
{
	public static CharSelectUI I;

	public bool IsSelectingFusion;

	public RectTransform XfmBacking;

	public CoolButtonGroup BtnGrp;

	public RectTransform WrapperList;

	public CoolSelectableWrapper BtnWrapper;

	public GridLayoutGroup CharGrid;

	public SlidingPanel SldPanelDetails;

	public CharInfoPanel DetailsPanel;

	public GameObject WrapperNoneSelected;

	public GameObject WrapperDetailsUnlocked;

	public GameObject WrapperDetailsLocked;

	public Localize LocReqDesc;

	public RectTransform WrapperDetailsBtns;

	public CoolButton BtnStats;

	public CoolButton BtnSelect;

	public CoolButton BtnClose;

	public CharSelectItem PrefabItem;

	[NonSerialized]
	public ObjectPool<CharSelectItem> ItemPool;

	public CharLevelCompleteItem PrefabLvlItem;

	[NonSerialized]
	public ObjectPool<CharLevelCompleteItem> LvlItemPool;

	public Transform WrapperLvlItems;

	private CharSelectItem _selectedItem;

	private int _previewNGPlus;

	public CoolButton BtnPrevNGPlus;

	public CoolButton BtnNextNGPlus;

	public CoolButton BtnLeaderboards;

	private void Awake()
	{
	}

	private new void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnInputChanged()
	{
	}

	private void OnResolutionChanged()
	{
	}

	public override void Activate()
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

	private void OnGrpExited(CoolButton btn)
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

	public void SelectItem(CharSelectItem item)
	{
	}

	public void ClickItem(CharSelectItem item)
	{
	}

	private void GoToLevelSelect()
	{
	}

	private void OnStatsClicked()
	{
	}

	private void OnSelectClicked()
	{
	}

	private void SetNGPlusPreview(int lvl)
	{
	}

	private void OnNextNGPlusClicked()
	{
	}

	private void OnPrevNGPlusClicked()
	{
	}

	public void OnLBClicked()
	{
	}
}
