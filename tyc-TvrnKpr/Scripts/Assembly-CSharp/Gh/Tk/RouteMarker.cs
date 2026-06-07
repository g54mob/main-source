using UnityEngine;

namespace Gh.Tk
{
	public class RouteMarker : MonoBehaviour
	{
		private GameObject _visual;

		private GameObject _currentVisualPrefab;

		private Route _route;

		public MapVisual MapVisual => null;

		public void SetVisual(GameObject prefab)
		{
		}

		public void SetRoute(Route route)
		{
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
