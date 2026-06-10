using UnityEngine;

namespace NSMedieval.Map.Navigation
{
	public class GridUpdater : MonoBehaviour
	{
		[SerializeField]
		private BoxCollider boxCollider;

		private Bounds bounds;

		private void Start()
		{
			bounds = boxCollider.bounds;
		}
	}
}
