using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainResources;

namespace Assets.Nimbatus.GUI.ShopLocation.Scripts
{
	public class SellOre : BuyItemButton
	{
		public int InputAmount;

		public ETerrainMaterial InputResource;

		public ETerrainMaterial OutputResource;

		public UILabel InputLabel;

		public UILabel OutputLabel;

		private int _startInputAmount;

		private int _outputAmount;

		public void Start()
		{
			_startInputAmount = InputAmount;
			AdjustInputAmount();
			Init();
		}

		private void AdjustInputAmount()
		{
			int num = (int)SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.GetAvailableResources(InputResource);
			if (num < _startInputAmount)
			{
				InputAmount = num;
			}
			InputLabel.text = InputAmount.ToString();
			_outputAmount = (int)SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.GetConversion(ETerrainMaterial.RareOre, ETerrainMaterial.CommonOre, InputAmount).Value;
			OutputLabel.text = _outputAmount.ToString();
		}

		protected override bool CanBeBought()
		{
			return SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.HasResources(InputResource, 1f);
		}

		protected override void Buy()
		{
			SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.UseResources(InputResource, InputAmount);
			SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.AddResources(OutputResource, _outputAmount);
			AdjustInputAmount();
		}
	}
}
