using System;
using AssembleSystem;
using Items;
using Loxodon.Framework.Contexts;
using UI.HUD;
using UI.Inventory;
using UnityEngine;
using Zenject;

namespace Player
{
	public class PlayerUIHintMarkers : MonoBehaviour
	{
		[SerializeField]
		private RaycasterInfo _playerDescriberViewInfo;

		private InfoCursorsViewModel _infoCursorViewModel;

		[Inject]
		private IInventoryUIService _inventoryUIService;

		private void Start()
		{
			_infoCursorViewModel = Loxodon.Framework.Contexts.Context.GetApplicationContext().GetService<InfoCursorsViewModel>();
			IInventoryUIService inventoryUIService = _inventoryUIService;
			inventoryUIService.OnInventoryOpened = (Action<bool>)Delegate.Combine(inventoryUIService.OnInventoryOpened, new Action<bool>(OnInventoryOpened));
		}

		private void OnDisable()
		{
			DisableAllCursors();
		}

		private void OnInventoryOpened(bool isOpened)
		{
			if (isOpened)
			{
				base.enabled = false;
			}
			else
			{
				base.enabled = true;
			}
		}

		private void Update()
		{
			TrySetDescriber();
		}

		private void TrySetDescriber()
		{
			if (_playerDescriberViewInfo.Hit.transform != null)
			{
				Transform transform = _playerDescriberViewInfo.Hit.transform;
				if (transform.TryGetComponent<IUsable>(out var _))
				{
					_infoCursorViewModel.EnableUseHint(value: true);
				}
				else
				{
					_infoCursorViewModel.EnableUseHint(value: false);
				}
				if (transform.TryGetComponent<IInventoryManagable>(out var component2) && (component2 as MonoBehaviour).enabled)
				{
					_infoCursorViewModel.EnablePickupHint(value: true);
					_infoCursorViewModel.EnableHoldHint(value: true);
				}
				if (transform.TryGetComponent<IGrabable>(out var _))
				{
					_infoCursorViewModel.EnableHoldHint(value: true);
				}
				if (transform.TryGetComponent<PartObject>(out var component4))
				{
					if (component4.StateMachine == null)
					{
						return;
					}
					if (component4.StateMachine.Placed && !component4.StateMachine.Tightened)
					{
						_infoCursorViewModel.EnableDropHint(value: true);
					}
				}
				if (transform.TryGetComponent<IMouseButtonManipulatable>(out var _))
				{
					_infoCursorViewModel.EnableUpHint(value: true);
					_infoCursorViewModel.EnableDownHint(value: true);
				}
				if (transform.TryGetComponent<IScrollManipulatable>(out var _))
				{
					_infoCursorViewModel.EnableScrollUpHint(value: true);
					_infoCursorViewModel.EnableScrollDownHint(value: true);
				}
				if (transform.TryGetComponent<EquipableToolItem>(out var _))
				{
					_infoCursorViewModel.EnableEquipHint(value: true);
				}
			}
			else
			{
				DisableAllCursors();
			}
		}

		private void DisableAllCursors()
		{
			_infoCursorViewModel?.EnableEquipHint(value: false);
			_infoCursorViewModel?.EnableUseHint(value: false);
			_infoCursorViewModel?.EnablePickupHint(value: false);
			_infoCursorViewModel?.EnableHoldHint(value: false);
			_infoCursorViewModel?.EnableDropHint(value: false);
			_infoCursorViewModel?.EnableUpHint(value: false);
			_infoCursorViewModel?.EnableDownHint(value: false);
			_infoCursorViewModel?.EnableScrollUpHint(value: false);
			_infoCursorViewModel?.EnableScrollDownHint(value: false);
		}
	}
}
