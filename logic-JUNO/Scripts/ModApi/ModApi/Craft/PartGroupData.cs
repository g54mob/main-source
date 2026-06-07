using System.Collections.Generic;
using ModApi.Craft.Parts;

namespace ModApi.Craft
{
	public class PartGroupData
	{
		public List<PartData> Parts { get; private set; }

		public PartGroupData()
		{
			Parts = new List<PartData>();
		}
	}
}
