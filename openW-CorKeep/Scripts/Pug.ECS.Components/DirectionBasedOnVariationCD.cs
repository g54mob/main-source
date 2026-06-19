using Unity.Entities;
using Unity.Mathematics;

public struct DirectionBasedOnVariationCD : IComponentData, IQueryTypeParameter
{
	public int2 direction;

	public bool alsoUpdateCollider;

	public bool alignWithNearbyAffectorsWhenPlaced;

	public static int2 GetDirectionFromVariation(int variation, bool variationZeroIsNoDirection = false)
	{
		if (variationZeroIsNoDirection)
		{
			if (variation == 0)
			{
				return int2.zero;
			}
			variation--;
		}
		return variation switch
		{
			0 => new int2(0, 1), 
			1 => new int2(1, 0), 
			2 => new int2(0, -1), 
			3 => new int2(-1, 0), 
			_ => int2.zero, 
		};
	}

	public static int GetVariationFromDirection(int2 direction, bool variationZeroIsNoDirection = false)
	{
		int num = 0;
		if (variationZeroIsNoDirection)
		{
			num = 1;
		}
		if (math.all(direction == new int2(0, 1)))
		{
			num = num;
		}
		else if (math.all(direction == new int2(1, 0)))
		{
			num++;
		}
		else if (math.all(direction == new int2(0, -1)))
		{
			num += 2;
		}
		else if (math.all(direction == new int2(-1, 0)))
		{
			num += 3;
		}
		return num;
	}

	public static int GetFlippedVariation(int variation, bool flippedX, bool flippedY)
	{
		if (flippedY && variation == 0)
		{
			return 2;
		}
		if (flippedX && variation == 1)
		{
			return 3;
		}
		if (flippedY && variation == 2)
		{
			return 0;
		}
		if (flippedX && variation == 3)
		{
			return 1;
		}
		return variation;
	}
}
