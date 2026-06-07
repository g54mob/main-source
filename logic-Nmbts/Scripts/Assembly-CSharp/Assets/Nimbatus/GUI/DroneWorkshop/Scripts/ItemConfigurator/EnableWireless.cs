using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Workshop;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator
{
	public class EnableWireless : MonoBehaviour
	{
		public UITexture Icon;

		public Color SelectedColor;

		public Color NormalColor;

		public Color HoverColor;

		private bool _hover;

		public void Start()
		{
			if (RuntimeGlobals.GameMode != EGameMode.Demo)
			{
				base.gameObject.SetActive(false);
			}
		}

		public void OnClick()
		{
			SerializableMonobehaviour<UiPreferences, UiPreferencesData>.Instance.EnableWireless = !SerializableMonobehaviour<UiPreferences, UiPreferencesData>.Instance.EnableWireless;
			if (RuntimeGlobals.GameMode != EGameMode.Demo)
			{
				return;
			}
			RuntimeGlobals.HasWirelessResourceTransfer = SerializableMonobehaviour<UiPreferences, UiPreferencesData>.Instance.EnableWireless;
			if (RuntimeGlobals.HasWirelessResourceTransfer)
			{
				if (!SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.HasEffect(EEffectType.WirelessResourceTransfer))
				{
					SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.AddEffect(EEffectType.WirelessResourceTransfer);
				}
			}
			else if (SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.HasEffect(EEffectType.WirelessResourceTransfer))
			{
				SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.RemoveEffectOfType(EEffectType.WirelessResourceTransfer);
			}
		}

		public void Update()
		{
			if (SerializableMonobehaviour<UiPreferences, UiPreferencesData>.Instance.EnableWireless)
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
			NimbatusToolTip.Show(LocalizationManager.GetTermTranslation("CreativeMode/Wireless"));
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
