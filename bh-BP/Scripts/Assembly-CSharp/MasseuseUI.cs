using I2.Loc;
using UnityEngine.UI;

public class MasseuseUI : OverlayUI
{
	public static MasseuseUI I;

	public CoolButton BtnClose;

	public Localize LocInstructions;

	public SerializedObjectPool<MasseuseItem> ItemPool;

	public GridLayoutGroup WorkerGrid;

	private void Awake()
	{
	}

	public override void Activate()
	{
	}

	public void RefreshList()
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

	private void OnResolutionChanged()
	{
	}
}
