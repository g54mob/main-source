using UnityEngine.Localization;

public static class LocalizedStringExtensions
{
	public static LocalizedString Duplicate(this LocalizedString localized)
	{
		return new LocalizedString(localized.TableReference, localized.TableEntryReference);
	}

	public static LocalizedString Localized(this string key, LocTable table)
	{
		return LocalizationUtility.Find(table, key);
	}
}
