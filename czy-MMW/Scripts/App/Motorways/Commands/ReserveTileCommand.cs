using Factory;
using Motorways.Models;
using Server;
using UnityEngine;

namespace Motorways.Commands
{
	public class ReserveTileCommand : Command
	{
		[Dependency]
		private TilemapModel _tilemap;

		private Vector2Int _coordinates;

		public override void Execute(ISimulation simulation)
		{
			_tilemap.ReserveTile(_coordinates);
		}

		public override void Reset()
		{
			base.Reset();
			_coordinates = default(Vector2Int);
		}

		public static ReserveTileCommand Create(IScope scope, Vector2Int coordinates)
		{
			ReserveTileCommand reserveTileCommand = scope.Get<ReserveTileCommand>();
			reserveTileCommand._coordinates = coordinates;
			return reserveTileCommand;
		}
	}
}
