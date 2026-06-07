using System.Collections.Generic;
using UnityEngine;

public class ModulePixelShapePreset
{
	public struct CustomizablePixelShapePreset
	{
		public CustomizableRenderer renderer;

		public Dictionary<int, PixelShapePreset[]> presets;

		public CustomizablePixelShapePreset(CustomizableRenderer renderer, Dictionary<int, PixelShapePreset[]> presets)
		{
			this.renderer = null;
			this.presets = null;
		}

		public PixelShapePreset[] GetActivePresets()
		{
			return null;
		}
	}

	public PixelShapePreset[] basePresets;

	public List<CustomizablePixelShapePreset> customizablesPresets;

	public ModulePixelShapePreset(int rotationCount)
	{
	}

	public void Apply(PixelShape target, int rotationI, Transform rootTransform = null)
	{
	}
}
