using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public static class VectorExtensions
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector2Int ToVector2Int(this Vector2 value)
	{
		return new Vector2Int((int)Math.Round(value.x, MidpointRounding.AwayFromZero), (int)Math.Round(value.y, MidpointRounding.AwayFromZero));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3Int ToVector3Int(this Vector3 value)
	{
		return new Vector3Int((int)Math.Round(value.x, MidpointRounding.AwayFromZero), (int)Math.Round(value.y, MidpointRounding.AwayFromZero), (int)Math.Round(value.z, MidpointRounding.AwayFromZero));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector2 Clamp(this Vector2 value, Vector2 minimum, Vector2 maximum)
	{
		return new Vector2(Math.Clamp(value.x, minimum.x, maximum.x), Math.Clamp(value.y, minimum.y, maximum.y));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3 Clamp(this Vector3 value, Vector3 minimum, Vector3 maximum)
	{
		return new Vector3(Math.Clamp(value.x, minimum.x, maximum.x), Math.Clamp(value.y, minimum.y, maximum.y), Math.Clamp(value.z, minimum.z, maximum.z));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 Clamp(this Vector4 value, Vector4 minimum, Vector4 maximum)
	{
		return new Vector4(Math.Clamp(value.x, minimum.x, maximum.x), Math.Clamp(value.y, minimum.y, maximum.y), Math.Clamp(value.z, minimum.z, maximum.z), Math.Clamp(value.w, minimum.w, maximum.w));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector2Int ClampReturn(this Vector2Int value, Vector2Int minimum, Vector2Int maximum)
	{
		return new Vector2Int(Math.Clamp(value.x, minimum.x, maximum.x), Math.Clamp(value.y, minimum.y, maximum.y));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3Int ClampReturn(this Vector3Int value, Vector3Int minimum, Vector3Int maximum)
	{
		return new Vector3Int(Math.Clamp(value.x, minimum.x, maximum.x), Math.Clamp(value.y, minimum.y, maximum.y), Math.Clamp(value.z, minimum.z, maximum.z));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector2 Random(this Vector2 max)
	{
		return BiteRandom.NextVector2(max);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3 Random(this Vector3 max)
	{
		return BiteRandom.NextVector3(max);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 Random(this Vector4 max)
	{
		return BiteRandom.NextVector4(max);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector2Int Random(this Vector2Int max)
	{
		return BiteRandom.NextVector2Int(max);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3Int Random(this Vector3Int max)
	{
		return BiteRandom.NextVector3Int(max);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsWithinBounds(this Vector2 max, Vector2 value)
	{
		return max.IsWithinBounds(value.x, value.y);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsWithinBounds(this Vector2 max, float x, float y)
	{
		if (x >= 0f && x < max.x && y >= 0f)
		{
			return y < max.y;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsWithinBounds(this Vector3 max, Vector3 value)
	{
		return max.IsWithinBounds(value.x, value.y, value.z);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsWithinBounds(this Vector3 max, float x, float y, float z)
	{
		if (x >= 0f && x < max.x && y >= 0f && y < max.y && z >= 0f)
		{
			return z < max.z;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsWithinBounds(this Vector4 max, Vector4 value)
	{
		return max.IsWithinBounds(value.x, value.y, value.z, value.w);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsWithinBounds(this Vector4 max, float x, float y, float z, float w)
	{
		if (x >= 0f && x < max.x && y >= 0f && y < max.y && z >= 0f && z < max.z && w >= 0f)
		{
			return w < max.w;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsWithinBounds(this Vector2Int max, Vector2Int value)
	{
		return max.IsWithinBounds(value.x, value.y);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsWithinBounds(this Vector2Int max, int x, int y)
	{
		if (x >= 0 && x < max.x && y >= 0)
		{
			return y < max.y;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsWithinBounds(this Vector3Int max, Vector3Int value)
	{
		return max.IsWithinBounds(value.x, value.y, value.z);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsWithinBounds(this Vector3Int max, int x, int y, int z)
	{
		if (x >= 0 && x < max.x && y >= 0 && y < max.y && z >= 0)
		{
			return z < max.z;
		}
		return false;
	}

	public static IEnumerable<Vector2Int> Grid(this Vector2Int size)
	{
		for (int y = 0; y < size.y; y++)
		{
			for (int x = 0; x < size.x; x++)
			{
				yield return new Vector2Int(x, y);
			}
		}
	}

	public static IEnumerable<Vector2Int> Neighbours(this Vector2Int position, Vector2Int size)
	{
		for (int y = position.y - 1; y <= position.y + 1; y++)
		{
			for (int x = position.x - 1; x <= position.x + 1; x++)
			{
				if ((x != position.x || y != position.y) && x >= 0 && x < size.x && y >= 0 && y < size.y)
				{
					yield return new Vector2Int(x, y);
				}
			}
		}
	}
}
