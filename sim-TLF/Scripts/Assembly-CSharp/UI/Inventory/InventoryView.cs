using System;
using DG.Tweening;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.Views;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Zenject;

namespace UI.Inventory
{
	public class InventoryView : UIView
	{
		[SerializeField]
		private RawImage _inventoryImage;

		[SerializeField]
		private RawImage _inventoryRayLimiter;

		[SerializeField]
		private Button _hideButton;

		[SerializeField]
		private Button _minimizeButton;

		[SerializeField]
		private Button _closeButton;

		[Space(5f)]
		[SerializeField]
		private Vector2 _closeAnchorPos;

		[SerializeField]
		private Vector2 _closeSizeDelta;

		[SerializeField]
		private float _closeTime;

		[SerializeField]
		private Vector2 _openAnchorPos;

		[SerializeField]
		private Vector2 _openSizeDelta;

		[SerializeField]
		private float _openTime;

		private bool _inventoryHidden;

		private Sequence _inventorySequence;

		private RectTransform _rect;

		[Inject]
		private IPlayerInputService _inputService;

		[Inject]
		private IInventoryUIService _inventoryUIService;

		public RawImage RenderImage => _inventoryImage;

		public RawImage RayLimiterImage => _inventoryRayLimiter;

		protected override void Awake()
		{
			_rect = base.transform as RectTransform;
		}

		protected override void OnEnable()
		{
			_inputService.OnInventory += ToggleInventory;
			IInventoryUIService inventoryUIService = _inventoryUIService;
			inventoryUIService.OnItemOfTheInventoryView = (Action)Delegate.Combine(inventoryUIService.OnItemOfTheInventoryView, new Action(CloseInventory));
		}

		protected override void OnDisable()
		{
			_inputService.OnInventory -= ToggleInventory;
			IInventoryUIService inventoryUIService = _inventoryUIService;
			inventoryUIService.OnItemOfTheInventoryView = (Action)Delegate.Remove(inventoryUIService.OnItemOfTheInventoryView, new Action(CloseInventory));
		}

		protected override void Start()
		{
			_inventorySequence = DOTween.Sequence();
			BindingSet<InventoryView, InventoryViewModel> bindingSet = this.CreateBindingSet<InventoryView, InventoryViewModel>();
			InventoryViewModel dataContext = new InventoryViewModel();
			this.SetDataContext(dataContext);
			bindingSet.Bind(_hideButton).For((Button v) => v.onClick).To((InventoryViewModel vm) => vm.HideInventoryCommand)
				.OneWay();
			bindingSet.Bind(_minimizeButton).For((Button v) => v.onClick).To((InventoryViewModel vm) => vm.MinimizeInventoryCommand)
				.OneWay();
			bindingSet.Bind(_closeButton).For((Button v) => v.onClick).To((InventoryViewModel vm) => vm.CloseInventoryCommand)
				.OneWay();
			bindingSet.Bind(this).For((InventoryView v) => v.CloseInventoryResponse).To((InventoryViewModel vm) => vm.CloseRequest);
			bindingSet.Bind(this).For((InventoryView v) => v.HideInventoryResponse).To((InventoryViewModel vm) => vm.HideRequest);
			bindingSet.Build();
		}

		private void ToggleInventory(InputAction.CallbackContext context)
		{
			if (context.performed)
			{
				Debug.Log("Toggle Inventory Performed");
				if (_inventoryUIService.InventoryOpened)
				{
					CloseInventory();
				}
				else
				{
					OpenInventory();
				}
			}
		}

		private void OpenInventory()
		{
			CursorLockKeeper.Apply(CursorLockMode.None, visible: true);
			_inventoryUIService.OpenInventory();
			ShowInventory();
		}

		private void CloseInventory()
		{
			CursorLockKeeper.Apply(CursorLockMode.Locked, visible: false);
			_inventoryUIService.CloseInventory();
			HideInventory();
		}

		private void HideInventory()
		{
			AnimateCloseInventory();
			_inventoryHidden = true;
		}

		private void ShowInventory()
		{
			AnimateOpenInventory();
			_inventoryHidden = false;
		}

		private void CloseInventoryResponse(object sender, InteractionEventArgs args)
		{
			CloseInventory();
		}

		private void HideInventoryResponse(object sender, InteractionEventArgs args)
		{
			if (_inventoryHidden)
			{
				ShowInventory();
			}
			else
			{
				HideInventory();
			}
		}

		private void AnimateOpenInventory()
		{
			_inventorySequence?.Kill();
			_inventorySequence.Append(_rect.DOAnchorPos(_openAnchorPos, _openTime)).Join(_rect.DOSizeDelta(_openSizeDelta, _openTime));
		}

		private void AnimateCloseInventory()
		{
			_inventorySequence?.Kill();
			_inventorySequence.Append(_rect.DOAnchorPos(_closeAnchorPos, _closeTime)).Join(_rect.DOSizeDelta(_closeSizeDelta, _closeTime));
		}
	}
}
