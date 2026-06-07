using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaseReturnUI : OverlayUI
{
	public static BaseReturnUI I;

	public Localize LocTitle;

	public GameObject WrapperResources;

	public TextMeshProUGUI TxtResources;

	public GameObject WrapperMiners;

	public Image[] ImgMiners;

	public CoolButton BtnClose;

	private void Awake()
	{
	}

	public override void Activate()
	{
	}

	protected override void MyUpdate()
	{
	}

	private void OnCloseClicked()
	{
	}

	public override void OnExitComplete()
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
