using System;
using System.Collections.Generic;
using NSEipix.Model;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class FishMapResource : MapResource
	{
		[SerializeField]
		private List<ResourceInstance> storedResources;

		[SerializeField]
		private int fishingCount;

		[SerializeField]
		private float fishSpawnTemperatureMin;

		[SerializeField]
		private float fishSpawnTemperatureMax;

		[SerializeField]
		private float chanceToFail;

		[SerializeField]
		private int lifespan;

		[SerializeField]
		private IntRange lifespanRandomRange;

		[SerializeField]
		private float newFishTemperatureLimit;

		[SerializeField]
		private float newFishPerDay;

		[SerializeField]
		private int neighborCheck;

		[SerializeField]
		private bool canSpawnOnZeroCount = true;

		[SerializeField]
		private int maxCount;

		[SerializeField]
		private float placeAnywhereChance = 0.3f;

		public List<ResourceInstance> StoredResources => storedResources;

		public int FishingCount => fishingCount;

		public float ChanceToFail => chanceToFail;

		public int Lifespan => lifespan;

		public IntRange LifespanRandomRange => lifespanRandomRange;

		public float NewFishTemperatureLimit => newFishTemperatureLimit;

		public float NewFishPerDay => newFishPerDay;

		public int NeighborCheck => neighborCheck;

		public bool CanSpawnOnZeroCount => canSpawnOnZeroCount;

		public int MaxCount => maxCount;

		public float PlaceAnywhereChance => placeAnywhereChance;

		public override HarvestParametars GetMiningParameters()
		{
			if (base.MiningParameters == null)
			{
				base.MiningParameters = new HarvestParametars(base.MiningDuration, AttributeType.FishingSpeed, AttributeType.FishingYield, AttributeType.FishingFailed, SkillType.AnimalHandling, 50f, base.MiningTool);
			}
			return base.MiningParameters;
		}
	}
}
