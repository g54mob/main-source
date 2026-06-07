using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Environment.Roads
{
	[ExecuteInEditMode]
	public class SyncEasyRoadsIntersections : MonoBehaviour
	{
		[SerializeField]
		private Transform _easyRoadsIntersectionsParent;

		[SerializeField]
		private GameObject[] _intersectionPrefabs;

		[ContextMenu("Sync Intersections")]
		public void SyncIntersections()
		{
			SyncedIntersectionScript[] componentsInChildren = GetComponentsInChildren<SyncedIntersectionScript>();
			foreach (Transform easyRoadsTransform in _easyRoadsIntersectionsParent)
			{
				if (componentsInChildren.Where((SyncedIntersectionScript x) => x.EasyRoadsIntersection == easyRoadsTransform).FirstOrDefault() == null)
				{
					GameObject gameObject = _intersectionPrefabs.Where((GameObject x) => easyRoadsTransform.gameObject.name.StartsWith(x.name)).FirstOrDefault();
					if (gameObject != null)
					{
						GameObject obj = Object.Instantiate(gameObject);
						obj.transform.SetParent(base.transform, worldPositionStays: false);
						SyncedIntersectionScript syncedIntersectionScript = obj.AddComponent<SyncedIntersectionScript>();
						syncedIntersectionScript.EasyRoadsIntersection = easyRoadsTransform;
						syncedIntersectionScript.Sync();
					}
				}
			}
		}
	}
}
