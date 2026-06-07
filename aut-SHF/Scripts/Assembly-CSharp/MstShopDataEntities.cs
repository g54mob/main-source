using System;
using System.Collections.Generic;

[Serializable]
public class MstShopDataEntities
{
	public eShopId id;

	public eShopType shopType;

	public string title;

	public string desc;

	public List<int> prices;

	public int limitCount;

	public bool defaultUnlock;

	public eUpgradeKind shopEffectKind1;

	public List<string> param1;

	public eUpgradeKind shopEffectKind2;

	public List<string> param2;

	public eUpgradeKind shopEffectKind3;

	public List<string> param3;

	public eShopId updateId;

	public eArchiveCategory archiveCategory;

	public string archiveId;
}
