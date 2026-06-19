using System;
using Unity.Mathematics;

public static class CompassDirectionExtensions
{
	public static CompassDirection CompassDirectionFromCore(int2 worldPosition)
	{
		if (math.all(worldPosition == 0))
		{
			return CompassDirection.Undefined;
		}
		int num = (int)math.round(math.atan2(worldPosition.y, worldPosition.x) / 2f / MathF.PI * 8f);
		if (num < 0)
		{
			num += 8;
		}
		num++;
		return (CompassDirection)num;
	}
}
