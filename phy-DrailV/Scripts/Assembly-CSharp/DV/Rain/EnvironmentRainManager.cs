using DV.Utils;
using DV.WeatherSystem;
using DV.WorldTools;
using UnityEngine;

namespace DV.Rain
{
	public class EnvironmentRainManager : MonoBehaviour
	{
		private const float VOLUME_THRESHOLD = 0.01f;

		public AudioSource rainSource;

		public AudioSource depotSource;

		public float volume = 1f;

		public float heightFadeOut = 100f;

		private void Update()
		{
			Camera activeCamera = PlayerManager.ActiveCamera;
			if (!activeCamera || !SingletonBehaviour<WeatherDriver>.Instance)
			{
				rainSource.volume = 0f;
				depotSource.volume = 0f;
				rainSource.enabled = false;
				depotSource.enabled = false;
				return;
			}
			ZoneDetector.GetValue(ZoneDetector.ZoneType.Depot, out var value);
			ZoneDetector.GetValue(ZoneDetector.ZoneType.Tunnel, out var value2);
			Vector3 position = activeCamera.transform.position;
			float num = Mathf.Max(LevelInfo.WaterLevel, HeightMapProvider.GetInterpolated(position));
			float num2 = 1f - Mathf.InverseLerp(0f, heightFadeOut, position.y - num);
			rainSource.volume = (float)SingletonBehaviour<WeatherDriver>.Instance.RainValue * volume * (1f - value2) * num2;
			depotSource.volume = (float)SingletonBehaviour<WeatherDriver>.Instance.RainValue * volume * value * num2;
			bool flag = rainSource.volume > 0.01f;
			bool flag2 = depotSource.volume > 0.01f;
			if (rainSource.enabled != flag)
			{
				rainSource.enabled = flag;
			}
			if (depotSource.enabled != flag2)
			{
				depotSource.enabled = flag2;
			}
		}
	}
}
