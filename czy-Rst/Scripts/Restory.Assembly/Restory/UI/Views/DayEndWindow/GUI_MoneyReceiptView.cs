using System;
using System.Collections.Generic;
using System.Linq;
using Helpers.Extensions;
using Restory.Data.RegularPayments;
using Restory.Gameplay.Statistics;
using Restory.ObjectPools;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Restory.UI.Views.DayEndWindow
{
	public class GUI_MoneyReceiptView : MonoBehaviour
	{
		[Serializable]
		private class MadeRegularPaymentData
		{
			public string PaymentID;

			public string LocalizationKey;

			public int OrderInGUI;

			public int SingleBillSum;

			public int TimesPaid;
		}

		[SerializeField]
		private TMP_Text moneyEarnedFromCompletingWorkOrdersText;

		[SerializeField]
		private TMP_Text moneyEarnedFromCompletingEmailOrdersText;

		[SerializeField]
		private TMP_Text moneyEarnedFromSellingDevicesText;

		[SerializeField]
		private TMP_Text moneyBalanceChangeTodayText;

		[SerializeField]
		private TMP_Text currentMoneyBalanceText;

		[SerializeField]
		private Color positiveColor = Color.green;

		[SerializeField]
		private Color neutralColor = Color.black;

		[SerializeField]
		private Color negativeColor = Color.red;

		[SerializeField]
		private Transform paymentViewsParent;

		private PaymentGuisPool paymentViewsPool;

		[Inject]
		private void Construct(PaymentGuisPool paymentViewsPool)
		{
			this.paymentViewsPool = paymentViewsPool;
		}

		public void Init(MoneyReceiptData moneyReceiptData)
		{
			SetMoneyCountText(moneyEarnedFromCompletingWorkOrdersText, moneyReceiptData.MoneyEarnedFromCompletingWorkOrders);
			SetMoneyCountText(moneyEarnedFromCompletingEmailOrdersText, moneyReceiptData.MoneyEarnedFromCompletingEmailOrders);
			SetMoneyCountText(moneyEarnedFromSellingDevicesText, moneyReceiptData.MoneyEarnedFromSellingDevices);
			SetMoneyCountText(moneyBalanceChangeTodayText, moneyReceiptData.MoneyBalanceChangeToday);
			SetUpPurchasesViews(moneyReceiptData.Purchases);
			SetUpRegularPaymentsViews(moneyReceiptData.RegularPaymentsMade);
			currentMoneyBalanceText.text = moneyReceiptData.MoneyBalance.ToReadableString();
		}

		private void SetMoneyCountText(TMP_Text tmpText, int count)
		{
			string text = string.Empty;
			Color color = neutralColor;
			if (count <= 0)
			{
				if (count < 0)
				{
					text = "-";
					color = negativeColor;
				}
			}
			else
			{
				text = "+";
				color = positiveColor;
			}
			string text2 = Mathf.Abs(count).ToReadableString();
			tmpText.text = text + " ¥ " + text2;
			tmpText.color = color;
		}

		private void SetUpPurchasesViews(ICollection<Expense> purchases)
		{
			List<Expense> list = CollectionPool<List<Expense>, Expense>.Get();
			list.AddRange(purchases.OrderBy((Expense x) => x.Info.OrderInGUI).ToList());
			foreach (Expense item in list)
			{
				paymentViewsPool.Get<GUI_SinglePayment>(paymentViewsParent).SetUp(item.Info.NameLocalizationKey, item.Sum, negativeColor);
			}
			CollectionPool<List<Expense>, Expense>.Release(list);
		}

		private void SetUpRegularPaymentsViews(ICollection<RegularPaymentInfo> regularPaymentsMade)
		{
			List<MadeRegularPaymentData> value;
			using (CollectionPool<List<MadeRegularPaymentData>, MadeRegularPaymentData>.Get(out value))
			{
				foreach (RegularPaymentInfo item in regularPaymentsMade)
				{
					if ((bool)item && !TryToUpdateAlreadyExistingMadePaymentData(item, value))
					{
						value.Add(new MadeRegularPaymentData
						{
							PaymentID = item.ID,
							LocalizationKey = item.NameLocalizationKey,
							OrderInGUI = item.OrderInGUI,
							SingleBillSum = item.Sum,
							TimesPaid = 1
						});
					}
				}
				value = value.OrderBy((MadeRegularPaymentData x) => x.OrderInGUI).ToList();
				foreach (MadeRegularPaymentData item2 in value)
				{
					paymentViewsPool.Get<GUI_SinglePayment>(paymentViewsParent).SetUp(item2.LocalizationKey, item2.SingleBillSum * item2.TimesPaid, negativeColor);
				}
			}
		}

		private static bool TryToUpdateAlreadyExistingMadePaymentData(RegularPaymentInfo regularPaymentInfo, List<MadeRegularPaymentData> madePaymentsCollection)
		{
			foreach (MadeRegularPaymentData item in madePaymentsCollection)
			{
				if (item.PaymentID == regularPaymentInfo.ID)
				{
					item.TimesPaid++;
					return true;
				}
			}
			return false;
		}
	}
}
