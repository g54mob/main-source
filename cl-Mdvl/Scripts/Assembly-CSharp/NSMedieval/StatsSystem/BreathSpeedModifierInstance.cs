using NSMedieval.State;
using NSMedieval.Village;
using NSMedieval.Village.Map;

namespace NSMedieval.StatsSystem
{
	public class BreathSpeedModifierInstance : CustomAttributeModifierInstance
	{
		private CreatureBase creature;

		public BreathSpeedModifierInstance(AttributeType attributeType, float value, string tag, bool negativeStacking = false)
			: base(attributeType, value, tag, negativeStacking)
		{
		}

		public override void Apply()
		{
			if (creature == null)
			{
				creature = base.Owner.Owner as CreatureBase;
			}
			if (attributeInstance != null && creature != null)
			{
				MapNode node = creature.GetNode();
				if (node != null)
				{
					attributeInstance.SetMultiplier(VillageManager.ActiveVillage.Map.WaterManager.CanDrown(node) ? (-1f) : 1f);
					_ = creature.GetAttribute(AttributeType.BreathStep).Value;
					_ = creature.GetAttribute(AttributeType.BreathLossSpeed).Value;
					_ = creature.GetAttribute(AttributeType.BreathGainSpeed).Value;
					creature.Stats.GetStat(StatType.Breath);
				}
			}
		}
	}
}
