using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.World;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainSettings;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainScene.Scripts
{
	public class DisplayAirResistance : WaitForLoadBehaviour
	{
		public class AirResSetting
		{
			public EAirResistance AirResistance;

			public Texture2D Icon;

			public Color IconColor;
		}

		public UITexture Icon;

		public List<AirResSetting> Settings;

		public override void WakeUp()
		{
			Set(WorldController.TerrainSettings.AirResistance);
		}

		private void Set(EAirResistance airRes)
		{
			AirResSetting airResSetting = Settings.FirstOrDefault((AirResSetting s) => s.AirResistance == airRes);
			if (airResSetting != null)
			{
				Icon.mainTexture = airResSetting.Icon;
				Icon.color = airResSetting.IconColor;
			}
			else
			{
				base.gameObject.SetActive(false);
			}
		}

		public void OnTooltip(bool show)
		{
			if (show)
			{
				NimbatusToolTip.Show(LocalizationManager.GetTermTranslation("GalaxyMap/AirResistance") + ": " + WorldController.TerrainSettings.AirResistance.ToLocalizationString());
			}
			else
			{
				NimbatusToolTip.Show(null);
			}
		}
	}
}
