using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.UI
{
	public class TradeResource
	{
		[SerializeField]
		private Resource resource;

		[SerializeField]
		private float health;

		[SerializeField]
		private int count;

		[SerializeField]
		private CreatureBase creature;

		[SerializeField]
		private bool constantWealthPoints;

		[SerializeField]
		private readonly bool isForbidden;

		[SerializeField]
		private readonly TradeForbiddenReason forbiddenReason;

		public bool IsCreature => creature != null;

		public bool IsItem
		{
			get
			{
				if (!IsCreature && resource != null)
				{
					return ResourceUtils.IsItem(resource);
				}
				return false;
			}
		}

		public Resource Resource => resource;

		public float Health => health;

		public int Count => count;

		public bool IsForbidden => isForbidden;

		public TradeForbiddenReason ForbiddenReason => forbiddenReason;

		public float Weight
		{
			get
			{
				if (IsCreature)
				{
					return 0f;
				}
				return resource.Weight;
			}
		}

		public float Nutrition
		{
			get
			{
				if (IsCreature)
				{
					return 0f;
				}
				return resource.Nutrition;
			}
		}

		public float WealthPoints
		{
			get
			{
				if (IsCreature)
				{
					if (creature == null || creature.HasDisposed || creature.Stats.HasDisposed)
					{
						return 0f;
					}
					return creature.WealthPoints;
				}
				return resource.WealthPoints;
			}
		}

		public CreatureBase Creature => creature;

		public bool ConstantWealthPoints => constantWealthPoints;

		public TradeResource(TradeResource tradeResource, int count)
		{
			resource = tradeResource.Resource;
			this.count = count;
			health = tradeResource.Health;
			constantWealthPoints = tradeResource.constantWealthPoints;
		}

		public TradeResource(Resource resource, int count)
		{
			this.resource = resource;
			this.count = count;
			if (IsItem)
			{
				health = 1f;
			}
			constantWealthPoints = resource.ConstantWealthPoints;
		}

		public TradeResource(ResourcePileInstance resourceInstance)
		{
			resource = resourceInstance.Blueprint;
			StatInstance stat = resourceInstance.GetStat(StatType.Health);
			health = stat.GetNormalizedPercentage();
			count = 1;
			constantWealthPoints = resourceInstance.Blueprint.ConstantWealthPoints;
		}

		public TradeResource(ResourceInstance resourceInstance)
		{
			resource = resourceInstance.Blueprint;
			StatInstance stat = resourceInstance.GetStat(StatType.Health);
			health = stat.GetNormalizedPercentage();
			count = resourceInstance.Amount;
			constantWealthPoints = resourceInstance.Blueprint.ConstantWealthPoints;
		}

		public TradeResource(CreatureBase creature, TradeForbiddenReason forbidden = TradeForbiddenReason.None)
		{
			forbiddenReason = forbidden;
			isForbidden = forbidden != TradeForbiddenReason.None;
			resource = null;
			StatInstance stat = creature.Stats.GetStat(StatType.Health);
			health = stat.GetNormalizedPercentage();
			count = 1;
			this.creature = creature;
		}

		public string GetTextIcon()
		{
			if (IsCreature)
			{
				return AssetUtils.GetSpriteAsset(creature.IconPath);
			}
			return ResourceUtils.GetTextIcon(resource);
		}

		public bool IsCaptive()
		{
			if (creature != null && creature is HumanoidInstance humanoidInstance)
			{
				return humanoidInstance.IsCaptive();
			}
			return false;
		}
	}
}
