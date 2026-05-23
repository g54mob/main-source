using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
	public class RouteShopDialog : BaseDialog
	{
		public TMP_Text upgradePointText;

		public ChoiceMenuShopButton choiceShopPrefab;

		private List<ChoiceMenuShopButton> _choiceShopButtons;

		[Header("詳細")]
		public GameObject descriptionGroup;

		public AnimatedImage gifPlayer;

		public ChoiceMenuButtonBase toolTip;

		public RectTransform artifactContent;

		public override void Init()
		{
		}

		public override void Open()
		{
		}

		public void UpdateUpgradePoint()
		{
		}

		public void CreateShopButton()
		{
		}

		public void CreateNew(ShopData shopdata)
		{
		}

		public void UpdateShop(ShopData nowShop, ShopData updateShop)
		{
		}

		private ChoiceMenuShopButton CreateChild()
		{
			return null;
		}

		public void BuyButtonAction(ShopData shopData)
		{
		}

		public void ShopButtonUpdate()
		{
		}

		public override void Back()
		{
		}
	}
}
