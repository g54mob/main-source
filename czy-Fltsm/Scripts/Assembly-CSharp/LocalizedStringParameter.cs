using System;
using I2.Loc;
using PajamaLlama.I2Language;
using UnityEngine;

[Serializable]
public class LocalizedStringParameter : ILocalizationParameter
{
	[SerializeField]
	[HideInInspector]
	private string _name = "Localized String";

	[SerializeField]
	private string _parameter = "PARAMETER";

	[SerializeField]
	private LocalizedString _localizedString;

	public string GetParameterValue(string parameter)
	{
		if (_localizedString.mTerm != null && parameter == _parameter)
		{
			return _localizedString;
		}
		return parameter;
	}
}
