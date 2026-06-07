namespace DV.Customization
{
	public class PlayerHouseCustomization : StaticParentCustomization<PlayerHouseCustomization>
	{
		public const string KEY = ":player_house:";

		public override string GetIdentificationKey()
		{
			return ":player_house:";
		}

		private void OnEnable()
		{
			Enable();
		}

		private void OnDisable()
		{
			Disable();
		}
	}
}
