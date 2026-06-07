using System;
using System.Globalization;
using Simulator;
using Simulator.GameWorld;
using TMPro;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public class TabletopDayEnd_HUDPopupModule : DayEnd_HUDPopupModule
	{
		[Header("Tabletop Shop")]
		[SerializeField]
		private TextMeshProUGUI m_miniaturesSoldText;

		[SerializeField]
		private TextMeshProUGUI m_miniaturesIncomeText;

		[SerializeField]
		private TextMeshProUGUI m_paintTimeText;

		[SerializeField]
		private TextMeshProUGUI m_paintIncomeText;

		[SerializeField]
		private TextMeshProUGUI m_warGameTimeText;

		[SerializeField]
		private TextMeshProUGUI m_warGameIncomeText;

		[Header("Tabletop Clients")]
		[SerializeField]
		private TextMeshProUGUI m_clientPaintingText;

		[SerializeField]
		private TextMeshProUGUI m_clientWarGameText;

		[SerializeField]
		private TextMeshProUGUI m_eventSubscriptionsText;

		protected override void UpdateContent()
		{
			base.UpdateContent();
			TabletopDayScoreTracker tabletopDayScoreTracker = TabletopWorld.TabletopDayScoreTracker;
			m_miniaturesSoldText.text = "+" + tabletopDayScoreTracker.MiniaturesSold;
			m_miniaturesIncomeText.text = "+" + tabletopDayScoreTracker.MiniaturesIncome.ToStringMoneyFormat();
			TimeSpan timeSpan = TimeSpan.FromSeconds(tabletopDayScoreTracker.PaintTime);
			string text = ((timeSpan.TotalHours >= 1.0) ? "hh\\:mm\\:ss" : "mm\\:ss");
			m_paintTimeText.text = "+" + timeSpan.ToString(text);
			m_paintIncomeText.text = "+" + tabletopDayScoreTracker.PaintIncome.ToStringMoneyFormat();
			m_warGameTimeText.text = "+" + tabletopDayScoreTracker.WargameTime.ToString(CultureInfo.InvariantCulture);
			m_warGameIncomeText.text = "+" + tabletopDayScoreTracker.WargameIncome.ToStringMoneyFormat();
			m_clientPaintingText.text = "+" + tabletopDayScoreTracker.ClientPainting;
			m_clientWarGameText.text = "+" + tabletopDayScoreTracker.ClientWargame;
			m_eventSubscriptionsText.text = "+" + tabletopDayScoreTracker.EventSubscriptions;
			if (TransientManager<InputManager>.Instance.CurrentDevice == EInputDeviceType.GAMEPAD)
			{
				Debug.Log("Can't use day end with gamepad");
			}
		}
	}
}
