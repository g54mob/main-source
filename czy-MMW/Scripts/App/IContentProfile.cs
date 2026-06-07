public interface IContentProfile
{
	bool CanUseIncompleteLocales { get; }

	LocaleDatabase.LocaleId[] SupportedLocales { get; }

	bool AllowSaving { get; }
}
