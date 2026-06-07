using System;

namespace AwesomeTechnologies.VegetationSystem
{
	[Serializable]
	public class TerrainTextureRule
	{
		public int TextureIndex;

		public float MinimumValue;

		public float MaximumValue;

		public TerrainTextureRule()
		{
		}

		public TerrainTextureRule(TerrainTextureRule sourceItem)
		{
			TextureIndex = sourceItem.TextureIndex;
			MinimumValue = sourceItem.MinimumValue;
			MaximumValue = sourceItem.MaximumValue;
		}
	}
}
