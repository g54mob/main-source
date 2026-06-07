using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Receivables.ReceivableSettings
{
	public class OreReceivableSettings : BaseReceivableSettings
	{
		public ETerrainMaterial OreType;

		public override BaseReceivable CreateReceivable(int seed, int amount)
		{
			float num = amount;
			if (!RuntimeGlobals.GameModeSettings.InCampaignTutorial && OreType == ETerrainMaterial.CommonOre)
			{
				num *= (float)RuntimeGlobals.GameModeSettings.CommonOreRewardScale / 100f;
			}
			amount = Mathf.Clamp(Mathf.FloorToInt(num / 10f) * 10, 10, int.MaxValue);
			return new OreReceivable
			{
				Reward = OreType,
				Amount = amount
			};
		}
	}
}
