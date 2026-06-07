using UnityEngine;
using UnityEngine.AI;

namespace CraftingAnims
{
	public class CrafterNavigation : MonoBehaviour
	{
		[HideInInspector]
		public CrafterController crafterController;

		[HideInInspector]
		public NavMeshAgent navMeshAgent;

		[HideInInspector]
		public GameObject nav;

		public bool isNavigating;

		private void Awake()
		{
		}

		private void OnDisable()
		{
		}

		private void Update()
		{
		}

		private void ShowNavPointer()
		{
		}

		private void HideNavPointer()
		{
		}

		private void Navigating()
		{
		}

		public void MeshNavToPoint(Vector3 destination)
		{
		}

		public void StopNavigating()
		{
		}

		private void RotateTowardsMovementDir()
		{
		}
	}
}
