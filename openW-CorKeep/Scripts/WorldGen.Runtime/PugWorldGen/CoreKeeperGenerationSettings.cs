using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

namespace PugWorldGen
{
	[Serializable]
	[CreateAssetMenu(menuName = "Pug/World Gen/CoreKeeper/Generation Settings", fileName = "CoreKeeper Generation Settings", order = 3)]
	public class CoreKeeperGenerationSettings : ScriptableObject
	{
		[Serializable]
		public class GenerationSetting
		{
			public WorldGenerationSettingType type;

			public List<AffectedWorldParameter> affectedWorldParameters;
		}

		[ArrayElementTitle("type")]
		public List<GenerationSetting> settings;

		public static void ApplyToParameters(List<LevelWorldGenerationSetting> levelSettings, CoreKeeperWorldParameters worldParameters)
		{
			foreach (LevelWorldGenerationSetting levelSetting in levelSettings)
			{
				switch (levelSetting.type)
				{
				case WorldGenerationSettingType.Chaos:
					ApplyChaosSettings(levelSetting.level, worldParameters);
					break;
				case WorldGenerationSettingType.OreDensity:
					ApplyOreDensitySettings(levelSetting.level, worldParameters);
					break;
				case WorldGenerationSettingType.Tunnels:
					ApplyTunnelsSettings(levelSetting.level, worldParameters);
					break;
				case WorldGenerationSettingType.Chambers:
					ApplyChambersSettings(levelSetting.level, worldParameters);
					break;
				case WorldGenerationSettingType.Rivers:
					ApplyRiversSettings(levelSetting.level, worldParameters);
					break;
				case WorldGenerationSettingType.Lakes:
					ApplyLakesSettings(levelSetting.level, worldParameters);
					break;
				case WorldGenerationSettingType.Pits:
					ApplyPitsSettings(levelSetting.level, worldParameters);
					break;
				case WorldGenerationSettingType.CeilingHoles:
					ApplyCeilingHolesSettings(levelSetting.level, worldParameters);
					break;
				}
			}
		}

		private static void ApplyChaosSettings(WorldGenerationSettingLevel level, CoreKeeperWorldParameters worldParameters)
		{
			switch (level)
			{
			case WorldGenerationSettingLevel.Off:
				worldParameters.biomeChaos = 0f;
				worldParameters.ring1Chaos = 0f;
				worldParameters.ring2Chaos = 0f;
				break;
			case WorldGenerationSettingLevel.Low:
				worldParameters.biomeChaos = 250f;
				worldParameters.ring1Chaos = 50f;
				worldParameters.ring2Chaos = 25f;
				break;
			case WorldGenerationSettingLevel.High:
				worldParameters.biomeChaos = 1500f;
				worldParameters.ring1Chaos = 150f;
				worldParameters.ring2Chaos = 60f;
				break;
			case WorldGenerationSettingLevel.Extreme:
				worldParameters.biomeChaos = 4000f;
				worldParameters.ring1Chaos = 250f;
				worldParameters.ring2Chaos = 70f;
				break;
			case WorldGenerationSettingLevel.Normal:
				break;
			}
		}

		private static void ApplyOreDensitySettings(WorldGenerationSettingLevel level, CoreKeeperWorldParameters worldParameters)
		{
			switch (level)
			{
			case WorldGenerationSettingLevel.Off:
				worldParameters.dirt.resourceThreshold = 0f;
				worldParameters.clay.resourceThreshold = 0f;
				worldParameters.stone.resourceThreshold = 0f;
				worldParameters.forest.resourceThreshold = 0f;
				worldParameters.desert.resourceThreshold = 0f;
				worldParameters.sea.resourceThreshold = 0f;
				worldParameters.crystal.resourceThreshold = 0f;
				worldParameters.excavation.resourceThreshold = 0f;
				break;
			case WorldGenerationSettingLevel.Low:
				worldParameters.dirt.resourceThreshold = 0.3f;
				worldParameters.clay.resourceThreshold = 0.3f;
				worldParameters.stone.resourceThreshold = 0.3f;
				worldParameters.forest.resourceThreshold = 0.3f;
				worldParameters.desert.resourceThreshold = 0.3f;
				worldParameters.sea.resourceThreshold = 0.3f;
				worldParameters.crystal.resourceThreshold = 0.3f;
				worldParameters.excavation.resourceThreshold = 0.3f;
				break;
			case WorldGenerationSettingLevel.High:
				worldParameters.dirt.resourceThreshold = 0.7f;
				worldParameters.clay.resourceThreshold = 0.7f;
				worldParameters.stone.resourceThreshold = 0.7f;
				worldParameters.forest.resourceThreshold = 0.7f;
				worldParameters.desert.resourceThreshold = 0.7f;
				worldParameters.sea.resourceThreshold = 0.7f;
				worldParameters.crystal.resourceThreshold = 0.7f;
				worldParameters.excavation.resourceThreshold = 0.7f;
				break;
			case WorldGenerationSettingLevel.Extreme:
				worldParameters.dirt.resourceThreshold = 1f;
				worldParameters.clay.resourceThreshold = 1f;
				worldParameters.stone.resourceThreshold = 1f;
				worldParameters.forest.resourceThreshold = 1f;
				worldParameters.desert.resourceThreshold = 1f;
				worldParameters.sea.resourceThreshold = 1f;
				worldParameters.crystal.resourceThreshold = 1f;
				worldParameters.excavation.resourceThreshold = 1f;
				break;
			case WorldGenerationSettingLevel.Normal:
				break;
			}
		}

		private static void ApplyTunnelsSettings(WorldGenerationSettingLevel level, CoreKeeperWorldParameters worldParameters)
		{
			switch (level)
			{
			case WorldGenerationSettingLevel.Off:
				worldParameters.dirt.tunnelAmount = 0f;
				worldParameters.clay.tunnelAmount = 0f;
				worldParameters.stone.tunnelAmount = 0f;
				worldParameters.forest.tunnelAmount = 0f;
				worldParameters.desert.tunnelAmount = 0f;
				worldParameters.sea.tunnelAmount = 0f;
				worldParameters.crystal.tunnelAmount = 0f;
				worldParameters.passage.tunnelAmount = 0f;
				worldParameters.excavation.tunnelAmount = 0f;
				break;
			case WorldGenerationSettingLevel.Low:
				worldParameters.dirt.tunnelAmount = 0.3f;
				worldParameters.clay.tunnelAmount = 0.3f;
				worldParameters.stone.tunnelAmount = 0.3f;
				worldParameters.forest.tunnelAmount = 0.25f;
				worldParameters.desert.tunnelAmount = 0.25f;
				worldParameters.sea.tunnelAmount = 0.25f;
				worldParameters.crystal.tunnelAmount = 0.25f;
				worldParameters.passage.tunnelAmount = 0.2f;
				worldParameters.excavation.tunnelAmount = 0.6f;
				break;
			case WorldGenerationSettingLevel.High:
				worldParameters.dirt.tunnelAmount = 0.55f;
				worldParameters.clay.tunnelAmount = 0.7f;
				worldParameters.stone.tunnelAmount = 0.6f;
				worldParameters.forest.tunnelAmount = 0.75f;
				worldParameters.desert.tunnelAmount = 0.75f;
				worldParameters.sea.tunnelAmount = 0.75f;
				worldParameters.crystal.tunnelAmount = 0.75f;
				worldParameters.passage.tunnelAmount = 0.6f;
				worldParameters.excavation.tunnelAmount = 0.138f;
				break;
			case WorldGenerationSettingLevel.Extreme:
				worldParameters.dirt.tunnelAmount = 1f;
				worldParameters.clay.tunnelAmount = 1f;
				worldParameters.stone.tunnelAmount = 1f;
				worldParameters.forest.tunnelAmount = 1f;
				worldParameters.desert.tunnelAmount = 1f;
				worldParameters.sea.tunnelAmount = 1f;
				worldParameters.crystal.tunnelAmount = 1f;
				worldParameters.passage.tunnelAmount = 1f;
				worldParameters.excavation.tunnelAmount = 0.093f;
				break;
			case WorldGenerationSettingLevel.Normal:
				break;
			}
		}

		private static void ApplyChambersSettings(WorldGenerationSettingLevel level, CoreKeeperWorldParameters worldParameters)
		{
			switch (level)
			{
			case WorldGenerationSettingLevel.Off:
				worldParameters.dirt.chamberThreshold = 0f;
				worldParameters.clay.chamberThreshold = 0f;
				worldParameters.stone.chamberThreshold = 0f;
				worldParameters.forest.chamberThreshold = 0f;
				worldParameters.desert.chamberThreshold = 0f;
				worldParameters.sea.chamberThreshold = 0f;
				worldParameters.crystal.chamberThreshold = 0f;
				worldParameters.passage.chamberThreshold = 0f;
				break;
			case WorldGenerationSettingLevel.Low:
				worldParameters.dirt.chamberThreshold = 0.1405f;
				worldParameters.clay.chamberThreshold = 0.125f;
				worldParameters.stone.chamberThreshold = 0.109f;
				worldParameters.forest.chamberThreshold = 0.175f;
				worldParameters.desert.chamberThreshold = 0.25f;
				worldParameters.sea.chamberThreshold = 0.1545f;
				worldParameters.crystal.chamberThreshold = 0.125f;
				worldParameters.passage.chamberThreshold = 0.0635f;
				break;
			case WorldGenerationSettingLevel.High:
				worldParameters.dirt.chamberThreshold = 0.4215f;
				worldParameters.clay.chamberThreshold = 0.375f;
				worldParameters.stone.chamberThreshold = 0.327f;
				worldParameters.forest.chamberThreshold = 0.525f;
				worldParameters.desert.chamberThreshold = 0.75f;
				worldParameters.sea.chamberThreshold = 0.4635f;
				worldParameters.crystal.chamberThreshold = 0.375f;
				worldParameters.passage.chamberThreshold = 0.1905f;
				break;
			case WorldGenerationSettingLevel.Extreme:
				worldParameters.dirt.chamberThreshold = 0.75f;
				worldParameters.clay.chamberThreshold = 0.75f;
				worldParameters.stone.chamberThreshold = 0.75f;
				worldParameters.forest.chamberThreshold = 0.75f;
				worldParameters.desert.chamberThreshold = 0.9f;
				worldParameters.sea.chamberThreshold = 0.75f;
				worldParameters.crystal.chamberThreshold = 0.75f;
				worldParameters.passage.chamberThreshold = 0.5f;
				break;
			case WorldGenerationSettingLevel.Normal:
				break;
			}
		}

		private static void ApplyRiversSettings(WorldGenerationSettingLevel level, CoreKeeperWorldParameters worldParameters)
		{
			switch (level)
			{
			case WorldGenerationSettingLevel.Off:
				worldParameters.dirt.riverAmount = 0f;
				worldParameters.clay.riverAmount = 0f;
				worldParameters.stone.riverAmount = 0f;
				worldParameters.forest.riverAmount = 0f;
				worldParameters.desert.riverAmount = 0f;
				worldParameters.sea.riverAmount = 0f;
				worldParameters.crystal.riverAmount = 0f;
				worldParameters.passage.riverAmount = 0f;
				worldParameters.excavation.riverAmount = 0f;
				break;
			case WorldGenerationSettingLevel.Low:
				worldParameters.dirt.riverAmount = 0.178f;
				worldParameters.clay.riverAmount = 0.3f;
				worldParameters.stone.riverAmount = 0.2f;
				worldParameters.forest.riverAmount = 0.3f;
				worldParameters.desert.riverAmount = 0.083f;
				worldParameters.sea.riverAmount = 0.5f;
				worldParameters.crystal.riverAmount = 0.25f;
				worldParameters.passage.riverAmount = 0.16f;
				worldParameters.excavation.riverAmount = 0.16f;
				break;
			case WorldGenerationSettingLevel.High:
				worldParameters.dirt.riverAmount = 0.534f;
				worldParameters.clay.riverAmount = 0.9f;
				worldParameters.stone.riverAmount = 0.6f;
				worldParameters.forest.riverAmount = 0.9f;
				worldParameters.desert.riverAmount = 0.249f;
				worldParameters.sea.riverAmount = 1f;
				worldParameters.crystal.riverAmount = 0.75f;
				worldParameters.passage.riverAmount = 0.48f;
				worldParameters.excavation.riverAmount = 0.8f;
				break;
			case WorldGenerationSettingLevel.Extreme:
				worldParameters.dirt.riverAmount = 1f;
				worldParameters.clay.riverAmount = 1f;
				worldParameters.stone.riverAmount = 1f;
				worldParameters.forest.riverAmount = 1f;
				worldParameters.desert.riverAmount = 0.5f;
				worldParameters.sea.riverAmount = 1f;
				worldParameters.crystal.riverAmount = 1f;
				worldParameters.passage.riverAmount = 1f;
				worldParameters.excavation.riverAmount = 1f;
				break;
			case WorldGenerationSettingLevel.Normal:
				break;
			}
		}

		private static void ApplyLakesSettings(WorldGenerationSettingLevel level, CoreKeeperWorldParameters worldParameters)
		{
			switch (level)
			{
			case WorldGenerationSettingLevel.Off:
				worldParameters.dirt.lakeThreshold = 0f;
				worldParameters.clay.lakeThreshold = 0f;
				worldParameters.stone.lakeThreshold = 0f;
				worldParameters.forest.lakeThreshold = 0f;
				worldParameters.desert.lakeThreshold = 0f;
				worldParameters.sea.lakeThreshold = 0f;
				worldParameters.crystal.lakeThreshold = 0f;
				worldParameters.passage.lakeThreshold = 0f;
				worldParameters.excavation.lakeThreshold = 0f;
				break;
			case WorldGenerationSettingLevel.Low:
				worldParameters.dirt.lakeThreshold = 0.111f;
				worldParameters.clay.lakeThreshold = 0.1f;
				worldParameters.stone.lakeThreshold = 0.1f;
				worldParameters.forest.lakeThreshold = 0.1f;
				worldParameters.desert.lakeThreshold = 0.065f;
				worldParameters.sea.lakeThreshold = 0.2f;
				worldParameters.crystal.lakeThreshold = 0.1f;
				worldParameters.passage.lakeThreshold = 0.0915f;
				worldParameters.excavation.lakeThreshold = 0.1f;
				break;
			case WorldGenerationSettingLevel.High:
				worldParameters.dirt.lakeThreshold = 0.333f;
				worldParameters.clay.lakeThreshold = 0.3f;
				worldParameters.stone.lakeThreshold = 0.3f;
				worldParameters.forest.lakeThreshold = 0.3f;
				worldParameters.desert.lakeThreshold = 0.195f;
				worldParameters.sea.lakeThreshold = 0.6f;
				worldParameters.crystal.lakeThreshold = 0.3f;
				worldParameters.passage.lakeThreshold = 0.2745f;
				worldParameters.excavation.lakeThreshold = 0.8f;
				break;
			case WorldGenerationSettingLevel.Extreme:
				worldParameters.dirt.lakeThreshold = 0.75f;
				worldParameters.clay.lakeThreshold = 0.75f;
				worldParameters.stone.lakeThreshold = 0.75f;
				worldParameters.forest.lakeThreshold = 0.75f;
				worldParameters.desert.lakeThreshold = 0.5f;
				worldParameters.sea.lakeThreshold = 0.75f;
				worldParameters.crystal.lakeThreshold = 0.75f;
				worldParameters.passage.lakeThreshold = 0.75f;
				worldParameters.excavation.lakeThreshold = 1f;
				break;
			case WorldGenerationSettingLevel.Normal:
				break;
			}
		}

		private static void ApplyPitsSettings(WorldGenerationSettingLevel level, CoreKeeperWorldParameters worldParameters)
		{
			switch (level)
			{
			case WorldGenerationSettingLevel.Off:
				worldParameters.dirt.pitThreshold.y = 0f;
				worldParameters.clay.pitThreshold.y = 0f;
				worldParameters.stone.pitThreshold.y = 0f;
				worldParameters.forest.pitThreshold.y = 0f;
				worldParameters.desert.pitThreshold.y = 0f;
				worldParameters.sea.pitThreshold.y = 0f;
				worldParameters.crystal.pitThreshold.y = 0f;
				worldParameters.passage.pitThreshold.y = 0f;
				worldParameters.excavation.pitThreshold.y = 0f;
				break;
			case WorldGenerationSettingLevel.Low:
				worldParameters.dirt.pitThreshold.y = 0f;
				worldParameters.clay.pitThreshold.y = 0.06f;
				worldParameters.stone.pitThreshold.y = 0.06f;
				worldParameters.forest.pitThreshold.y = 0.06f;
				worldParameters.desert.pitThreshold.y = 0.06f;
				worldParameters.sea.pitThreshold.y = 0f;
				worldParameters.crystal.pitThreshold.y = 0.06f;
				worldParameters.passage.pitThreshold.y = 0.04318748f;
				worldParameters.excavation.pitThreshold.y = 0.051f;
				break;
			case WorldGenerationSettingLevel.High:
				worldParameters.dirt.pitThreshold.y = 0.12f;
				worldParameters.clay.pitThreshold.y = 0.36f;
				worldParameters.stone.pitThreshold.y = 0.36f;
				worldParameters.forest.pitThreshold.y = 0.36f;
				worldParameters.desert.pitThreshold.y = 0.36f;
				worldParameters.sea.pitThreshold.y = 0.12f;
				worldParameters.crystal.pitThreshold.y = 0.36f;
				worldParameters.passage.pitThreshold.y = 0.2591248f;
				worldParameters.excavation.pitThreshold.y = 0.2f;
				break;
			case WorldGenerationSettingLevel.Extreme:
				worldParameters.dirt.pitThreshold.y = 0.75f;
				worldParameters.clay.pitThreshold.y = 0.75f;
				worldParameters.stone.pitThreshold.y = 0.75f;
				worldParameters.forest.pitThreshold.y = 0.75f;
				worldParameters.desert.pitThreshold.y = 0.75f;
				worldParameters.sea.pitThreshold.y = 0.75f;
				worldParameters.crystal.pitThreshold.y = 0.75f;
				worldParameters.passage.pitThreshold.y = 0.75f;
				worldParameters.excavation.pitThreshold.y = 0.35f;
				break;
			case WorldGenerationSettingLevel.Normal:
				break;
			}
		}

		private static void ApplyCeilingHolesSettings(WorldGenerationSettingLevel level, CoreKeeperWorldParameters worldParameters)
		{
			switch (level)
			{
			case WorldGenerationSettingLevel.Off:
				worldParameters.dirt.ceilingHoleThreshold = 0f;
				worldParameters.clay.ceilingHoleThreshold = 0f;
				worldParameters.stone.ceilingHoleThreshold = 0f;
				worldParameters.forest.ceilingHoleThreshold = 0f;
				worldParameters.desert.ceilingHoleThreshold = 0f;
				worldParameters.sea.ceilingHoleThreshold = 0f;
				worldParameters.crystal.ceilingHoleThreshold = 0f;
				worldParameters.passage.ceilingHoleThreshold = 0f;
				worldParameters.excavation.ceilingHoleThreshold = 0f;
				break;
			case WorldGenerationSettingLevel.Low:
				worldParameters.dirt.ceilingHoleThreshold = 0f;
				worldParameters.clay.ceilingHoleThreshold = 0.104f;
				worldParameters.stone.ceilingHoleThreshold = 0.112f;
				worldParameters.forest.ceilingHoleThreshold = 0.208f;
				worldParameters.desert.ceilingHoleThreshold = 0.323f;
				worldParameters.sea.ceilingHoleThreshold = 0.1975f;
				worldParameters.crystal.ceilingHoleThreshold = 0f;
				worldParameters.passage.ceilingHoleThreshold = 0f;
				worldParameters.excavation.ceilingHoleThreshold = 0f;
				break;
			case WorldGenerationSettingLevel.High:
				worldParameters.dirt.ceilingHoleThreshold = 0.36f;
				worldParameters.clay.ceilingHoleThreshold = 0.6f;
				worldParameters.stone.ceilingHoleThreshold = 0.672f;
				worldParameters.forest.ceilingHoleThreshold = 0.75f;
				worldParameters.desert.ceilingHoleThreshold = 0.8f;
				worldParameters.sea.ceilingHoleThreshold = 0.75f;
				worldParameters.crystal.ceilingHoleThreshold = 0.36f;
				worldParameters.passage.ceilingHoleThreshold = 0.36f;
				worldParameters.excavation.ceilingHoleThreshold = 0.3f;
				break;
			case WorldGenerationSettingLevel.Extreme:
				worldParameters.dirt.ceilingHoleThreshold = 1f;
				worldParameters.clay.ceilingHoleThreshold = 1f;
				worldParameters.stone.ceilingHoleThreshold = 1f;
				worldParameters.forest.ceilingHoleThreshold = 1f;
				worldParameters.desert.ceilingHoleThreshold = 1f;
				worldParameters.sea.ceilingHoleThreshold = 1f;
				worldParameters.crystal.ceilingHoleThreshold = 1f;
				worldParameters.passage.ceilingHoleThreshold = 1f;
				worldParameters.excavation.ceilingHoleThreshold = 0.728f;
				break;
			case WorldGenerationSettingLevel.Normal:
				break;
			}
		}
	}
}
