using System.Collections.Generic;
using Assets.Behaviour.Util;
using TMPro;
using UnityEngine;
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
		private Toggle _windowModeToggle;

		[SerializeField]
		private Slider _musicSlider;

		[SerializeField]
		private Slider _soundSlider;

		private List<OptionsResolution> _resolutions;

		private MainMenuUI _parent;

		private GameUI _ingameParent;

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
			_windowModeToggle.isOn = !Screen.fullScreen;
			_musicSlider.value = MusicManager.Volume;
			_soundSlider.value = UISounds.Volume;
		}

		public void ApplyAndClose()
		{
			OptionsResolution optionsResolution = _resolutions[_resolutionsDropdown.value];
			if (optionsResolution.Width > 0 && optionsResolution.Height > 0)
			{
				Screen.SetResolution(optionsResolution.Width, optionsResolution.Height, (!_windowModeToggle.isOn) ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed);
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
	}
}
