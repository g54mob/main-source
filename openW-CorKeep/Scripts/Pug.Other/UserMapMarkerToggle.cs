public class UserMapMarkerToggle : ToggleUIElement
{
	public UserMapMarkerType userMapMarkerType;

	public MapUI mapUI;

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
		mapUI.SetUserMapMarkerToggle(this);
		base.OnLeftClicked(mod1, mod2);
	}
}
