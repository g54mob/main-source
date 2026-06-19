using System.Linq;
using AssembleSystem;
using JSAM;
using MyBox;
using StarterAssets;
using UI.Craft;
using UI.HUD;
using UI.Inventory;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Player
{
	public class PlayerItemPicker : MonoBehaviour
	{
		[SerializeField]
		private RaycasterInfo _playerViewRaycaster;

		private IInventoryManagable _pickingItem;

		private Transform _pickingHit;

		private FirstPersonController _fpc;

		[Inject]
		private IPlayerInputService _inputService;

		[Inject]
		private IAssembleSystemService _assembleSystemService;

		[Inject]
		private ICraftUIService _craftUIService;

		[Inject]
		private IInventoryService _inventoryService;

		[Inject]
		private IInventoryUIService _inventoryUIService;

		[Inject]
		private PlayerHUDView _hudView;

		private void Awake()
		{
			_fpc = GetComponentInParent<FirstPersonController>();
		}

		private void OnEnable()
		{
			_inputService.OnInteract += TryPickupViewedItem;
		}

		private void OnDisable()
		{
			_inputService.OnInteract -= TryPickupViewedItem;
			ResetPickup();
		}

		private void TryPickupViewedItem(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				OnPickupStarted();
			}
			if (context.canceled)
			{
				OnPickupCanceled();
			}
		}

		private void OnPickupStarted()
		{
			if (_fpc != null && _fpc.IsInVehicle)
			{
				return;
			}
			Transform transform = _playerViewRaycaster.Hit.transform;
			if (!(transform == null))
			{
				transform.TryGetComponent<IInventoryManagable>(out _pickingItem);
				if (_pickingItem != null)
				{
					_pickingHit = transform;
				}
			}
		}

		private void OnPickupCanceled()
		{
			if (_pickingItem != null)
			{
				if (!IsStillLookingAtSameItem())
				{
					ResetPickup();
				}
				else if (_pickingItem is PartObject partObject && !TryHandlePartObject(partObject))
				{
					ResetPickup();
				}
				else
				{
					CompletePickup();
				}
			}
		}

		private bool IsStillLookingAtSameItem()
		{
			if (_pickingHit == null)
			{
				return true;
			}
			_pickingHit.TryGetComponent<IInventoryManagable>(out var component);
			if (component != null)
			{
				return component == _pickingItem;
			}
			return false;
		}

		private bool TryHandlePartObject(PartObject partObject)
		{
			if (!partObject.IsPickable || !partObject.enabled)
			{
				return false;
			}
			GameObject assembleParent = partObject.AssembleParent;
			if (assembleParent == null)
			{
				return false;
			}
			AssembleObjectParent component = assembleParent.GetComponent<AssembleObjectParent>();
			if (component == null)
			{
				return false;
			}
			TryRegisterCraftItem(component);
			if (partObject.IsBase)
			{
				IncrementBasePartCount(component);
			}
			return true;
		}

		private void TryRegisterCraftItem(AssembleObjectParent parent)
		{
			if (!_craftUIService.IsCraftItemExists(parent) && (!(parent.StateMachine != null) || !parent.StateMachine.Placed))
			{
				_craftUIService.CrateUICraftItem(parent).transform.SetParent(_hudView.CraftRecipeParent);
			}
		}

		private void IncrementBasePartCount(AssembleObjectParent parent)
		{
			_craftUIService.CraftItems.Where((CraftItemViewModel x) => x.Parent == parent).ForEach(delegate(CraftItemViewModel x)
			{
				x.CurrentBasePartsAmount.Value++;
			});
		}

		private void CompletePickup()
		{
			AudioManager.PlaySound(InteractionLibrarySounds.PickupEffectItem);
			_inventoryService.AddItem(_pickingItem);
			_inventoryUIService.AddItem(_pickingItem);
			ResetPickup();
		}

		private void ResetPickup()
		{
			_pickingItem = null;
			_pickingHit = null;
		}
	}
}
