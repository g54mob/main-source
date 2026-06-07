using System;

[Serializable]
public class Ingredient
{
	public int propertyIndex;

	public int curLevel;

	public int targetLevel;

	public int pairedIngred;

	public float weight;

	public float pairedWeight;

	public bool unlocked;

	public Ingredient()
	{
		curLevel = 0;
		targetLevel = 0;
		pairedIngred = 0;
		weight = 0f;
		pairedWeight = 0f;
		unlocked = true;
	}
}
