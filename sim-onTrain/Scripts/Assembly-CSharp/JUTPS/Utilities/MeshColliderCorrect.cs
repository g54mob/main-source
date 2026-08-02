using UnityEngine;

namespace JUTPS.Utilities
{
	[AddComponentMenu("JU TPS/Utilities/Mesh Collider Correct")]
	public class MeshColliderCorrect : MonoBehaviour
	{
		public GameObject Mesh;

		private Transform[] gameobjectschilds;

		private void OnCollisionEnter(Collision col)
		{
			if (base.transform.childCount == 0)
			{
				return;
			}
			gameobjectschilds = GetComponentsInChildren<Transform>();
			for (int i = 0; i < gameobjectschilds.Length - 1; i++)
			{
				if (gameobjectschilds[i] != base.transform)
				{
					gameobjectschilds[i].transform.SetParent(Mesh.transform);
				}
			}
		}
	}
}
