using NaughtyAttributes;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

namespace CTS
{
	public class RoomNavmesh : MonoBehaviour
	{
		[InfoBox("Please rebake navmeshes in the prefabs instead of the scenes c: \nAnd bake using the Bake button of this component, not the NavMeshSurface", EInfoBoxType.Warning)]
		[SerializeField]
		private NavMeshData _navMeshData;

		private void Awake()
		{
			if ((bool)_navMeshData)
			{
				NavMeshSurface component = GetComponent<NavMeshSurface>();
				if ((bool)component.navMeshData)
				{
					component.RemoveData();
				}
				component.navMeshData = _navMeshData;
				component.AddData();
			}
		}
	}
}
