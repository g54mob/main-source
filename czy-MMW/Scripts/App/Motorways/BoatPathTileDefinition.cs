using Factory;
using Factory.Pools;

namespace Motorways
{
	public class BoatPathTileDefinition : IReusable, IReleasedFromScopeHandler
	{
		public int index = -1;

		public RoadTilePath path;

		public RoadTileRotation rotation;

		public BoatPathTileDefinition CreateRotatedDefinition(IScope scope, RoadTileRotation newRotation)
		{
			BoatPathTileDefinition boatPathTileDefinition = scope.Get<BoatPathTileDefinition>();
			boatPathTileDefinition.rotation = TileUtilities.AddRotation(newRotation, rotation);
			boatPathTileDefinition.path = path.CreateRotatedPath(newRotation);
			return boatPathTileDefinition;
		}

		public void Reset()
		{
			index = -1;
			path = null;
			rotation = RoadTileRotation.None;
		}

		public void OnReleasedFromScope(IScope scope)
		{
			if (path != null)
			{
				scope.Release(path);
				path = null;
			}
		}
	}
}
