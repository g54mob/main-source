using System.Collections.Generic;
using I2.Loc;

public class ItemUnlockUI : OverlayUI
{
	public static ItemUnlockUI I;

	public Localize LocTitle;

	public Localize LocDesc;

	public LocalizationParamsManager ParamsExtraNum;

	public LevelInfo TgtLvl;

	public int NewGameVersionNum;

	public ItemUnlockItem[] Items;

	public CoolButton BtnClose;

	public List<UpgradeInfo> NewGameContentList;

	public List<UpgradeInfo> HiddenNewGameContentList;

	private int _extraContentNum;

	private void Awake()
	{
	}

	public void PopulateNewGameContent()
	{
	}

	public override void Activate()
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
}
