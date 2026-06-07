using UnityEngine;

public class MeshCombine : MonoBehaviour
{
	private void Awake()
	{
		MeshCombiner.CombineMeshesInChildren(base.gameObject);
	}
}
