using ModApi.Craft.Parts;

namespace Assets.Scripts.Craft.Fuel
{
	public interface IFuelTransferManager
	{
		void AddFuelSource(IFuelSource fuelSource);

		void RemoveFuelSource(IFuelSource fuelSource);
	}
}
