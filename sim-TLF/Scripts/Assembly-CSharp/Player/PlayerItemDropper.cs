using System.Linq;
using AssembleSystem;
using Items;
using JSAM;
using MyBox;
using Player.FSM;
using StarterAssets;
using UI.Craft;
using UI.Inventory;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Player
{
	public class PlayerItemDropper : MonoBehaviour
	{
		[SerializeField]
		private Transform _dropPoint;

		[SerializeField]
		private float _dropForce;

		[Inject]
		private IPlayerInputService _inputService;

		[Inject]
		private IInventoryService _inventoryService;

		[Inject]
		private IInventoryUIService _inventoryUIService;

		[Inject]
		private ICraftUIService _craftUIService;

		[Inject]
		private IAssembleSystemService _assembleSystemService;

		[Inject]
		private IPlayerEquipService _playerEquipService;

		private FirstPersonController _fpc;

		public Transform DropPoint => _dropPoint;

		public float DropForce => _dropForce;

		private void Awake()
		{
			_fpc = GetComponentInParent<FirstPersonController>();
		}

		private void OnEnable()
		{
			_inputService.OnDrop += PlayerItemDrop;
		}

		private void OnDisable()
		{
			_inputService.OnDrop -= PlayerItemDrop;
		}

		private void PlayerItemDrop(InputAction.CallbackContext context)
		{
			if (!context.performed || (_fpc != null && _fpc.IsInVehicle) || _playerEquipService.IsConsumableInRightHand() || _inventoryService.Items.Count == 0)
			{
				return;
			}
			IInventoryManagable inventoryManagable = _inventoryService.Items.Last();
			_inventoryService.RemoveItem(inventoryManagable);
			_inventoryUIService.RemoveItem(inventoryManagable);
			AudioManager.PlaySound(PlayerLibrarySounds.ThrowSwoosh);
			MonoBehaviour monoBehaviour = inventoryManagable as MonoBehaviour;
			AssembleObjectParent parent = monoBehaviour?.GetComponent<PartObject>()?.AssembleParent.GetComponent<AssembleObjectParent>();
			if (monoBehaviour != null)
			{
				MeshRenderer component = monoBehaviour.GetComponent<MeshRenderer>();
				if (component != null)
				{
					Vector3 vector = component.bounds.center - monoBehaviour.transform.position;
					monoBehaviour.transform.position = _dropPoint.position - vector;
				}
				else
				{
					monoBehaviour.transform.position = _dropPoint.position;
				}
			}
			if (inventoryManagable is IThrowable throwable)
			{
				throwable.Throw(_dropPoint.forward * _dropForce);
			}
			if (inventoryManagable is IEquipable equipable)
			{
				if (_playerEquipService.GetEquipableAt(EquipSide.RIGHT_HAND) == equipable)
				{
					_playerEquipService.TryUnequip(EquipSide.RIGHT_HAND);
				}
				else if (_playerEquipService.GetEquipableAt(EquipSide.LEFT_HAND) == equipable)
				{
					_playerEquipService.TryUnequip(EquipSide.LEFT_HAND);
				}
				else
				{
					equipable.Unequip();
				}
			}
			else
			{
				if (!(inventoryManagable is PartObject partObject))
				{
					return;
				}
				if (partObject.StateMachine != null)
				{
					partObject.StateMachine.InInventoryParentPlaced = false;
				}
				if ((object)parent == null)
				{
					return;
				}
				if (partObject.IsBase)
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
