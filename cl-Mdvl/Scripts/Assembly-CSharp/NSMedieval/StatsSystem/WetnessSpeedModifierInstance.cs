using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.StatsSystem
{
	public class WetnessSpeedModifierInstance : CustomAttributeModifierInstance
	{
		private readonly WeatherManager weatherManager;

		private CreatureBase creature;

		public WetnessSpeedModifierInstance(AttributeType attributeType, float value, string tag, bool negativeStacking = false)
			: base(attributeType, value, tag, negativeStacking)
		{
			weatherManager = MonoSingleton<WeatherManager>.Instance;
		}

		public override void Apply()
		{
			if (creature == null)
			{
				creature = base.Owner.Owner as CreatureBase;
			}
			if (attributeInstance == null || !MonoSingleton<WeatherManager>.IsInstantiated() || creature == null)
			{
				return;
			}
			MapNode node = creature.GetNode();
			if (node == null)
			{
				return;
			}
			if (node.IsWater)
			{
				if (VillageManager.ActiveVillage.Map.WaterManager.CanWalkInside(node))
				{
					attributeInstance.SetMultiplier(-1f);
				}
				else
				{
					attributeInstance.SetMultiplier(-3f);
				}
			}
			else
			{
				float t = ((node.Coverage != CoverageType.Outside) ? 0f : Mathf.Clamp01(weatherManager.RainEffectWeight));
				attributeInstance.SetMultiplier(Mathf.Lerp(1f, -3f, t));
			}
		}
	}
}
