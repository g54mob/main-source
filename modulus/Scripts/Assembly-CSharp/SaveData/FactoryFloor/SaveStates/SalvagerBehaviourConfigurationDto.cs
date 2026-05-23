using System;
using System.Collections.Generic;
using Data.Shapes;
using Newtonsoft.Json;

namespace SaveData.FactoryFloor.SaveStates
{
	[Serializable]
	public class SalvagerBehaviourConfigurationDto : BehaviourConfigurationDto
	{
		[JsonProperty("i")]
		public int Index;

		public override BehaviourConfigurationDto CopyOf()
		{
			return new SalvagerBehaviourConfigurationDto
			{
				Index = Index
			};
		}

		public override List<ShapeDto> GetAllRelatedShapes()
		{
			return new List<ShapeDto>();
		}
	}
}
