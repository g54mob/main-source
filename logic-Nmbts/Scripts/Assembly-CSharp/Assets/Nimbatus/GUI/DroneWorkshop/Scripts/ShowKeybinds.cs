using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Workshop;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class ShowKeybinds : MonoBehaviour
	{
		public TweenPosition Tween;

		public UITexture Icon;

		public Color SelectedColor;

		public Color NormalColor;

		public Color HoverColor;

		private bool _hover;

		public void Start()
		{
			Tween.Play(SerializableMonobehaviour<UiPreferences, UiPreferencesData>.Instance.ShowKeyBindings);
		}

		public void OnClick()
		{
			SerializableMonobehaviour<UiPreferences, UiPreferencesData>.Instance.ShowKeyBindings = !SerializableMonobehaviour<UiPreferences, UiPreferencesData>.Instance.ShowKeyBindings;
			Tween.Play(SerializableMonobehaviour<UiPreferences, UiPreferencesData>.Instance.ShowKeyBindings);
		}

		public void Update()
		{
			if (SerializableMonobehaviour<UiPreferences, UiPreferencesData>.Instance.ShowKeyBindings)
			{
				Icon.color = SelectedColor;
			}
			else
			{
				Icon.color = (_hover ? HoverColor : NormalColor);
			}
		}

		public void OnTooltip(bool show)
		{
			NimbatusToolTip.Show(LocalizationManager.GetTermTranslation("DroneWorkshop/ToggleHotkeys"));
			if (!show)
			{
				NimbatusToolTip.Show(null);
			}
		}

		protected virtual void OnHover(bool isOver)
		{
			_hover = isOver;
		}
	}
}
