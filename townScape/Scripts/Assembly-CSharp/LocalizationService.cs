using FuryStudios.FurySDK;

public sealed class LocalizationService : ILocalisationService
{
	public Language DefaultLanguage { get; }

	public bool IsLanguageSupported(Language language)
	{
		return false;
	}

	public string Translate(TextID text)
	{
		return null;
	}

	public string Translate(TextID text, Language language)
	{
		return null;
	}
}
