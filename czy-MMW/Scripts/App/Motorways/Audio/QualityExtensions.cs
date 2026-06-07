using System.Collections.Generic;
using System.Linq;

namespace Motorways.Audio
{
	public static class QualityExtensions
	{
		public static List<Quality> Chromatic(this List<Quality> list, string addendName = "")
		{
			List<Quality> list2 = list.ToList();
			list2.Edit((Quality x) => x.Chromatic(addendName));
			return list2;
		}

		public static List<Quality> Transpose(this List<Quality> list, int delta)
		{
			List<Quality> list2 = list.ToList();
			list2.Edit((Quality x) => x.Transpose(delta));
			return list2;
		}

		public static List<Quality> Modal(this List<Quality> list, string addendName = "")
		{
			List<Quality> list2 = list.ToList();
			list2.Edit(delegate(Quality x)
			{
				x.Name += ((addendName.Length > 0) ? (" " + addendName) : "");
				return x.Modal();
			});
			return list2;
		}

		public static List<Quality> Chromodal(this List<Quality> list)
		{
			return list.Modal().Chromatic();
		}

		public static List<Quality> Keyless(this List<Quality> list)
		{
			List<Quality> list2 = list.ToList();
			list2.Edit((Quality q) => q.Keyless());
			return list2;
		}
	}
}
