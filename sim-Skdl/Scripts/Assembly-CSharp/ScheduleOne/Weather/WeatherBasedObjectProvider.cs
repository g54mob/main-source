using System;
using UnityEngine;

namespace ScheduleOne.Weather
{
	[CreateAssetMenu(fileName = "WeatherBasedObjectProvider", menuName = "ScriptableObjects/Weather/Weather Based Object Provider")]
	public class WeatherBasedObjectProvider : ScriptableObject
	{
		[Serializable]
		public enum EvaluationType
		{
			LessThan = 0,
			Equals = 1,
			GreaterThan = 2,
			Blend = 3
		}

		[Flags]
		public enum ConditionFlags
		{
			None = 0,
			Sunny = 1,
			Cloudy = 2,
			Rainy = 4,
			Stormy = 8,
			Snowy = 0x10,
			Foggy = 0x20,
			Windy = 0x40,
			Hail = 0x80,
			Sleet = 0x100
		}

		[SerializeField]
		private ConditionFlags _selectedConditions;

		[SerializeField]
		private WeatherConditions _conditions;

		[SerializeField]
		private EvaluationType _evaluationType;

		[SerializeField]
		private UnityEngine.Object _object;

		public UnityEngine.Object Object => null;

		public bool DoesSatisfyConditions(WeatherConditions activeConditions)
		{
			return false;
		}

		public float GetAverageBlend(WeatherConditions activeConditions)
		{
			return 0f;
		}

		private float GetConditionBlendValue(float activeValue, float condition)
		{
			return 0f;
		}

		private bool EvaluateConditions(float conditionValue, float conditionThreshold)
		{
			return false;
		}
	}
}
