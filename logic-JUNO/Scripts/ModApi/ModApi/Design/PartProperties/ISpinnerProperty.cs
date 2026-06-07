using System.Collections.Generic;

namespace ModApi.Design.PartProperties
{
	public interface ISpinnerProperty : IConfigurableProperty
	{
		bool IsTextSpinner { get; }

		string LabelValue { get; set; }

		decimal NumericValue { get; }

		string TextValue { get; }

		IReadOnlyList<string> Values { get; }

		void UpdateNumericSpinnerSettings(decimal minValue, decimal maxValue, decimal stepSize);

		void UpdateValues();
	}
}
