using System.Globalization;

namespace Gh.Tk
{
	internal class LanguageInfo
	{
		private string _currentUiLanguage;

		private CultureInfo _cultureInfo;

		public string LanguageCode { get; private set; }

		public CultureInfo CultureInfo => null;

		public LanguageInfo(string languageCode)
		{
		}

		public string GetLabel()
		{
			return null;
		}
	}
}
