using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MyBox;
using UnityEngine;
using __Project__.Scripts.Computer;

namespace __Project__.Scripts.WholeSale
{
	public class WholeSaleManager : NoktaSingleton<WholeSaleManager>
	{
		public enum OfferType
		{
			Buy = 0,
			Sell = 1
		}

		[CompilerGenerated]
		private sealed class _003CDelayedPopup_003Ed__58 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public WholeSaleManager _003C_003E4__this;

			private float _003CdelayGameTime_003E5__2;

			private float _003CdelayRealTime_003E5__3;

			private float _003Celapsed_003E5__4;

			private float _003CwaitTime_003E5__5;

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
			public _003CDelayedPopup_003Ed__58(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CManualWholeSaleTrigger_003Ed__62 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public WholeSaleManager _003C_003E4__this;

			private float _003CwaitTime_003E5__2;

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
			public _003CManualWholeSaleTrigger_003Ed__62(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CStart_003Ed__38 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public WholeSaleManager _003C_003E4__this;

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
			public _003CStart_003Ed__38(int _003C_003E1__state)
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
		private List<WholeSaleSettingsSO> m_WholeSaleSettings;

		public WholeSaleOfferCanvas m_WholeSaleScreen;

		public WholeSaleOfferCanvas m_WholeSaleScreenSingleplayer;

		public WholeSaleOfferCanvas m_WholeSaleScreenMultiplayer;

		[SerializeField]
		private float m_RealTimeWaitAfterExceeded;

		[SerializeField]
		private float m_OfferShowTime;

		[SerializeField]
		private WholesaleOfferIndicator m_WholesaleOfferIndicator;

		[Header("Indicator Left Positions")]
		[SerializeField]
		private Vector2 m_LeftPosition;

		[SerializeField]
		private Vector2 m_RightPosition;

		[HideInInspector]
		public bool m_OfferShown;

		public bool VotingCompleted;

		private WholeSaleSettingsSO m_OfferSettingSO;

		private List<int> m_OpenedProducts;

		private CartData m_CartData;

		private ItemQuantity m_DeliverItems;

		private int m_RandomProductID;

		private Pricing currentProductPricing;

		private bool m_CanGenerateOffer;

		private __Project__.Scripts.Computer.Computer m_Computer;

		private bool m_IsCheckingOfferAvailability;

		private bool m_IsPurchase;

		private int m_RandomProductCount;

		private ProductSO m_RandomProductSO;

		private float m_FinalPrice;

		private float m_InitialPrice;

		private int stockCount;

		private float AvgCost;

		private float BoxMarketPrice;

		private float SalesPrice;

		public Action onWholesaleOfferWarningRaised;

		public Action onWholesaleOfferAcceptedWarningRaised;

		public Action onWholesaleOfferDeclinedWarningRaised;

		[Separator("Generate With ID", false)]
		[SerializeField]
		private int m_generateID;

		[SerializeField]
		private int m_generateBoxCount;

		[SerializeField]
		private OfferType m_SelectedOfferType;

		public bool CanGenerateOffer => false;

		public bool IsCheckingOfferAvailability
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		[IteratorStateMachine(typeof(_003CStart_003Ed__38))]
		private IEnumerator Start()
		{
			return null;
		}

		private void LoadSaveProgress()
		{
		}

		private void OnDisable()
		{
		}

		private void GetCurrentOfferSO()
		{
		}

		private void GetCurrentProductList()
		{
		}

		private void CalculateOfferPrice(bool isBuyOffer)
		{
		}

		private void GenerateOffer()
		{
		}

		public void UpdateOfferDetails()
		{
		}

		public void InitializeWholeSaleBuyOfferCanvas(bool m_IsPurchase, bool CanAcceptOffer, int m_RandomProductCount, int m_RandomProductID, float m_FinalPrice, int stockCount, float AvgCost, float BoxMarketPrice, float m_InitialPrice)
		{
		}

		public void InitializeWholeSaleSellOfferCanvas(bool m_IsPurchase, bool CanAcceptOffer, int piecesCount, int m_RandomProductID, float m_FinalPrice, int stockCount, float AvgCost, float SalesPrice)
		{
		}

		private bool CanAcceptOffer(bool isBuyOffer)
		{
			return false;
		}

		private void OnStartedNewDay()
		{
		}

		private void OnWholesaleOffer()
		{
		}

		public void Sell()
		{
		}

		private void GetInventoryAmountEach()
		{
		}

		public void Buy()
		{
		}

		public void CancelOffer()
		{
		}

		public void DeclineOffer()
		{
		}

		public void AcceptOffer()
		{
		}

		private float CheckDelayTime()
		{
			return 0f;
		}

		[IteratorStateMachine(typeof(_003CDelayedPopup_003Ed__58))]
		private IEnumerator DelayedPopup()
		{
			return null;
		}

		public void OnDelayedPopupStarted()
		{
		}

		public void OnDelayedPopupCompleted()
		{
		}

		public void WholeSaleTriggerEditor()
		{
		}

		[IteratorStateMachine(typeof(_003CManualWholeSaleTrigger_003Ed__62))]
		private IEnumerator ManualWholeSaleTrigger()
		{
			return null;
		}

		public void WholesaleOfferIndicator(bool isLeft)
		{
		}

		private void ResetManager()
		{
		}

		[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
		private void GeneratePopupTest()
		{
		}

		[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
		private void GeneratePopupEnterIDTest()
		{
		}
	}
}
