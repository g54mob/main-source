namespace KitchenData
{
	public interface IEffectPropertySource
	{
		IEffectRange EffectRange { get; }

		IEffectCondition EffectCondition { get; }

		IEffectType EffectType { get; }

		EffectRepresentation EffectInformation { get; }
	}
}
