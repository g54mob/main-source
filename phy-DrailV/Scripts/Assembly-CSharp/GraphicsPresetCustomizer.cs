using System.Collections.Generic;
using System.Linq;
using DV.ThingTypes;
using DV.UI.Presets;
using DV.Utils;
using IniParser.Model;

public class GraphicsPresetCustomizer : APreferencesCustomizer
{
	public override void Customize(PreferencesPersistence persistence, IniData data, PreferencesExclusivity currentExclusivity)
	{
		List<SettingsPreset> source = GraphicsPresets.Get();
		if (currentExclusivity == PreferencesExclusivity.VR)
		{
			SettingsPreset settingsPreset = source.FirstOrDefault((SettingsPreset p) => p.Name == SingletonBehaviour<APlatformProvider>.Instance.RecommendedGraphicsPreset_VR);
			if (settingsPreset != null)
			{
				ApplyPreset(persistence, settingsPreset, data, currentExclusivity);
			}
		}
		else
		{
			SettingsPreset settingsPreset2 = source.FirstOrDefault((SettingsPreset p) => p.Name == SingletonBehaviour<APlatformProvider>.Instance.RecommendedGraphicsPreset_NonVR);
			if (settingsPreset2 != null)
			{
				ApplyPreset(persistence, settingsPreset2, data, currentExclusivity);
			}
		}
	}
}
