using Unity.Netcode;
using UnityEngine;

namespace Brewery.Shop
{
	public class ShopDisplayController : MonoBehaviour
	{
		[Header("Grid Configuration")]
		[SerializeField]
		private Transform gridOrigin;

		[SerializeField]
		private ShopConfig shopConfig;

		[Header("Visual Settings")]
		[SerializeField]
		private bool showGizmos;

		[SerializeField]
		private Color gizmoColor;

		[SerializeField]
		private float gizmoSphereSize;

		[Header("References")]
		[SerializeField]
		private Transform itemsContainer;

		private void Awake()
		{
		}

		public void UpdateDisplay(NetworkList<ShopGridSlot> gridSlots)
		{
		}

		public void ClearDisplay()
		{
		}

		public Vector3 GetSlotWorldPosition(int slotIndex)
		{
			return default(Vector3);
		}

		private Vector3 GetSlotLocalPosition(int slotIndex)
		{
			return default(Vector3);
		}

		private void OnDestroy()
		{
		}
	}
}
