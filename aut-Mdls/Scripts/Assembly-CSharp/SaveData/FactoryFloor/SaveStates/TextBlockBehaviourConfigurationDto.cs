using System;
using System.Collections.Generic;
using Data.Shapes;
using Newtonsoft.Json;
using TMPro;

namespace SaveData.FactoryFloor.SaveStates
{
	[Serializable]
	public class TextBlockBehaviourConfigurationDto : BehaviourConfigurationDto
	{
		[JsonProperty("t")]
		public string Text = string.Empty;

		[JsonProperty("a")]
		public TextAlignmentOptions Alignment = TextAlignmentOptions.Midline;

		public override BehaviourConfigurationDto CopyOf()
		{
			return new TextBlockBehaviourConfigurationDto
			{
				Text = Text,
				Alignment = Alignment
			};
		}

		public override List<ShapeDto> GetAllRelatedShapes()
		{
			return new List<ShapeDto>();
		}
	}
}
