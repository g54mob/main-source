using System;
using System.Collections.Generic;

[Serializable]
public class MstRelicDataEntities : ICommonEntiies
{
	public eRelic id;

	public int sortNum;

	public string name;

	public string desc;

	public string releaseConditionMessage;

	public eRelicRarity rarity;

	public eWriterId writer;

	public eUpgradeKind kind1;

	public List<string> param1;

	public eUpgradeKind kind2;

	public List<string> param2;

	public List<eArchiveCategory> needArchiveCategories;

	public List<string> needArchiveIds;

	public List<eStageId> ignoreStage;

	public bool isShop;

	public string iconPath;

	public string gifPath;

	public bool isHidden;

	public bool isTrial;

	public bool isEarly;

	public string Name => null;

	public string Desc => null;

	public string IconPath => null;

	public string GifPath => null;
}
