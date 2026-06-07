using Data.FactoryFloor.Resources;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.FactoryFloor.Toolbar
{
	public class ResourceUI : MonoBehaviour
	{
		[SerializeField]
		private Image _resourceImage;

		[SerializeField]
		private TextMeshProUGUI _nameText;

		[SerializeField]
		private TextMeshProUGUI _amountText;

		public void SetResource(NonShapeResourceDataSO resourceDataSo, string amount)
		{
			_resourceImage.sprite = resourceDataSo.Sprite;
			_nameText.SetText(LocalizationUtility.GetLocalizedText(resourceDataSo.NameLocaKey));
			_amountText.SetText(amount);
		}

		public void SetColor(Color color)
		{
			_nameText.color = color;
		}

		public void SetAmountColor(Color color)
		{
			_amountText.color = color;
		}
	}
}
