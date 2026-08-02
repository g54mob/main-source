using System;

[Serializable]
public class FuelSlotData
{
	public string fuelItemName;

	public bool isActive;

	public float burningTimeRemaining;

	public FuelSlotData()
	{
		fuelItemName = "";
		isActive = false;
		burningTimeRemaining = 0f;
	}
}
