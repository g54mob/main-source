using System.Collections.Generic;

namespace Mandragora.ResourceUtils
{
	public class CompareByPathGameResource : IComparer<ResourceData>
	{
		public int Compare(ResourceData x, ResourceData y)
		{
			if (x.Path == null)
			{
				return -1;
			}
			if (y.Path == null)
			{
				return 1;
			}
			return string.Compare(x.Path, y.Path);
		}
	}
}
