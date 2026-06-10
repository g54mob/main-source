using NSMedieval.Goap;
using NSMedieval.State;
using NSMedieval.Types;

namespace NSMedieval.Manager
{
	public static class CombatAgentExtensions
	{
		public static bool HasShield(this IDamageCommonAgent agent)
		{
			return agent.GetShield() != null;
		}

		public static EquipmentInstance GetShield(this IDamageCommonAgent agent)
		{
			if (agent == null)
			{
				return null;
			}
			if (agent.GetEquipment() == null)
			{
				return null;
			}
			return agent.GetEquipment().Find(GetMeleeShieldFilter);
		}

		private static bool GetMeleeShieldFilter(EquipmentInstance item)
		{
			if (item.Blueprint.ItemType == ItemType.Armor)
			{
				return (item.Blueprint.EquipmentSlots & (EquipmentSlotType.RightHand | EquipmentSlotType.LeftHand)) != 0;
			}
			return false;
		}
	}
}
