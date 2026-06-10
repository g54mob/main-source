using System;
using System.Collections.Generic;
using NSMedieval.Construction;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class DigMarkerResource : MapResource
	{
		[SerializeField]
		private List<ResourceInstance> storedResources;

		[SerializeField]
		private OrderType orderType;

		[SerializeField]
		private float baseHealth;

		[SerializeField]
		private bool autoRemoveOnCancelOrder;

		[SerializeField]
		private ReachableLevel reachableLevel;

		[SerializeField]
		private bool updateReachablePositionAfterDig = true;

		[SerializeField]
		private string destroyParticles;

		public List<ResourceInstance> StoredResources => storedResources;

		public OrderType OrderTypes => orderType;

		public float BaseHealth => baseHealth;

		public bool AutoRemoveOnCancelOrder => autoRemoveOnCancelOrder;

		public OrderType AutoStartOrder => OrderType.Digging;

		public ReachableLevel ReachableLevel => reachableLevel;

		public bool UpdateReachablePositionAfterDig => updateReachablePositionAfterDig;

		public string DestroyParticles => destroyParticles;

		public override HarvestParametars GetMiningParameters()
		{
			if (base.MiningParameters == null)
			{
				base.MiningParameters = new HarvestParametars(base.MiningDuration, AttributeType.MineSpeed, AttributeType.MineAmount, AttributeType.MineFail, SkillType.Mining, 50f, base.MiningTool);
			}
			return base.MiningParameters;
		}
	}
}
