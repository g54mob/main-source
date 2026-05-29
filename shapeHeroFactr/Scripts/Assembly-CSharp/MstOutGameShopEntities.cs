using System;
using System.Collections.Generic;

[Serializable]
public class MstOutGameShopEntities
{
	public eOutGameShopId id;

	public string title;

	public string desc;

	public bool useChallenge;

	public bool switchEnable;

	public int price;

	public bool defaultUnlock;

	public eWriterId writerId;

	public bool isConsumption;

	public eUpgradeKind shopEffectKind1;

	public List<string> param1;

	public eUpgradeKind shopEffectKind2;

	public List<string> param2;

	public eUpgradeKind shopEffectKind3;

	public List<string> param3;

	public eOutGameShopId updateId;

	public string iconPath;

	public bool isHidden;

	public bool isTrial;

	public bool isEarly;
}
