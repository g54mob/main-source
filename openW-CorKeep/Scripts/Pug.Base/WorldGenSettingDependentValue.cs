using System;
using System.Runtime.CompilerServices;

[Serializable]
public struct WorldGenSettingDependentValue<T>
{
	public WorldGenerationSettingType worldGenSetting;

	public T off;

	public T low;

	public T normal;

	public T high;

	public T extreme;

	public static WorldGenSettingDependentValue<T> FromConstant(T value)
	{
		return new WorldGenSettingDependentValue<T>
		{
			off = value,
			low = value,
			normal = value,
			high = value,
			extreme = value
		};
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public T GetValue(WorldGenerationSettingLevel level)
	{
		return level switch
		{
			WorldGenerationSettingLevel.Off => off, 
			WorldGenerationSettingLevel.Low => low, 
			WorldGenerationSettingLevel.Normal => normal, 
			WorldGenerationSettingLevel.High => high, 
			WorldGenerationSettingLevel.Extreme => extreme, 
			_ => throw new ArgumentOutOfRangeException("level", level, null), 
		};
	}
}
