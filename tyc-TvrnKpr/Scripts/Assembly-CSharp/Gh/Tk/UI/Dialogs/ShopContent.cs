using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Gh.UI;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class ShopContent : LarderSideInfoContent
	{
		[SerializeField]
		private ScrollableUIView _scrollView;

		[SerializeField]
		private GameObject _pickableUIElementPrefab;

		private IEnumerable<Tuple<UIController.PickableStock, GameItemTemplate>> _pickableStock;

		private Dictionary<string, PickableUIElement> _pickableUIElements;

		private static string[] CategoryOrder;

		[SerializeField]
		private GameObject _categoryHeaderPrefab;

		private Dictionary<string, GameObject> _categoryHeaders;

		private int _totalCost;

		private int _itemsCost;

		private int _fixedRateCost;

		private int _maxCost;

		public int TotalCost => 0;

		public int ItemsCost => 0;

		public int FixedRateCost
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int MaxCost
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public event EventHandler CostsChanged
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

		public void ResetShopState()
		{
		}

		protected override void Awake()
		{
		}

		protected void SetShopCategory(string category)
		{
		}

		protected override void ClearUIElements()
		{
		}

		private string GetCategory(GameItemTemplate template)
		{
			return null;
		}

		private static string GetCategoryI18nNameKey(string category)
		{
			return null;
		}

		public override void UpdateInfo()
		{
		}

		private void UpdateItemCost()
		{
		}

		private void OnAmountChanged(object sender, EventArgs<int> e)
		{
		}

		private void UpdateCanAffordStates()
		{
		}

		public void UpdateInfo(IEnumerable<UIController.PickableStock> pickableStock)
		{
		}

		public IEnumerable<Tuple<UIController.PickableStock, int>> GetAmounts()
		{
			return null;
		}

		public bool IsAnyItemChosen()
		{
			return false;
		}
	}
}
