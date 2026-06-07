using Dhs5.Utility.Databases;

namespace Simulator.GameWorld
{
	[Database("Shop/Furnitures", typeof(Furniture))]
	public class FurnitureDatabase : FolderDataContainer
	{
	}
}
