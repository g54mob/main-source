using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Pathfinding.Poly2Tri
{
	public struct FixedBitArray3 : IEnumerable, IEnumerable<bool>
	{
		public bool _0;

		public bool _1;

		public bool _2;

		public bool this[int index]
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public bool Contains(bool value)
		{
			return false;
		}

		public int IndexOf(bool value)
		{
			return 0;
		}

		public void Clear()
		{
		}

		public void Clear(bool value)
		{
		}

		[DebuggerHidden]
		private IEnumerable<bool> Enumerate()
		{
			return null;
		}

		public IEnumerator<bool> GetEnumerator()
		{
			return null;
		}
	}
}
