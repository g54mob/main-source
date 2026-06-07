using System.Collections.Generic;
using DV.Localization;
using DV.Scenarios.Common;

namespace DV.UI
{
	public static class TrainExtensions
	{
		private static readonly Dictionary<string, string> LOCALIZATION_KEYS = new Dictionary<string, string>();

		public static string ToLocalizedString(this ITrain train)
		{
			if (train.IsReadOnly && LOCALIZATION_KEYS.TryGetValue(train.Name, out var value))
			{
				return LocalizationAPI.L(value);
			}
			return train.Name;
		}
	}
}
