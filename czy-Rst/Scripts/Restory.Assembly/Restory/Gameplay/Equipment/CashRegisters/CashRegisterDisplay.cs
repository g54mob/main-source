using DG.Tweening;
using Helpers.Extensions;
using Restory.Gameplay.Inventory;
using Restory.Utils;
using TMPro;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment.CashRegisters
{
	public class CashRegisterDisplay : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI moneyText;

		[SerializeField]
		private string moneyFormat = "¥{0}";

		[SerializeField]
		[Min(0f)]
		private float duration = 0.5f;

		private int currentMoney;

		private Sequence moneyChangeSequence;

		private Wallet wallet;

		private TweenSequencesService sequencesService;

		[Inject]
		private void Construct(Wallet wallet, TweenSequencesService sequencesService)
		{
			this.wallet = wallet;
			this.sequencesService = sequencesService;
			if (base.isActiveAndEnabled)
			{
				wallet.OnMoneyAmountChanged += ResolveOnMoneyAmountChanged;
				UpdateMoneyDisplay(instantly: true);
			}
		}

		private void OnEnable()
		{
			if (wallet != null)
			{
				wallet.OnMoneyAmountChanged += ResolveOnMoneyAmountChanged;
				UpdateMoneyDisplay(instantly: true);
			}
		}

		private void OnDisable()
		{
			if (wallet != null)
			{
				wallet.OnMoneyAmountChanged -= ResolveOnMoneyAmountChanged;
			}
			if (moneyChangeSequence != null)
			{
				sequencesService.Kill(moneyChangeSequence);
			}
		}

		private void UpdateMoneyDisplay(bool instantly)
		{
			if (moneyChangeSequence != null)
			{
				sequencesService.Kill(moneyChangeSequence);
			}
			if (instantly)
			{
				currentMoney = wallet.MoneyAvailable;
				if (moneyText != null)
				{
					moneyText.text = string.Format(moneyFormat, currentMoney);
				}
				return;
			}
			moneyChangeSequence = sequencesService.Create().Append(DOTween.To(() => currentMoney, delegate(int value)
			{
				currentMoney = value;
				if (moneyText != null)
				{
					moneyText.text = string.Format(moneyFormat, currentMoney.ToReadableString());
				}
			}, wallet.MoneyAvailable, duration));
		}

		private void ResolveOnMoneyAmountChanged()
		{
			UpdateMoneyDisplay(instantly: false);
		}
	}
}
