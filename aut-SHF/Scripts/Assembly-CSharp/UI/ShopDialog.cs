using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
	public class ShopDialog : BaseDialog
	{
		public TMP_Text materialPoint;

		public ChoiceMenuShopButton developMenu;

		public ChoiceMenuShopButton upgradeMenu;

		[Header("詳細")]
		public GameObject descriptionGroup;

		public AnimatedImage gifPlayer;

		public ChoiceMenuButtonBase toolTip;

		public RectTransform artifactContent;

		public ChoiceMenuShopButton choiceShopPrefab;

		private List<ChoiceMenuShopButton> _choiceShopButtons;

		private ChoiceMenuShopButton CreateChild()
		{
			return null;
		}

		public override void Init()
		{
		}

		public override void Open()
		{
		}

		public void UpdateMaterialPoint()
		{
		}

		public void CreateShopButton()
		{
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
