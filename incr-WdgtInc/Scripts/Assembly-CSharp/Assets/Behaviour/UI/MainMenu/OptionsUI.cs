using System;
using System.Collections.Generic;
using Assets.Behaviour.Util;
using Assets.Source.Util;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Behaviour.UI.MainMenu
{
	public class OptionsUI : MonoBehaviour
	{
		private struct OptionsResolution
		{
			public int Width;

			public int Height;

			public TMP_Dropdown.OptionData Option => new TMP_Dropdown.OptionData(Width + "x" + Height);

			public OptionsResolution(Resolution res)
			{
				Width = res.width;
				Height = res.height;
			}

			public OptionsResolution(int width, int height)
			{
				Width = width;
				Height = height;
			}

			public override bool Equals(object obj)
			{
				if (obj is OptionsResolution optionsResolution)
				{
					if (Width == optionsResolution.Width)
					{
						return Height == optionsResolution.Height;
					}
					return false;
				}
				return false;
			}

			public override int GetHashCode()
			{
				return Width.GetHashCode() | Height.GetHashCode();
			}

			public bool IsCurrentResolution()
			{
				if (Screen.width == Width)
				{
					return Screen.height == Height;
				}
				return false;
			}
		}

		[SerializeField]
		private TMP_Dropdown _resolutionsDropdown;

		[SerializeField]
		private TMP_Dropdown _languageDropdown;

		[SerializeField]
		private Toggle _windowModeToggle;

		[SerializeField]
		private Slider _musicSlider;

		[SerializeField]
		private Slider _soundSlider;

		[SerializeField]
		private Slider _fpsSlider;

		[SerializeField]
		private TMP_Text _fpsDisplay;

		private List<OptionsResolution> _resolutions;

		private List<Translation> _languages;

		private MainMenuUI _parent;

		private GameUI _ingameParent;

		public static int DefaultFramerate => (int)Math.Round(Screen.currentResolution.refreshRateRatio.value);

		public static int TargetFramerate => PlayerPrefs.GetInt("TargetFramerate", DefaultFramerate);

		private void Start()
		{
			_parent = GetComponentInParent<MainMenuUI>();
			_ingameParent = GetComponentInParent<GameUI>();
		}

		private void OnEnable()
		{
			_resolutions = new List<OptionsResolution>();
			Resolution[] resolutions = Screen.resolutions;
			for (int i = 0; i < resolutions.Length; i++)
			{
				Resolution res = resolutions[i];
				OptionsResolution item = new OptionsResolution(res);
				if (res.width >= 1280 && res.height >= 720 && !_resolutions.Contains(item))
				{
					_resolutions.Add(item);
				}
			}
			int num = -1;
			List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
			for (int j = 0; j < _resolutions.Count; j++)
			{
				list.Add(_resolutions[j].Option);
				if (_resolutions[j].IsCurrentResolution())
				{
					num = j;
				}
			}
			if (num == -1)
			{
				_resolutions.Insert(0, new OptionsResolution(0, 0));
				list.Insert(0, new TMP_Dropdown.OptionData("Custom"));
				num = 0;
			}
			_resolutionsDropdown.options = list;
			_resolutionsDropdown.value = num;
			_languages = new List<Translation>(Translation.All);
			_languages.Sort((Translation a, Translation b) => a.DisplayName.CompareTo(b.DisplayName));
			list = new List<TMP_Dropdown.OptionData>();
			foreach (Translation language in _languages)
			{
				list.Add(new TMP_Dropdown.OptionData(language.DisplayName));
			}
			_languageDropdown.options = list;
			_languageDropdown.value = _languages.IndexOf(Translation.Current);
			_windowModeToggle.isOn = !Screen.fullScreen;
			_fpsDisplay.text = TargetFramerate.ToString();
			_fpsSlider.value = TargetFramerate;
			_musicSlider.value = MusicManager.Volume;
			_soundSlider.value = UISounds.Volume;
		}

		public void ApplyAndClose()
		{
			OptionsResolution optionsResolution = _resolutions[_resolutionsDropdown.value];
			FullScreenMode fullScreenMode = ((!_windowModeToggle.isOn) ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed);
			if (optionsResolution.Width > 0 && optionsResolution.Height > 0)
			{
				Screen.SetResolution(optionsResolution.Width, optionsResolution.Height, fullScreenMode);
			}
			else if (fullScreenMode != Screen.fullScreenMode)
			{
				Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, fullScreenMode);
			}
			PlayerPrefs.SetInt("TargetFramerate", Mathf.RoundToInt(_fpsSlider.value));
			UpdateFramerate();
			Translation translation = _languages[_languageDropdown.value];
			if (translation != Translation.Current)
			{
				Translation.UpdateLocale(translation);
				UIAlertWindow.Show("@OptionsLanguageChanged", "@OptionsLanguageChangedDesc", delegate
				{
					SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				});
			}
			MusicManager.Volume = _musicSlider.value;
			UISounds.Volume = _soundSlider.value;
			if ((bool)_parent)
			{
				_parent.ShowMainMenu();
			}
			else
			{
				_ingameParent.ReturnToIngameMenu();
			}
		}

		public void CancelOptions()
		{
			if ((bool)_parent)
			{
				_parent.ShowMainMenu();
			}
			else
			{
				_ingameParent.ReturnToIngameMenu();
			}
			MusicManager.Volume = MusicManager.Volume;
			UISounds.Volume = UISounds.Volume;
		}

		public void PreviewMusicVolume()
		{
			MusicManager.PreviewVolume(_musicSlider.value);
		}

		public void UpdateFpsDisplay()
		{
			_fpsDisplay.text = Mathf.RoundToInt(_fpsSlider.value).ToString();
		}

		public static void UpdateFramerate()
		{
			Application.targetFrameRate = TargetFramerate;
			if (!PlayerPrefs.HasKey("TargetFramerate") || Math.Abs(DefaultFramerate - TargetFramerate) < 5)
			{
				QualitySettings.vSyncCount = 1;
			}
			else
			{
				QualitySettings.vSyncCount = 0;
			}
		}
	}
}
