namespace Tabletop.GameWorld
{
	public static class WargameEffectTriggerModifierExtension
	{
		public static bool Encapsulate(this EWargameEffectTriggerModifier modifier, EWargameEffectType type, int modification)
		{
			switch (modifier)
			{
			case EWargameEffectTriggerModifier.ANY_EFFECT:
				return true;
			case EWargameEffectTriggerModifier.ASSAULT:
				return type == EWargameEffectType.ASSAULT;
			case EWargameEffectTriggerModifier.DAMAGE:
				return type == EWargameEffectType.DAMAGE;
			case EWargameEffectTriggerModifier.PV:
				return type == EWargameEffectType.PV;
			case EWargameEffectTriggerModifier.ANY_POSITIVE_EFFECT:
				return modification > 0;
			case EWargameEffectTriggerModifier.ASSAULT_POSITIVE:
				if (type == EWargameEffectType.ASSAULT)
				{
					return modification > 0;
				}
				return false;
			case EWargameEffectTriggerModifier.DAMAGE_POSITIVE:
				if (type == EWargameEffectType.DAMAGE)
				{
					return modification > 0;
				}
				return false;
			case EWargameEffectTriggerModifier.PV_POSITIVE:
				if (type == EWargameEffectType.PV)
				{
					return modification > 0;
				}
				return false;
			case EWargameEffectTriggerModifier.ANY_NEGATIVE_EFFECT:
				return modification < 0;
			case EWargameEffectTriggerModifier.ASSAULT_NEGATIVE:
				if (type == EWargameEffectType.ASSAULT)
				{
					return modification < 0;
				}
				return false;
			case EWargameEffectTriggerModifier.DAMAGE_NEGATIVE:
				if (type == EWargameEffectType.DAMAGE)
				{
					return modification < 0;
				}
				return false;
			case EWargameEffectTriggerModifier.PV_NEGATIVE:
				if (type == EWargameEffectType.PV)
				{
					return modification < 0;
				}
				return false;
			default:
				return false;
			}
		}
	}
}
