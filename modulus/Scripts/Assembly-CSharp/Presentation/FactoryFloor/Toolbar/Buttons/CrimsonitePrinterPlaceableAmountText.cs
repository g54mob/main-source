using Data.FactoryFloor;
using Data.Operator;
using Data.Variables;
using TMPro;
using UnityEngine;

namespace Presentation.FactoryFloor.Toolbar.Buttons
{
	public class CrimsonitePrinterPlaceableAmountText : MonoBehaviour
	{
		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private FactoryObjectData _crimsonitePrinterData;

		[SerializeField]
		private IntVariableSO _crimsonitePrinterMaxAmountSO;

		[SerializeField]
		private TextMeshProUGUI _amountText;

		private void OnEnable()
		{
			_crimsonitePrinterMaxAmountSO.ValueChanged += UpdateAmountText;
			_factoryLayer.OnObjectsInLayerChanged += UpdateAmountText;
			UpdateAmountText();
		}

		private void OnDisable()
		{
			_crimsonitePrinterMaxAmountSO.ValueChanged -= UpdateAmountText;
			_factoryLayer.OnObjectsInLayerChanged -= UpdateAmountText;
		}

		private void UpdateAmountText(FactoryLayer _)
		{
			UpdateAmountText();
		}

		private void UpdateAmountText(int _)
		{
			UpdateAmountText();
		}

		private void UpdateAmountText()
		{
			int value = _crimsonitePrinterMaxAmountSO.Value;
			int count = _factoryLayer.GetObjectsFromData(_crimsonitePrinterData).Count;
			int num = value - count;
			string text = ((num == 0) ? "<color=red>0</color>" : num.ToString());
			_amountText.SetText(text);
		}
	}
}
