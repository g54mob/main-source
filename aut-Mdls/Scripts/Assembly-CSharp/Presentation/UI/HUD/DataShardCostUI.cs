using TMPro;
using UnityEngine;

namespace Presentation.UI.HUD
{
	public class DataShardCostUI : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _amountText;

		public void SetAmount(int amount)
		{
			_amountText.SetText(amount.ToString());
		}

		public void SetColor(Color color)
		{
			_amountText.color = color;
		}

		public void ResetColor()
		{
			_amountText.color = Color.white;
		}
	}
}
