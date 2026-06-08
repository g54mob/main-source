using UnityEngine;
using UnityEngine.AI;

namespace Kitchen
{
	public class TutorialNavSurface : MonoBehaviour
	{
		public NavMeshSurface Surface;

		public void Start()
		{
			Build();
		}

		public void Build()
		{
			Surface.collectObjects = CollectObjects.Children;
			Surface.layerMask = LayerMask.GetMask("Statics", "NavMesh Level Geometry");
			Surface.tileSize = 32;
			Surface.overrideTileSize = true;
			Surface.voxelSize = 0.075f;
			Surface.overrideVoxelSize = true;
			Surface.useGeometry = NavMeshCollectGeometry.PhysicsColliders;
			BoxCollider boxCollider = Surface.gameObject.GetComponent<BoxCollider>();
			if (boxCollider == null)
			{
				boxCollider = Surface.gameObject.AddComponent<BoxCollider>();
			}
			boxCollider.center = new Vector3(0f, 0f, 0f);
			boxCollider.size = new Vector3(30f, 0.01f, 10f);
			Surface.gameObject.SetLayer(LayerMask.NameToLayer("NavMesh Level Geometry"));
			Surface.BuildNavMesh();
		}
	}
}
