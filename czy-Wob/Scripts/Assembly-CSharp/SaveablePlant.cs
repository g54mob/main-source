using System;

[Serializable]
public class SaveablePlant
{
	public float life;

	public float maxLife;

	public float currentGrowTimer;

	public int currentSproutStage;

	public PlantController.PlantStage currentPlantStage;

	public SaveablePlant()
	{
	}

	public SaveablePlant(PlantController pc)
	{
		pc.SavePlant(this);
	}

	public void Load(PlantController pc)
	{
		pc.LoadPlant(this);
	}

	public SaveablePlant GetCopy()
	{
		return new SaveablePlant
		{
			life = life,
			maxLife = maxLife,
			currentGrowTimer = currentGrowTimer,
			currentSproutStage = currentSproutStage,
			currentPlantStage = currentPlantStage
		};
	}
}
