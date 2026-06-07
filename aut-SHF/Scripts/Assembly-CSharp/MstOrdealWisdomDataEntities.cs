using System;
using System.Collections.Generic;

[Serializable]
public class MstOrdealWisdomDataEntities
{
	public eOrdealWisdom id;

	public int sortNum;

	public string name;

	public string blessingDesc;

	public string curseDesc;

	public eWriterId writer;

	public eUpgradeKind kind1;

	public List<string> param1;

	public eUpgradeKind kind2;

	public List<string> param2;

	public eUpgradeKind kind3;

	public List<string> param3;

	public string iconPath;

	public string gifPath;

	public bool isHidden;

	public bool isTrial;

	public bool isEarly;
}
