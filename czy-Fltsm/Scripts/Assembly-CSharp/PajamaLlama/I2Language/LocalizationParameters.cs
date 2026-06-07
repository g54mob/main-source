using System;
using UnityEngine;

namespace PajamaLlama.I2Language
{
	[Serializable]
	public class LocalizationParameters
	{
		[SerializeReference]
		[SubclassSelector]
		private ILocalizationParameter[] _localizationParameters;

		public string GetParameterValue(string parameter)
		{
			if (_localizationParameters.IsNullOrEmpty())
			{
				return parameter;
			}
			string empty = string.Empty;
			ILocalizationParameter[] localizationParameters = _localizationParameters;
			foreach (ILocalizationParameter localizationParameter in localizationParameters)
			{
				if (localizationParameter != null)
				{
					empty = localizationParameter.GetParameterValue(parameter);
					if (empty != null && empty != parameter)
					{
						return empty;
					}
				}
			}
			return parameter;
		}
	}
}
