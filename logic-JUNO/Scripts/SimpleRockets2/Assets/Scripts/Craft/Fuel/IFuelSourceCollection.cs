using ModApi.Craft.Parts;

namespace Assets.Scripts.Craft.Fuel
{
	public interface IFuelSourceCollection
	{
		int Count { get; }

		bool ContainsFuelSource(IFuelSource fuelSource);

		void RemoveFuelSource(IFuelSource fuelSource);
	}
}
