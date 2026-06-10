using System;
using System.Collections.Generic;
using UnityEngine;

namespace NSMedieval.StatsSystem
{
	[Serializable]
	public class EffectDetailsHolder
	{
		[Serializable]
		private class ThresholdEffectParameter
		{
			[SerializeField]
			private string key;

			[SerializeField]
			private string value;

			public string Key => key;

			public string Value => value;
		}

		[SerializeField]
		private EffectorType type;

		[SerializeField]
		private ThresholdEffectParameter[] parameters;

		private Dictionary<string, string> parametersDict;

		public EffectorType Type => type;

		public Dictionary<string, string> Parameters
		{
			get
			{
				if (parametersDict == null)
				{
					GenerateParametersDict();
				}
				return parametersDict;
			}
		}

		private void GenerateParametersDict()
		{
			parametersDict = new Dictionary<string, string>();
			if (parameters != null)
			{
				ThresholdEffectParameter[] array = parameters;
				foreach (ThresholdEffectParameter thresholdEffectParameter in array)
				{
					parametersDict.Add(thresholdEffectParameter.Key, string.IsNullOrEmpty(thresholdEffectParameter.Value) ? thresholdEffectParameter.Value : thresholdEffectParameter.Value.Replace(",", "."));
				}
			}
		}
	}
}
