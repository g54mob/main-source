namespace DV.UI.LocoHUD
{
	public class HUDCustomNameProvider : HUDElementNameProviderBase
	{
		public string customName;

		public override string GetName()
		{
			return customName;
		}
	}
}
