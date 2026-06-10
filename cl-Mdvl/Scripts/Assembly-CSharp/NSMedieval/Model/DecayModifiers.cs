using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Dictionary;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class DecayModifiers : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private float[] temperatureCoefficients;

		[SerializeField]
		private float groundCoefficient;

		[SerializeField]
		private float waterCoefficient;

		[SerializeField]
		private StringKeyPair weatherModifiers;

		public float GroundCoefficient => groundCoefficient;

		public float[] TemperatureCoefficients => temperatureCoefficients;

		public float WaterCoefficient => waterCoefficient;

		public Dictionary<string, float> WeatherModifiers => this?.weatherModifiers?.Dictionary;

		public void SetDefaultTemperatureCoefficients(float[] temperatureCoefficients)
		{
			this.temperatureCoefficients = temperatureCoefficients;
		}

		public void SetDefaultWeatherModifiers(Dictionary<string, float> weatherModifiersDictionary)
		{
			if (weatherModifiers == null)
			{
				weatherModifiers = new StringKeyPair();
			}
			weatherModifiers.Dictionary = weatherModifiersDictionary;
		}

		public override string GetID()
		{
			return id;
		}
	}
}
