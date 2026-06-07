using System.Collections.Generic;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public class LanguageConnection : ConnectionWithOptions<string>
	{
		public List<string> _values;

		public static List<string> _I2values;

		public List<string> _labels;

		private static string currentValue;

		public static string currentLanguage;

		public static string CurrentValue => currentValue;

		public override List<string> GetOptionLabels()
		{
			if (_labels == null && _I2values.Count > 0)
			{
				_labels = _I2values;
			}
			return _labels;
		}

		public override void SetOptionLabels(List<string> optionLabels)
		{
			List<string> optionLabels2 = GetOptionLabels();
			if (optionLabels == null || optionLabels.Count != optionLabels2.Count)
			{
				Debug.LogError("Invalid new labels. Need to be " + optionLabels2.Count + ".");
			}
			else
			{
				_labels = new List<string>(optionLabels);
			}
		}

		public override void RefreshOptionLabels()
		{
			_labels = null;
			GetOptionLabels();
		}

		public override int Get()
		{
			List<string> optionLabels = GetOptionLabels();
			for (int i = 0; i < optionLabels.Count; i++)
			{
				if (optionLabels[i] == currentLanguage)
				{
					return i;
				}
			}
			return 0;
		}

		public override void Set(int index)
		{
			List<string> optionLabels = GetOptionLabels();
			index = Mathf.Clamp(index, 0, optionLabels.Count - 1);
			currentLanguage = optionLabels[index];
			NotifyListenersIfChanged(index);
		}
	}
}
