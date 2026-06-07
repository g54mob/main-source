using System;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainResources;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Receivables
{
	[Serializable]
	public class OreReceivable : BaseReceivable
	{
		public ETerrainMaterial Reward;

		public int Amount;

		public override EReceivableType Type()
		{
			return EReceivableType.Ore;
		}

		public override T GetReward<T>()
		{
			return (T)(object)Reward;
		}

		public override Texture2D GetIcon()
		{
			return SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.GetResourceSetting(Reward).Icon;
		}

		public override string GetToolTip()
		{
			ResourceSetting resourceSetting = SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.GetResourceSetting(Reward);
			return LabelHelper.Orange + Amount + " " + LabelHelper.White + resourceSetting.Name.GetTranslation();
		}

		public override string GetTitle()
		{
			return SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.GetResourceSetting(Reward).Name.GetTranslation();
		}

		public override string GetAmount()
		{
			return Amount.ToString();
		}

		public override void HandleReward()
		{
			SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.AddResources(Reward, Amount);
		}

		public override bool IsPositive()
		{
			return Amount > 0;
		}
	}
}
