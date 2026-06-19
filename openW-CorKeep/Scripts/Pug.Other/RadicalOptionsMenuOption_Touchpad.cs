public class RadicalOptionsMenuOption_Touchpad : RadicalOptionsMenuOption_TextToggle
{
	public override bool IsOn
	{
		get
		{
			return Manager.prefs.AllowTouchpad;
		}
		protected set
		{
			Manager.input.SetTouchpadMapsEnabled(value);
			Manager.prefs.AllowTouchpad = value;
		}
	}
}
