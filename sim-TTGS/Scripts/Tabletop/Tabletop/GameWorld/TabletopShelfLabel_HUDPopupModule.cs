using Simulator;
using Simulator.GameWorld;
using UnityEngine;
using UnityEngine.UI;

namespace Tabletop.GameWorld
{
	public class TabletopShelfLabel_HUDPopupModule : ShelfLabel_HUDPopupModule
	{
		[Header("Tabletop")]
		[SerializeField]
		private SimulatorText m_productNameText;

		[SerializeField]
		private Button m_infoButton;

		protected override void UpdateContent()
		{
			m_productNameText.SetTerm(base.CurrentData.NameTerm);
			bool flag = base.CurrentPrice > 0f;
			m_averagePriceText.text = base.AveragePrice.ToStringMoneyFormat();
			m_marketPriceText.text = PriceManager.GetProductMarketPrice(base.CurrentData.UID).ToStringMoneyFormat();
			m_currentPriceInputField.text = (flag ? base.CurrentPrice.ToString("0.00") : "- - -");
			float num = base.CurrentPrice - base.AveragePrice;
			m_marginText.text = ((!flag) ? "- -" : (((num >= 0f) ? "+" : "") + num.ToStringMoneyFormat()));
			m_marginText.color = ((!flag) ? Color.white : ((num >= 0f) ? Color.green : Color.red));
			m_validateButton.interactable = flag;
			m_increasePriceButton.interactable = flag;
			m_decreasePriceButton.interactable = flag;
			m_roundPriceButton.interactable = flag;
		}
	}
}
