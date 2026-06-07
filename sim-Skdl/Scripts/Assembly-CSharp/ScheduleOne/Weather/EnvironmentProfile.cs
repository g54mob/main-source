using Funly.SkyStudio;
using UnityEngine;

namespace ScheduleOne.Weather
{
	[CreateAssetMenu(fileName = "EnvironmentProfile", menuName = "ScriptableObjects/Weather/Environment Profile")]
	public class EnvironmentProfile : ScriptableObject
	{
		[SerializeField]
		[Header("Sky profile (TEMP - REPLACING)")]
		private SkyProfile _skyProfile;

		[Header("Sky Settings")]
		[SerializeField]
		private SkySettings _skySettings;

		public SkySettings SkySettings => null;

		public SkyProfile GetSkyProfile()
		{
			return null;
		}
	}
}
