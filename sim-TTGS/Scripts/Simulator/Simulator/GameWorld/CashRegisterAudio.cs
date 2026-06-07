using System;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class CashRegisterAudio : MonoBehaviour
	{
		[SerializeField]
		private CashRegister m_cashRegister;

		private void OnEnable()
		{
			m_cashRegister.Workshop.OnProductInteractedEvent += OnProductInteracted_PlaySound;
			m_cashRegister.Workshop.OnChangeReturned += OnChangeReturned_PlaySound;
			m_cashRegister.Workshop.OnCompleteCheckoutEvent += OnCompleteCheckout;
			m_cashRegister.Workshop.CashBox.Opened += OnCashBoxToggled_PlaySound;
			m_cashRegister.Workshop.CardMachine.Interface.OnButtonClicked += OnCardMachineButtonClicked_PlaySound;
		}

		private void OnDisable()
		{
			m_cashRegister.Workshop.OnProductInteractedEvent -= OnProductInteracted_PlaySound;
			m_cashRegister.Workshop.OnChangeReturned -= OnChangeReturned_PlaySound;
			m_cashRegister.Workshop.OnCompleteCheckoutEvent -= OnCompleteCheckout;
			m_cashRegister.Workshop.CashBox.Opened -= OnCashBoxToggled_PlaySound;
			m_cashRegister.Workshop.CardMachine.Interface.OnButtonClicked -= OnCardMachineButtonClicked_PlaySound;
		}

		private void OnCashBoxToggled_PlaySound(bool open)
		{
			if (open)
			{
				AudioManager.PlaySingleEvent(WorldAudioSettings.CashRegisterOpen);
			}
		}

		private void OnProductInteracted_PlaySound(Product _)
		{
			AudioManager.PlaySingleEvent(WorldAudioSettings.CashRegisterArticle);
		}

		private void OnChangeReturned_PlaySound(ECashAmount obj)
		{
			AudioManager.PlaySingleEvent(obj.IsBill() ? WorldAudioSettings.CashRegisterBills : WorldAudioSettings.CashRegisterCoins);
		}

		private void OnCompleteCheckout(EPaymentMethod paymentMethod)
		{
			switch (paymentMethod)
			{
			case EPaymentMethod.CASH:
				AudioManager.PlaySingleEvent(WorldAudioSettings.CashRegisterCashValidate);
				break;
			case EPaymentMethod.CARD:
				AudioManager.PlaySingleEvent(WorldAudioSettings.CashRegisterCardMachineValidate);
				break;
			default:
				throw new ArgumentOutOfRangeException("paymentMethod", paymentMethod, null);
			}
		}

		private void OnCardMachineButtonClicked_PlaySound()
		{
			AudioManager.PlaySingleEvent(WorldAudioSettings.CashRegisterCardMachineButtonClick);
		}
	}
}
