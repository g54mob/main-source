using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Campaign;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainResources;
using I2.Loc;

namespace Assets.Nimbatus.GUI.ShopLocation.Scripts
{
	public class ScrapHull : BuyItemButton
	{
		public int Reward;

		public ETerrainMaterial Resource;

		public void Start()
		{
			Init();
		}

		protected override bool CanBeBought()
		{
			if (!RuntimeGlobals.GameModeSettings.InCampaignTutorial)
			{
				return SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.CurrentHealth > 1;
			}
			return false;
		}

		protected override void Buy()
		{
			SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.ChangeHealth(-1);
			SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.AddResources(Resource, Reward);
		}

		public override void OnTooltip(bool show)
		{
			if (show)
			{
				if (RuntimeGlobals.GameModeSettings.InCampaignTutorial)
				{
					NimbatusToolTip.Show(null);
				}
				else if (!HasEnoughResources)
				{
					NimbatusToolTip.Show(LocalizationManager.GetTermTranslation("GalaxyMap/NimbatusMinHull"));
				}
				else
				{
					NimbatusToolTip.Show(null);
				}
			}
		}
	}
}
