using System.Collections.Generic;

public class CostumeSaveData
{
	public Dictionary<CostumeID, bool> CostumeBuyStateDict;

	public CostumeID EquippedCostumeID;

	public CostumeSaveData(Dictionary<CostumeID, bool> costumeBuyStateDict, CostumeID equippedCostumeID)
	{
		CostumeBuyStateDict = costumeBuyStateDict;
		EquippedCostumeID = equippedCostumeID;
	}
}
