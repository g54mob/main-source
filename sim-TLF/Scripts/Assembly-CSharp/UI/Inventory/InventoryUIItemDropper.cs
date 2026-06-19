using System.Linq;
using AssembleSystem;
using AssembleSystem.FSM.Parts;
using Items;
using JSAM;
using MyBox;
using Player;
using Player.FSM;
using StarterAssets;
using UI.Craft;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace UI.Inventory
{
	public class InventoryUIItemDropper : MonoBehaviour
	{
		[SerializeField]
		private RaycasterInfo _inventoryItemsObserver;

		private PlayerItemDropper _playerItemDropper;

		private FirstPersonController _fpc;

		[Inject]
		private IPlayerStateMachineParametersManipulator _playerStateMachineParametersManipulator;

		[Inject]
		private IPlayerInputService _playerInputService;

		[Inject]
		private IInventoryService _inventoryService;

		[Inject]
		private IInventoryUIService _inventoryUIService;

		[Inject]
		private ICraftUIService _craftUIService;

		[Inject]
		private IAssembleSystemService _assembleSystemService;

		[Inject]
		private IPlayerEquipService _equipService;

		private void Awake()
		{
			Transform root = (_playerStateMachineParametersManipulator as MonoBehaviour).transform.root;
			_playerItemDropper = root.GetComponentInChildren<PlayerItemDropper>();
			_fpc = root.GetComponentInChildren<FirstPersonController>();
		}

		private void OnEnable()
		{
			_playerInputService.OnDrop += DropViewedItem;
			_playerItemDropper.enabled = false;
		}

		private void OnDisable()
		{
			_playerInputService.OnDrop -= DropViewedItem;
			_playerItemDropper.enabled = true;
		}

		private void DropViewedItem(InputAction.CallbackContext context)
		{
			if (!context.performed || (_fpc != null && _fpc.IsInVehicle) || !(_inventoryItemsObserver.Hit.transform != null) || !_inventoryItemsObserver.Hit.transform.TryGetComponent<IInventoryManagable>(out var component))
			{
				return;
			}
			IInventoryManagable inventoryItem = component;
			IInventoryManagable inventoryManagable = _inventoryService.Items.FirstOrDefault((IInventoryManagable x) => x == inventoryItem);
			if (inventoryManagable == null)
			{
				return;
			}
			_inventoryService.RemoveItem(inventoryManagable);
			_inventoryUIService.RemoveItem(inventoryManagable);
			AudioManager.PlaySound(PlayerLibrarySounds.ThrowSwoosh);
			PartObject partObject = (inventoryManagable as MonoBehaviour)?.GetComponent<PartObject>();
			GameObject gameObject = ((partObject != null) ? partObject.AssembleParent : null);
			AssembleObjectParent parent = ((gameObject != null) ? gameObject.GetComponent<AssembleObjectParent>() : null);
			MonoBehaviour monoBehaviour = inventoryManagable as MonoBehaviour;
			if (monoBehaviour == null)
			{
				return;
			}
			MeshRenderer component2 = monoBehaviour.GetComponent<MeshRenderer>();
			if (component2 != null)
			{
				Vector3 vector = component2.bounds.center - monoBehaviour.transform.position;
				monoBehaviour.transform.position = _playerItemDropper.DropPoint.position - vector;
			}
			else
			{
				monoBehaviour.transform.position = _playerItemDropper.DropPoint.position;
			}
			if (inventoryManagable is IThrowable throwable)
			{
				throwable.Throw(_playerItemDropper.DropPoint.forward * _playerItemDropper.DropForce);
			}
			if (inventoryManagable is IEquipable equipable)
			{
				if (_equipService.GetEquipableAt(EquipSide.RIGHT_HAND) == equipable)
				{
					_equipService.TryUnequip(EquipSide.RIGHT_HAND);
				}
				else if (_equipService.GetEquipableAt(EquipSide.LEFT_HAND) == equipable)
				{
					_equipService.TryUnequip(EquipSide.LEFT_HAND);
				}
				else
				{
					equipable.Unequip();
				}
			}
			else
			{
				if (!(inventoryManagable is PartObject partObject2))
				{
					return;
				}
				partObject2.GetComponent<PartObjectStateMachine>().InInventoryParentPlaced = false;
				if ((object)parent == null)
				{
					return;
				}
				if (partObject2.IsBase)
				{
					_craftUIService.CraftItems.Where((CraftItemViewModel x) => x.Parent == parent).ForEach(delegate(CraftItemViewModel x)
					{
						x.CurrentBasePartsAmount.Value--;
					});
				}
				if (!_assembleSystemService.AnyPartsInInventoryOf(parent))
				{
					_craftUIService.RemoveCraftItem(parent);
				}
			}
		}
	}
}
