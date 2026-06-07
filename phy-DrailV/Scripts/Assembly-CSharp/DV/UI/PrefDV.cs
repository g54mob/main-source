using System.Linq;

namespace DV.UI
{
	public class PrefDV<T> : PreferenceValues<T>
	{
		public PrefDV(string name, T defaultValue, T initialValue)
			: base(name, defaultValue, initialValue)
		{
		}

		public override void Apply()
		{
			Preferences p = PreferencesUtils.GetAllPreferences().First((Preferences preferences) => preferences.ToString() == name);
			T value = (T)latestValue;
			GamePreferences.Set(p, value);
			base.Apply();
		}
	}
}
