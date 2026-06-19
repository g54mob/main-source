namespace ModIOBrowser
{
	public interface ITranslatable
	{
		string Identifier { get; }

		string TransformPath { get; }

		string GetReference();

		void SetTranslation(string s);

		void MarkAsUntranslated();
	}
}
