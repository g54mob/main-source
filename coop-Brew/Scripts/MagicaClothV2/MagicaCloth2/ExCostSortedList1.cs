using System;
using System.Runtime.CompilerServices;

namespace MagicaCloth2
{
	public struct ExCostSortedList1 : IComparable<ExCostSortedList1>
	{
		internal float cost;

		internal int data;

		public bool IsValid => false;

		public int Count => 0;

		public float Cost => 0f;

		public int Data => 0;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ExCostSortedList1(float invalidCost)
		{
			cost = 0f;
			data = 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ExCostSortedList1(float invalidCost, int initData)
		{
			cost = 0f;
			data = 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Add(float cost, int item)
		{
		}

		public int CompareTo(ExCostSortedList1 other)
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
