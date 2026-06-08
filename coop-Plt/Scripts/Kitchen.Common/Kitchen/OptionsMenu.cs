using System;
using System.Collections.Generic;
using System.Linq;
using Kitchen.Components;
using Kitchen.Modules;
using KitchenData;
using Platforms;
using UnityEngine;

namespace Kitchen
{
	public class OptionsMenu<T> : Menu<T>
	{
		private Option<float> Volume;

		private Option<float> MusicVolume;

		private Option<Locale> LocalisationOption;

		private IModule LocalisationModule;

		private Option<bool> LiveSplitSetting;

		private bool ShowCredits;

		private bool ShowLanguage;

		public OptionsMenu(Transform container, ModuleList module_list, bool show_credits = false, bool show_language = false)
			: base(container, module_list)
		{
			ShowCredits = show_credits;
			ShowLanguage = show_language;
		}

		public override void CreateSubmenus(ref Dictionary<Type, Menu<T>> menus)
		{
			menus.Add(typeof(AccessibilityMenu<T>), new AccessibilityMenu<T>(Container, ModuleList));
			if (PlatformSettings.SupportsGraphicsMenu)
			{
				menus.Add(typeof(GraphicsMenu<T>), new GraphicsMenu<T>(Container, ModuleList));
			}
			menus.Add(typeof(AdvancedMenu<T>), new AdvancedMenu<T>(Container, ModuleList));
			menus.Add(typeof(GameOptionsMenu<T>), new GameOptionsMenu<T>(Container, ModuleList));
		}

		public override void Setup(int player_id)
		{
			Volume = new Option<float>(VolumeManagement.VolumeValues, VolumeManagement.GetVolume(SoundCategory.Effects), VolumeManagement.VolumeLevels, (float a, float b) => Math.Abs(a - b));
			Volume.OnChanged += delegate(object _, float f)
			{
				VolumeManagement.SetVolume(SoundCategory.Effects, f);
			};
			MusicVolume = new Option<float>(VolumeManagement.MusicVolumeValues, VolumeManagement.GetVolume(SoundCategory.Music), VolumeManagement.VolumeLevels, (float a, float b) => Math.Abs(a - b));
			MusicVolume.OnChanged += delegate(object _, float f)
			{
				VolumeManagement.SetVolume(SoundCategory.Music, f);
			};
			List<Locale> list = (from Locale l in Enum.GetValues(typeof(Locale))
				where l != Locale.BlankText && l != Locale.Default
				select l).ToList();
			List<string> names = list.Select((Locale l) => base.Localisation[l.NameKey()]).ToList();
			LocalisationOption = new Option<Locale>(list, KitchenData.Localisation.CurrentLocale, names);
			LocalisationOption.OnChanged += delegate(object _, Locale f)
			{
				Preferences.Set(Pref.Localisation, f);
				ModuleList.Clear();
				Setup(player_id);
				SelectLocalisationBox();
			};
			AddButton(base.Localisation["MENU_GAME_SETTINGS"], delegate
			{
				RequestSubMenu(typeof(GameOptionsMenu<T>));
			});
			if (PlatformSettings.SupportsGraphicsMenu)
			{
				AddButton(base.Localisation["MENU_GRAPHICS_SETTINGS"], delegate
				{
					RequestSubMenu(typeof(GraphicsMenu<T>));
				});
			}
			AddButton(base.Localisation["MENU_ACCESSIBILITY_SETTINGS"], delegate
			{
				RequestSubMenu(typeof(AccessibilityMenu<T>));
			});
			if (PlatformSettings.SupportsExternalTools)
			{
				AddButton(base.Localisation["MENU_ADVANCED_SETTINGS"], delegate
				{
					RequestSubMenu(typeof(AdvancedMenu<T>));
				});
			}
			New<SpacerElement>();
			if (PlatformSettings.SupportsLanguageSelection && ShowLanguage)
			{
				AddLabel(base.Localisation["SETTINGS_LANGUAGE"]);
				LocalisationModule = AddSelect(LocalisationOption);
				New<SpacerElement>();
			}
			AddLabel(base.Localisation["SETTING_VOLUME"]);
			AddSelect(Volume);
			AddLabel(base.Localisation["SETTING_VOLUME_MUSIC"]);
			AddSelect(MusicVolume);
			if (ShowCredits)
			{
				AddSubmenuButton(base.Localisation["MAIN_MENU_CREDITS"], typeof(CreditsMainMenu));
			}
			New<SpacerElement>();
			New<SpacerElement>();
			AddButton(base.Localisation["MENU_BACK_SETTINGS"], delegate
			{
				RequestPreviousMenu();
			});
		}

		public void SelectLocalisationBox()
		{
			ModuleList.Select(LocalisationModule);
		}
	}
}
