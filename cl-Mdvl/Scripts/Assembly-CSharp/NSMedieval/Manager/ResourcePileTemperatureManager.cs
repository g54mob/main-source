using FoxyVoxel.Logging;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Repository;

namespace NSMedieval.Manager
{
	public class ResourcePileTemperatureManager : MonoSingleton<ResourcePileTemperatureManager>
	{
		public static int GetTemperatureThresholdIndex(float temperature)
		{
			int num = -1;
			float[] temperatureThresholds = Repository<ResourceSettingsData, ResourceSettings>.Instance.GetData<ResourceSettings>().TemperatureThresholds;
			for (int i = 0; i < temperatureThresholds.Length; i++)
			{
				if (temperature <= temperatureThresholds[i])
				{
					num = i;
					break;
				}
			}
			if (num <= -1)
			{
				if (!(temperature > temperatureThresholds[^1]))
				{
					Log.Error("There was some strange problem with temperature thresholds!", "C:\\GIT\\dev\\Assets\\Scripts\\Gameplay\\Resource\\ResourcePileTemperatureManager.cs");
					return num;
				}
				num = temperatureThresholds.Length - 1;
			}
			return num;
		}
	}
}
