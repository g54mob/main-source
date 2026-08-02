using System;

[Serializable]
public class PlantData
{
	public string plantName;

	public bool isPlanted;

	public bool itHasWater;

	public float growingStatus;

	public float waterTimer;

	public int currentGrowLevel;

	public PlantData()
	{
		plantName = "";
		isPlanted = false;
		itHasWater = false;
		growingStatus = 0f;
		waterTimer = 0f;
		currentGrowLevel = -1;
	}
}
