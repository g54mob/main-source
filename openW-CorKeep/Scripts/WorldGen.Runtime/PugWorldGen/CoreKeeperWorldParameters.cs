using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace PugWorldGen
{
	[Serializable]
	[CreateAssetMenu(menuName = "Pug/World Gen/CoreKeeper/World Parameters", fileName = "CoreKeeper World Parameters", order = 3)]
	public class CoreKeeperWorldParameters : WorldParameters
	{
		[Serializable]
		public class BiomeParameters
		{
			[Range(0f, 5f)]
			public int ResourceCount = 2;

			[Splits(splitCountField = "ResourceCount")]
			public Vector4 resourceDistribution = new Vector4(0.2f, 0.2f, 0.2f, 0.2f);

			[Range(0f, 1f)]
			public float resourceThreshold = 0.005f;

			[Range(0f, 1f)]
			public float riverSize = 0.15f;

			[Range(0f, 1f)]
			public float riverAmount = 0.5f;

			[Range(0f, 1f)]
			public float lakeThreshold = 0.2f;

			[Range(0f, 1f)]
			public float chamberThreshold = 0.25f;

			[Range(0f, 1f)]
			public float scatteredWallThreshold = 0.1f;

			[Range(0f, 1f)]
			public float ceilingHoleThreshold = 0.02f;

			[Range(0f, 1f)]
			public float tunnelThreshold = 0.08f;

			[Range(0f, 1f)]
			public float tunnelAmount = 0.5f;

			[Range(0f, 1f)]
			public float sandThreshold = 0.03f;

			[Range(0f, 1f)]
			public float sandAmount = 0.75f;

			[RangeVector(0f, 1f)]
			public Vector2 pitThreshold = new Vector2(0f, 0.1f);

			public float biomeEdgePitSize = 10f;

			public float biomeEdgePitLedgeSize = 4f;

			[Range(0f, 1f)]
			public float biomeSubTileTreshold;

			[Range(0f, 1f)]
			public float explosiveWallAmount;
		}

		[Header("Global")]
		public float worldScale = 1f;

		public float biomeChaos = 150f;

		public float ring1Size = 150f;

		public float ring2Size = 400f;

		public float ring3Size = 900f;

		public float ring4Size = 1050f;

		public float ring1Chaos = 100f;

		public float ring2Chaos = 50f;

		public float ring3Chaos = 200f;

		public float ring4Chaos = 200f;

		public float northBlobRadius = 200f;

		public BiomeParameters dirt = new BiomeParameters();

		public BiomeParameters clay = new BiomeParameters();

		public BiomeParameters stone = new BiomeParameters();

		public BiomeParameters forest = new BiomeParameters();

		public BiomeParameters desert = new BiomeParameters();

		public BiomeParameters sea = new BiomeParameters();

		public BiomeParameters crystal = new BiomeParameters();

		public BiomeParameters passage = new BiomeParameters();

		public BiomeParameters excavation = new BiomeParameters();

		private static int _GlobalSeed = Shader.PropertyToID("_GlobalSeed");

		private static int _WorldScale = Shader.PropertyToID("_WorldScale");

		private static int _BiomeChaos = Shader.PropertyToID("_BiomeChaos");

		private static int _Ring1Size = Shader.PropertyToID("_Ring1Size");

		private static int _Ring2Size = Shader.PropertyToID("_Ring2Size");

		private static int _Ring3Size = Shader.PropertyToID("_Ring3Size");

		private static int _Ring4Size = Shader.PropertyToID("_Ring4Size");

		private static int _Ring1Chaos = Shader.PropertyToID("_Ring1Chaos");

		private static int _Ring2Chaos = Shader.PropertyToID("_Ring2Chaos");

		private static int _Ring3Chaos = Shader.PropertyToID("_Ring3Chaos");

		private static int _Ring4Chaos = Shader.PropertyToID("_Ring4Chaos");

		private static int _NorthBlobRadius = Shader.PropertyToID("_NorthBlobRadius");

		private static int _Dirt_ResourceCount = Shader.PropertyToID("_Dirt_ResourceCount");

		private static int _Dirt_ResourceDistribution = Shader.PropertyToID("_Dirt_ResourceDistribution");

		private static int _Dirt_ResourceThreshold = Shader.PropertyToID("_Dirt_ResourceThreshold");

		private static int _Dirt_RiverSize = Shader.PropertyToID("_Dirt_RiverSize");

		private static int _Dirt_RiverAmount = Shader.PropertyToID("_Dirt_RiverAmount");

		private static int _Dirt_LakeThreshold = Shader.PropertyToID("_Dirt_LakeThreshold");

		private static int _Dirt_ChamberThreshold = Shader.PropertyToID("_Dirt_ChamberThreshold");

		private static int _Dirt_ScatteredWallThreshold = Shader.PropertyToID("_Dirt_ScatteredWallThreshold");

		private static int _Dirt_CeilingHoleThreshold = Shader.PropertyToID("_Dirt_CeilingHoleThreshold");

		private static int _Dirt_TunnelThreshold = Shader.PropertyToID("_Dirt_TunnelThreshold");

		private static int _Dirt_TunnelAmount = Shader.PropertyToID("_Dirt_TunnelAmount");

		private static int _Dirt_SandThreshold = Shader.PropertyToID("_Dirt_SandThreshold");

		private static int _Dirt_SandAmount = Shader.PropertyToID("_Dirt_SandAmount");

		private static int _Dirt_PitThreshold = Shader.PropertyToID("_Dirt_PitThreshold");

		private static int _Dirt_BiomeEdgePitSize = Shader.PropertyToID("_Dirt_BiomeEdgePitSize");

		private static int _Dirt_BiomeEdgePitLedgeSize = Shader.PropertyToID("_Dirt_BiomeEdgePitLedgeSize");

		private static int _Dirt_BiomeSubTileTreshold = Shader.PropertyToID("_Dirt_BiomeSubTileTreshold");

		private static int _Dirt_ExplosiveWallAmount = Shader.PropertyToID("_Dirt_ExplosiveWallAmount");

		private static int _Clay_ResourceCount = Shader.PropertyToID("_Clay_ResourceCount");

		private static int _Clay_ResourceDistribution = Shader.PropertyToID("_Clay_ResourceDistribution");

		private static int _Clay_ResourceThreshold = Shader.PropertyToID("_Clay_ResourceThreshold");

		private static int _Clay_RiverSize = Shader.PropertyToID("_Clay_RiverSize");

		private static int _Clay_RiverAmount = Shader.PropertyToID("_Clay_RiverAmount");

		private static int _Clay_LakeThreshold = Shader.PropertyToID("_Clay_LakeThreshold");

		private static int _Clay_ChamberThreshold = Shader.PropertyToID("_Clay_ChamberThreshold");

		private static int _Clay_ScatteredWallThreshold = Shader.PropertyToID("_Clay_ScatteredWallThreshold");

		private static int _Clay_CeilingHoleThreshold = Shader.PropertyToID("_Clay_CeilingHoleThreshold");

		private static int _Clay_TunnelThreshold = Shader.PropertyToID("_Clay_TunnelThreshold");

		private static int _Clay_TunnelAmount = Shader.PropertyToID("_Clay_TunnelAmount");

		private static int _Clay_SandThreshold = Shader.PropertyToID("_Clay_SandThreshold");

		private static int _Clay_SandAmount = Shader.PropertyToID("_Clay_SandAmount");

		private static int _Clay_PitThreshold = Shader.PropertyToID("_Clay_PitThreshold");

		private static int _Clay_BiomeEdgePitSize = Shader.PropertyToID("_Clay_BiomeEdgePitSize");

		private static int _Clay_BiomeEdgePitLedgeSize = Shader.PropertyToID("_Clay_BiomeEdgePitLedgeSize");

		private static int _Clay_BiomeSubTileTreshold = Shader.PropertyToID("_Clay_BiomeSubTileTreshold");

		private static int _Clay_ExplosiveWallAmount = Shader.PropertyToID("_Clay_ExplosiveWallAmount");

		private static int _Stone_ResourceCount = Shader.PropertyToID("_Stone_ResourceCount");

		private static int _Stone_ResourceDistribution = Shader.PropertyToID("_Stone_ResourceDistribution");

		private static int _Stone_ResourceThreshold = Shader.PropertyToID("_Stone_ResourceThreshold");

		private static int _Stone_RiverSize = Shader.PropertyToID("_Stone_RiverSize");

		private static int _Stone_RiverAmount = Shader.PropertyToID("_Stone_RiverAmount");

		private static int _Stone_LakeThreshold = Shader.PropertyToID("_Stone_LakeThreshold");

		private static int _Stone_ChamberThreshold = Shader.PropertyToID("_Stone_ChamberThreshold");

		private static int _Stone_ScatteredWallThreshold = Shader.PropertyToID("_Stone_ScatteredWallThreshold");

		private static int _Stone_CeilingHoleThreshold = Shader.PropertyToID("_Stone_CeilingHoleThreshold");

		private static int _Stone_TunnelThreshold = Shader.PropertyToID("_Stone_TunnelThreshold");

		private static int _Stone_TunnelAmount = Shader.PropertyToID("_Stone_TunnelAmount");

		private static int _Stone_SandThreshold = Shader.PropertyToID("_Stone_SandThreshold");

		private static int _Stone_SandAmount = Shader.PropertyToID("_Stone_SandAmount");

		private static int _Stone_PitThreshold = Shader.PropertyToID("_Stone_PitThreshold");

		private static int _Stone_BiomeEdgePitSize = Shader.PropertyToID("_Stone_BiomeEdgePitSize");

		private static int _Stone_BiomeEdgePitLedgeSize = Shader.PropertyToID("_Stone_BiomeEdgePitLedgeSize");

		private static int _Stone_BiomeSubTileTreshold = Shader.PropertyToID("_Stone_BiomeSubTileTreshold");

		private static int _Stone_ExplosiveWallAmount = Shader.PropertyToID("_Stone_ExplosiveWallAmount");

		private static int _Forest_ResourceCount = Shader.PropertyToID("_Forest_ResourceCount");

		private static int _Forest_ResourceDistribution = Shader.PropertyToID("_Forest_ResourceDistribution");

		private static int _Forest_ResourceThreshold = Shader.PropertyToID("_Forest_ResourceThreshold");

		private static int _Forest_RiverSize = Shader.PropertyToID("_Forest_RiverSize");

		private static int _Forest_RiverAmount = Shader.PropertyToID("_Forest_RiverAmount");

		private static int _Forest_LakeThreshold = Shader.PropertyToID("_Forest_LakeThreshold");

		private static int _Forest_ChamberThreshold = Shader.PropertyToID("_Forest_ChamberThreshold");

		private static int _Forest_ScatteredWallThreshold = Shader.PropertyToID("_Forest_ScatteredWallThreshold");

		private static int _Forest_CeilingHoleThreshold = Shader.PropertyToID("_Forest_CeilingHoleThreshold");

		private static int _Forest_TunnelThreshold = Shader.PropertyToID("_Forest_TunnelThreshold");

		private static int _Forest_TunnelAmount = Shader.PropertyToID("_Forest_TunnelAmount");

		private static int _Forest_SandThreshold = Shader.PropertyToID("_Forest_SandThreshold");

		private static int _Forest_SandAmount = Shader.PropertyToID("_Forest_SandAmount");

		private static int _Forest_PitThreshold = Shader.PropertyToID("_Forest_PitThreshold");

		private static int _Forest_BiomeEdgePitSize = Shader.PropertyToID("_Forest_BiomeEdgePitSize");

		private static int _Forest_BiomeEdgePitLedgeSize = Shader.PropertyToID("_Forest_BiomeEdgePitLedgeSize");

		private static int _Forest_BiomeSubTileTreshold = Shader.PropertyToID("_Forest_BiomeSubTileTreshold");

		private static int _Forest_ExplosiveWallAmount = Shader.PropertyToID("_Forest_ExplosiveWallAmount");

		private static int _Desert_ResourceCount = Shader.PropertyToID("_Desert_ResourceCount");

		private static int _Desert_ResourceDistribution = Shader.PropertyToID("_Desert_ResourceDistribution");

		private static int _Desert_ResourceThreshold = Shader.PropertyToID("_Desert_ResourceThreshold");

		private static int _Desert_RiverSize = Shader.PropertyToID("_Desert_RiverSize");

		private static int _Desert_RiverAmount = Shader.PropertyToID("_Desert_RiverAmount");

		private static int _Desert_LakeThreshold = Shader.PropertyToID("_Desert_LakeThreshold");

		private static int _Desert_ChamberThreshold = Shader.PropertyToID("_Desert_ChamberThreshold");

		private static int _Desert_ScatteredWallThreshold = Shader.PropertyToID("_Desert_ScatteredWallThreshold");

		private static int _Desert_CeilingHoleThreshold = Shader.PropertyToID("_Desert_CeilingHoleThreshold");

		private static int _Desert_TunnelThreshold = Shader.PropertyToID("_Desert_TunnelThreshold");

		private static int _Desert_TunnelAmount = Shader.PropertyToID("_Desert_TunnelAmount");

		private static int _Desert_SandThreshold = Shader.PropertyToID("_Desert_SandThreshold");

		private static int _Desert_SandAmount = Shader.PropertyToID("_Desert_SandAmount");

		private static int _Desert_PitThreshold = Shader.PropertyToID("_Desert_PitThreshold");

		private static int _Desert_BiomeEdgePitSize = Shader.PropertyToID("_Desert_BiomeEdgePitSize");

		private static int _Desert_BiomeEdgePitLedgeSize = Shader.PropertyToID("_Desert_BiomeEdgePitLedgeSize");

		private static int _Desert_BiomeSubTileTreshold = Shader.PropertyToID("_Desert_BiomeSubTileTreshold");

		private static int _Desert_ExplosiveWallAmount = Shader.PropertyToID("_Desert_ExplosiveWallAmount");

		private static int _Sea_ResourceCount = Shader.PropertyToID("_Sea_ResourceCount");

		private static int _Sea_ResourceDistribution = Shader.PropertyToID("_Sea_ResourceDistribution");

		private static int _Sea_ResourceThreshold = Shader.PropertyToID("_Sea_ResourceThreshold");

		private static int _Sea_RiverSize = Shader.PropertyToID("_Sea_RiverSize");

		private static int _Sea_RiverAmount = Shader.PropertyToID("_Sea_RiverAmount");

		private static int _Sea_LakeThreshold = Shader.PropertyToID("_Sea_LakeThreshold");

		private static int _Sea_ChamberThreshold = Shader.PropertyToID("_Sea_ChamberThreshold");

		private static int _Sea_ScatteredWallThreshold = Shader.PropertyToID("_Sea_ScatteredWallThreshold");

		private static int _Sea_CeilingHoleThreshold = Shader.PropertyToID("_Sea_CeilingHoleThreshold");

		private static int _Sea_TunnelThreshold = Shader.PropertyToID("_Sea_TunnelThreshold");

		private static int _Sea_TunnelAmount = Shader.PropertyToID("_Sea_TunnelAmount");

		private static int _Sea_SandThreshold = Shader.PropertyToID("_Sea_SandThreshold");

		private static int _Sea_SandAmount = Shader.PropertyToID("_Sea_SandAmount");

		private static int _Sea_PitThreshold = Shader.PropertyToID("_Sea_PitThreshold");

		private static int _Sea_BiomeEdgePitSize = Shader.PropertyToID("_Sea_BiomeEdgePitSize");

		private static int _Sea_BiomeEdgePitLedgeSize = Shader.PropertyToID("_Sea_BiomeEdgePitLedgeSize");

		private static int _Sea_BiomeSubTileTreshold = Shader.PropertyToID("_Sea_BiomeSubTileTreshold");

		private static int _Sea_ExplosiveWallAmount = Shader.PropertyToID("_Sea_ExplosiveWallAmount");

		private static int _Crystal_ResourceCount = Shader.PropertyToID("_Crystal_ResourceCount");

		private static int _Crystal_ResourceDistribution = Shader.PropertyToID("_Crystal_ResourceDistribution");

		private static int _Crystal_ResourceThreshold = Shader.PropertyToID("_Crystal_ResourceThreshold");

		private static int _Crystal_RiverSize = Shader.PropertyToID("_Crystal_RiverSize");

		private static int _Crystal_RiverAmount = Shader.PropertyToID("_Crystal_RiverAmount");

		private static int _Crystal_LakeThreshold = Shader.PropertyToID("_Crystal_LakeThreshold");

		private static int _Crystal_ChamberThreshold = Shader.PropertyToID("_Crystal_ChamberThreshold");

		private static int _Crystal_ScatteredWallThreshold = Shader.PropertyToID("_Crystal_ScatteredWallThreshold");

		private static int _Crystal_CeilingHoleThreshold = Shader.PropertyToID("_Crystal_CeilingHoleThreshold");

		private static int _Crystal_TunnelThreshold = Shader.PropertyToID("_Crystal_TunnelThreshold");

		private static int _Crystal_TunnelAmount = Shader.PropertyToID("_Crystal_TunnelAmount");

		private static int _Crystal_SandThreshold = Shader.PropertyToID("_Crystal_SandThreshold");

		private static int _Crystal_SandAmount = Shader.PropertyToID("_Crystal_SandAmount");

		private static int _Crystal_PitThreshold = Shader.PropertyToID("_Crystal_PitThreshold");

		private static int _Crystal_BiomeEdgePitSize = Shader.PropertyToID("_Crystal_BiomeEdgePitSize");

		private static int _Crystal_BiomeEdgePitLedgeSize = Shader.PropertyToID("_Crystal_BiomeEdgePitLedgeSize");

		private static int _Crystal_BiomeSubTileTreshold = Shader.PropertyToID("_Crystal_BiomeSubTileTreshold");

		private static int _Crystal_ExplosiveWallAmount = Shader.PropertyToID("_Crystal_ExplosiveWallAmount");

		private static int _Passage_ResourceCount = Shader.PropertyToID("_Passage_ResourceCount");

		private static int _Passage_ResourceDistribution = Shader.PropertyToID("_Passage_ResourceDistribution");

		private static int _Passage_ResourceThreshold = Shader.PropertyToID("_Passage_ResourceThreshold");

		private static int _Passage_RiverSize = Shader.PropertyToID("_Passage_RiverSize");

		private static int _Passage_RiverAmount = Shader.PropertyToID("_Passage_RiverAmount");

		private static int _Passage_LakeThreshold = Shader.PropertyToID("_Passage_LakeThreshold");

		private static int _Passage_ChamberThreshold = Shader.PropertyToID("_Passage_ChamberThreshold");

		private static int _Passage_ScatteredWallThreshold = Shader.PropertyToID("_Passage_ScatteredWallThreshold");

		private static int _Passage_CeilingHoleThreshold = Shader.PropertyToID("_Passage_CeilingHoleThreshold");

		private static int _Passage_TunnelThreshold = Shader.PropertyToID("_Passage_TunnelThreshold");

		private static int _Passage_TunnelAmount = Shader.PropertyToID("_Passage_TunnelAmount");

		private static int _Passage_SandThreshold = Shader.PropertyToID("_Passage_SandThreshold");

		private static int _Passage_SandAmount = Shader.PropertyToID("_Passage_SandAmount");

		private static int _Passage_PitThreshold = Shader.PropertyToID("_Passage_PitThreshold");

		private static int _Passage_BiomeEdgePitSize = Shader.PropertyToID("_Passage_BiomeEdgePitSize");

		private static int _Passage_BiomeEdgePitLedgeSize = Shader.PropertyToID("_Passage_BiomeEdgePitLedgeSize");

		private static int _Passage_BiomeSubTileTreshold = Shader.PropertyToID("_Passage_BiomeSubTileTreshold");

		private static int _Passage_ExplosiveWallAmount = Shader.PropertyToID("_Passage_ExplosiveWallAmount");

		private static int _Excavation_ResourceCount = Shader.PropertyToID("_Excavation_ResourceCount");

		private static int _Excavation_ResourceDistribution = Shader.PropertyToID("_Excavation_ResourceDistribution");

		private static int _Excavation_ResourceThreshold = Shader.PropertyToID("_Excavation_ResourceThreshold");

		private static int _Excavation_RiverSize = Shader.PropertyToID("_Excavation_RiverSize");

		private static int _Excavation_RiverAmount = Shader.PropertyToID("_Excavation_RiverAmount");

		private static int _Excavation_LakeThreshold = Shader.PropertyToID("_Excavation_LakeThreshold");

		private static int _Excavation_ChamberThreshold = Shader.PropertyToID("_Excavation_ChamberThreshold");

		private static int _Excavation_ScatteredWallThreshold = Shader.PropertyToID("_Excavation_ScatteredWallThreshold");

		private static int _Excavation_CeilingHoleThreshold = Shader.PropertyToID("_Excavation_CeilingHoleThreshold");

		private static int _Excavation_TunnelThreshold = Shader.PropertyToID("_Excavation_TunnelThreshold");

		private static int _Excavation_TunnelAmount = Shader.PropertyToID("_Excavation_TunnelAmount");

		private static int _Excavation_SandThreshold = Shader.PropertyToID("_Excavation_SandThreshold");

		private static int _Excavation_SandAmount = Shader.PropertyToID("_Excavation_SandAmount");

		private static int _Excavation_PitThreshold = Shader.PropertyToID("_Excavation_PitThreshold");

		private static int _Excavation_BiomeEdgePitSize = Shader.PropertyToID("_Excavation_BiomeEdgePitSize");

		private static int _Excavation_BiomeEdgePitLedgeSize = Shader.PropertyToID("_Excavation_BiomeEdgePitLedgeSize");

		private static int _Excavation_BiomeSubTileTreshold = Shader.PropertyToID("_Excavation_BiomeSubTileTreshold");

		private static int _Excavation_ExplosiveWallAmount = Shader.PropertyToID("_Excavation_ExplosiveWallAmount");

		public override void SetShaderProperties()
		{
			Shader.SetGlobalFloat(_GlobalSeed, globalSeed);
			Shader.SetGlobalFloat(_WorldScale, worldScale);
			Shader.SetGlobalFloat(_BiomeChaos, biomeChaos);
			Shader.SetGlobalFloat(_Ring1Size, ring1Size);
			Shader.SetGlobalFloat(_Ring2Size, ring2Size);
			Shader.SetGlobalFloat(_Ring3Size, ring3Size);
			Shader.SetGlobalFloat(_Ring4Size, ring4Size);
			Shader.SetGlobalFloat(_Ring1Chaos, ring1Chaos);
			Shader.SetGlobalFloat(_Ring2Chaos, ring2Chaos);
			Shader.SetGlobalFloat(_Ring3Chaos, ring3Chaos);
			Shader.SetGlobalFloat(_Ring4Chaos, ring4Chaos);
			Shader.SetGlobalFloat(_NorthBlobRadius, northBlobRadius);
			Shader.SetGlobalFloat(_Dirt_ResourceCount, dirt.ResourceCount);
			Shader.SetGlobalVector(_Dirt_ResourceDistribution, dirt.resourceDistribution);
			Shader.SetGlobalFloat(_Dirt_ResourceThreshold, dirt.resourceThreshold);
			Shader.SetGlobalFloat(_Dirt_RiverSize, dirt.riverSize);
			Shader.SetGlobalFloat(_Dirt_RiverAmount, dirt.riverAmount);
			Shader.SetGlobalFloat(_Dirt_LakeThreshold, dirt.lakeThreshold);
			Shader.SetGlobalFloat(_Dirt_ChamberThreshold, dirt.chamberThreshold);
			Shader.SetGlobalFloat(_Dirt_ScatteredWallThreshold, dirt.scatteredWallThreshold);
			Shader.SetGlobalFloat(_Dirt_CeilingHoleThreshold, dirt.ceilingHoleThreshold);
			Shader.SetGlobalFloat(_Dirt_TunnelThreshold, dirt.tunnelThreshold);
			Shader.SetGlobalFloat(_Dirt_TunnelAmount, dirt.tunnelAmount);
			Shader.SetGlobalFloat(_Dirt_SandThreshold, dirt.sandThreshold);
			Shader.SetGlobalFloat(_Dirt_SandAmount, dirt.sandAmount);
			Shader.SetGlobalVector(_Dirt_PitThreshold, dirt.pitThreshold);
			Shader.SetGlobalFloat(_Dirt_BiomeEdgePitSize, dirt.biomeEdgePitSize);
			Shader.SetGlobalFloat(_Dirt_BiomeEdgePitLedgeSize, dirt.biomeEdgePitLedgeSize);
			Shader.SetGlobalFloat(_Dirt_BiomeSubTileTreshold, dirt.biomeSubTileTreshold);
			Shader.SetGlobalFloat(_Dirt_ExplosiveWallAmount, dirt.explosiveWallAmount);
			Shader.SetGlobalFloat(_Clay_ResourceCount, clay.ResourceCount);
			Shader.SetGlobalVector(_Clay_ResourceDistribution, clay.resourceDistribution);
			Shader.SetGlobalFloat(_Clay_ResourceThreshold, clay.resourceThreshold);
			Shader.SetGlobalFloat(_Clay_RiverSize, clay.riverSize);
			Shader.SetGlobalFloat(_Clay_RiverAmount, clay.riverAmount);
			Shader.SetGlobalFloat(_Clay_LakeThreshold, clay.lakeThreshold);
			Shader.SetGlobalFloat(_Clay_ChamberThreshold, clay.chamberThreshold);
			Shader.SetGlobalFloat(_Clay_ScatteredWallThreshold, clay.scatteredWallThreshold);
			Shader.SetGlobalFloat(_Clay_CeilingHoleThreshold, clay.ceilingHoleThreshold);
			Shader.SetGlobalFloat(_Clay_TunnelThreshold, clay.tunnelThreshold);
			Shader.SetGlobalFloat(_Clay_TunnelAmount, clay.tunnelAmount);
			Shader.SetGlobalFloat(_Clay_SandThreshold, clay.sandThreshold);
			Shader.SetGlobalFloat(_Clay_SandAmount, clay.sandAmount);
			Shader.SetGlobalVector(_Clay_PitThreshold, clay.pitThreshold);
			Shader.SetGlobalFloat(_Clay_BiomeEdgePitSize, clay.biomeEdgePitSize);
			Shader.SetGlobalFloat(_Clay_BiomeEdgePitLedgeSize, clay.biomeEdgePitLedgeSize);
			Shader.SetGlobalFloat(_Clay_BiomeSubTileTreshold, clay.biomeSubTileTreshold);
			Shader.SetGlobalFloat(_Clay_ExplosiveWallAmount, clay.explosiveWallAmount);
			Shader.SetGlobalFloat(_Stone_ResourceCount, stone.ResourceCount);
			Shader.SetGlobalVector(_Stone_ResourceDistribution, stone.resourceDistribution);
			Shader.SetGlobalFloat(_Stone_ResourceThreshold, stone.resourceThreshold);
			Shader.SetGlobalFloat(_Stone_RiverSize, stone.riverSize);
			Shader.SetGlobalFloat(_Stone_RiverAmount, stone.riverAmount);
			Shader.SetGlobalFloat(_Stone_LakeThreshold, stone.lakeThreshold);
			Shader.SetGlobalFloat(_Stone_ChamberThreshold, stone.chamberThreshold);
			Shader.SetGlobalFloat(_Stone_ScatteredWallThreshold, stone.scatteredWallThreshold);
			Shader.SetGlobalFloat(_Stone_CeilingHoleThreshold, stone.ceilingHoleThreshold);
			Shader.SetGlobalFloat(_Stone_TunnelThreshold, stone.tunnelThreshold);
			Shader.SetGlobalFloat(_Stone_TunnelAmount, stone.tunnelAmount);
			Shader.SetGlobalFloat(_Stone_SandThreshold, stone.sandThreshold);
			Shader.SetGlobalFloat(_Stone_SandAmount, stone.sandAmount);
			Shader.SetGlobalVector(_Stone_PitThreshold, stone.pitThreshold);
			Shader.SetGlobalFloat(_Stone_BiomeEdgePitSize, stone.biomeEdgePitSize);
			Shader.SetGlobalFloat(_Stone_BiomeEdgePitLedgeSize, stone.biomeEdgePitLedgeSize);
			Shader.SetGlobalFloat(_Stone_BiomeSubTileTreshold, stone.biomeSubTileTreshold);
			Shader.SetGlobalFloat(_Stone_ExplosiveWallAmount, stone.explosiveWallAmount);
			Shader.SetGlobalFloat(_Forest_ResourceCount, forest.ResourceCount);
			Shader.SetGlobalVector(_Forest_ResourceDistribution, forest.resourceDistribution);
			Shader.SetGlobalFloat(_Forest_ResourceThreshold, forest.resourceThreshold);
			Shader.SetGlobalFloat(_Forest_RiverSize, forest.riverSize);
			Shader.SetGlobalFloat(_Forest_RiverAmount, forest.riverAmount);
			Shader.SetGlobalFloat(_Forest_LakeThreshold, forest.lakeThreshold);
			Shader.SetGlobalFloat(_Forest_ChamberThreshold, forest.chamberThreshold);
			Shader.SetGlobalFloat(_Forest_ScatteredWallThreshold, forest.scatteredWallThreshold);
			Shader.SetGlobalFloat(_Forest_CeilingHoleThreshold, forest.ceilingHoleThreshold);
			Shader.SetGlobalFloat(_Forest_TunnelThreshold, forest.tunnelThreshold);
			Shader.SetGlobalFloat(_Forest_TunnelAmount, forest.tunnelAmount);
			Shader.SetGlobalFloat(_Forest_SandThreshold, forest.sandThreshold);
			Shader.SetGlobalFloat(_Forest_SandAmount, forest.sandAmount);
			Shader.SetGlobalVector(_Forest_PitThreshold, forest.pitThreshold);
			Shader.SetGlobalFloat(_Forest_BiomeEdgePitSize, forest.biomeEdgePitSize);
			Shader.SetGlobalFloat(_Forest_BiomeEdgePitLedgeSize, forest.biomeEdgePitLedgeSize);
			Shader.SetGlobalFloat(_Forest_BiomeSubTileTreshold, forest.biomeSubTileTreshold);
			Shader.SetGlobalFloat(_Forest_ExplosiveWallAmount, forest.explosiveWallAmount);
			Shader.SetGlobalFloat(_Desert_ResourceCount, desert.ResourceCount);
			Shader.SetGlobalVector(_Desert_ResourceDistribution, desert.resourceDistribution);
			Shader.SetGlobalFloat(_Desert_ResourceThreshold, desert.resourceThreshold);
			Shader.SetGlobalFloat(_Desert_RiverSize, desert.riverSize);
			Shader.SetGlobalFloat(_Desert_RiverAmount, desert.riverAmount);
			Shader.SetGlobalFloat(_Desert_LakeThreshold, desert.lakeThreshold);
			Shader.SetGlobalFloat(_Desert_ChamberThreshold, desert.chamberThreshold);
			Shader.SetGlobalFloat(_Desert_ScatteredWallThreshold, desert.scatteredWallThreshold);
			Shader.SetGlobalFloat(_Desert_CeilingHoleThreshold, desert.ceilingHoleThreshold);
			Shader.SetGlobalFloat(_Desert_TunnelThreshold, desert.tunnelThreshold);
			Shader.SetGlobalFloat(_Desert_TunnelAmount, desert.tunnelAmount);
			Shader.SetGlobalFloat(_Desert_SandThreshold, desert.sandThreshold);
			Shader.SetGlobalFloat(_Desert_SandAmount, desert.sandAmount);
			Shader.SetGlobalVector(_Desert_PitThreshold, desert.pitThreshold);
			Shader.SetGlobalFloat(_Desert_BiomeEdgePitSize, desert.biomeEdgePitSize);
			Shader.SetGlobalFloat(_Desert_BiomeEdgePitLedgeSize, desert.biomeEdgePitLedgeSize);
			Shader.SetGlobalFloat(_Desert_BiomeSubTileTreshold, desert.biomeSubTileTreshold);
			Shader.SetGlobalFloat(_Desert_ExplosiveWallAmount, desert.explosiveWallAmount);
			Shader.SetGlobalFloat(_Sea_ResourceCount, sea.ResourceCount);
			Shader.SetGlobalVector(_Sea_ResourceDistribution, sea.resourceDistribution);
			Shader.SetGlobalFloat(_Sea_ResourceThreshold, sea.resourceThreshold);
			Shader.SetGlobalFloat(_Sea_RiverSize, sea.riverSize);
			Shader.SetGlobalFloat(_Sea_RiverAmount, sea.riverAmount);
			Shader.SetGlobalFloat(_Sea_LakeThreshold, sea.lakeThreshold);
			Shader.SetGlobalFloat(_Sea_ChamberThreshold, sea.chamberThreshold);
			Shader.SetGlobalFloat(_Sea_ScatteredWallThreshold, sea.scatteredWallThreshold);
			Shader.SetGlobalFloat(_Sea_CeilingHoleThreshold, sea.ceilingHoleThreshold);
			Shader.SetGlobalFloat(_Sea_TunnelThreshold, sea.tunnelThreshold);
			Shader.SetGlobalFloat(_Sea_TunnelAmount, sea.tunnelAmount);
			Shader.SetGlobalFloat(_Sea_SandThreshold, sea.sandThreshold);
			Shader.SetGlobalFloat(_Sea_SandAmount, sea.sandAmount);
			Shader.SetGlobalVector(_Sea_PitThreshold, sea.pitThreshold);
			Shader.SetGlobalFloat(_Sea_BiomeEdgePitSize, sea.biomeEdgePitSize);
			Shader.SetGlobalFloat(_Sea_BiomeEdgePitLedgeSize, sea.biomeEdgePitLedgeSize);
			Shader.SetGlobalFloat(_Sea_BiomeSubTileTreshold, sea.biomeSubTileTreshold);
			Shader.SetGlobalFloat(_Sea_ExplosiveWallAmount, sea.explosiveWallAmount);
			Shader.SetGlobalFloat(_Crystal_ResourceCount, crystal.ResourceCount);
			Shader.SetGlobalVector(_Crystal_ResourceDistribution, crystal.resourceDistribution);
			Shader.SetGlobalFloat(_Crystal_ResourceThreshold, crystal.resourceThreshold);
			Shader.SetGlobalFloat(_Crystal_RiverSize, crystal.riverSize);
			Shader.SetGlobalFloat(_Crystal_RiverAmount, crystal.riverAmount);
			Shader.SetGlobalFloat(_Crystal_LakeThreshold, crystal.lakeThreshold);
			Shader.SetGlobalFloat(_Crystal_ChamberThreshold, crystal.chamberThreshold);
			Shader.SetGlobalFloat(_Crystal_ScatteredWallThreshold, crystal.scatteredWallThreshold);
			Shader.SetGlobalFloat(_Crystal_CeilingHoleThreshold, crystal.ceilingHoleThreshold);
			Shader.SetGlobalFloat(_Crystal_TunnelThreshold, crystal.tunnelThreshold);
			Shader.SetGlobalFloat(_Crystal_TunnelAmount, crystal.tunnelAmount);
			Shader.SetGlobalFloat(_Crystal_SandThreshold, crystal.sandThreshold);
			Shader.SetGlobalFloat(_Crystal_SandAmount, crystal.sandAmount);
			Shader.SetGlobalVector(_Crystal_PitThreshold, crystal.pitThreshold);
			Shader.SetGlobalFloat(_Crystal_BiomeEdgePitSize, crystal.biomeEdgePitSize);
			Shader.SetGlobalFloat(_Crystal_BiomeEdgePitLedgeSize, crystal.biomeEdgePitLedgeSize);
			Shader.SetGlobalFloat(_Crystal_BiomeSubTileTreshold, crystal.biomeSubTileTreshold);
			Shader.SetGlobalFloat(_Crystal_ExplosiveWallAmount, crystal.explosiveWallAmount);
			Shader.SetGlobalFloat(_Passage_ResourceCount, passage.ResourceCount);
			Shader.SetGlobalVector(_Passage_ResourceDistribution, passage.resourceDistribution);
			Shader.SetGlobalFloat(_Passage_ResourceThreshold, passage.resourceThreshold);
			Shader.SetGlobalFloat(_Passage_RiverSize, passage.riverSize);
			Shader.SetGlobalFloat(_Passage_RiverAmount, passage.riverAmount);
			Shader.SetGlobalFloat(_Passage_LakeThreshold, passage.lakeThreshold);
			Shader.SetGlobalFloat(_Passage_ChamberThreshold, passage.chamberThreshold);
			Shader.SetGlobalFloat(_Passage_ScatteredWallThreshold, passage.scatteredWallThreshold);
			Shader.SetGlobalFloat(_Passage_CeilingHoleThreshold, passage.ceilingHoleThreshold);
			Shader.SetGlobalFloat(_Passage_TunnelThreshold, passage.tunnelThreshold);
			Shader.SetGlobalFloat(_Passage_TunnelAmount, passage.tunnelAmount);
			Shader.SetGlobalFloat(_Passage_SandThreshold, passage.sandThreshold);
			Shader.SetGlobalFloat(_Passage_SandAmount, passage.sandAmount);
			Shader.SetGlobalVector(_Passage_PitThreshold, passage.pitThreshold);
			Shader.SetGlobalFloat(_Passage_BiomeEdgePitSize, passage.biomeEdgePitSize);
			Shader.SetGlobalFloat(_Passage_BiomeEdgePitLedgeSize, passage.biomeEdgePitLedgeSize);
			Shader.SetGlobalFloat(_Passage_BiomeSubTileTreshold, passage.biomeSubTileTreshold);
			Shader.SetGlobalFloat(_Passage_ExplosiveWallAmount, passage.explosiveWallAmount);
			Shader.SetGlobalFloat(_Excavation_ResourceCount, excavation.ResourceCount);
			Shader.SetGlobalVector(_Excavation_ResourceDistribution, excavation.resourceDistribution);
			Shader.SetGlobalFloat(_Excavation_ResourceThreshold, excavation.resourceThreshold);
			Shader.SetGlobalFloat(_Excavation_RiverSize, excavation.riverSize);
			Shader.SetGlobalFloat(_Excavation_RiverAmount, excavation.riverAmount);
			Shader.SetGlobalFloat(_Excavation_LakeThreshold, excavation.lakeThreshold);
			Shader.SetGlobalFloat(_Excavation_ChamberThreshold, excavation.chamberThreshold);
			Shader.SetGlobalFloat(_Excavation_ScatteredWallThreshold, excavation.scatteredWallThreshold);
			Shader.SetGlobalFloat(_Excavation_CeilingHoleThreshold, excavation.ceilingHoleThreshold);
			Shader.SetGlobalFloat(_Excavation_TunnelThreshold, excavation.tunnelThreshold);
			Shader.SetGlobalFloat(_Excavation_TunnelAmount, excavation.tunnelAmount);
			Shader.SetGlobalFloat(_Excavation_SandThreshold, excavation.sandThreshold);
			Shader.SetGlobalFloat(_Excavation_SandAmount, excavation.sandAmount);
			Shader.SetGlobalVector(_Excavation_PitThreshold, excavation.pitThreshold);
			Shader.SetGlobalFloat(_Excavation_BiomeEdgePitSize, excavation.biomeEdgePitSize);
			Shader.SetGlobalFloat(_Excavation_BiomeEdgePitLedgeSize, excavation.biomeEdgePitLedgeSize);
			Shader.SetGlobalFloat(_Excavation_BiomeSubTileTreshold, excavation.biomeSubTileTreshold);
			Shader.SetGlobalFloat(_Excavation_ExplosiveWallAmount, excavation.explosiveWallAmount);
		}

		public override void SetShaderProperties(CommandBuffer cmd)
		{
			cmd.SetGlobalFloat(_GlobalSeed, globalSeed);
			cmd.SetGlobalFloat(_WorldScale, worldScale);
			cmd.SetGlobalFloat(_BiomeChaos, biomeChaos);
			cmd.SetGlobalFloat(_Ring1Size, ring1Size);
			cmd.SetGlobalFloat(_Ring2Size, ring2Size);
			cmd.SetGlobalFloat(_Ring3Size, ring3Size);
			cmd.SetGlobalFloat(_Ring4Size, ring4Size);
			cmd.SetGlobalFloat(_Ring1Chaos, ring1Chaos);
			cmd.SetGlobalFloat(_Ring2Chaos, ring2Chaos);
			cmd.SetGlobalFloat(_Ring3Chaos, ring3Chaos);
			cmd.SetGlobalFloat(_Ring4Chaos, ring4Chaos);
			cmd.SetGlobalFloat(_NorthBlobRadius, northBlobRadius);
			cmd.SetGlobalFloat(_Dirt_ResourceCount, dirt.ResourceCount);
			cmd.SetGlobalVector(_Dirt_ResourceDistribution, dirt.resourceDistribution);
			cmd.SetGlobalFloat(_Dirt_ResourceThreshold, dirt.resourceThreshold);
			cmd.SetGlobalFloat(_Dirt_RiverSize, dirt.riverSize);
			cmd.SetGlobalFloat(_Dirt_RiverAmount, dirt.riverAmount);
			cmd.SetGlobalFloat(_Dirt_LakeThreshold, dirt.lakeThreshold);
			cmd.SetGlobalFloat(_Dirt_ChamberThreshold, dirt.chamberThreshold);
			cmd.SetGlobalFloat(_Dirt_ScatteredWallThreshold, dirt.scatteredWallThreshold);
			cmd.SetGlobalFloat(_Dirt_CeilingHoleThreshold, dirt.ceilingHoleThreshold);
			cmd.SetGlobalFloat(_Dirt_TunnelThreshold, dirt.tunnelThreshold);
			cmd.SetGlobalFloat(_Dirt_TunnelAmount, dirt.tunnelAmount);
			cmd.SetGlobalFloat(_Dirt_SandThreshold, dirt.sandThreshold);
			cmd.SetGlobalFloat(_Dirt_SandAmount, dirt.sandAmount);
			cmd.SetGlobalVector(_Dirt_PitThreshold, dirt.pitThreshold);
			cmd.SetGlobalFloat(_Dirt_BiomeEdgePitSize, dirt.biomeEdgePitSize);
			cmd.SetGlobalFloat(_Dirt_BiomeEdgePitLedgeSize, dirt.biomeEdgePitLedgeSize);
			cmd.SetGlobalFloat(_Dirt_BiomeSubTileTreshold, dirt.biomeSubTileTreshold);
			cmd.SetGlobalFloat(_Dirt_ExplosiveWallAmount, dirt.explosiveWallAmount);
			cmd.SetGlobalFloat(_Clay_ResourceCount, clay.ResourceCount);
			cmd.SetGlobalVector(_Clay_ResourceDistribution, clay.resourceDistribution);
			cmd.SetGlobalFloat(_Clay_ResourceThreshold, clay.resourceThreshold);
			cmd.SetGlobalFloat(_Clay_RiverSize, clay.riverSize);
			cmd.SetGlobalFloat(_Clay_RiverAmount, clay.riverAmount);
			cmd.SetGlobalFloat(_Clay_LakeThreshold, clay.lakeThreshold);
			cmd.SetGlobalFloat(_Clay_ChamberThreshold, clay.chamberThreshold);
			cmd.SetGlobalFloat(_Clay_ScatteredWallThreshold, clay.scatteredWallThreshold);
			cmd.SetGlobalFloat(_Clay_CeilingHoleThreshold, clay.ceilingHoleThreshold);
			cmd.SetGlobalFloat(_Clay_TunnelThreshold, clay.tunnelThreshold);
			cmd.SetGlobalFloat(_Clay_TunnelAmount, clay.tunnelAmount);
			cmd.SetGlobalFloat(_Clay_SandThreshold, clay.sandThreshold);
			cmd.SetGlobalFloat(_Clay_SandAmount, clay.sandAmount);
			cmd.SetGlobalVector(_Clay_PitThreshold, clay.pitThreshold);
			cmd.SetGlobalFloat(_Clay_BiomeEdgePitSize, clay.biomeEdgePitSize);
			cmd.SetGlobalFloat(_Clay_BiomeEdgePitLedgeSize, clay.biomeEdgePitLedgeSize);
			cmd.SetGlobalFloat(_Clay_BiomeSubTileTreshold, clay.biomeSubTileTreshold);
			cmd.SetGlobalFloat(_Clay_ExplosiveWallAmount, clay.explosiveWallAmount);
			cmd.SetGlobalFloat(_Stone_ResourceCount, stone.ResourceCount);
			cmd.SetGlobalVector(_Stone_ResourceDistribution, stone.resourceDistribution);
			cmd.SetGlobalFloat(_Stone_ResourceThreshold, stone.resourceThreshold);
			cmd.SetGlobalFloat(_Stone_RiverSize, stone.riverSize);
			cmd.SetGlobalFloat(_Stone_RiverAmount, stone.riverAmount);
			cmd.SetGlobalFloat(_Stone_LakeThreshold, stone.lakeThreshold);
			cmd.SetGlobalFloat(_Stone_ChamberThreshold, stone.chamberThreshold);
			cmd.SetGlobalFloat(_Stone_ScatteredWallThreshold, stone.scatteredWallThreshold);
			cmd.SetGlobalFloat(_Stone_CeilingHoleThreshold, stone.ceilingHoleThreshold);
			cmd.SetGlobalFloat(_Stone_TunnelThreshold, stone.tunnelThreshold);
			cmd.SetGlobalFloat(_Stone_TunnelAmount, stone.tunnelAmount);
			cmd.SetGlobalFloat(_Stone_SandThreshold, stone.sandThreshold);
			cmd.SetGlobalFloat(_Stone_SandAmount, stone.sandAmount);
			cmd.SetGlobalVector(_Stone_PitThreshold, stone.pitThreshold);
			cmd.SetGlobalFloat(_Stone_BiomeEdgePitSize, stone.biomeEdgePitSize);
			cmd.SetGlobalFloat(_Stone_BiomeEdgePitLedgeSize, stone.biomeEdgePitLedgeSize);
			cmd.SetGlobalFloat(_Stone_BiomeSubTileTreshold, stone.biomeSubTileTreshold);
			cmd.SetGlobalFloat(_Stone_ExplosiveWallAmount, stone.explosiveWallAmount);
			cmd.SetGlobalFloat(_Forest_ResourceCount, forest.ResourceCount);
			cmd.SetGlobalVector(_Forest_ResourceDistribution, forest.resourceDistribution);
			cmd.SetGlobalFloat(_Forest_ResourceThreshold, forest.resourceThreshold);
			cmd.SetGlobalFloat(_Forest_RiverSize, forest.riverSize);
			cmd.SetGlobalFloat(_Forest_RiverAmount, forest.riverAmount);
			cmd.SetGlobalFloat(_Forest_LakeThreshold, forest.lakeThreshold);
			cmd.SetGlobalFloat(_Forest_ChamberThreshold, forest.chamberThreshold);
			cmd.SetGlobalFloat(_Forest_ScatteredWallThreshold, forest.scatteredWallThreshold);
			cmd.SetGlobalFloat(_Forest_CeilingHoleThreshold, forest.ceilingHoleThreshold);
			cmd.SetGlobalFloat(_Forest_TunnelThreshold, forest.tunnelThreshold);
			cmd.SetGlobalFloat(_Forest_TunnelAmount, forest.tunnelAmount);
			cmd.SetGlobalFloat(_Forest_SandThreshold, forest.sandThreshold);
			cmd.SetGlobalFloat(_Forest_SandAmount, forest.sandAmount);
			cmd.SetGlobalVector(_Forest_PitThreshold, forest.pitThreshold);
			cmd.SetGlobalFloat(_Forest_BiomeEdgePitSize, forest.biomeEdgePitSize);
			cmd.SetGlobalFloat(_Forest_BiomeEdgePitLedgeSize, forest.biomeEdgePitLedgeSize);
			cmd.SetGlobalFloat(_Forest_BiomeSubTileTreshold, forest.biomeSubTileTreshold);
			cmd.SetGlobalFloat(_Forest_ExplosiveWallAmount, forest.explosiveWallAmount);
			cmd.SetGlobalFloat(_Desert_ResourceCount, desert.ResourceCount);
			cmd.SetGlobalVector(_Desert_ResourceDistribution, desert.resourceDistribution);
			cmd.SetGlobalFloat(_Desert_ResourceThreshold, desert.resourceThreshold);
			cmd.SetGlobalFloat(_Desert_RiverSize, desert.riverSize);
			cmd.SetGlobalFloat(_Desert_RiverAmount, desert.riverAmount);
			cmd.SetGlobalFloat(_Desert_LakeThreshold, desert.lakeThreshold);
			cmd.SetGlobalFloat(_Desert_ChamberThreshold, desert.chamberThreshold);
			cmd.SetGlobalFloat(_Desert_ScatteredWallThreshold, desert.scatteredWallThreshold);
			cmd.SetGlobalFloat(_Desert_CeilingHoleThreshold, desert.ceilingHoleThreshold);
			cmd.SetGlobalFloat(_Desert_TunnelThreshold, desert.tunnelThreshold);
			cmd.SetGlobalFloat(_Desert_TunnelAmount, desert.tunnelAmount);
			cmd.SetGlobalFloat(_Desert_SandThreshold, desert.sandThreshold);
			cmd.SetGlobalFloat(_Desert_SandAmount, desert.sandAmount);
			cmd.SetGlobalVector(_Desert_PitThreshold, desert.pitThreshold);
			cmd.SetGlobalFloat(_Desert_BiomeEdgePitSize, desert.biomeEdgePitSize);
			cmd.SetGlobalFloat(_Desert_BiomeEdgePitLedgeSize, desert.biomeEdgePitLedgeSize);
			cmd.SetGlobalFloat(_Desert_BiomeSubTileTreshold, desert.biomeSubTileTreshold);
			cmd.SetGlobalFloat(_Desert_ExplosiveWallAmount, desert.explosiveWallAmount);
			cmd.SetGlobalFloat(_Sea_ResourceCount, sea.ResourceCount);
			cmd.SetGlobalVector(_Sea_ResourceDistribution, sea.resourceDistribution);
			cmd.SetGlobalFloat(_Sea_ResourceThreshold, sea.resourceThreshold);
			cmd.SetGlobalFloat(_Sea_RiverSize, sea.riverSize);
			cmd.SetGlobalFloat(_Sea_RiverAmount, sea.riverAmount);
			cmd.SetGlobalFloat(_Sea_LakeThreshold, sea.lakeThreshold);
			cmd.SetGlobalFloat(_Sea_ChamberThreshold, sea.chamberThreshold);
			cmd.SetGlobalFloat(_Sea_ScatteredWallThreshold, sea.scatteredWallThreshold);
			cmd.SetGlobalFloat(_Sea_CeilingHoleThreshold, sea.ceilingHoleThreshold);
			cmd.SetGlobalFloat(_Sea_TunnelThreshold, sea.tunnelThreshold);
			cmd.SetGlobalFloat(_Sea_TunnelAmount, sea.tunnelAmount);
			cmd.SetGlobalFloat(_Sea_SandThreshold, sea.sandThreshold);
			cmd.SetGlobalFloat(_Sea_SandAmount, sea.sandAmount);
			cmd.SetGlobalVector(_Sea_PitThreshold, sea.pitThreshold);
			cmd.SetGlobalFloat(_Sea_BiomeEdgePitSize, sea.biomeEdgePitSize);
			cmd.SetGlobalFloat(_Sea_BiomeEdgePitLedgeSize, sea.biomeEdgePitLedgeSize);
			cmd.SetGlobalFloat(_Sea_BiomeSubTileTreshold, sea.biomeSubTileTreshold);
			cmd.SetGlobalFloat(_Sea_ExplosiveWallAmount, sea.explosiveWallAmount);
			cmd.SetGlobalFloat(_Crystal_ResourceCount, crystal.ResourceCount);
			cmd.SetGlobalVector(_Crystal_ResourceDistribution, crystal.resourceDistribution);
			cmd.SetGlobalFloat(_Crystal_ResourceThreshold, crystal.resourceThreshold);
			cmd.SetGlobalFloat(_Crystal_RiverSize, crystal.riverSize);
			cmd.SetGlobalFloat(_Crystal_RiverAmount, crystal.riverAmount);
			cmd.SetGlobalFloat(_Crystal_LakeThreshold, crystal.lakeThreshold);
			cmd.SetGlobalFloat(_Crystal_ChamberThreshold, crystal.chamberThreshold);
			cmd.SetGlobalFloat(_Crystal_ScatteredWallThreshold, crystal.scatteredWallThreshold);
			cmd.SetGlobalFloat(_Crystal_CeilingHoleThreshold, crystal.ceilingHoleThreshold);
			cmd.SetGlobalFloat(_Crystal_TunnelThreshold, crystal.tunnelThreshold);
			cmd.SetGlobalFloat(_Crystal_TunnelAmount, crystal.tunnelAmount);
			cmd.SetGlobalFloat(_Crystal_SandThreshold, crystal.sandThreshold);
			cmd.SetGlobalFloat(_Crystal_SandAmount, crystal.sandAmount);
			cmd.SetGlobalVector(_Crystal_PitThreshold, crystal.pitThreshold);
			cmd.SetGlobalFloat(_Crystal_BiomeEdgePitSize, crystal.biomeEdgePitSize);
			cmd.SetGlobalFloat(_Crystal_BiomeEdgePitLedgeSize, crystal.biomeEdgePitLedgeSize);
			cmd.SetGlobalFloat(_Crystal_BiomeSubTileTreshold, crystal.biomeSubTileTreshold);
			cmd.SetGlobalFloat(_Crystal_ExplosiveWallAmount, crystal.explosiveWallAmount);
			cmd.SetGlobalFloat(_Passage_ResourceCount, passage.ResourceCount);
			cmd.SetGlobalVector(_Passage_ResourceDistribution, passage.resourceDistribution);
			cmd.SetGlobalFloat(_Passage_ResourceThreshold, passage.resourceThreshold);
			cmd.SetGlobalFloat(_Passage_RiverSize, passage.riverSize);
			cmd.SetGlobalFloat(_Passage_RiverAmount, passage.riverAmount);
			cmd.SetGlobalFloat(_Passage_LakeThreshold, passage.lakeThreshold);
			cmd.SetGlobalFloat(_Passage_ChamberThreshold, passage.chamberThreshold);
			cmd.SetGlobalFloat(_Passage_ScatteredWallThreshold, passage.scatteredWallThreshold);
			cmd.SetGlobalFloat(_Passage_CeilingHoleThreshold, passage.ceilingHoleThreshold);
			cmd.SetGlobalFloat(_Passage_TunnelThreshold, passage.tunnelThreshold);
			cmd.SetGlobalFloat(_Passage_TunnelAmount, passage.tunnelAmount);
			cmd.SetGlobalFloat(_Passage_SandThreshold, passage.sandThreshold);
			cmd.SetGlobalFloat(_Passage_SandAmount, passage.sandAmount);
			cmd.SetGlobalVector(_Passage_PitThreshold, passage.pitThreshold);
			cmd.SetGlobalFloat(_Passage_BiomeEdgePitSize, passage.biomeEdgePitSize);
			cmd.SetGlobalFloat(_Passage_BiomeEdgePitLedgeSize, passage.biomeEdgePitLedgeSize);
			cmd.SetGlobalFloat(_Passage_BiomeSubTileTreshold, passage.biomeSubTileTreshold);
			cmd.SetGlobalFloat(_Passage_ExplosiveWallAmount, passage.explosiveWallAmount);
			cmd.SetGlobalFloat(_Excavation_ResourceCount, excavation.ResourceCount);
			cmd.SetGlobalVector(_Excavation_ResourceDistribution, excavation.resourceDistribution);
			cmd.SetGlobalFloat(_Excavation_ResourceThreshold, excavation.resourceThreshold);
			cmd.SetGlobalFloat(_Excavation_RiverSize, excavation.riverSize);
			cmd.SetGlobalFloat(_Excavation_RiverAmount, excavation.riverAmount);
			cmd.SetGlobalFloat(_Excavation_LakeThreshold, excavation.lakeThreshold);
			cmd.SetGlobalFloat(_Excavation_ChamberThreshold, excavation.chamberThreshold);
			cmd.SetGlobalFloat(_Excavation_ScatteredWallThreshold, excavation.scatteredWallThreshold);
			cmd.SetGlobalFloat(_Excavation_CeilingHoleThreshold, excavation.ceilingHoleThreshold);
			cmd.SetGlobalFloat(_Excavation_TunnelThreshold, excavation.tunnelThreshold);
			cmd.SetGlobalFloat(_Excavation_TunnelAmount, excavation.tunnelAmount);
			cmd.SetGlobalFloat(_Excavation_SandThreshold, excavation.sandThreshold);
			cmd.SetGlobalFloat(_Excavation_SandAmount, excavation.sandAmount);
			cmd.SetGlobalVector(_Excavation_PitThreshold, excavation.pitThreshold);
			cmd.SetGlobalFloat(_Excavation_BiomeEdgePitSize, excavation.biomeEdgePitSize);
			cmd.SetGlobalFloat(_Excavation_BiomeEdgePitLedgeSize, excavation.biomeEdgePitLedgeSize);
			cmd.SetGlobalFloat(_Excavation_BiomeSubTileTreshold, excavation.biomeSubTileTreshold);
			cmd.SetGlobalFloat(_Excavation_ExplosiveWallAmount, excavation.explosiveWallAmount);
		}

		public override void SetShaderProperties(Material material)
		{
			material.SetFloat(_GlobalSeed, globalSeed);
			material.SetFloat(_WorldScale, worldScale);
			material.SetFloat(_BiomeChaos, biomeChaos);
			material.SetFloat(_Ring1Size, ring1Size);
			material.SetFloat(_Ring2Size, ring2Size);
			material.SetFloat(_Ring3Size, ring3Size);
			material.SetFloat(_Ring4Size, ring4Size);
			material.SetFloat(_Ring1Chaos, ring1Chaos);
			material.SetFloat(_Ring2Chaos, ring2Chaos);
			material.SetFloat(_Ring3Chaos, ring3Chaos);
			material.SetFloat(_Ring4Chaos, ring4Chaos);
			material.SetFloat(_NorthBlobRadius, northBlobRadius);
			material.SetFloat(_Dirt_ResourceCount, dirt.ResourceCount);
			material.SetVector(_Dirt_ResourceDistribution, dirt.resourceDistribution);
			material.SetFloat(_Dirt_ResourceThreshold, dirt.resourceThreshold);
			material.SetFloat(_Dirt_RiverSize, dirt.riverSize);
			material.SetFloat(_Dirt_RiverAmount, dirt.riverAmount);
			material.SetFloat(_Dirt_LakeThreshold, dirt.lakeThreshold);
			material.SetFloat(_Dirt_ChamberThreshold, dirt.chamberThreshold);
			material.SetFloat(_Dirt_ScatteredWallThreshold, dirt.scatteredWallThreshold);
			material.SetFloat(_Dirt_CeilingHoleThreshold, dirt.ceilingHoleThreshold);
			material.SetFloat(_Dirt_TunnelThreshold, dirt.tunnelThreshold);
			material.SetFloat(_Dirt_TunnelAmount, dirt.tunnelAmount);
			material.SetFloat(_Dirt_SandThreshold, dirt.sandThreshold);
			material.SetFloat(_Dirt_SandAmount, dirt.sandAmount);
			material.SetVector(_Dirt_PitThreshold, dirt.pitThreshold);
			material.SetFloat(_Dirt_BiomeEdgePitSize, dirt.biomeEdgePitSize);
			material.SetFloat(_Dirt_BiomeEdgePitLedgeSize, dirt.biomeEdgePitLedgeSize);
			material.SetFloat(_Dirt_BiomeSubTileTreshold, dirt.biomeSubTileTreshold);
			material.SetFloat(_Dirt_ExplosiveWallAmount, dirt.explosiveWallAmount);
			material.SetFloat(_Clay_ResourceCount, clay.ResourceCount);
			material.SetVector(_Clay_ResourceDistribution, clay.resourceDistribution);
			material.SetFloat(_Clay_ResourceThreshold, clay.resourceThreshold);
			material.SetFloat(_Clay_RiverSize, clay.riverSize);
			material.SetFloat(_Clay_RiverAmount, clay.riverAmount);
			material.SetFloat(_Clay_LakeThreshold, clay.lakeThreshold);
			material.SetFloat(_Clay_ChamberThreshold, clay.chamberThreshold);
			material.SetFloat(_Clay_ScatteredWallThreshold, clay.scatteredWallThreshold);
			material.SetFloat(_Clay_CeilingHoleThreshold, clay.ceilingHoleThreshold);
			material.SetFloat(_Clay_TunnelThreshold, clay.tunnelThreshold);
			material.SetFloat(_Clay_TunnelAmount, clay.tunnelAmount);
			material.SetFloat(_Clay_SandThreshold, clay.sandThreshold);
			material.SetFloat(_Clay_SandAmount, clay.sandAmount);
			material.SetVector(_Clay_PitThreshold, clay.pitThreshold);
			material.SetFloat(_Clay_BiomeEdgePitSize, clay.biomeEdgePitSize);
			material.SetFloat(_Clay_BiomeEdgePitLedgeSize, clay.biomeEdgePitLedgeSize);
			material.SetFloat(_Clay_BiomeSubTileTreshold, clay.biomeSubTileTreshold);
			material.SetFloat(_Clay_ExplosiveWallAmount, clay.explosiveWallAmount);
			material.SetFloat(_Stone_ResourceCount, stone.ResourceCount);
			material.SetVector(_Stone_ResourceDistribution, stone.resourceDistribution);
			material.SetFloat(_Stone_ResourceThreshold, stone.resourceThreshold);
			material.SetFloat(_Stone_RiverSize, stone.riverSize);
			material.SetFloat(_Stone_RiverAmount, stone.riverAmount);
			material.SetFloat(_Stone_LakeThreshold, stone.lakeThreshold);
			material.SetFloat(_Stone_ChamberThreshold, stone.chamberThreshold);
			material.SetFloat(_Stone_ScatteredWallThreshold, stone.scatteredWallThreshold);
			material.SetFloat(_Stone_CeilingHoleThreshold, stone.ceilingHoleThreshold);
			material.SetFloat(_Stone_TunnelThreshold, stone.tunnelThreshold);
			material.SetFloat(_Stone_TunnelAmount, stone.tunnelAmount);
			material.SetFloat(_Stone_SandThreshold, stone.sandThreshold);
			material.SetFloat(_Stone_SandAmount, stone.sandAmount);
			material.SetVector(_Stone_PitThreshold, stone.pitThreshold);
			material.SetFloat(_Stone_BiomeEdgePitSize, stone.biomeEdgePitSize);
			material.SetFloat(_Stone_BiomeEdgePitLedgeSize, stone.biomeEdgePitLedgeSize);
			material.SetFloat(_Stone_BiomeSubTileTreshold, stone.biomeSubTileTreshold);
			material.SetFloat(_Stone_ExplosiveWallAmount, stone.explosiveWallAmount);
			material.SetFloat(_Forest_ResourceCount, forest.ResourceCount);
			material.SetVector(_Forest_ResourceDistribution, forest.resourceDistribution);
			material.SetFloat(_Forest_ResourceThreshold, forest.resourceThreshold);
			material.SetFloat(_Forest_RiverSize, forest.riverSize);
			material.SetFloat(_Forest_RiverAmount, forest.riverAmount);
			material.SetFloat(_Forest_LakeThreshold, forest.lakeThreshold);
			material.SetFloat(_Forest_ChamberThreshold, forest.chamberThreshold);
			material.SetFloat(_Forest_ScatteredWallThreshold, forest.scatteredWallThreshold);
			material.SetFloat(_Forest_CeilingHoleThreshold, forest.ceilingHoleThreshold);
			material.SetFloat(_Forest_TunnelThreshold, forest.tunnelThreshold);
			material.SetFloat(_Forest_TunnelAmount, forest.tunnelAmount);
			material.SetFloat(_Forest_SandThreshold, forest.sandThreshold);
			material.SetFloat(_Forest_SandAmount, forest.sandAmount);
			material.SetVector(_Forest_PitThreshold, forest.pitThreshold);
			material.SetFloat(_Forest_BiomeEdgePitSize, forest.biomeEdgePitSize);
			material.SetFloat(_Forest_BiomeEdgePitLedgeSize, forest.biomeEdgePitLedgeSize);
			material.SetFloat(_Forest_BiomeSubTileTreshold, forest.biomeSubTileTreshold);
			material.SetFloat(_Forest_ExplosiveWallAmount, forest.explosiveWallAmount);
			material.SetFloat(_Desert_ResourceCount, desert.ResourceCount);
			material.SetVector(_Desert_ResourceDistribution, desert.resourceDistribution);
			material.SetFloat(_Desert_ResourceThreshold, desert.resourceThreshold);
			material.SetFloat(_Desert_RiverSize, desert.riverSize);
			material.SetFloat(_Desert_RiverAmount, desert.riverAmount);
			material.SetFloat(_Desert_LakeThreshold, desert.lakeThreshold);
			material.SetFloat(_Desert_ChamberThreshold, desert.chamberThreshold);
			material.SetFloat(_Desert_ScatteredWallThreshold, desert.scatteredWallThreshold);
			material.SetFloat(_Desert_CeilingHoleThreshold, desert.ceilingHoleThreshold);
			material.SetFloat(_Desert_TunnelThreshold, desert.tunnelThreshold);
			material.SetFloat(_Desert_TunnelAmount, desert.tunnelAmount);
			material.SetFloat(_Desert_SandThreshold, desert.sandThreshold);
			material.SetFloat(_Desert_SandAmount, desert.sandAmount);
			material.SetVector(_Desert_PitThreshold, desert.pitThreshold);
			material.SetFloat(_Desert_BiomeEdgePitSize, desert.biomeEdgePitSize);
			material.SetFloat(_Desert_BiomeEdgePitLedgeSize, desert.biomeEdgePitLedgeSize);
			material.SetFloat(_Desert_BiomeSubTileTreshold, desert.biomeSubTileTreshold);
			material.SetFloat(_Desert_ExplosiveWallAmount, desert.explosiveWallAmount);
			material.SetFloat(_Sea_ResourceCount, sea.ResourceCount);
			material.SetVector(_Sea_ResourceDistribution, sea.resourceDistribution);
			material.SetFloat(_Sea_ResourceThreshold, sea.resourceThreshold);
			material.SetFloat(_Sea_RiverSize, sea.riverSize);
			material.SetFloat(_Sea_RiverAmount, sea.riverAmount);
			material.SetFloat(_Sea_LakeThreshold, sea.lakeThreshold);
			material.SetFloat(_Sea_ChamberThreshold, sea.chamberThreshold);
			material.SetFloat(_Sea_ScatteredWallThreshold, sea.scatteredWallThreshold);
			material.SetFloat(_Sea_CeilingHoleThreshold, sea.ceilingHoleThreshold);
			material.SetFloat(_Sea_TunnelThreshold, sea.tunnelThreshold);
			material.SetFloat(_Sea_TunnelAmount, sea.tunnelAmount);
			material.SetFloat(_Sea_SandThreshold, sea.sandThreshold);
			material.SetFloat(_Sea_SandAmount, sea.sandAmount);
			material.SetVector(_Sea_PitThreshold, sea.pitThreshold);
			material.SetFloat(_Sea_BiomeEdgePitSize, sea.biomeEdgePitSize);
			material.SetFloat(_Sea_BiomeEdgePitLedgeSize, sea.biomeEdgePitLedgeSize);
			material.SetFloat(_Sea_BiomeSubTileTreshold, sea.biomeSubTileTreshold);
			material.SetFloat(_Sea_ExplosiveWallAmount, sea.explosiveWallAmount);
			material.SetFloat(_Crystal_ResourceCount, crystal.ResourceCount);
			material.SetVector(_Crystal_ResourceDistribution, crystal.resourceDistribution);
			material.SetFloat(_Crystal_ResourceThreshold, crystal.resourceThreshold);
			material.SetFloat(_Crystal_RiverSize, crystal.riverSize);
			material.SetFloat(_Crystal_RiverAmount, crystal.riverAmount);
			material.SetFloat(_Crystal_LakeThreshold, crystal.lakeThreshold);
			material.SetFloat(_Crystal_ChamberThreshold, crystal.chamberThreshold);
			material.SetFloat(_Crystal_ScatteredWallThreshold, crystal.scatteredWallThreshold);
			material.SetFloat(_Crystal_CeilingHoleThreshold, crystal.ceilingHoleThreshold);
			material.SetFloat(_Crystal_TunnelThreshold, crystal.tunnelThreshold);
			material.SetFloat(_Crystal_TunnelAmount, crystal.tunnelAmount);
			material.SetFloat(_Crystal_SandThreshold, crystal.sandThreshold);
			material.SetFloat(_Crystal_SandAmount, crystal.sandAmount);
			material.SetVector(_Crystal_PitThreshold, crystal.pitThreshold);
			material.SetFloat(_Crystal_BiomeEdgePitSize, crystal.biomeEdgePitSize);
			material.SetFloat(_Crystal_BiomeEdgePitLedgeSize, crystal.biomeEdgePitLedgeSize);
			material.SetFloat(_Crystal_BiomeSubTileTreshold, crystal.biomeSubTileTreshold);
			material.SetFloat(_Crystal_ExplosiveWallAmount, crystal.explosiveWallAmount);
			material.SetFloat(_Passage_ResourceCount, passage.ResourceCount);
			material.SetVector(_Passage_ResourceDistribution, passage.resourceDistribution);
			material.SetFloat(_Passage_ResourceThreshold, passage.resourceThreshold);
			material.SetFloat(_Passage_RiverSize, passage.riverSize);
			material.SetFloat(_Passage_RiverAmount, passage.riverAmount);
			material.SetFloat(_Passage_LakeThreshold, passage.lakeThreshold);
			material.SetFloat(_Passage_ChamberThreshold, passage.chamberThreshold);
			material.SetFloat(_Passage_ScatteredWallThreshold, passage.scatteredWallThreshold);
			material.SetFloat(_Passage_CeilingHoleThreshold, passage.ceilingHoleThreshold);
			material.SetFloat(_Passage_TunnelThreshold, passage.tunnelThreshold);
			material.SetFloat(_Passage_TunnelAmount, passage.tunnelAmount);
			material.SetFloat(_Passage_SandThreshold, passage.sandThreshold);
			material.SetFloat(_Passage_SandAmount, passage.sandAmount);
			material.SetVector(_Passage_PitThreshold, passage.pitThreshold);
			material.SetFloat(_Passage_BiomeEdgePitSize, passage.biomeEdgePitSize);
			material.SetFloat(_Passage_BiomeEdgePitLedgeSize, passage.biomeEdgePitLedgeSize);
			material.SetFloat(_Passage_BiomeSubTileTreshold, passage.biomeSubTileTreshold);
			material.SetFloat(_Passage_ExplosiveWallAmount, passage.explosiveWallAmount);
			material.SetFloat(_Excavation_ResourceCount, excavation.ResourceCount);
			material.SetVector(_Excavation_ResourceDistribution, excavation.resourceDistribution);
			material.SetFloat(_Excavation_ResourceThreshold, excavation.resourceThreshold);
			material.SetFloat(_Excavation_RiverSize, excavation.riverSize);
			material.SetFloat(_Excavation_RiverAmount, excavation.riverAmount);
			material.SetFloat(_Excavation_LakeThreshold, excavation.lakeThreshold);
			material.SetFloat(_Excavation_ChamberThreshold, excavation.chamberThreshold);
			material.SetFloat(_Excavation_ScatteredWallThreshold, excavation.scatteredWallThreshold);
			material.SetFloat(_Excavation_CeilingHoleThreshold, excavation.ceilingHoleThreshold);
			material.SetFloat(_Excavation_TunnelThreshold, excavation.tunnelThreshold);
			material.SetFloat(_Excavation_TunnelAmount, excavation.tunnelAmount);
			material.SetFloat(_Excavation_SandThreshold, excavation.sandThreshold);
			material.SetFloat(_Excavation_SandAmount, excavation.sandAmount);
			material.SetVector(_Excavation_PitThreshold, excavation.pitThreshold);
			material.SetFloat(_Excavation_BiomeEdgePitSize, excavation.biomeEdgePitSize);
			material.SetFloat(_Excavation_BiomeEdgePitLedgeSize, excavation.biomeEdgePitLedgeSize);
			material.SetFloat(_Excavation_BiomeSubTileTreshold, excavation.biomeSubTileTreshold);
			material.SetFloat(_Excavation_ExplosiveWallAmount, excavation.explosiveWallAmount);
		}

		public override void SetShaderProperties(ComputeShader computeShader)
		{
			computeShader.SetFloat(_GlobalSeed, globalSeed);
			computeShader.SetFloat(_WorldScale, worldScale);
			computeShader.SetFloat(_BiomeChaos, biomeChaos);
			computeShader.SetFloat(_Ring1Size, ring1Size);
			computeShader.SetFloat(_Ring2Size, ring2Size);
			computeShader.SetFloat(_Ring3Size, ring3Size);
			computeShader.SetFloat(_Ring4Size, ring4Size);
			computeShader.SetFloat(_Ring1Chaos, ring1Chaos);
			computeShader.SetFloat(_Ring2Chaos, ring2Chaos);
			computeShader.SetFloat(_Ring3Chaos, ring3Chaos);
			computeShader.SetFloat(_Ring4Chaos, ring4Chaos);
			computeShader.SetFloat(_NorthBlobRadius, northBlobRadius);
			computeShader.SetFloat(_Dirt_ResourceCount, dirt.ResourceCount);
			computeShader.SetVector(_Dirt_ResourceDistribution, dirt.resourceDistribution);
			computeShader.SetFloat(_Dirt_ResourceThreshold, dirt.resourceThreshold);
			computeShader.SetFloat(_Dirt_RiverSize, dirt.riverSize);
			computeShader.SetFloat(_Dirt_RiverAmount, dirt.riverAmount);
			computeShader.SetFloat(_Dirt_LakeThreshold, dirt.lakeThreshold);
			computeShader.SetFloat(_Dirt_ChamberThreshold, dirt.chamberThreshold);
			computeShader.SetFloat(_Dirt_ScatteredWallThreshold, dirt.scatteredWallThreshold);
			computeShader.SetFloat(_Dirt_CeilingHoleThreshold, dirt.ceilingHoleThreshold);
			computeShader.SetFloat(_Dirt_TunnelThreshold, dirt.tunnelThreshold);
			computeShader.SetFloat(_Dirt_TunnelAmount, dirt.tunnelAmount);
			computeShader.SetFloat(_Dirt_SandThreshold, dirt.sandThreshold);
			computeShader.SetFloat(_Dirt_SandAmount, dirt.sandAmount);
			computeShader.SetVector(_Dirt_PitThreshold, dirt.pitThreshold);
			computeShader.SetFloat(_Dirt_BiomeEdgePitSize, dirt.biomeEdgePitSize);
			computeShader.SetFloat(_Dirt_BiomeEdgePitLedgeSize, dirt.biomeEdgePitLedgeSize);
			computeShader.SetFloat(_Dirt_BiomeSubTileTreshold, dirt.biomeSubTileTreshold);
			computeShader.SetFloat(_Dirt_ExplosiveWallAmount, dirt.explosiveWallAmount);
			computeShader.SetFloat(_Clay_ResourceCount, clay.ResourceCount);
			computeShader.SetVector(_Clay_ResourceDistribution, clay.resourceDistribution);
			computeShader.SetFloat(_Clay_ResourceThreshold, clay.resourceThreshold);
			computeShader.SetFloat(_Clay_RiverSize, clay.riverSize);
			computeShader.SetFloat(_Clay_RiverAmount, clay.riverAmount);
			computeShader.SetFloat(_Clay_LakeThreshold, clay.lakeThreshold);
			computeShader.SetFloat(_Clay_ChamberThreshold, clay.chamberThreshold);
			computeShader.SetFloat(_Clay_ScatteredWallThreshold, clay.scatteredWallThreshold);
			computeShader.SetFloat(_Clay_CeilingHoleThreshold, clay.ceilingHoleThreshold);
			computeShader.SetFloat(_Clay_TunnelThreshold, clay.tunnelThreshold);
			computeShader.SetFloat(_Clay_TunnelAmount, clay.tunnelAmount);
			computeShader.SetFloat(_Clay_SandThreshold, clay.sandThreshold);
			computeShader.SetFloat(_Clay_SandAmount, clay.sandAmount);
			computeShader.SetVector(_Clay_PitThreshold, clay.pitThreshold);
			computeShader.SetFloat(_Clay_BiomeEdgePitSize, clay.biomeEdgePitSize);
			computeShader.SetFloat(_Clay_BiomeEdgePitLedgeSize, clay.biomeEdgePitLedgeSize);
			computeShader.SetFloat(_Clay_BiomeSubTileTreshold, clay.biomeSubTileTreshold);
			computeShader.SetFloat(_Clay_ExplosiveWallAmount, clay.explosiveWallAmount);
			computeShader.SetFloat(_Stone_ResourceCount, stone.ResourceCount);
			computeShader.SetVector(_Stone_ResourceDistribution, stone.resourceDistribution);
			computeShader.SetFloat(_Stone_ResourceThreshold, stone.resourceThreshold);
			computeShader.SetFloat(_Stone_RiverSize, stone.riverSize);
			computeShader.SetFloat(_Stone_RiverAmount, stone.riverAmount);
			computeShader.SetFloat(_Stone_LakeThreshold, stone.lakeThreshold);
			computeShader.SetFloat(_Stone_ChamberThreshold, stone.chamberThreshold);
			computeShader.SetFloat(_Stone_ScatteredWallThreshold, stone.scatteredWallThreshold);
			computeShader.SetFloat(_Stone_CeilingHoleThreshold, stone.ceilingHoleThreshold);
			computeShader.SetFloat(_Stone_TunnelThreshold, stone.tunnelThreshold);
			computeShader.SetFloat(_Stone_TunnelAmount, stone.tunnelAmount);
			computeShader.SetFloat(_Stone_SandThreshold, stone.sandThreshold);
			computeShader.SetFloat(_Stone_SandAmount, stone.sandAmount);
			computeShader.SetVector(_Stone_PitThreshold, stone.pitThreshold);
			computeShader.SetFloat(_Stone_BiomeEdgePitSize, stone.biomeEdgePitSize);
			computeShader.SetFloat(_Stone_BiomeEdgePitLedgeSize, stone.biomeEdgePitLedgeSize);
			computeShader.SetFloat(_Stone_BiomeSubTileTreshold, stone.biomeSubTileTreshold);
			computeShader.SetFloat(_Stone_ExplosiveWallAmount, stone.explosiveWallAmount);
			computeShader.SetFloat(_Forest_ResourceCount, forest.ResourceCount);
			computeShader.SetVector(_Forest_ResourceDistribution, forest.resourceDistribution);
			computeShader.SetFloat(_Forest_ResourceThreshold, forest.resourceThreshold);
			computeShader.SetFloat(_Forest_RiverSize, forest.riverSize);
			computeShader.SetFloat(_Forest_RiverAmount, forest.riverAmount);
			computeShader.SetFloat(_Forest_LakeThreshold, forest.lakeThreshold);
			computeShader.SetFloat(_Forest_ChamberThreshold, forest.chamberThreshold);
			computeShader.SetFloat(_Forest_ScatteredWallThreshold, forest.scatteredWallThreshold);
			computeShader.SetFloat(_Forest_CeilingHoleThreshold, forest.ceilingHoleThreshold);
			computeShader.SetFloat(_Forest_TunnelThreshold, forest.tunnelThreshold);
			computeShader.SetFloat(_Forest_TunnelAmount, forest.tunnelAmount);
			computeShader.SetFloat(_Forest_SandThreshold, forest.sandThreshold);
			computeShader.SetFloat(_Forest_SandAmount, forest.sandAmount);
			computeShader.SetVector(_Forest_PitThreshold, forest.pitThreshold);
			computeShader.SetFloat(_Forest_BiomeEdgePitSize, forest.biomeEdgePitSize);
			computeShader.SetFloat(_Forest_BiomeEdgePitLedgeSize, forest.biomeEdgePitLedgeSize);
			computeShader.SetFloat(_Forest_BiomeSubTileTreshold, forest.biomeSubTileTreshold);
			computeShader.SetFloat(_Forest_ExplosiveWallAmount, forest.explosiveWallAmount);
			computeShader.SetFloat(_Desert_ResourceCount, desert.ResourceCount);
			computeShader.SetVector(_Desert_ResourceDistribution, desert.resourceDistribution);
			computeShader.SetFloat(_Desert_ResourceThreshold, desert.resourceThreshold);
			computeShader.SetFloat(_Desert_RiverSize, desert.riverSize);
			computeShader.SetFloat(_Desert_RiverAmount, desert.riverAmount);
			computeShader.SetFloat(_Desert_LakeThreshold, desert.lakeThreshold);
			computeShader.SetFloat(_Desert_ChamberThreshold, desert.chamberThreshold);
			computeShader.SetFloat(_Desert_ScatteredWallThreshold, desert.scatteredWallThreshold);
			computeShader.SetFloat(_Desert_CeilingHoleThreshold, desert.ceilingHoleThreshold);
			computeShader.SetFloat(_Desert_TunnelThreshold, desert.tunnelThreshold);
			computeShader.SetFloat(_Desert_TunnelAmount, desert.tunnelAmount);
			computeShader.SetFloat(_Desert_SandThreshold, desert.sandThreshold);
			computeShader.SetFloat(_Desert_SandAmount, desert.sandAmount);
			computeShader.SetVector(_Desert_PitThreshold, desert.pitThreshold);
			computeShader.SetFloat(_Desert_BiomeEdgePitSize, desert.biomeEdgePitSize);
			computeShader.SetFloat(_Desert_BiomeEdgePitLedgeSize, desert.biomeEdgePitLedgeSize);
			computeShader.SetFloat(_Desert_BiomeSubTileTreshold, desert.biomeSubTileTreshold);
			computeShader.SetFloat(_Desert_ExplosiveWallAmount, desert.explosiveWallAmount);
			computeShader.SetFloat(_Sea_ResourceCount, sea.ResourceCount);
			computeShader.SetVector(_Sea_ResourceDistribution, sea.resourceDistribution);
			computeShader.SetFloat(_Sea_ResourceThreshold, sea.resourceThreshold);
			computeShader.SetFloat(_Sea_RiverSize, sea.riverSize);
			computeShader.SetFloat(_Sea_RiverAmount, sea.riverAmount);
			computeShader.SetFloat(_Sea_LakeThreshold, sea.lakeThreshold);
			computeShader.SetFloat(_Sea_ChamberThreshold, sea.chamberThreshold);
			computeShader.SetFloat(_Sea_ScatteredWallThreshold, sea.scatteredWallThreshold);
			computeShader.SetFloat(_Sea_CeilingHoleThreshold, sea.ceilingHoleThreshold);
			computeShader.SetFloat(_Sea_TunnelThreshold, sea.tunnelThreshold);
			computeShader.SetFloat(_Sea_TunnelAmount, sea.tunnelAmount);
			computeShader.SetFloat(_Sea_SandThreshold, sea.sandThreshold);
			computeShader.SetFloat(_Sea_SandAmount, sea.sandAmount);
			computeShader.SetVector(_Sea_PitThreshold, sea.pitThreshold);
			computeShader.SetFloat(_Sea_BiomeEdgePitSize, sea.biomeEdgePitSize);
			computeShader.SetFloat(_Sea_BiomeEdgePitLedgeSize, sea.biomeEdgePitLedgeSize);
			computeShader.SetFloat(_Sea_BiomeSubTileTreshold, sea.biomeSubTileTreshold);
			computeShader.SetFloat(_Sea_ExplosiveWallAmount, sea.explosiveWallAmount);
			computeShader.SetFloat(_Crystal_ResourceCount, crystal.ResourceCount);
			computeShader.SetVector(_Crystal_ResourceDistribution, crystal.resourceDistribution);
			computeShader.SetFloat(_Crystal_ResourceThreshold, crystal.resourceThreshold);
			computeShader.SetFloat(_Crystal_RiverSize, crystal.riverSize);
			computeShader.SetFloat(_Crystal_RiverAmount, crystal.riverAmount);
			computeShader.SetFloat(_Crystal_LakeThreshold, crystal.lakeThreshold);
			computeShader.SetFloat(_Crystal_ChamberThreshold, crystal.chamberThreshold);
			computeShader.SetFloat(_Crystal_ScatteredWallThreshold, crystal.scatteredWallThreshold);
			computeShader.SetFloat(_Crystal_CeilingHoleThreshold, crystal.ceilingHoleThreshold);
			computeShader.SetFloat(_Crystal_TunnelThreshold, crystal.tunnelThreshold);
			computeShader.SetFloat(_Crystal_TunnelAmount, crystal.tunnelAmount);
			computeShader.SetFloat(_Crystal_SandThreshold, crystal.sandThreshold);
			computeShader.SetFloat(_Crystal_SandAmount, crystal.sandAmount);
			computeShader.SetVector(_Crystal_PitThreshold, crystal.pitThreshold);
			computeShader.SetFloat(_Crystal_BiomeEdgePitSize, crystal.biomeEdgePitSize);
			computeShader.SetFloat(_Crystal_BiomeEdgePitLedgeSize, crystal.biomeEdgePitLedgeSize);
			computeShader.SetFloat(_Crystal_BiomeSubTileTreshold, crystal.biomeSubTileTreshold);
			computeShader.SetFloat(_Crystal_ExplosiveWallAmount, crystal.explosiveWallAmount);
			computeShader.SetFloat(_Passage_ResourceCount, passage.ResourceCount);
			computeShader.SetVector(_Passage_ResourceDistribution, passage.resourceDistribution);
			computeShader.SetFloat(_Passage_ResourceThreshold, passage.resourceThreshold);
			computeShader.SetFloat(_Passage_RiverSize, passage.riverSize);
			computeShader.SetFloat(_Passage_RiverAmount, passage.riverAmount);
			computeShader.SetFloat(_Passage_LakeThreshold, passage.lakeThreshold);
			computeShader.SetFloat(_Passage_ChamberThreshold, passage.chamberThreshold);
			computeShader.SetFloat(_Passage_ScatteredWallThreshold, passage.scatteredWallThreshold);
			computeShader.SetFloat(_Passage_CeilingHoleThreshold, passage.ceilingHoleThreshold);
			computeShader.SetFloat(_Passage_TunnelThreshold, passage.tunnelThreshold);
			computeShader.SetFloat(_Passage_TunnelAmount, passage.tunnelAmount);
			computeShader.SetFloat(_Passage_SandThreshold, passage.sandThreshold);
			computeShader.SetFloat(_Passage_SandAmount, passage.sandAmount);
			computeShader.SetVector(_Passage_PitThreshold, passage.pitThreshold);
			computeShader.SetFloat(_Passage_BiomeEdgePitSize, passage.biomeEdgePitSize);
			computeShader.SetFloat(_Passage_BiomeEdgePitLedgeSize, passage.biomeEdgePitLedgeSize);
			computeShader.SetFloat(_Passage_BiomeSubTileTreshold, passage.biomeSubTileTreshold);
			computeShader.SetFloat(_Passage_ExplosiveWallAmount, passage.explosiveWallAmount);
			computeShader.SetFloat(_Excavation_ResourceCount, excavation.ResourceCount);
			computeShader.SetVector(_Excavation_ResourceDistribution, excavation.resourceDistribution);
			computeShader.SetFloat(_Excavation_ResourceThreshold, excavation.resourceThreshold);
			computeShader.SetFloat(_Excavation_RiverSize, excavation.riverSize);
			computeShader.SetFloat(_Excavation_RiverAmount, excavation.riverAmount);
			computeShader.SetFloat(_Excavation_LakeThreshold, excavation.lakeThreshold);
			computeShader.SetFloat(_Excavation_ChamberThreshold, excavation.chamberThreshold);
			computeShader.SetFloat(_Excavation_ScatteredWallThreshold, excavation.scatteredWallThreshold);
			computeShader.SetFloat(_Excavation_CeilingHoleThreshold, excavation.ceilingHoleThreshold);
			computeShader.SetFloat(_Excavation_TunnelThreshold, excavation.tunnelThreshold);
			computeShader.SetFloat(_Excavation_TunnelAmount, excavation.tunnelAmount);
			computeShader.SetFloat(_Excavation_SandThreshold, excavation.sandThreshold);
			computeShader.SetFloat(_Excavation_SandAmount, excavation.sandAmount);
			computeShader.SetVector(_Excavation_PitThreshold, excavation.pitThreshold);
			computeShader.SetFloat(_Excavation_BiomeEdgePitSize, excavation.biomeEdgePitSize);
			computeShader.SetFloat(_Excavation_BiomeEdgePitLedgeSize, excavation.biomeEdgePitLedgeSize);
			computeShader.SetFloat(_Excavation_BiomeSubTileTreshold, excavation.biomeSubTileTreshold);
			computeShader.SetFloat(_Excavation_ExplosiveWallAmount, excavation.explosiveWallAmount);
		}
	}
}
