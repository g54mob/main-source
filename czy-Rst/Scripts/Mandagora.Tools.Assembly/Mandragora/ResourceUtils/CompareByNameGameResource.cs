using System.Collections.Generic;

namespace Mandragora.ResourceUtils
{
	public class CompareByNameGameResource : IComparer<ResourceData>
	{
		public int Compare(ResourceData x, ResourceData y)
		{
			if (x.Name == null)
			{
				return -1;
			}
			if (y.Name == null)
			{
				return 1;
			}
			return string.Compare(x.Name, y.Name);
		}
	}
}
