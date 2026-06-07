using System.Collections.Generic;

namespace ModApi.Settings.Core
{
	public interface IEnumSetting
	{
		IReadOnlyList<string> AvailableStringValues { get; }

		string DisplayValue { get; }

		string GetDisplayValue(string value);

		void SetInternalValueFromDisplayValue(string displayValue);

		void SetStringValue(string value);
	}
}
