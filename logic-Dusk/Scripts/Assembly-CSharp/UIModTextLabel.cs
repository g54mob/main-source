public class UIModTextLabel : UITextLabel
{
	protected override void Start()
	{
		if (ModificationUI.Instance != null)
		{
			activeTextColor = ModificationUI.Instance.activeTitleTextColor;
			inactiveTextColor = ModificationUI.Instance.inactiveTitleTextColor;
			activeBorderColor = ModificationUI.Instance.selectedBorderColor;
			inactiveBorderColor = ModificationUI.Instance.deSelectedBorderColor;
			errorTextColor = ModificationUI.Instance.errorTextColor;
			errorBorderColor = ModificationUI.Instance.errorBorderColor;
		}
		base.Start();
	}
}
