using System.Collections.Generic;
using MiscUtil.Extensions;

namespace MiscUtil.Collections
{
	internal class LinkedComparer<T> : IComparer<T>
	{
		private readonly IComparer<T> primary;

		private readonly IComparer<T> secondary;

		public LinkedComparer(IComparer<T> primary, IComparer<T> secondary)
		{
			primary.ThrowIfNull("primary");
			secondary.ThrowIfNull("secondary");
			this.primary = primary;
			this.secondary = secondary;
		}

		int IComparer<T>.Compare(T x, T y)
		{
			int num = primary.Compare(x, y);
			if (num != 0)
			{
				return num;
			}
			return secondary.Compare(x, y);
		}
	}
}
