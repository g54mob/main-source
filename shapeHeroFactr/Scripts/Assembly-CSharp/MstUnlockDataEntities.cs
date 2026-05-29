using System;
using System.Collections.Generic;

[Serializable]
public class MstUnlockDataEntities
{
	public eUnlockId unlockId;

	public eWriterId writer;

	public eStageDivision division;

	public bool isClearDivision;

	public int ascension;

	public List<eUnlockId> pair;

	public List<eUnlockId> needUnlock;

	public eUpgradeKind upgradeKind;

	public List<string> param;

	public string lockText;
}
