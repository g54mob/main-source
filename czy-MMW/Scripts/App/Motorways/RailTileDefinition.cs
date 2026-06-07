using Factory;
using Factory.Pools;

namespace Motorways
{
	public class RailTileDefinition : IReusable, IReleasedFromScopeHandler
	{
		public int index = -1;

		public RoadTilePath path;

		public RoadTileRotation rotation;

		public RailTileDefinition CreateRotatedDefinition(IScope scope, RoadTileRotation newRotation)
		{
			RailTileDefinition railTileDefinition = scope.Get<RailTileDefinition>();
			railTileDefinition.rotation = TileUtilities.AddRotation(newRotation, rotation);
			railTileDefinition.path = path.CreateRotatedPath(newRotation);
			return railTileDefinition;
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
