using UnityEngine;

namespace Brewery.Thief
{
	public class LootDisplayPoint : MonoBehaviour
	{
		[Header("Visual Settings")]
		[Tooltip("Random Y rotation applied to spawned items (degrees).")]
		[SerializeField]
		private float randomRotationRange;

		[Tooltip("Random XZ offset applied to item placement.")]
		[SerializeField]
		private float randomOffsetRange;

		[Header("Gizmo Settings")]
		[Tooltip("Size of the gizmo cube displayed in editor.")]
		[SerializeField]
		private float gizmoSize;

		[Tooltip("Color when this point is available.")]
		[SerializeField]
		private Color availableColor;

		[Tooltip("Color when this point is occupied.")]
		[SerializeField]
		private Color occupiedColor;

		[Header("Runtime State (Read Only)")]
		[SerializeField]
		private bool isOccupied;

		[SerializeField]
		private int occupiedByIndex;

		[SerializeField]
		private GameObject displayedItem;

		public bool IsOccupied => false;

		public int OccupiedByIndex => 0;

		public GameObject DisplayedItem => null;

		public void Occupy(int stolenItemIndex, GameObject item)
		{
		}

		public void Free()
		{
		}

		public Vector3 GetSpawnPosition()
		{
			return default(Vector3);
		}

		public Quaternion GetSpawnRotation()
		{
			return default(Quaternion);
		}

		private void OnDrawGizmos()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
