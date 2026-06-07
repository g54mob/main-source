using UnityEngine.UI;

public static class UIEventSyncExtensions
{
	private static Slider.SliderEvent emptySliderEvent;

	private static Toggle.ToggleEvent emptyToggleEvent;

	private static InputField.OnChangeEvent emptyInputFieldEvent;

	public static void SetValue(this Slider instance, float value)
	{
	}

	public static void SetValue(this Toggle instance, bool value)
	{
	}

	public static void SetValue(this InputField instance, string value)
	{
	}
}
