using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HarvestSummaryUI : OverlayUI
{
	public static HarvestSummaryUI I;

	public Localize LocTitle;

	public Image ImgBorder;

	public GameObject WrapperResources;

	public TextMeshProUGUI TxtResources;

	public GameObject WrapperBuildings;

	public HarvestSummaryBuildItem[] BldItems;

	private Cost _displayedCost;

	public CoolButton BtnClose;

	private void Awake()
	{
	}

	public override void Activate()
	{
	}

	private void OnCloseClicked()
	{
	}

	protected override void MyUpdate()
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
