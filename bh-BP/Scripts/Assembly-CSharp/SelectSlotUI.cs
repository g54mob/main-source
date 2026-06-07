using I2.Loc;
using MEC;
using UnityEngine;
using UnityEngine.UI;

public class SelectSlotUI : OverlayUI
{
	public static SelectSlotUI I;

	public CoolButton BtnClose;

	public Localize LocTitle;

	public ScrollRect Scrl;

	public RectTransform WrapperList;

	public SerializedObjectPool<SelectSlotItem> ItemPool;

	private CoroutineHandle _curScrl;

	private void Awake()
	{
	}

	public override void Activate()
	{
	}

	public void RefreshList()
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

	public void ScrollToItem(SelectSlotItem item)
	{
	}
}
