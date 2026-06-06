using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding
{
	public static class Vector2IntExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 ToInt2(this Vector2Int v)
		{
			return default(int2);
		}
	}
}
