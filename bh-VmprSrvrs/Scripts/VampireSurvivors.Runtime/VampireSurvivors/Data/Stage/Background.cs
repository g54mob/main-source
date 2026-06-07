using System;
using Poncle.Schema.Attributes.Attributes;

namespace VampireSurvivors.Data.Stage
{
	[Serializable]
	[Title("Background")]
	public class Background
	{
		[Title("Texture")]
		public string texture { get; set; }

		[Title("Stage Type")]
		public StageType? stageType { get; set; }
	}
}
