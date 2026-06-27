using UnityEngine;

namespace DistantLands.Cozy
{
	[ExecuteAlways]
	public class CozySatellite : MonoBehaviour
	{
		public float orbitOffset;

		public float satelliteRotateSpeed;

		public float satelliteDirection;

		private Transform m_Satellite;

		private CozyWeather m_WeatherManager;

		private void Awake()
		{
			m_Satellite = base.transform.GetChild(0);
			m_WeatherManager = CozyWeather.instance;
		}

		private void Update()
		{
			m_Satellite.localEulerAngles += Vector3.up * Time.deltaTime * satelliteRotateSpeed;
			base.transform.localEulerAngles = new Vector3(0f - ((float)m_WeatherManager.timeModule.currentTime * 360f - 90f + orbitOffset), satelliteDirection, 0f);
		}
	}
}
