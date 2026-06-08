using System.Collections.Generic;
using System.Linq;
using Kitchen.Modules;
using UnityEngine;

namespace Kitchen
{
	public class GraphicsMenu<T> : Menu<T>
	{
		private Option<(int, int)> Resolutions;

		private Option<FullScreenMode> FullScreenModes;

		private Option<int> VSyncCount;

		private Option<int> MaxFPSOptions;

		private Option<int> QualityOptions;

		public GraphicsMenu(Transform container, ModuleList module_list)
			: base(container, module_list)
		{
		}

		public override void Setup(int player_id)
		{
			List<(int, int)> list = Screen.resolutions.Select((Resolution s) => (width: s.width, height: s.height)).ToList();
			list.StripDuplicates();
			Resolution resolution = new Resolution
			{
				width = Screen.width,
				height = Screen.height,
				refreshRate = Screen.currentResolution.refreshRate
			};
			Resolutions = new Option<(int, int)>(list.ToList(), (resolution.width, resolution.height), list.Select<(int, int), string>(((int width, int height) r) => $"{r.width}x{r.height}").ToList(), ((int, int) a, (int, int) b) => Mathf.Abs(a.Item1 - b.Item1) + Mathf.Abs(a.Item2 - b.Item2));
			FullScreenModes = new Option<FullScreenMode>(Preferences.WindowModes, Screen.fullScreenMode, Preferences.WindowLabels.Select((string e) => base.Localisation[e]).ToList());
			VSyncCount = new Option<int>(new List<int> { 0, 1, 2 }, Preferences.Get<int>(Pref.VSyncCount), new List<string>
			{
				base.Localisation["SETTING_DISABLED"],
				"1",
				"2"
			});
			VSyncCount.OnChanged += delegate(object _, int f)
			{
				Preferences.Set(Pref.VSyncCount, f);
			};
			MaxFPSOptions = new Option<int>(new List<int> { 30, 60, 120, -1 }, Application.targetFrameRate, new List<string>
			{
				"30",
				"60",
				"120",
				base.Localisation["SETTING_FPS_UNCAPPED"]
			}, (int a, int b) => Mathf.Abs(a - b));
			MaxFPSOptions.OnChanged += delegate(object _, int f)
			{
				Preferences.Set(Pref.MaxFPS, f);
			};
			QualityOptions = new Option<int>(new List<int> { 0, 1, 2 }, QualitySettings.GetQualityLevel(), new List<string>
			{
				base.Localisation["SETTING_QUALITY_LOW"],
				base.Localisation["SETTING_QUALITY_MEDIUM"],
				base.Localisation["SETTING_QUALITY_HIGH"]
			}, (int a, int b) => Mathf.Abs(a - b));
			QualityOptions.OnChanged += delegate(object _, int f)
			{
				Preferences.Set(Pref.Quality, f);
			};
			AddLabel(base.Localisation["SETTING_RESOLUTION"]);
			AddSelect(Resolutions);
			AddLabel(base.Localisation["SETTING_FULLSCREEN_MODE"]);
			AddSelect(FullScreenModes);
			AddLabel(base.Localisation["SETTING_VSYNC"]);
			AddSelect(VSyncCount);
			AddLabel(base.Localisation["SETTING_FPS_CAP"]);
			AddSelect(MaxFPSOptions);
			AddLabel(base.Localisation["SETTING_QUALITY"]);
			AddSelect(QualityOptions);
			New<SpacerElement>();
			AddButton(base.Localisation["MENU_APPLY_SETTINGS"], delegate
			{
				ApplyResolutionSettings();
				RequestSubMenu(GetType(), skip_stack: true);
			});
			New<SpacerElement>();
			New<SpacerElement>();
			AddButton(base.Localisation["MENU_BACK_SETTINGS"], delegate
			{
				RequestPreviousMenu();
			});
		}

		public void ApplyResolutionSettings()
		{
			FullScreenMode orDefault = FullScreenModes.GetOrDefault(Screen.fullScreenMode);
			if (Resolutions.TryGetChosen(out var value))
			{
				Resolution resolution = new Resolution
				{
					width = value.Item1,
					height = value.Item2,
					refreshRate = 0
				};
				Preferences.Set(Pref.ScreenResolution, new ScreenPreference.ScreenData
				{
					Resolution = resolution,
					FullScreenMode = orDefault
				});
			}
		}
	}
}
