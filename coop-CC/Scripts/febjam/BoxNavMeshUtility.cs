using Unity.AI.Navigation;
using UnityEngine;

public class BoxNavMeshUtility : MonoBehaviour
{
	private NavMeshSurface _navMeshSurface;

	public void PrepareForBake()
	{
		_navMeshSurface = GetComponent<NavMeshSurface>();
		string text = "playAreaNavMesh-" + base.gameObject.scene.name;
		base.gameObject.name = text;
	}
}
