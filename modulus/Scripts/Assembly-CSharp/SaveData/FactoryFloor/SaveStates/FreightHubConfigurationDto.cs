using System;
using System.Collections.Generic;
using Data.Shapes;
using Newtonsoft.Json;

namespace SaveData.FactoryFloor.SaveStates
{
	[Serializable]
	public class FreightHubConfigurationDto : BehaviourConfigurationDto
	{
		public const int CurrentVersion = 0;

		[JsonProperty("n")]
		public string CustomName;

		public FreightHubConfigurationDto(string customName)
			: base(0)
		{
			CustomName = customName;
		}

		public override BehaviourConfigurationDto CopyOf()
		{
			return new FreightHubConfigurationDto(CustomName);
		}

		public override List<ShapeDto> GetAllRelatedShapes()
		{
			return new List<ShapeDto>();
		}
	}
}
