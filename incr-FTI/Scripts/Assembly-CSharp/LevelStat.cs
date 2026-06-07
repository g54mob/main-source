using UnityEngine;

public class LevelStat
{
	public int level;

	public double points;

	public float currentLevelFloor;

	public float currentLevelCeil;

	public float progressToNextLevel;

	private readonly float initialValue;

	private readonly float growthRate;

	private readonly float growthAdditive;

	public string localizationKey;

	public bool isRounded;

	public ItemType iconItem;

	public LevelStat(ItemType item, float initial, float rate, float additive)
	{
		initialValue = initial;
		growthRate = rate;
		growthAdditive = additive;
		iconItem = item;
	}

	public void GainLevel()
	{
		level++;
		CalcLevelBounds();
		CalcProgress();
	}

	public void SetLevel(int l)
	{
		level = l;
	}

	public void SetPoints(float f)
	{
		points = f;
	}

	public void Reset()
	{
		level = 0;
		points = 0.0;
		CalcLevelBounds();
	}

	public void CalculateLevelFromPoints()
	{
		level = DerivedLevelFromPoints(points);
		CalcLevelBounds();
		CalcProgress();
	}

	public int DerivedLevelFromPoints(double skillValue)
	{
		int num = 0;
		float num2 = initialValue;
		while (skillValue >= (double)num2)
		{
			num++;
			num2 = CeilingForLevel(num);
		}
		return num;
	}

	public void CalcLevelBounds()
	{
		currentLevelFloor = CeilingForLevel(level - 1);
		currentLevelCeil = CeilingForLevel(level);
		CalcProgress();
	}

	public void CalcProgress()
	{
		float value = GameUtility.AsFloat(points);
		progressToNextLevel = Mathf.InverseLerp(currentLevelFloor, currentLevelCeil, value);
	}

	public void GainPoints(double f, bool calcProgress = true)
	{
		points += f;
		if (calcProgress)
		{
			CalcProgress();
		}
	}

	public float CeilingForLevel(int testLevel)
	{
		if (testLevel < 0)
		{
			return 0f;
		}
		float num = 120f;
		float num2 = 20f;
		float num3 = 10f;
		float num4 = 10f;
		float num5 = 10f;
		float num6 = 100f + (float)testLevel * num + Mathf.Pow(testLevel, 2f) * num2;
		if (testLevel >= 20)
		{
			num6 += Mathf.Pow(testLevel - 19, 3f) * num3;
		}
		if (testLevel >= 40)
		{
			num6 += Mathf.Pow(testLevel - 39, 4f) * num4;
		}
		if (testLevel >= 60)
		{
			num6 += Mathf.Pow(testLevel - 59, 5f) * num5;
		}
		return GameUtility.RoundToIntOrSigDigits(num6);
	}
}
