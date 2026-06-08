using System;

namespace Platforms
{
	public class Nothing : IComparable<Nothing>
	{
		public int CompareTo(Nothing obj)
		{
			return 0;
		}
	}
}
