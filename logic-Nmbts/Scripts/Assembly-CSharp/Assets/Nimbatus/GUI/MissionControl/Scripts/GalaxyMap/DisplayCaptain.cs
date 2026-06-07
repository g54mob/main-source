using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionControl.Scripts.GalaxyMap
{
	public class DisplayCaptain : MonoBehaviour
	{
		public UITexture Icon;

		public Texture2D DefaultTexture;

		private DronePerk _activePerk;

		public void Start()
		{
			_activePerk = SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.ActivePerk;
			if (_activePerk != null)
			{
				Icon.mainTexture = _activePerk.Icon;
			}
			else
			{
				Icon.mainTexture = DefaultTexture;
			}
		}

		public void OnTooltip(bool show)
		{
			if (_activePerk != null)
			{
				string text = _activePerk.GetDetailedTooltip() + LabelHelper.NewLine;
				text = text + LabelHelper.White + LocalizationManager.GetTermTranslation("MainMenu/Difficulty") + " " + LabelHelper.Orange + RuntimeGlobals.GameModeSettings.Difficulty;
				if (SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.ActiveEffects != null && SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.ActiveEffects.Count > 0)
				{
					text = text + LabelHelper.NewLine + LabelHelper.NewLine + LabelHelper.Blue + LocalizationManager.GetTermTranslation("CampaignMode/ActivePerks");
					foreach (DroneEffect activeEffect in SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.ActiveEffects)
					{
						text = text + LabelHelper.NewLine + activeEffect.GetDescription();
					}
				}
				NimbatusToolTip.Show(text, show);
			}
			else
			{
				NimbatusToolTip.Show(RuntimeGlobals.GameModeSettings.GetSandboxDetails(), show);
			}
		}
	}
}
