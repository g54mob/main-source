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
	public class DisplayGravity : WaitForLoadBehaviour
	{
		public class GravitySetting
		{
			public EGravity Gravity;

			public Texture2D Icon;

			public Color IconColor;
		}

		public UITexture Icon;

		public List<GravitySetting> Settings;

		public override void WakeUp()
		{
			Set(WorldController.TerrainSettings.Gravity);
		}

		private void Set(EGravity gravity)
		{
			GravitySetting gravitySetting = Settings.FirstOrDefault((GravitySetting s) => s.Gravity == gravity);
			if (gravitySetting != null)
			{
				Icon.mainTexture = gravitySetting.Icon;
				Icon.color = gravitySetting.IconColor;
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
				NimbatusToolTip.Show(LocalizationManager.GetTermTranslation("GalaxyMap/Gravity") + ": " + WorldController.TerrainSettings.Gravity.ToLocalizationString());
			}
			else
			{
				NimbatusToolTip.Show(null);
			}
		}
	}
}
