using System;

namespace Kitchen
{
	public struct ProgressInfo : IComparable<ProgressInfo>
	{
		public int Level;

		public int Exp;

		public int CompareTo(ProgressInfo other)
		{
			int num = Level.CompareTo(other.Level);
			if (num != 0)
			{
				return num;
			}
			return Exp.CompareTo(other.Exp);
		}
	}
}
