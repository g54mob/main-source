using DV.Utils;
using DV.WeatherSystem;
using UnityEngine;

[ExecutionOrder(50)]
public class UpdateFogValuesDV : UpdateFogValues
{
	private static readonly int WATER_HEIGHT = Shader.PropertyToID("DV_WaterHeight");

	private void Awake()
	{
		Shader.SetGlobalFloat(WATER_HEIGHT, (SingletonBehaviour<LevelInfo>.Instance != null) ? SingletonBehaviour<LevelInfo>.Instance.waterLevel : (-10f));
	}

	protected override float GetWaterLevelY()
	{
		return LevelInfo.WaterLevel;
	}
}
