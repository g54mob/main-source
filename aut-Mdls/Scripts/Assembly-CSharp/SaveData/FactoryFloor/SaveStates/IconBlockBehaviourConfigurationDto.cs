using System;
using System.Collections.Generic;
using Data.Shapes;
using Newtonsoft.Json;

namespace SaveData.FactoryFloor.SaveStates
{
	[Serializable]
	public class IconBlockBehaviourConfigurationDto : BehaviourConfigurationDto
	{
		[JsonProperty("i")]
		public int IconIndex;

		public override BehaviourConfigurationDto CopyOf()
		{
			return new IconBlockBehaviourConfigurationDto
			{
				IconIndex = IconIndex
			};
		}

		public override List<ShapeDto> GetAllRelatedShapes()
		{
			return new List<ShapeDto>();
		}
	}
}
