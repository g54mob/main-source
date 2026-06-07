using System;
using UnityEngine.Rendering;

namespace RetroShadersPro.URP
{
	[Serializable]
	public sealed class ColorRampModeParameter : VolumeParameter<ColorRampMode>
	{
		public ColorRampModeParameter(ColorRampMode value, bool overrideState = false)
			: base(value, overrideState)
		{
		}
	}
}
