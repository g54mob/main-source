using TMPro;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class UI_CashRegisterProduct : MonoBehaviour
	{
		[Header("UI Components")]
		[SerializeField]
		private SimulatorText m_productNameText;

		[SerializeField]
		private TextMeshProUGUI m_priceText;

		[SerializeField]
		private TextMeshProUGUI m_unitText;

		[SerializeField]
		private TextMeshProUGUI m_totalText;

		private float m_price;

		public void Init(BoughtProductInfo info, int quantity)
		{
			m_productNameText.SetTerm(info.Data.NameTerm);
			m_price = info.Price;
			m_priceText.text = m_price.ToStringMoneyFormat();
			m_unitText.text = quantity.ToString();
			m_totalText.text = ((float)quantity * m_price).ToStringMoneyFormat();
		}

		public void UpdateUnitCount(int count)
		{
			m_unitText.text = count.ToString();
			m_totalText.text = ((float)count * m_price).ToStringMoneyFormat();
		}
	}
}
