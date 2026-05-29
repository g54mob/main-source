using System;
using CTS.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization;
using UnityEngine.UI;

namespace CTS
{
	public class UIThemeButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private Image _iconImage;

		[SerializeField]
		private Sprite _lockedSprite;

		[SerializeField]
		private Image _iconLock;

		[SerializeField]
		private ToolTipsShower _toolTipsShower;

		private Toggle _toggleButton;

		public BarStyleParameters ThemeButton { get; private set; }

		public bool IsLocked { get; private set; }

		public static event Action<BarStyleParameters> OnThemeChanged;

		public static event Action<BarStyleParameters> OnThemeEnterOver;

		public static event Action OnThemeExitOver;

		private void Awake()
		{
			_toggleButton = GetComponent<Toggle>();
			_toggleButton.onValueChanged.AddListener(OnToggleValueChanged);
		}

		private void OnDestroy()
		{
		}

		public void Init(BarStyleParameters theme, ToggleGroup toggleGroup, LocalizedString title, LocalizedString description)
		{
			ThemeButton = theme;
			_toggleButton.group = toggleGroup;
			if (!title.IsEmpty && !description.IsEmpty)
			{
				_toolTipsShower.SetTootipsInfo(title, description);
				_toolTipsShower.enabled = theme.IsLocked;
			}
			else
			{
				_toolTipsShower.enabled = false;
			}
			SetLockState(theme.IsLocked);
		}

		public void EnableTheme()
		{
			_toggleButton.isOn = true;
		}

		public void SetLockState(bool locked)
		{
			IsLocked = locked;
			_toolTipsShower.enabled = locked;
			_iconImage.sprite = (IsLocked ? _lockedSprite : ThemeButton.Icon);
			_iconLock.enabled = locked;
			_toggleButton.interactable = !IsLocked;
		}

		private void OnToggleValueChanged(bool value)
		{
			if (value)
			{
				UIThemeButton.OnThemeChanged?.Invoke(ThemeButton);
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			UIThemeButton.OnThemeEnterOver?.Invoke(ThemeButton);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			UIThemeButton.OnThemeExitOver?.Invoke();
		}
	}
}
