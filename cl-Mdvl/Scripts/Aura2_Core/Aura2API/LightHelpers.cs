using UnityEngine.Rendering;

namespace Aura2API
{
	public static class LightHelpers
	{
		public static bool IsColorTemperatureAvailable
		{
			get
			{
				if (GraphicsSettings.lightsUseLinearIntensity)
				{
					return GraphicsSettings.lightsUseColorTemperature;
				}
				return false;
			}
		}
	}
}
