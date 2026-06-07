using UnityEngine;

namespace ScheduleOne.Weather
{
	[CreateAssetMenu(fileName = "WeatherProfile", menuName = "ScriptableObjects/Weather/Weather Profile")]
	public class WeatherProfile : ScriptableObject
	{
		[SerializeField]
		private string _id;

		[SerializeField]
		private SkySettings _skySettings;

		[SerializeField]
		private WeatherVolume _weatherVolumePrefab;

		[SerializeField]
		private WeatherConditions _conditions;

		public string Id => null;

		public WeatherVolume WeatherVolumePrefab => null;

		public SkySettings SkySettings => null;

		public WeatherConditions Conditions => null;
	}
}
