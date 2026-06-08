namespace KitchenData
{
	public class GlobalEffect : UnlockEffect, IEffectPropertySource
	{
		public IEffectCondition EffectCondition;

		public IEffectType EffectType;

		public EffectRepresentation EffectInformation;

		public IEffectRange EffectRange => default(CEffectRangeGlobal);

		IEffectRange IEffectPropertySource.EffectRange => EffectRange;

		IEffectCondition IEffectPropertySource.EffectCondition => EffectCondition;

		IEffectType IEffectPropertySource.EffectType => EffectType;

		EffectRepresentation IEffectPropertySource.EffectInformation => EffectInformation;
	}
}
