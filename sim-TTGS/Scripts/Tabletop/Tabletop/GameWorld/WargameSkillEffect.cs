using UnityEngine;

namespace Tabletop.GameWorld
{
	[CreateAssetMenu(fileName = "WSE_", menuName = "Tabletop/Wargame/Skill effect")]
	public class WargameSkillEffect : ScriptableObject
	{
		public EWargameEffectTrigger trigger;

		public EWargameEffectTriggerModifier triggerModifier;

		public EWargameEffectType type;

		public EWargameEffectMiniatureTarget miniatureTarget;

		public EWargameEffectOperation operation;

		public EWargameEffectQuantity quantity;

		public EWargameEffectQuantityModifier quantityModifier;

		public float operand;

		public EWargameEffectTarget target;

		public EWargameEffectTarget secondaryTarget;
	}
}
