namespace Rewired.UI.ControlMapper.PugUI.Menu.Options
{
	public class RadicalOptionsMenuOption_ClearAdminBan : RadicalMenuOption
	{
		public override void OnActivated()
		{
			base.OnActivated();
			Manager.networking.EmptyAdminAndBan();
		}
	}
}
