using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using I18n;
using TMPro;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class VideoSettingsPage3DUIView : SettingsPage3DUIView
	{
		private class ResolutionOption : TMP_Dropdown.OptionData
		{
			public Resolution resolution;

			public ResolutionOption(string text, Resolution resolution)
			{
			}
		}

		private TMP_DropdownI18n _resolutionDropdown;

		private List<ResolutionOption> _fullScreenResolutionOptions;

		private List<ResolutionOption> _windowResolutionOptions;

		private TMP_DropdownI18n _windowMode;

		private Tuple<FullScreenMode, string>[] _windowModes;

		private TMP_DropdownI18n _quality;

		private VideoCheckSetting3DUIView _videoCheck;

		private int _previousWindowModeOption;

		private int _previousResolutionOption;

		private static readonly Dictionary<string, float> _commonAspectRatios;

		private static readonly Dictionary<string, string> _unusualAspectRatios;

		private static int _smallestWidth;

		private static int _smallestHeight;

		private static readonly string[] _shadowResolutions;

		private static readonly string[] _vSyncOptions;

		private bool IsFullscreenExclusiveSelected => false;

		private List<ResolutionOption> CurrentResolutionOptions => null;

		private Resolution SelectedResolution => default(Resolution);

		public static event EventHandler ResolutionSettingsChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public override void Init()
		{
		}

		private void InitResolutionSettings()
		{
		}

		private void ApplyResolutionSettings()
		{
		}

		private void OnResolutionSettingsConfirmed()
		{
		}

		private void RevertAppliedResolutionSettings()
		{
		}

		private void OnResolutionSettingsChanged()
		{
		}

		private void AddVideoCheckSetting()
		{
		}

		private void UpdateResolutionDropdown()
		{
		}

		public static string GetResolutionText(int width, int height, double? hz = null)
		{
			return null;
		}

		public static void UpdateShadowDistanceFromSettings()
		{
		}

		private static void UpdateShadowTextureFromSettings()
		{
		}

		private static void UpdateVSyncFromSettings()
		{
		}

		private static void UpdateTargetFrameRateFromSettings()
		{
		}

		public static void ActivateSettingsPage()
		{
		}
	}
}
