using System;
using UnityEngine;

namespace NSEipix.Model
{
	[Serializable]
	public struct ShortRange
	{
		[SerializeField]
		private short min;

		[SerializeField]
		private short max;

		public short Min
		{
			get
			{
				return min;
			}
			set
			{
				min = value;
			}
		}

		public short Max
		{
			get
			{
				return max;
			}
			set
			{
				max = value;
			}
		}

		public ShortRange(short min, short max)
		{
			this.min = min;
			this.max = max;
		}

		public bool IsZero()
		{
			if (min == 0)
			{
				return max == 0;
			}
			return false;
		}

		public int Random()
		{
			return UnityEngine.Random.Range(min, max);
		}

		public float Average()
		{
			return (float)(min + max) / 2f;
		}
	}
}
