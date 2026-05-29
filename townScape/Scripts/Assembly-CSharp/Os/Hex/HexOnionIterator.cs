using System;
using Unity.Mathematics;
using UnityEngine;

namespace Os.Hex
{
	[Serializable]
	public struct HexOnionIterator
	{
		[SerializeField]
		private uint _vertIndex;

		[SerializeField]
		private uint _sideIndex;

		[SerializeField]
		private uint _layerIndex;

		[SerializeField]
		private uint _vertIndexInSide;

		[SerializeField]
		private uint _vertCountInSide;

		[SerializeField]
		private int3 _hexPos;

		[SerializeField]
		private int3 delta;

		public uint layerIndex => 0u;

		public uint vertCountInSide => 0u;

		public uint vertIndexInSide => 0u;

		public uint sideIndex => 0u;

		public uint vertIndex
		{
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		public int3 hexPos3 => default(int3);

		public int2 hexPos2 => default(int2);

		public int2 dualPos2 => default(int2);

		public int3 GetAndIncrement()
		{
			return default(int3);
		}

		public static HexOnionIterator GetWidthDelta(int3 delta)
		{
			return default(HexOnionIterator);
		}

		public static HexOnionIterator GetAt(uint vertIndex)
		{
			return default(HexOnionIterator);
		}

		public int3 Increment()
		{
			return default(int3);
		}

		public int3 Decrement()
		{
			return default(int3);
		}
	}
}
