using System;
using Restory.Gameplay.DetectableObjects;
using Restory.Gameplay.Tooltips;
using Restory.Utils;
using UnityEngine;

namespace Restory.Gameplay.Equipment.CashRegisters
{
	public class CashRegister : MonoBehaviour, IDetectableObject
	{
		[SerializeField]
		private ClickableTrigger clickableTrigger;

		[SerializeField]
		private TooltipIndicator tooltipIndicator;

		[SerializeField]
		private CashRegisterVisualizer visualizer;

		[SerializeField]
		private CashDrawerState initialCashDrawerState = CashDrawerState.Closed;

		private CashDrawerState currentCashDrawerState;

		public bool CanBeDetected
		{
			set
			{
				clickableTrigger.enabled = value;
			}
		}

		public CashDrawerState CurrentState
		{
			get
			{
				return currentCashDrawerState;
			}
			private set
			{
				if (value != currentCashDrawerState)
				{
					currentCashDrawerState = value;
					this.OnCurrentStateChanged?.Invoke();
				}
			}
		}

		public event Action OnCurrentStateChanged;

		public event Action OnMoneyAdded;

		private void OnEnable()
		{
			clickableTrigger.OnClick += ResolveOnClick;
		}

		private void OnDisable()
		{
			clickableTrigger.OnClick -= ResolveOnClick;
		}

		public void ToggleIndicator(bool isActive)
		{
			tooltipIndicator.gameObject.SetActive(isActive);
		}

		public void ProcessAddingMoneyToRegister(int moneyAmount)
		{
			this.OnMoneyAdded?.Invoke();
		}

		public void SetCashDrawerState(CashDrawerState state, bool animate)
		{
			if (state != currentCashDrawerState)
			{
				currentCashDrawerState = state;
				if (visualizer.MonoShellExists())
				{
					visualizer.SetCashDrawerState(currentCashDrawerState, animate);
				}
			}
		}

		public bool SwitchCashDrawerState(bool animate)
		{
			CurrentState = currentCashDrawerState switch
			{
				CashDrawerState.Open => CashDrawerState.Closed, 
				CashDrawerState.Closed => CashDrawerState.Open, 
				_ => initialCashDrawerState, 
			};
			if (visualizer.MonoShellExists())
			{
				visualizer.SetCashDrawerState(currentCashDrawerState, animate);
			}
			return true;
		}

		private void ResolveOnClick()
		{
			SwitchCashDrawerState(animate: true);
		}
	}
}
