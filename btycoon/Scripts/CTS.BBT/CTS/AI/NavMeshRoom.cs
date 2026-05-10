using Unity.AI.Navigation;
using UnityEngine;

namespace CTS.AI
{
	[DefaultExecutionOrder(-20)]
	public sealed class NavMeshRoom : MonoBehaviour
	{
		private NavMeshSurface _surfaceComponent;

		public bool IsDirty { get; private set; } = true;

		public void SetDirty()
		{
			IsDirty = true;
		}

		private void Awake()
		{
			_surfaceComponent = GetComponent<NavMeshSurface>();
		}

		public void BakeSurface()
		{
			if (!_surfaceComponent.navMeshData)
			{
				_surfaceComponent.BuildNavMesh();
			}
			else
			{
				_surfaceComponent.UpdateNavMesh(_surfaceComponent.navMeshData);
			}
			IsDirty = false;
		}
	}
}
