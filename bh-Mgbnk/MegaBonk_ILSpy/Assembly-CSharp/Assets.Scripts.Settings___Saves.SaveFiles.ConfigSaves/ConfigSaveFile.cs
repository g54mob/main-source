using System;
using System.Collections.Generic;
using Assets.Scripts._Data.Hats;
using Assets.Scripts.Saves___Serialization.SaveFiles.Configs;
using Assets.Scripts.Saves___Serialization.SaveFiles.Configs.ConfigSettingsTypes;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSettingsTypes;
using Cpp2ILInjected;

namespace Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;

[Serializable]
public class ConfigSaveFile
{
	public int settingsVersion = 2;

	public bool hasSelectedLanguage;

	public CFGameSettings cfGameSettings;

	public CFVideoSettings cfVideoSettings;

	public CFAudioSettings cfAudioSettings;

	public CFControlSettings cfControlSettings;

	public CFVisualsSettings cfVisualsSettings;

	public CFOtherSettings cfOtherSettings;

	public ConfigSettingsExtra otherSettings;

	public Preferences preferences;

	public void Init()
	{
		preferences.Init();
	}

	public ConfigSaveFile()
	{
		CFGameSettings cFGameSettings = new CFGameSettings();
		cfGameSettings = cFGameSettings;
		CFVideoSettings cFVideoSettings = new CFVideoSettings();
		cfVideoSettings = cFVideoSettings;
		cfAudioSettings = new CFAudioSettings
		{
			master_volume = 0.69f,
			music = 0.48f,
			game_sfx = 1f,
			ambience = 1f,
			ui = 1f,
			xp_and_gold = 1f
		};
		CFControlSettings cFControlSettings = new CFControlSettings();
		cfControlSettings = cFControlSettings;
		cfVisualsSettings = new CFVisualsSettings
		{
			damage_numbers = 1,
			damage_flash = 1,
			low_hp_effects = 1,
			particle_opacity = 1f,
			particle_auto_opacity = 1,
			xp_gold_hud = 1
		};
		CFOtherSettings cFOtherSettings = new CFOtherSettings();
		cfOtherSettings = cFOtherSettings;
		ConfigSettingsExtra configSettingsExtra = new ConfigSettingsExtra();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831725EE]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		configSettingsExtra.lastSteamLanguage = "en";
		otherSettings = configSettingsExtra;
		Preferences preferences = new Preferences();
		Dictionary<ECharacter, int> characterSkins = new Dictionary<ECharacter, int>();
		preferences.characterSkins = characterSkins;
		Dictionary<ECharacter, EHat> characterHats = new Dictionary<ECharacter, EHat>();
		preferences.characterHats = characterHats;
		this.preferences = preferences;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
	}
}
