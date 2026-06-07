using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Workshop;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class ShowPartOverlap : MonoBehaviour
	{
		public UITexture Icon;

		public Color SelectedColor;

		public Color NormalColor;

		public Color DisabledColor;

		public Color HoverColor;

		private bool _hover;

		public void OnClick()
		{
			if (DronePartManager.Instance.ActiveNumberOfDroneParts <= 100 || SerializableMonobehaviour<UiPreferences, UiPreferencesData>.Instance.OverlapDetectionEnabled)
			{
				SerializableMonobehaviour<UiPreferences, UiPreferencesData>.Instance.OverlapDetectionEnabled = !SerializableMonobehaviour<UiPreferences, UiPreferencesData>.Instance.OverlapDetectionEnabled;
			}
		}

		public void Update()
		{
			if (DronePartManager.Instance.ActiveNumberOfDroneParts > 100)
			{
				Icon.color = DisabledColor;
			}
			else if (SerializableMonobehaviour<UiPreferences, UiPreferencesData>.Instance.OverlapDetectionEnabled)
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
			if (DronePartManager.Instance.ActiveNumberOfDroneParts <= 100)
			{
				NimbatusToolTip.Show(LocalizationManager.GetTermTranslation("DroneWorkshop/ToggleOverlap"));
			}
			else
			{
				NimbatusToolTip.Show(LocalizationManager.GetTermTranslation("DroneWorkshop/OverlapWarning"));
			}
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
