using System.Globalization;

namespace NUnit.Framework.Internal
{
	public class CultureDetector
	{
		private CultureInfo currentCulture;

		private string reason = string.Empty;

		public string Reason => reason;

		public CultureDetector()
		{
			currentCulture = CultureInfo.CurrentCulture;
		}

		public CultureDetector(string culture)
		{
			currentCulture = new CultureInfo(culture);
		}

		public bool IsCultureSupported(string[] cultures)
		{
			foreach (string culture in cultures)
			{
				if (IsCultureSupported(culture))
				{
					return true;
				}
			}
			return false;
		}

		public bool IsCultureSupported(CultureAttribute cultureAttribute)
		{
			string include = cultureAttribute.Include;
			string exclude = cultureAttribute.Exclude;
			if (include != null && !IsCultureSupported(include))
			{
				reason = $"Only supported under culture {include}";
				return false;
			}
			if (exclude != null && IsCultureSupported(exclude))
			{
				reason = $"Not supported under culture {exclude}";
				return false;
			}
			return true;
		}

		public bool IsCultureSupported(string culture)
		{
			culture = culture.Trim();
			if (culture.IndexOf(',') >= 0)
			{
				if (IsCultureSupported(culture.Split(new char[1] { ',' })))
				{
					return true;
				}
			}
			else if (currentCulture.Name == culture || currentCulture.TwoLetterISOLanguageName == culture)
			{
				return true;
			}
			reason = "Only supported under culture " + culture;
			return false;
		}
	}
}
