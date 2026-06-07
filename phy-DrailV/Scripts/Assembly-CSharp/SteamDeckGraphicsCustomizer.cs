using DV.Platform.Steam;
using IniParser.Model;

public class SteamDeckGraphicsCustomizer : APreferencesCustomizer
{
	public override void Customize(PreferencesPersistence persistence, IniData data, PreferencesExclusivity currentExclusivity)
	{
		if (currentExclusivity == PreferencesExclusivity.NonVR && DVSteamworks.IsSteamDeck)
		{
			Set(persistence, data, Preferences.AntiAliasingDeferredLevelsIndex, "1", PreferencesExclusivity.NonVR);
		}
	}
}
