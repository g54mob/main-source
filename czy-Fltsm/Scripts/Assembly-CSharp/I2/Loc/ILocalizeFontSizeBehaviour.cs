namespace I2.Loc
{
	internal interface ILocalizeFontSizeBehaviour
	{
		void ApplyOverride(LocalizeFontSize.Override fontSizeOverride);

		void Restore();
	}
}
