using System;
using System.Collections.Generic;

[Serializable]
public class MstWriterDataEntities
{
	public eWriterId writerId;

	public string name;

	public string abilityDesc;

	public string mapPath;

	public bool defaultUnlock;

	public List<eUnitRace> useRace;

	public bool isHidden;

	public bool isTrial;

	public bool isEarly;

	public string iconPath;

	public string collectionIconPath;
}
