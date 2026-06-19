public class CharacterUIElement : UIelement
{
	public bool isVanity;

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
		Manager.ui.AttemptToEquipItem(Manager.main.player.mouseInventoryHandler, 0, isVanity);
		base.OnLeftClicked(mod1, mod2);
	}
}
