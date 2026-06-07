namespace play.screen
{
	public sealed class SettingsMenuPurpose_Title : SettingsMenuPurpose
	{
		public readonly Array availableLanguageCodes;

		public readonly bool allowPhoneTabletPlatformChange;

		public SettingsMenuPurpose_Title(Array availableLanguageCodes, bool allowPhoneTabletPlatformChange)
			: base(0)
		{
		}

		public override Array getParams()
		{
			return null;
		}

		public override string getTag()
		{
			return null;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override bool Equals(object other)
		{
			return false;
		}

		public override string toString()
		{
			return null;
		}
	}
}
