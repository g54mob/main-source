using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMODUnity;
using OUSystems.Basics.Effects;
using UnityEngine;

public class MagicMarket : BuildingBehaviour
{
	[CompilerGenerated]
	private sealed class _003CHandleDispenseItems_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MagicMarket _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CHandleDispenseItems_003Ed__41(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[SerializeField]
	private PaymentCollector _paymentCollector;

	public MagicMarketPurchaseAttempt MarketPurchaseAttempt;

	public MagicMarketUIPurchase MarketPurchaseUI;

	public MagicMarketUIDealSelect MarketDealSelectUI;

	public MagicMarketUITimer MarketTimerUI;

	[Header("Deals")]
	public MagicMarketDealPool DealPool;

	public List<MagicMarketDeal> DealOffers;

	public float SpecialChance;

	public float SpecialChanceModifier;

	[Header("Timer")]
	public float DefaultTimer;

	public float InitialTimer;

	public float Timer;

	private float _timerRateModifier;

	[Header("Output")]
	public List<ItemStack> ItemsToDispense;

	public ShakeReceiver ItemDispenseShakeReceiver;

	public Transform ItemDispenseSpawnPos;

	public float ItemDispenseDir;

	public float ItemDispenseDirRand;

	public float ItemDispenseSendDistance;

	public float ItemDispenseTime;

	public float ItemDispenseShake;

	public float ItemFloatDuration;

	public ItemType CurrencyType;

	[SerializeField]
	private EventReference _completeSound;

	[SerializeField]
	private EventReference _currencySound;

	[SerializeField]
	private EventReference _itemSound;

	public bool TrackingPurchase => false;

	public override void SetBuilding(Building building)
	{
	}

	public IEnumerable<ItemStack> GetStorageItemsForDeconstruction()
	{
		return null;
	}

	public void AddSpecialChance(float chance)
	{
	}

	public override void Initiate()
	{
	}

	public void FigureOutNextAction()
	{
	}

	public void StartDealSelect()
	{
	}

	public bool CanShowDeal(MagicMarketDealTemplate temp)
	{
		return false;
	}

	public void OnSelectDeal(MagicMarketDeal deal)
	{
	}

	public void ClearDeals()
	{
	}

	public void AddWaitTimeRateModifier(float modifier)
	{
	}

	public void SetWaitTime(float modifier)
	{
	}

	private void Update()
	{
	}

	public void OnDealFulfilled()
	{
	}

	[IteratorStateMachine(typeof(_003CHandleDispenseItems_003Ed__41))]
	public IEnumerator HandleDispenseItems()
	{
		return null;
	}

	public void CreateDispenseItem()
	{
	}
}
