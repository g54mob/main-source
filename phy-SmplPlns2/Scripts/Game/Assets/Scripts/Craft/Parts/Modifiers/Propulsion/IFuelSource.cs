namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion
{
	public interface IFuelSource
	{
		bool IsEmpty { get; }

		float TotalCapacity { get; }

		float TotalFuel { get; }

		void RemoveFuel(float amount);
	}
}
