using System;

namespace Battle
{
	[Serializable]
	public class BuffStatusRecord
	{
		public int abilityId;

		public eAbilityEffectId effectId;

		public float statusPoint;

		public bool isBase;

		public BuffStatusRecord(int abilityId, eAbilityEffectId effectId, float statusPoint, bool isBase)
		{
		}
	}
}
