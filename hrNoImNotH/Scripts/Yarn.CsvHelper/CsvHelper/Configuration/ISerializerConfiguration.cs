namespace CsvHelper.Configuration
{
	public interface ISerializerConfiguration
	{
		string Delimiter { get; set; }

		char Quote { get; set; }

		char Escape { get; set; }

		TrimOptions TrimOptions { get; set; }

		bool SanitizeForInjection { get; set; }

		char[] InjectionCharacters { get; set; }

		char InjectionEscapeCharacter { get; set; }
	}
}
