using Factory;
using Motorways.Models;
using Server;

namespace Motorways.Commands
{
	public class ClearTileReservationsCommand : Command
	{
		[Dependency]
		private TilemapModel _tilemap;

		public override void Execute(ISimulation simulation)
		{
			_tilemap.ClearTileReservations();
		}

		public static ClearTileReservationsCommand Create(IScope scope)
		{
			return scope.Get<ClearTileReservationsCommand>();
		}
	}
}
