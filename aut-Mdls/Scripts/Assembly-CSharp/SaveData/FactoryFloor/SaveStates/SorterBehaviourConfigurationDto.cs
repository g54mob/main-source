using System.Collections.Generic;
using Data.FactoryFloor.Resources;
using Data.Shapes;
using Newtonsoft.Json;

namespace SaveData.FactoryFloor.SaveStates
{
	public class SorterBehaviourConfigurationDto : BehaviourConfigurationDto
	{
		public const int CurrentVersion = 1;

		[JsonProperty("r")]
		public ResourceDto FilteredResource;

		public SorterBehaviourConfigurationDto()
			: base(1)
		{
			FilteredResource = null;
		}

		public override BehaviourConfigurationDto CopyOf()
		{
			return new SorterBehaviourConfigurationDto
			{
				FilteredResource = FilteredResource
			};
		}

		public override List<ShapeDto> GetAllRelatedShapes()
		{
			return new List<ShapeDto>();
		}
	}
}
