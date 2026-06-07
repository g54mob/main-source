using System.Collections.Generic;
using ModApi.Craft.Parts;

namespace ModApi.Craft
{
	public class ActivationStage
	{
		public List<PartData> Parts { get; private set; }

		public ActivationStage()
		{
			Parts = new List<PartData>();
		}
	}
}
