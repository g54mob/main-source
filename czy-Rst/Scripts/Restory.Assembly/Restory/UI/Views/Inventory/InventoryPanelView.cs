using System;
using Restory.UserInterface.CommonElements;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Restory.UI.Views.Inventory
{
	public sealed class InventoryPanelView : UIBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private TextMeshProUGUI selectedCountText;

		[SerializeField]
		private GUI_AnimatedButtonView closeButton;

		[SerializeField]
		private GUI_AnimatedButtonView dropButton;

		[SerializeField]
		private InventoryPanelFilterView filters;

		[SerializeField]
		private InventoryItemsView items;

		private int selectedCount;

		private bool isVisibility = true;

		public int SelectedCount
		{
			get
			{
				return selectedCount;
			}
			set
			{
				selectedCount = value;
				UpdateSelectedCountText();
			}
		}

		public bool Visible => isVisibility;

		public bool DropButtonVisibility
		{
			set
			{
				if (!value)
				{
					if (!dropButton.IsActive)
					{
						dropButton.gameObject.SetActive(value: false);
					}
					return;
				}
				if (dropButton.IsActive)
				{
					dropButton.gameObject.SetActive(value: false);
				}
				dropButton.gameObject.SetActive(value: true);
			}
		}

		public InventoryPanelFilterView Filters => filters;

		public InventoryItemsView Items => items;

		public event Action<InventoryPanelView> CloseClick;

		public event Action<InventoryPanelView> DropClick;

		public event Action<InventoryPanelView> PointerEnter;

		public event Action<InventoryPanelView> PointerExit;

		protected override void OnEnable()
		{
			closeButton.OnAnimationStart += OnCloseClick;
			dropButton.OnAnimationStart += OnDropClickStart;
			UpdateSelectedCountText();
		}

		protected override void OnDisable()
		{
			closeButton.OnAnimationStart -= OnCloseClick;
			dropButton.OnAnimationStart -= OnDropClickStart;
		}

		public void Show()
		{
			if (!isVisibility)
			{
				isVisibility = true;
				UpdateCanvasGroup();
			}
		}

		public void Hide()
		{
			if (isVisibility)
			{
				isVisibility = false;
				UpdateCanvasGroup();
			}
		}

		private void UpdateCanvasGroup()
		{
			canvasGroup.alpha = (isVisibility ? 1 : 0);
			canvasGroup.blocksRaycasts = isVisibility;
			canvasGroup.interactable = isVisibility;
		}

		private void UpdateSelectedCountText()
		{
			selectedCountText.text = $"Selected: {selectedCount}";
		}

		private void OnCloseClick()
		{
			this.CloseClick?.Invoke(this);
		}

		private void OnDropClickStart()
		{
			this.DropClick?.Invoke(this);
		}

		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
			this.PointerEnter?.Invoke(this);
		}

		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
			this.PointerExit?.Invoke(this);
		}

		public void Clear()
		{
			this.CloseClick = null;
			this.DropClick = null;
			this.PointerEnter = null;
			this.PointerExit = null;
			closeButton.OnAnimationStart -= OnCloseClick;
			dropButton.OnAnimationStart -= OnDropClickStart;
			selectedCountText.text = string.Empty;
			selectedCount = 0;
		}
	}
}
