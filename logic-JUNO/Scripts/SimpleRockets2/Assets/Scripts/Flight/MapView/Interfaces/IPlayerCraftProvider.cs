using Assets.Scripts.Flight.MapView.Items;

namespace Assets.Scripts.Flight.MapView.Interfaces
{
	public interface IPlayerCraftProvider
	{
		MapPlayerCraft PlayerCraft { get; }

		event PlayerCraftHandler PlayerCraftChanged;
	}
}
