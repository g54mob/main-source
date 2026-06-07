using System;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class DualToggleBoolButtonAttribute : Attribute
{
	private readonly string _buttonOnText;

	private readonly string _buttonOffText;

	private readonly string _labelText;

	private readonly bool _showLabel;

	private readonly bool _invertButtons;

	public string ButtonOnText => null;

	public string ButtonOffText => null;

	public string LabelText => null;

	public bool ShowLabel => false;

	public bool InvertButtons => false;

	public DualToggleBoolButtonAttribute(string buttonOnText, string buttonOffText, string labelText = null, bool showLabel = true, bool invertButtons = false)
	{
	}
}
