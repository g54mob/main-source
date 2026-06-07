using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Player;
using Property;
using Synty.AnimationBaseLocomotion.Samples;
using UI.Core;
using UnityEngine;
using UnityEngine.UIElements;

namespace Brewery.UI.Property
{
	[RequireComponent(typeof(UIDocument))]
	public class HousePurchaseUIController : MonoBehaviour, IUIPanel
	{
		[CompilerGenerated]
		private sealed class _003CCloseAfterDelay_003Ed__63 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float delay;

			public HousePurchaseUIController _003C_003E4__this;

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
			public _003CCloseAfterDelay_003Ed__63(int _003C_003E1__state)
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
		private sealed class _003CHideToastAfterDelay_003Ed__65 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float delay;

			public HousePurchaseUIController _003C_003E4__this;

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
			public _003CHideToastAfterDelay_003Ed__65(int _003C_003E1__state)
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

		[Header("UI Document")]
		[SerializeField]
		private UIDocument uiDocument;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private VisualElement overlayContainer;

		private VisualElement housePanel;

		private Button closeButton;

		private Label titleLabel;

		private Label subtitleLabel;

		private VisualElement purchaseScreen;

		private Label purchasePriceLabel;

		private Label playerBalanceLabel;

		private Button purchaseButton;

		private Label purchaseErrorLabel;

		private VisualElement ownedScreen;

		private VisualElement furnitureStatusContainer;

		private Label currentValueLabel;

		private Label sellProfitLabel;

		private Button sellToVisitorButton;

		private Label noVisitorsLabel;

		private VisualElement statusToast;

		private Label toastMessage;

		private HouseData currentHouse;

		private PlotForSaleSignInteractable currentSign;

		private PlotBuildingController currentBuildController;

		private PropertyManager propertyManager;

		private PlayerCurrency playerCurrency;

		private bool isUIVisible;

		private Coroutine toastCoroutine;

		private SampleCameraController cameraController;

		public string PanelId => null;

		public int Priority => 0;

		public bool IsOpen => false;

		public static HousePurchaseUIController Instance { get; private set; }

		public void Close()
		{
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void Start()
		{
		}

		private void SetupUI()
		{
		}

		private void FindPlayerCurrency()
		{
		}

		private void FindManagers()
		{
		}

		private void FindCameraController()
		{
		}

		public void ShowUI(HouseData house, PlotForSaleSignInteractable sign = null)
		{
		}

		public void HideUI()
		{
		}

		private void ShowPurchaseScreen()
		{
		}

		private void ShowOwnedScreen()
		{
		}

		private void UpdatePurchaseScreen()
		{
		}

		private void UpdateOwnedScreen()
		{
		}

		private void UpdateConstructionStatus()
		{
		}

		private void UpdateFurnitureStatus()
		{
		}

		private void AddFurnitureStatusRow(string name, bool isValid, string status)
		{
		}

		private void UpdateValueDisplay()
		{
		}

		private void UpdateSellButton()
		{
		}

		private void UpdatePlayerBalanceDisplay()
		{
		}

		private void OnPurchaseClicked()
		{
		}

		private void OnSellToVisitorClicked()
		{
		}

		private void OnHousePurchased(string houseId, ulong buyerId)
		{
		}

		private void OnOwnershipChanged(string houseId, ulong newOwnerId)
		{
		}

		private void OnPlayerCurrencyChanged(float newAmount)
		{
		}

		[IteratorStateMachine(typeof(_003CCloseAfterDelay_003Ed__63))]
		private IEnumerator CloseAfterDelay(float delay)
		{
			return null;
		}

		private void ShowToast(string message, bool isSuccess)
		{
		}

		[IteratorStateMachine(typeof(_003CHideToastAfterDelay_003Ed__65))]
		private IEnumerator HideToastAfterDelay(float delay)
		{
			return null;
		}

		private void HideToast()
		{
		}
	}
}
