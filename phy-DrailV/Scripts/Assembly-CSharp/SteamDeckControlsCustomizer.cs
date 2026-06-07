using DV.Platform.Steam;
using IniParser.Model;

public class SteamDeckControlsCustomizer : APreferencesCustomizer
{
	public override void Customize(PreferencesPersistence persistence, IniData data, PreferencesExclusivity currentExclusivity)
	{
		if (currentExclusivity == PreferencesExclusivity.NonVR && DVSteamworks.IsSteamDeck)
		{
			Set(persistence, data, Preferences.InvertPageFlipping, "True", PreferencesExclusivity.NonVR);
			Set(persistence, data, Preferences.RunToggle, "True", PreferencesExclusivity.NonVR);
			Set(persistence, data, Preferences.CrouchToggle, "True", PreferencesExclusivity.NonVR);
		}
	}
}
