namespace FuryStudios.FurySDK
{
	public interface ILocalisationService
	{
		Language DefaultLanguage { get; }

		bool IsLanguageSupported(Language language);

		string Translate(TextID text);

		string Translate(TextID text, Language language);
	}
}
