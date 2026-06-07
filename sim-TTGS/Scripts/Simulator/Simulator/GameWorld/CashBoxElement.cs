using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class CashBoxElement : MonoBehaviour, ISensable
	{
		[Header("Components")]
		[SerializeField]
		private CashBox m_cashBox;

		[SerializeField]
		private Collider m_collider;

		[SerializeField]
		private Outline m_outline;

		[SerializeField]
		private CashAmount m_cashAmount;

		[SerializeField]
		private CashBoxElementInputHint m_inputHint;

		public ECashAmount CashAmount => m_cashAmount.Get();

		private void Start()
		{
			if (m_inputHint != null)
			{
				RefreshInputHint();
			}
		}

		private void OnEnable()
		{
			m_cashBox.Opened += OnCashBoxOpened;
			CashRegisterWorkshop.OnAddChangeReturned += OnAddChange;
			CashRegisterWorkshop.OnRemoveChangeReturned += OnRemoveChange;
			CashRegisterWorkshop.ClientCheckedOut += OnClientCheckedOut;
			GameplayApplicationOptions.Currency.OnValueChanged += OnCurrentValueChanged;
		}

		private void OnDisable()
		{
			m_cashBox.Opened -= OnCashBoxOpened;
			CashRegisterWorkshop.OnAddChangeReturned -= OnAddChange;
			CashRegisterWorkshop.OnRemoveChangeReturned -= OnRemoveChange;
			CashRegisterWorkshop.ClientCheckedOut -= OnClientCheckedOut;
			GameplayApplicationOptions.Currency.OnValueChanged -= OnCurrentValueChanged;
		}

		public bool CanBeSensed()
		{
			if (m_cashBox.IsOpen)
			{
				return World.PlayerController.Context == EControllerContext.REGISTER;
			}
			return false;
		}

		public void OnSensed()
		{
			m_outline.enabled = true;
			if (m_inputHint != null)
			{
				m_inputHint.enabled = true;
			}
		}

		public void OnUnsensed()
		{
			m_outline.enabled = false;
			if (m_inputHint != null)
			{
				m_inputHint.enabled = false;
			}
		}

		private void OnCashBoxOpened(bool open)
		{
			m_collider.enabled = open;
		}

		private void OnCurrentValueChanged(GameplayApplicationOptions.ECurrency currency)
		{
			RefreshInputHint();
		}

		private void RefreshInputHint()
		{
			if (!(m_inputHint == null))
			{
				InputHint.Data[] array = m_inputHint.Datas.ToArray();
				for (int i = 0; i < array.Length; i++)
				{
					InputHint.Data data = array[i];
					data.formatArgs = m_cashAmount.Get().Name();
					array[i] = data;
				}
				m_inputHint.SetDatas(array);
			}
		}

		private void OnAddChange(ECashAmount cashAmount)
		{
			if (cashAmount == CashAmount)
			{
				m_inputHint.AddFlagsAndRefreshInputHint(CashBoxElementInputHint.EActionStates.REMOVE);
			}
		}

		private void OnRemoveChange(ECashAmount cashAmount, bool hasRemainingChange)
		{
			if (cashAmount == CashAmount && !hasRemainingChange)
			{
				m_inputHint.RemoveFlagsAndRefreshInputHint(CashBoxElementInputHint.EActionStates.REMOVE);
			}
		}

		private void OnClientCheckedOut(List<Product> products, float totalCost)
		{
			OnRemoveChange(CashAmount, hasRemainingChange: false);
		}
	}
}
