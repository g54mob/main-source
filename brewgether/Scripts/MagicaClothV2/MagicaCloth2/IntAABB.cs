using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MagicaCloth2
{
	[Serializable]
	public struct IntAABB : IEquatable<IntAABB>
	{
		public int3 Min;

		public int3 Max;

		public int3 Extents => default(int3);

		public int3 Center => default(int3);

		public bool IsValid => false;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public IntAABB(int3 min, int3 max)
		{
			Min = default(int3);
			Max = default(int3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Contains(int3 point)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Contains(IntAABB aabb)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Overlaps(IntAABB aabb)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Expand(int signedDistance)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Encapsulate(IntAABB aabb)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Encapsulate(int3 point)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(IntAABB other)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return null;
		}
	}
}
