using System;
using CTS.Core;
using CTS.Furnitures;
using CTS.UI;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS.BBT
{
	public class UIFurnitureSellButton : MonoSingleton<UIFurnitureSellButton>
	{
		[SerializeField]
		[Required(null)]
		private Button _button;

		[SerializeField]
		[Required(null)]
		private CanvasGroupController _canvasGroupController;

		[SerializeField]
		private TMP_Text _sheelPriceText;

		public static event Action FurnitureSellButtonClicked;

		private void OnEnable()
		{
			_canvasGroupController.QuickHide();
			_button.onClick.AddListener(OnButtonClicked);
			FurniturePlacer.FurniturePickedUp += OnFurniturePickedUp;
		}

		private void OnDisable()
		{
			_canvasGroupController.QuickHide();
			_button.onClick.RemoveListener(OnButtonClicked);
			FurniturePlacer.FurniturePickedUp -= OnFurniturePickedUp;
		}

		private void OnFurniturePickedUp(Furniture p_furniture)
		{
			if ((bool)p_furniture && p_furniture.Purchased)
			{
				_canvasGroupController.QuickShow();
				_sheelPriceText.text = MoneyHandler.GetToMoneyStringFormat(p_furniture.GetResellPriceWithSlots());
			}
			else
			{
				_canvasGroupController.QuickHide();
			}
		}

		private void OnButtonClicked()
		{
			UIFurnitureSellButton.FurnitureSellButtonClicked?.Invoke();
		}

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}
	}
}
