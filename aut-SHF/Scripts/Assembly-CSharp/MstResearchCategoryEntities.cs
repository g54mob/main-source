using System;
using System.Collections.Generic;

[Serializable]
public class MstResearchCategoryEntities : ICommonEntiies
{
	public eResearchCategory id;

	public int sortNum;

	public string name;

	public eResearchCategoryType categoryType;

	public eWriterId writer;

	public string overview;

	public string releaseConditionMessage;

	public List<eResearchTreeId> firstUnlockTrees;

	public eUpgradePack rewardType;

	public eResearchCollectionCategory collectionCategory;

	public string iconPath;

	public string backgroundPath;

	public string gifPath;

	public bool isHidden;

	public bool isTrial;

	public bool isEarly;

	public string Name => null;

	public string Desc => null;

	public string IconPath => null;

	public string GifPath => null;
}
