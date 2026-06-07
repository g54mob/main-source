public class CoreFoundationLocaleQuery
{
	public static LocaleDatabase.LocaleId GetLocaleId(LocaleDatabase localeDatabase)
	{
		int localeCount = GetLocaleCount();
		for (int i = 0; i < localeCount; i++)
		{
			string locale = GetLocale(i);
			Locale locale2 = localeDatabase.MatchLocale(locale);
			if (locale2 != null)
			{
				return locale2.Id;
			}
		}
		return LocaleDatabase.LocaleId.en_US;
	}

	private static int GetLocaleCount()
	{
		return 1;
	}

	private static string GetLocale(int index)
	{
		return "en-US";
	}
}
