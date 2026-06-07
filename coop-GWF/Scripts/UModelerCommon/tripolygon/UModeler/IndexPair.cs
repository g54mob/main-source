using System;
using UnityEngine;

namespace tripolygon.UModeler
{
	[Serializable]
	public class IndexPair : SelectExtended
	{
		public static IndexPair invalide_pair = new IndexPair(-1, -1);

		[SerializeField]
		private int i0_;

		[SerializeField]
		private int i1_;

		public int i0
		{
			get
			{
				return i0_;
			}
			set
			{
				i0_ = value;
			}
		}

		public int i1
		{
			get
			{
				return i1_;
			}
			set
			{
				i1_ = value;
			}
		}

		public IndexPair()
		{
			i0_ = 0;
			i1_ = 0;
		}

		public IndexPair(int idx0, int idx1)
		{
			Set(idx0, idx1);
		}

		public IndexPair(IndexPair pair)
		{
			Set(pair);
		}

		public void Set(int idx0, int idx1)
		{
			i0_ = idx0;
			i1_ = idx1;
		}

		public void Set(IndexPair pair)
		{
			i0_ = pair.i0;
			i1_ = pair.i1;
		}

		public void Swap()
		{
			int num = i0;
			i0 = i1;
			i1 = num;
		}

		public bool IsPoint()
		{
			return i0 == i1;
		}

		public IndexPair Clone()
		{
			return new IndexPair(i0, i1)
			{
				selection = base.selection
			};
		}

		public void SetIndex(int idx, int i)
		{
			if (idx == 0)
			{
				i0_ = i;
			}
			else
			{
				i1_ = i;
			}
		}

		public bool IsEquivalent(IndexPair ip)
		{
			if (this != ip)
			{
				if (i0 == ip.i0)
				{
					return i1 == ip.i1;
				}
				return false;
			}
			return true;
		}
	}
}
