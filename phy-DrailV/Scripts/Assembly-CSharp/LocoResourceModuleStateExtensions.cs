using DV.Localization;

public static class LocoResourceModuleStateExtensions
{
	private static readonly string[] _localizationKeys = new string[3] { "pit/state_ready", "pit/state_unplugged", "pit/state_misaligned" };

	public static string GetLocalizedString(this LocoResourceModuleState state)
	{
		return LocalizationAPI.L(_localizationKeys[(int)state]);
	}
}
