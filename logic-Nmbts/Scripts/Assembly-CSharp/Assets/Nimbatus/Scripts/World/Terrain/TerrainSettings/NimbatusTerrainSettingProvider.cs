using System;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Common.Helpers;

namespace Assets.Nimbatus.Scripts.World.Terrain.TerrainSettings
{
	[Serializable]
	public class NimbatusTerrainSettingProvider
	{
		public static int MinPlanetSize = 150;

		public static int MaxPlanetSize = 400;

		public List<EPlanetSize> PlanetSize;

		public List<EAirResistance> AirResistance;

		public List<EGravity> Gravity;

		public List<EFoliageDensity> FoliageDensity;

		public List<EResourceAmount> ResourceAmount;

		public NimbatusTerrainSetting GenerateSettings(Random randomGenerator, bool testflight = false)
		{
			return new NimbatusTerrainSetting
			{
				IsInitialized = true,
				Gravity = Gravity.RandomItem(randomGenerator),
				AirResistance = AirResistance.RandomItem(randomGenerator),
				PlanetSize = (testflight ? 400 : GetPlanetRadius(PlanetSize.RandomItem(randomGenerator), randomGenerator)),
				FoliageDensity = FoliageDensity.RandomItem(randomGenerator),
				ResourceAmount = GetResourceModificator(ResourceAmount.RandomItem(randomGenerator), randomGenerator),
				TerrainStrength = ETerrainHardness.Normal
			};
		}

		private float GetResourceModificator(EResourceAmount amount, Random rnd)
		{
			int num = 0;
			switch (amount)
			{
			case EResourceAmount.Low:
				num = rnd.Next(0, 10);
				break;
			case EResourceAmount.Medium:
				num = rnd.Next(40, 60);
				break;
			case EResourceAmount.High:
				num = rnd.Next(75, 100);
				break;
			case EResourceAmount.None:
				num = 0;
				break;
			}
			return (float)num * 0.01f;
		}

		private int GetPlanetRadius(EPlanetSize size, Random rnd)
		{
			switch (size)
			{
			case EPlanetSize.XS:
				return rnd.Next(150, 190);
			case EPlanetSize.S:
				return rnd.Next(190, 230);
			case EPlanetSize.M:
				return rnd.Next(230, 270);
			case EPlanetSize.L:
				return rnd.Next(270, 300);
			case EPlanetSize.XL:
				return rnd.Next(300, 350);
			case EPlanetSize.XXL:
				return rnd.Next(350, 380);
			default:
				return 0;
			}
		}
	}
}
