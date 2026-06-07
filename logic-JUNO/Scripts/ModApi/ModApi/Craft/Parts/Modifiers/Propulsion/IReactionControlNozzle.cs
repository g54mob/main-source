namespace ModApi.Craft.Parts.Modifiers.Propulsion
{
	public interface IReactionControlNozzle
	{
		float CurrentThrust { get; }

		IFuelSource FuelSource { get; }

		bool IsActive { get; }

		PartData Part { get; }
	}
}
