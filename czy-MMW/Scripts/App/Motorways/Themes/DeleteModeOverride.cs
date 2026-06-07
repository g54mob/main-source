using System;

namespace Motorways.Themes
{
	[Serializable]
	public class DeleteModeOverride
	{
		[StringEnumSearch(typeof(ThemedMaterialType))]
		public string type;

		public float hueOverride;

		public float additionalSaturationMultiplier;

		public float additionalDarkenMultiplier;

		public DeleteModeOverride(ThemedMaterialType themeType, float additionalDarken, float additionalSaturation)
		{
			type = themeType.ToString();
			additionalDarkenMultiplier = additionalDarken;
			additionalSaturationMultiplier = additionalSaturation;
		}
	}
}
