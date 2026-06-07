using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Campaign;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainResources;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.ShopLocation.Scripts
{
	public class RepairHull : BuyItemButton
	{
		private const ETerrainMaterial Resource = ETerrainMaterial.RareOre;

		private const int BasePrice = 50;

		public UILabel PriceLabel;

		private int _price;

		private bool _maxHealth;

		public void Start()
		{
			CalculatePrice();
			Init();
		}

		protected override bool CanBeBought()
		{
			_maxHealth = SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.CurrentHealth == SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.MaxHealth;
			if (SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.HasResources(ETerrainMaterial.RareOre, _price))
			{
				return !_maxHealth;
			}
			return false;
		}

		protected override void Buy()
		{
			SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.ChangeHealth(1);
			SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.UseResources(ETerrainMaterial.RareOre, _price);
			if (!RuntimeGlobals.GameModeSettings.InCampaignTutorial)
			{
				SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.Repairs++;
			}
			CalculatePrice();
		}

		private void CalculatePrice()
		{
			int maxRepairs = RuntimeGlobals.GameModeSettings.MaxRepairs;
			int num = Mathf.Clamp(SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.Repairs, 0, maxRepairs) * (100 / maxRepairs);
			_price = 50 + num;
			PriceLabel.text = _price.ToString();
		}

		public override void OnTooltip(bool show)
		{
			if (!show)
			{
				return;
			}
			if (!HasEnoughResources)
			{
				if (_maxHealth)
				{
					NimbatusToolTip.Show(LocalizationManager.GetTermTranslation("GalaxyMap/NimbatusMaxHull"));
				}
				else
				{
					NimbatusToolTip.Show(LocalizationManager.GetTermTranslation("GalaxyMap/NotEnoughResources"));
				}
			}
			else
			{
				NimbatusToolTip.Show(null);
			}
		}
	}
}
