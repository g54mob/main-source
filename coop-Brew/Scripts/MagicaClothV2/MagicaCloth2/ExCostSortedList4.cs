using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MagicaCloth2
{
	public struct ExCostSortedList4
	{
		internal float4 costs;

		internal int4 data;

		public int Count
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return 0;
			}
		}

		public bool IsValid => false;

		public float MinCost
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return 0f;
			}
		}

		public float MaxCost
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return 0f;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ExCostSortedList4(float invalidCost)
		{
			costs = default(float4);
			data = default(int4);
		}

		public bool Add(float cost, int item)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Contains(int item)
		{
			return false;
		}

		public int indexOf(int item)
		{
			return 0;
		}

		public void RemoveItem(int item)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
