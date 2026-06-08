using System;
using System.Collections.Generic;

namespace CsvHelper.Configuration
{
	internal class MemberMapComparer : IComparer<MemberMap>
	{
		public virtual int Compare(object x, object y)
		{
			MemberMap x2 = x as MemberMap;
			MemberMap y2 = y as MemberMap;
			return Compare(x2, y2);
		}

		public virtual int Compare(MemberMap x, MemberMap y)
		{
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			return x.Data.Index.CompareTo(y.Data.Index);
		}
	}
}
