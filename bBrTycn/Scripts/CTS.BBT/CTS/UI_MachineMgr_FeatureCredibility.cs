using CTS.BBT;
using CTS.Core;
using CTS.UI;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CTS
{
	public class UI_MachineMgr_FeatureCredibility : UI_MachineMgr_MachinePanelFeature
	{
		[SerializeField]
		private ClickAndHoldButton _plusButton;

		[SerializeField]
		private ClickAndHoldButton _minusButton;

		[SerializeField]
		private TMP_Text _countText;

		[SerializeField]
		private InputActionReference _multiAddInput;

		private readonly LockToggle _plusLock = new LockToggle();

		private readonly LockToggle _minusLock = new LockToggle();

		protected override void OnAwake()
		{
			base.OnAwake();
			_plusButton.HeldTick += OnPlusButtonTick;
			_minusButton.HeldTick += OnMinusButtonTick;
			_plusLock.Add(_plusButton);
			_minusLock.Add(_minusButton);
		}

		protected void OnDestroy()
		{
			_plusButton.HeldTick -= OnPlusButtonTick;
			_minusButton.HeldTick -= OnMinusButtonTick;
		}

		private void OnMinusButtonTick()
		{
			AddCredibility(-1);
		}

		private void OnPlusButtonTick()
		{
			AddCredibility(1);
		}

		private void AddCredibility(int value)
		{
			if (_multiAddInput.action.inProgress)
			{
				value *= 10;
			}
			if (base._furniture is IBodyDisposalMachine bodyDisposalMachine)
			{
				bodyDisposalMachine.MachineCredibility.SetCredibility(bodyDisposalMachine.MachineCredibility.Credibility + value);
			}
		}

		public override bool CanBeDisplayedForFurniture(FurnitureInteractor furniture)
		{
			return furniture is IBodyDisposalMachine;
		}

		protected override void OnFurnitureSet(FurnitureInteractor furniture)
		{
			if (furniture is IBodyDisposalMachine bodyDisposalMachine)
			{
				bodyDisposalMachine.MachineCredibility.CredibilityChanged += OnCredibilityChanged;
			}
		}

		protected override void OnFurnitureUnset(FurnitureInteractor furniture)
		{
			if (furniture is IBodyDisposalMachine bodyDisposalMachine)
			{
				bodyDisposalMachine.MachineCredibility.CredibilityChanged -= OnCredibilityChanged;
			}
		}

		protected override void OnRepaint()
		{
			if (base._furniture is IBodyDisposalMachine bodyDisposalMachine)
			{
				int credibility = bodyDisposalMachine.MachineCredibility.Credibility;
				_plusLock.SetLock(credibility >= 100);
				_minusLock.SetLock(credibility <= 1);
				_countText.text = credibility.ToString();
			}
		}

		private void OnCredibilityChanged()
		{
			OnRepaint();
		}
	}
}
