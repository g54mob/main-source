using System;
using System.Collections.Generic;

namespace Kitchen
{
	public static class SetMatcher
	{
		public static bool Difference<T1, T2>(IEnumerable<T1> set1, IEnumerable<T2> set2, ref List<T1> missing, ref List<T2> extra, Func<T1, T2, bool> is_same)
		{
			missing.Clear();
			extra.Clear();
			foreach (T2 item in set2)
			{
				extra.Add(item);
			}
			foreach (T1 item2 in set1)
			{
				bool flag = false;
				foreach (T2 item3 in extra)
				{
					if (is_same(item2, item3))
					{
						flag = true;
						extra.Remove(item3);
						break;
					}
				}
				if (!flag)
				{
					missing.Add(item2);
				}
			}
			if (missing.Count == 0)
			{
				return extra.Count == 0;
			}
			return false;
		}
	}
}
