using UnityEngine.Localization;

public class DemoLockedFeaturePopup : StringPopup
{
	public string PopupID;

	public DemoPopupContent PopupContent;

	public LocalizedString TitleString;

	public LocalizedString MessageString;

	public LocalizedString WishlistButtonString;

	public LocalizedString RejectButtonString;

	public LocalizedString ThanksTitleString;

	public LocalizedString ThanksMessageString;

	public LocalizedString SeeSocialsButtonString;

	public LocalizedString ReturnButtonString;

	private bool _wishlisted;

	public string WishlistPlayerActionID;

	public string SocialsPlayerActionID;

	public override string ID => null;

	protected override void Show()
	{
	}

	public void OnClickOutgoingButton()
	{
	}
}
