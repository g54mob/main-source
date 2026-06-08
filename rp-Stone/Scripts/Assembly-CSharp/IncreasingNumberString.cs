using System;

[Serializable]
public class IncreasingNumberString : AsciiString
{
	public long displayedValue { get; set; }

	public long targetValue { get; set; }

	public void UpdateTic()
	{
		if (displayedValue != targetValue)
		{
			displayedValue = MoneyUI.IterateVisibleCount(targetValue, displayedValue);
			string value = Utils.FormatNumber(displayedValue);
			SetValue(value);
		}
	}
}
