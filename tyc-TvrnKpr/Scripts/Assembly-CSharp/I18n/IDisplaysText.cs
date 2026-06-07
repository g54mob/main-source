using Gh.Tk;

namespace I18n
{
	public interface IDisplaysText
	{
		void DisplayText(string keyString, string gender = null);

		string GetCurrentTextKeyString();

		FontData GetFontData();
	}
}
