using System;
using System.Collections.Generic;

[Serializable]
public class SetBonusInfo
{
	public SetBonusID setBonusID;

	public AreaLevel areaLevel;

	public Rarity rarity;

	public List<ObjectID> availablePieces;

	public List<SetBonusData> setBonusDatas;
}
