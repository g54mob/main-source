using System;
using System.Collections.Generic;

[Serializable]
public class MstResearchTreeDataEntities : ICommonEntiies
{
	public eResearchTreeId id;

	public eResearchCategory category;

	public string name;

	public int researchPoint;

	public int redPoint;

	public bool isRoot;

	public List<eResearchTreeId> unlockTree;

	public bool isLoop;

	public bool isLock;

	public eResearchTreeId replaceTree;

	public eUpgradeKind kind1;

	public List<string> param1;

	public eUpgradeKind kind2;

	public List<string> param2;

	public string iconPath;

	public string imagePath;

	public string moviePath;

	public string Name => null;

	public string Desc => null;

	public string IconPath => null;
}
