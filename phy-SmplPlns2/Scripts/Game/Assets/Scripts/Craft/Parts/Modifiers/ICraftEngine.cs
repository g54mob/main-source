using Assets.Scripts.Craft.Parts.Modifiers.Powertrain;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public interface ICraftEngine
	{
		CraftEngineType EngineType { get; }

		float IRSignature { get; }

		IPowertrain Powertrain { get; }
	}
}
