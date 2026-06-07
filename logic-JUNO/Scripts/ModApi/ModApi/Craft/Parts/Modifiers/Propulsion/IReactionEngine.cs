namespace ModApi.Craft.Parts.Modifiers.Propulsion
{
	public interface IReactionEngine
	{
		bool IsActive { get; }

		float CurrentMassFlowRate { get; }

		float CurrentThrust { get; }

		IFuelSource FuelSource { get; }

		float MaximumMassFlowRate { get; }

		float MaximumThrust { get; }

		float ThrottleResponse { get; }

		PartData Part { get; }

		float RemainingFuel { get; }

		bool SupportsWarpBurn { get; }
	}
}
