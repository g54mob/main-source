using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using I18n;
using TMPro;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class PickableUIElement : BuyButton3DUIView
	{
		[SerializeField]
		private TextMeshProI18n _name;

		[SerializeField]
		private Transform _preview;

		[SerializeField]
		private BaseInteractable3DUIView _previewInteractable;

		[SerializeField]
		private Stars3DUIView _stars;

		[SerializeField]
		private TextMeshPro _availableAmountText;

		[SerializeField]
		private TextMeshPro _amountText;

		[SerializeField]
		private Transform _amountSelectedHighlight;

		[SerializeField]
		private TextMeshPro _priceText;

		[SerializeField]
		private Transform _priceTag;

		[SerializeField]
		private Transform _cantAffordPriceTag;

		[SerializeField]
		private TextMeshPro _cantAffordPriceText;

		[SerializeField]
		private BaseInteractable3DUIView _plusButton;

		[SerializeField]
		private Button3DUIView _cantAffordPlusButton;

		[SerializeField]
		private BaseInteractable3DUIView _minusButton;

		[SerializeField]
		private Transform _plusMinusButtonBacker;

		[SerializeField]
		private TraitsContainer3DUIView _traitsContainer;

		[SerializeField]
		private GameItemDemand3DUIView _demandUI;

		[SerializeField]
		private MarketTrendVisual3DUIView _priceTrendVisual;

		[SerializeField]
		private MarketTrendVisual3DUIView _amountTrendVisual;

		private int _amount;

		private UIController.PickableStock _pickableStock;

		private Dictionary<Color, MaterialColorVisualizer> _materialColorVisualizers;

		public Color gameItemDisabledColour;

		public Color starsDisabledColour;

		private GameItemTemplate _itemTemplate;

		private GameItem _spawnedItem;

		public int Amount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public UIController.PickableStock Stock
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override bool IsEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public GameItemTemplate ItemTemplate
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override bool CanAfford
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public event EventHandler<EventArgs<int>> AmountChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void OnSettingsChanged(object sender, string s)
		{
		}

		private void UpdateIsHoveredChanged(object sender, EventArgs<bool> e)
		{
		}

		private void InvalidateAvailableAmountText()
		{
		}

		private void UpdatePriceLabel()
		{
		}

		private void ResetDynamicVisualisers()
		{
		}

		private void ApplyDisabledVisualizerToGameObject(GameObject visual, Color disabledColor, float smoothness = -1f, float metallic = -1f)
		{
		}

		private void UpdateInteractableStates()
		{
		}

		private void UpdateIsEnabledState()
		{
		}

		private TooltipData GetTooltipDataForItem()
		{
			return null;
		}

		protected override TooltipData GetTooltipDataInternal()
		{
			return null;
		}
	}
}
