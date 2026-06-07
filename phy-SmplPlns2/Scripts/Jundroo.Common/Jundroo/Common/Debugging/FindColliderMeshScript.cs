using UnityEngine;

namespace Jundroo.Common.Debugging
{
	[ExecuteAlways]
	public class FindColliderMeshScript : MonoBehaviour
	{
		[SerializeField]
		private string _meshName;

		[ContextMenu("Find Collider Mesh")]
		public void FindColliderMesh()
		{
			Object[] array = Object.FindObjectsByType(typeof(MeshCollider), FindObjectsInactive.Include, FindObjectsSortMode.None);
			Debug.Log($"Searching {array.Length} colliders");
			Object[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				MeshCollider meshCollider = (MeshCollider)array2[i];
				if (meshCollider.sharedMesh != null && meshCollider.sharedMesh.name == _meshName)
				{
					Debug.Log("Found collider " + meshCollider.name, meshCollider.gameObject);
				}
			}
		}
	}
}
