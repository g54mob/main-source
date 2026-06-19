using System;
using Extensions;
using Items;
using Loxodon.Framework.Contexts;
using Player;
using UI.HUD;
using UI.Inventory.Describer;
using UnityEngine;
using Zenject;

namespace UI.Inventory
{
	public class InventoryUIItemDescriber : MonoBehaviour
	{
		[SerializeField]
		private Camera _inventoryCamera;

		[SerializeField]
		private RaycasterInfo _inventoryRaycaster;

		private InventoryDescriberViewModel _describerVM;

		private InfoCursorsViewModel _infoCursorsVM;

		private Transform _lastHitItem;

		[Inject]
		private IInventoryUIService _inventoryUIService;

		[Inject]
		private IPlayerInputService _playerInputService;

		private void Start()
		{
			_infoCursorsVM = Loxodon.Framework.Contexts.Context.GetApplicationContext().GetService<InfoCursorsViewModel>();
			_describerVM = Loxodon.Framework.Contexts.Context.GetApplicationContext().GetService<InventoryDescriberViewModel>();
		}

		private void OnEnable()
		{
			IInventoryUIService inventoryUIService = _inventoryUIService;
			inventoryUIService.OnInventoryOpened = (Action<bool>)Delegate.Combine(inventoryUIService.OnInventoryOpened, new Action<bool>(OnInventoryOpened));
			_lastHitItem = null;
		}

		private void OnDisable()
		{
			IInventoryUIService inventoryUIService = _inventoryUIService;
			inventoryUIService.OnInventoryOpened = (Action<bool>)Delegate.Remove(inventoryUIService.OnInventoryOpened, new Action<bool>(OnInventoryOpened));
			_describerVM.Enabled.Value = false;
			_lastHitItem = null;
		}

		private void Update()
		{
			OnInventoryLook();
		}

		private void OnInventoryOpened(bool value)
		{
			if (!value)
			{
				_infoCursorsVM.EnableDropHint(value: false);
				_infoCursorsVM.EnableToWorldHint(value: false);
				_infoCursorsVM.EnableUseHint(value: false);
			}
		}

		private void OnInventoryLook()
		{
			if (_describerVM == null)
			{
				return;
			}
			Transform transform = _inventoryRaycaster.Hit.transform;
			if (transform == _lastHitItem)
			{
				return;
			}
			_lastHitItem = transform;
			if (transform == null)
			{
				_describerVM.Enabled.Value = false;
				_infoCursorsVM.EnableDropHint(value: false);
				_infoCursorsVM.EnableEquipHint(value: false);
				return;
			}
			_infoCursorsVM.ItemName = transform.gameObject.name.ToCleanName();
			IEquipable component;
			bool flag = transform.TryGetComponent<IEquipable>(out component);
			UsableConsumableItem component2;
			bool flag2 = transform.TryGetComponent<UsableConsumableItem>(out component2);
			_infoCursorsVM.EnableEquipHint(flag || flag2);
			if (flag2 && component2 is IConsumeDecremental consumeDecremental)
			{
				_describerVM.Enabled.Value = true;
				_describerVM.InfoText = $"{consumeDecremental.CurrentQuantity} / {consumeDecremental.MaxQuantity}";
			}
			else if (flag2 && component2 is IConsumeProgressable consumeProgressable)
			{
				_describerVM.Enabled.Value = true;
				_describerVM.InfoText = $"{consumeProgressable.CurrentProgress} / {consumeProgressable.MaxProgress}";
			}
			else
			{
				_describerVM.Enabled.Value = false;
			}
			_infoCursorsVM.EnableDropHint(value: true);
		}
	}
}
