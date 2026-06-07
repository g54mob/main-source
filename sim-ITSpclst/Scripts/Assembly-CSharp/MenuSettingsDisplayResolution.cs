using System;

[Serializable]
public class MenuSettingsDisplayResolution
{
	public string name;

	public int width;

	public int height;

	public string proportions;

	private static readonly (int, int)[] standardRatios;

	public MenuSettingsDisplayResolution(int width, int height)
	{
	}

	private string CalculateProportions(int width, int height)
	{
		return null;
	}

	private (int, int) FindNearestStandardRatio(int width, int height)
	{
		return default((int, int));
	}

	private int GCD(int a, int b)
	{
		return 0;
	}
}
