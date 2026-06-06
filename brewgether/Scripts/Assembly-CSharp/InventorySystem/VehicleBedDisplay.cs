using UnityEngine;

namespace InventorySystem
{
	[RequireComponent(typeof(VehicleInventoryManager))]
	public class VehicleBedDisplay : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private VehicleInventoryManager inventoryManager;

		[Header("Gizmo Visualization")]
		[SerializeField]
		private bool showGizmos;

		[SerializeField]
		private bool showGizmosSelected;

		[SerializeField]
		private bool showCellLabels;

		[SerializeField]
		private bool showOccupancyInfo;

		[Header("Gizmo Colors")]
		[SerializeField]
		private Color freeCellColor;

		[SerializeField]
		private Color occupiedCellColor;

		[SerializeField]
		private Color gridLineColor;

		[SerializeField]
		private Color anchorCellColor;

		[Header("Gizmo Sizes")]
		[SerializeField]
		private float cellGizmoSize;

		[SerializeField]
		private float labelOffsetY;

		private void Awake()
		{
		}
	}
}
