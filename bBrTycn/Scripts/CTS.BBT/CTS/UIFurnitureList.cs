using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class UIFurnitureList : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroupController _canvasGroupController;

		[SerializeField]
		private float _animationDuration;

		[SerializeField]
		private CanvasGroupController _filterCanvasGroupController;

		[SerializeField]
		private CanvasGroupController _filterStyleCanvasGroupController;

		[SerializeField]
		private float _filterAnimationDuration;

		private void OnEnable()
		{
			FurnitureShop.FurnitureShopStatusChanged += ShowList;
		}

		private void OnDisable()
		{
			FurnitureShop.FurnitureShopStatusChanged -= ShowList;
		}

		private void ShowList(bool p_value)
		{
			_canvasGroupController.ShowCanvasGroup(p_value, _animationDuration);
			_filterCanvasGroupController.ShowCanvasGroup(p_value, _filterAnimationDuration);
			_filterStyleCanvasGroupController.ShowCanvasGroup(p_value, _filterAnimationDuration);
		}
	}
}
