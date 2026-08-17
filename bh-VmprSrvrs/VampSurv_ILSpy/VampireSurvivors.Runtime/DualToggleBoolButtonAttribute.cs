using System;

public class DualToggleBoolButtonAttribute : Attribute
{
	private readonly string _buttonOnText;

	private readonly string _buttonOffText;

	private readonly string _labelText;

	private readonly bool _showLabel;

	private readonly bool _invertButtons;

	public string ButtonOnText => _buttonOnText;

	public string ButtonOffText => _buttonOffText;

	public string LabelText => _labelText;

	public bool ShowLabel => _showLabel;

	public bool InvertButtons => _invertButtons;

	public DualToggleBoolButtonAttribute(string buttonOnText, string buttonOffText, string labelText = null, bool showLabel = true, bool invertButtons = false)
	{
		_buttonOnText = buttonOnText;
		_buttonOffText = buttonOffText;
		_labelText = labelText;
		bool showLabel2 = default(bool);
		_showLabel = showLabel2;
		bool invertButtons2 = default(bool);
		_invertButtons = invertButtons2;
	}
}
