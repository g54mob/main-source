using System.Collections.Generic;
using DV.Utils;
using I2.Loc;
using UnityEngine;

namespace DV.Localization
{
	[ExecutionOrder(-115)]
	[DisallowMultipleComponent]
	public class Localize : MonoBehaviour
	{
		public string key = "";

		private Option<I2.Loc.Localize> i2localization;

		private Option<LocalizationParamsManager> i2paramsManager;

		private void Awake()
		{
			UpdateLocalization();
		}

		public void UpdateLocalization(Dictionary<string, string> parameters = null)
		{
			if (!i2localization.IsSome(out var value))
			{
				i2localization = Option<I2.Loc.Localize>.Some(value = base.gameObject.AddComponent<I2.Loc.Localize>());
			}
			if (parameters != null)
			{
				if (!i2paramsManager.IsSome(out var value2))
				{
					i2paramsManager = Option<LocalizationParamsManager>.Some(value2 = base.gameObject.AddComponent<LocalizationParamsManager>());
				}
				foreach (KeyValuePair<string, string> parameter in parameters)
				{
					value2.SetParameterValue(parameter.Key, parameter.Value);
				}
			}
			value.SetTerm(key.Trim());
		}
	}
}
