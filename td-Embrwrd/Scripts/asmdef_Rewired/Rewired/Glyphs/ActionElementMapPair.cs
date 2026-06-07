using System;

namespace Rewired.Glyphs
{
	public struct ActionElementMapPair : IEquatable<ActionElementMapPair>
	{
		public ActionElementMap a;

		public ActionElementMap b;

		public int Count => 0;

		public ActionElementMapPair(ActionElementMap a, ActionElementMap b)
		{
			this.a = null;
			this.b = null;
		}

		public bool Equals(ActionElementMapPair other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(ActionElementMapPair a, ActionElementMapPair b)
		{
			return false;
		}

		public static bool operator !=(ActionElementMapPair a, ActionElementMapPair b)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
