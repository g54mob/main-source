using System;
using Pug.UnityExtensions;

[Serializable]
public struct EnvironmentalSpawnChance
{
	public enum Source
	{
		Constant = 0,
		WorldGenSetting = 1
	}

	public Source source;

	public PlatformDependentValue<float> constantValue;

	public WorldGenSettingDependentValue<float> worldGenDependentValue;

	public WorldGenSettingDependentValue<float> AsWorldGenSettingDependentValue()
	{
		if (source != Source.Constant)
		{
			return worldGenDependentValue;
		}
		return WorldGenSettingDependentValue<float>.FromConstant(constantValue.GetValueForCurrentPlatform());
	}
}
