namespace Client
{
	public interface IThemeComponent
	{
		void InitializeTheme(IThemeDatabase themeDatabase);

		void ApplyTheme(ITheme theme);

		ThemeBlendingResult ApplyBlendedTheme(ITheme oldTheme, ITheme newTheme, float progress);

		void ReleaseTheme(IThemeDatabase themeDatabase);
	}
}
