using Sirenix.Utilities;

namespace Kitchen
{
	public struct Pref
	{
		public string Namespace;

		public string Name;

		public static Pref OverallVolume = new Pref("OverallVolume");

		public static Pref MusicVolume = new Pref("MusicVolume");

		public static Pref EffectVolume = new Pref("EffectVolume");

		public static Pref VSyncCount = new Pref("VSyncCount");

		public static Pref LiveSplitEnabled = new Pref("LiveSplitEnabled");

		public static Pref ScreenResolution = new Pref("ScreenResolution");

		public static Pref MaxFPS = new Pref("MaxFPS");

		public static Pref Quality = new Pref("Quality");

		public static Pref AccessibilityEnableNightFade = new Pref("AccessibilityEnableNightFade");

		public static Pref AccessibilityColourBlindMode = new Pref("ColourBlindMode");

		public static Pref AccessibilityWeatherVisible = new Pref("WeatherOffMode");

		public static Pref LettersSpawnInside = new Pref("LettersSpawnInside");

		public static Pref ProvideStartingEnvelopesAsParcels = new Pref("ProvideStartingEnvelopesAsParcels");

		public static Pref Localisation = new Pref("Localisation");

		public static Pref RequirePingForBlueprintInfo = new Pref("RequirePingForBlueprintInfo");

		public static Pref SeedsAffectEverything = new Pref("SeedsAffectEverything");

		public static Pref SkipNewRecipePopups = new Pref("SkipNewRecipePopups");

		public static Pref AlwaysShowRunTimer = new Pref("AlwaysShowRunTimer");

		public static Pref SpeedrunMode = new Pref("SpeedrunMode");

		public static Pref SwitchLegacyControls = new Pref("SwitchLegacyControls");

		public string StorageKey => (Namespace.IsNullOrWhitespace() ? "" : (Namespace + "/")) + Name;

		public static implicit operator string(Pref p)
		{
			return p.StorageKey;
		}

		public override string ToString()
		{
			return StorageKey;
		}

		private Pref(string p)
		{
			Name = p;
			Namespace = "";
		}

		public Pref(string ns, string key)
		{
			Name = key;
			Namespace = ns;
		}
	}
}
