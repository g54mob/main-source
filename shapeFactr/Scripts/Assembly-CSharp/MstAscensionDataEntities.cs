using System;
using System.Collections.Generic;

[Serializable]
public class MstAscensionDataEntities
{
	public eAscension id;

	public int ascensionLevel;

	public string desc;

	public string toDesc;

	public eUpgradeKind kind1;

	public List<string> param1;

	public eUpgradeKind kind2;

	public List<string> param2;

	public eUpgradeKind baseUpKind1;

	public List<string> baseUpParam1;

	public eUpgradeKind baseUpKind2;

	public List<string> baseUpParam2;

	public List<eRelic> initRelic;

	public bool isTrial;

	public bool isEarly;
}
