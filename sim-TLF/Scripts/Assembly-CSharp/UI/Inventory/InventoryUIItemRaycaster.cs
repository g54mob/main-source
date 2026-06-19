using UI.HUD;
using UnityEngine;
using Zenject;

namespace UI.Inventory
{
	public class InventoryUIItemRaycaster : MonoBehaviour
	{
		[SerializeField]
		private Camera _inventoryCamera;

		[SerializeField]
		private RaycasterInfo _inventoryRaycasterInfo;

		[SerializeField]
		private RaycasterInfo _inventoryMoverInfo;

		[Inject]
		private PlayerHUDView _playerHUD;

		private void Update()
		{
			_inventoryRaycasterInfo.ShootRayFromRenderTexture(_inventoryCamera, _playerHUD.InventoryViewRenderImage, _playerHUD.InventoryViewRayLimiter);
			_inventoryMoverInfo.ShootRayFromRenderTexture(_inventoryCamera, _playerHUD.InventoryViewRenderImage, _playerHUD.InventoryViewRayLimiter);
		}
	}
}
