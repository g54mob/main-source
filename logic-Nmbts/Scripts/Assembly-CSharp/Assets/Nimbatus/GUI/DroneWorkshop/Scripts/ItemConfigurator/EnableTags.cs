using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Workshop;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator
{
	public class EnableTags : MonoBehaviour
	{
		public UITexture Icon;

		public Color SelectedColor;

		public Color NormalColor;

		public Color HoverColor;

		private bool _hover;

		public void OnClick()
		{
			SerializableMonobehaviour<UiPreferences, UiPreferencesData>.Instance.TagsEnabled = !SerializableMonobehaviour<UiPreferences, UiPreferencesData>.Instance.TagsEnabled;
		}

		public void Update()
		{
			if (SerializableMonobehaviour<UiPreferences, UiPreferencesData>.Instance.TagsEnabled)
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
			NimbatusToolTip.Show(LocalizationManager.GetTermTranslation("DroneWorkshop/ToggleTags"));
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
