using AssembleSystem;
using JSAM;
using Player;
using Player.FSM;
using UnityEngine;
using Zenject;

namespace UI.Inventory
{
	public class InventoryUILostItemsDetector : MonoBehaviour
	{
		[Inject]
		private IInventoryUIService _inventoryUIService;

		[Inject]
		private IInventoryService _inventoryService;

		[Inject]
		private IPlayerStateMachineParametersManipulator _playerFSM;

		private PlayerBehaviour _playerBehaviour;

		private void Start()
		{
			_playerBehaviour = (_playerFSM as MonoBehaviour).GetComponentInParent<PlayerBehaviour>();
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent<IInventoryManagable>(out var component))
			{
				_inventoryUIService.RemoveItem(component);
				_inventoryService.RemoveItem(component);
				MonoBehaviour monoBehaviour = component as MonoBehaviour;
				if (monoBehaviour != null)
				{
					monoBehaviour.transform.position = _playerBehaviour.transform.position + Vector3.up * 2f;
					AudioManager.PlaySound(InteractionLibrarySounds.CrateItemJump);
				}
			}
		}
	}
}
