using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public class InGameShopItem : MonoBehaviour
	{
		public class InGameShopItemData
		{
			public InGameShopDialog.eInGameShopCategory category;

			public string iconPath;

			public int price;

			public int priceCountUp;

			public int purchaseCount;

			public bool isFree;

			public string archiveId;

			public List<string> param1;

			public List<string> param2;
		}

		[SerializeField]
		private GameObject starArea;

		[SerializeField]
		private List<GameObject> starOff;

		[SerializeField]
		private List<GameObject> starOn;

		[SerializeField]
		private Image iconImage;

		[SerializeField]
		private TMP_Text priceText;

		[SerializeField]
		private Color priceNomalColor;

		[SerializeField]
		private Color priceFreeColor;

		[SerializeField]
		private Color priceNotEnoughColor;

		[SerializeField]
		private Button button;

		[SerializeField]
		private GameObject cursorObj;

		[SerializeField]
		private GameObject decideCursor;

		private InGameShopItemData data;

		private UnityAction<InGameShopItem> onClickAction;

		private Action onPadSelectAction;

		private bool isOn;

		private bool soldout;

		public InGameShopItemData ItemData => null;

		public bool IsOn => false;

		public bool Soldout => false;

		public int PurchaseCount => 0;

		public bool IsFree => false;

		public bool IsLoop => false;

		public void Init(InGameShopItemData data, UnityAction<InGameShopItem> onClickAction, Action onPadSelectAction)
		{
		}

		public void UpdatePrice(bool? isUseFree = null)
		{
		}

		public void Purchase()
		{
		}

		public void SetPurchaseCount(int count)
		{
		}

		public int GetPrice()
		{
			return 0;
		}

		private void LoadIcon()
		{
		}

		private void InitStar()
		{
		}

		private void SetStar(int max, int level)
		{
		}

		public void OnClickButton(bool isOn)
		{
		}

		public void OnPadSelect()
		{
		}

		public void SetIsOn(bool isOn)
		{
		}
	}
}
