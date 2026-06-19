using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class LoanMenu : AnimatedMenuBase
	{
		[Serializable]
		public class ColorScheme
		{
			public Color BackgroundColor;

			public Color LoanAmountTextColor;

			public Color LoanAmountBackingColor;

			public Sprite ButtonSprite;
		}

		[SerializeField]
		private ColorScheme _availableScheme;

		[SerializeField]
		private ColorScheme _takenScheme;

		[SerializeField]
		private ColorScheme _unavailableScheme;

		[SerializeField]
		private Transform _listContent;

		[SerializeField]
		private GameObject _listItemPrefab;

		private LoanManager _loanManager;

		private FinanceManager _financeManager;

		private List<LoanListItem> _listItems = new List<LoanListItem>();

		public void Initialise(LoanManager loanManager, FinanceManager financeManager)
		{
			_loanManager = loanManager;
			_financeManager = financeManager;
			foreach (LoanOffer offer in loanManager.Offers)
			{
				LoanListItem loanListItem = _listItems.FirstOrDefault((LoanListItem item) => item.Offer == offer);
				if (loanListItem == null)
				{
					loanListItem = UnityEngine.Object.Instantiate(_listItemPrefab, _listContent, worldPositionStays: false).GetComponent<LoanListItem>();
					loanListItem.Initialise(offer, _financeManager, _loanManager);
					_listItems.Add(loanListItem);
				}
				RefreshItem(loanListItem);
			}
		}

		public override void OpenMenu()
		{
			base.OpenMenu();
			LoanManager loanManager = _loanManager;
			loanManager.OnLoanStateChanged = (Action<LoanOffer>)Delegate.Combine(loanManager.OnLoanStateChanged, new Action<LoanOffer>(RefreshOffer));
			FinanceManager financeManager = _financeManager;
			financeManager.OnBalanceUpdated = (Action<int>)Delegate.Combine(financeManager.OnBalanceUpdated, new Action<int>(OnBalanceUpdated));
		}

		public override void CloseMenu()
		{
			LoanManager loanManager = _loanManager;
			loanManager.OnLoanStateChanged = (Action<LoanOffer>)Delegate.Remove(loanManager.OnLoanStateChanged, new Action<LoanOffer>(RefreshOffer));
			FinanceManager financeManager = _financeManager;
			financeManager.OnBalanceUpdated = (Action<int>)Delegate.Remove(financeManager.OnBalanceUpdated, new Action<int>(OnBalanceUpdated));
			base.CloseMenu();
		}

		public override void Destroy()
		{
			if (_loanManager != null && _financeManager != null)
			{
				LoanManager loanManager = _loanManager;
				loanManager.OnLoanStateChanged = (Action<LoanOffer>)Delegate.Remove(loanManager.OnLoanStateChanged, new Action<LoanOffer>(RefreshOffer));
				FinanceManager financeManager = _financeManager;
				financeManager.OnBalanceUpdated = (Action<int>)Delegate.Remove(financeManager.OnBalanceUpdated, new Action<int>(OnBalanceUpdated));
			}
			base.Destroy();
		}

		public void Setup()
		{
			foreach (LoanOffer offer in _loanManager.Offers)
			{
				LoanListItem loanListItem = _listItems.FirstOrDefault((LoanListItem item) => item.Offer == offer);
				if (!(loanListItem == null))
				{
					RefreshItem(loanListItem);
				}
			}
		}

		private void OnBalanceUpdated(int balance)
		{
			foreach (LoanListItem listItem in _listItems)
			{
				listItem.RefreshUI();
			}
		}

		private void RefreshOffer(LoanOffer offer)
		{
			LoanListItem loanListItem = _listItems.FirstOrDefault((LoanListItem item) => item.Offer == offer);
			if (loanListItem != null)
			{
				RefreshItem(loanListItem);
			}
		}

		private void RefreshItem(LoanListItem listItem)
		{
			listItem.RefreshUI();
			if (listItem.Offer.Active)
			{
				listItem.ApplyScheme(_takenScheme);
			}
			else if (listItem.Offer.Available)
			{
				listItem.ApplyScheme(_availableScheme);
			}
			else
			{
				listItem.ApplyScheme(_unavailableScheme);
			}
		}
	}
}
