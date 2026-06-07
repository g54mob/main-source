using Data.FactoryFloor.Resources;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.OperatorUIs
{
	public class InputResourceUI : MonoBehaviour
	{
		[SerializeField]
		private Image _resourceImage;

		[SerializeField]
		private TextMeshProUGUI _totalAmountText;

		[SerializeField]
		private TextMeshProUGUI _amountText;

		[SerializeField]
		private ResourceInfoPanelContent _infoPanel;

		public void SetResource(NonShapeResourceDataSO resourceDataSo)
		{
			_resourceImage.sprite = resourceDataSo.Sprite;
			_infoPanel.UpdateContent(resourceDataSo);
		}

		public virtual void SetAmount(int amount, string totalAmount)
		{
			string text = ((amount == 0) ? $"<color=red>{amount}</color>" : amount.ToString());
			_amountText.SetText(text);
			_totalAmountText.SetText(totalAmount);
		}
	}
}
