using UnityEngine;

public class PetSlimeBlob : PetBase
{
	public override void OnOccupied()
	{
		base.OnOccupied();
		if (base.objectData.objectID == ObjectID.PetLavaSlimeBlob)
		{
			spriteObjects[0].emissiveColor = Color.white;
		}
		else
		{
			spriteObjects[0].emissiveColor = Color.black;
		}
	}
}
