using UnityEngine;

namespace Brewery.Map.Controllers
{
	public class MapBoundaryController
	{
		private readonly MapCameraSettings settings;

		private BoxCollider[] boundaryColliders;

		private Vector3 lastValidPosition;

		public MapBoundaryController(MapCameraSettings settings)
		{
		}

		public void DiscoverBoundaryColliders()
		{
		}

		public void SetInitialPosition(Vector3 position)
		{
		}

		public Vector3 ClampPosition(Vector3 position)
		{
			return default(Vector3);
		}

		private Vector3 ClampToColliderBoundaries(Vector3 position)
		{
			return default(Vector3);
		}

		public BoxCollider[] GetBoundaryColliders()
		{
			return null;
		}
	}
}
