using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ScheduleOne.Audio;
using ScheduleOne.Delivery;
using ScheduleOne.DevUtilities;
using ScheduleOne.UI.Shop;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI.Phone.Delivery
{
	public class DeliveryApp : App<DeliveryApp>
	{
		[Serializable]
		public class DeliveryShopElement
		{
			public DeliveryShop Shop;

			public Button Button;
		}

		[CompilerGenerated]
		private sealed class _003CDoShopTransitionRoutine_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public List<RectTransform> panels;

			public DeliveryApp _003C_003E4__this;

			public int direction;

			public float duration;

			public Action onComplete;

			private float _003CelapsedTime_003E5__2;

			private List<Vector2> _003CstartPos_003E5__3;

			private List<Vector2> _003CtargetPos_003E5__4;

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
			public _003CDoShopTransitionRoutine_003Ed__27(int _003C_003E1__state)
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

		private List<DeliveryShop> deliveryShops;

		public DeliveryStatusDisplay StatusDisplayPrefab;

		[Header("References")]
		public Animation OrderSubmittedAnim;

		public AudioSourceController OrderSubmittedSound;

		public RectTransform StatusDisplayContainer;

		public GameObject NoDeliveriesIndicator;

		public GameObject NoPastDeliveriesIndicator;

		public ScrollRect MainScrollRect;

		public LayoutGroup MainLayoutGroup;

		[SerializeField]
		[Header("Components")]
		private DeliveryReceiptDisplay _deliveryReceiptPrefab;

		public RectTransform PastDeliveriesContainer;

		[SerializeField]
		[Header("References")]
		private TabController _tabController;

		[SerializeField]
		private CanvasGroup shopListCanvas;

		[SerializeField]
		private CanvasGroup orderCanvas;

		[SerializeField]
		private List<DeliveryShopElement> _shopElements;

		[SerializeField]
		[Header("Settings")]
		private float shopPanelWidth;

		[SerializeField]
		private float shopTransitionDuration;

		private List<DeliveryStatusDisplay> statusDisplays;

		private DeliveryReceiptDisplay[] _pastDeliveries;

		private bool started;

		private List<RectTransform> _shopPanels;

		private List<Vector2> _shopPanelInitialAnchors;

		private Coroutine _shopTransitionCoroutine;

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		public void OpenShop(DeliveryShop shop)
		{
		}

		public void CloseShop(DeliveryShop shop)
		{
		}

		[IteratorStateMachine(typeof(_003CDoShopTransitionRoutine_003Ed__27))]
		private IEnumerator DoShopTransitionRoutine(float duration, int direction, List<RectTransform> panels, Action onComplete)
		{
			return null;
		}

		public override void Exit(ExitAction exit)
		{
		}

		private void SetCanvasInteraction(CanvasGroup canvas, bool interactable)
		{
		}

		public override void SetOpen(bool open)
		{
		}

		private void OnMinPass()
		{
		}

		public void RefreshContent(bool keepScrollPosition = true)
		{
		}

		public void OnSubmitOrder(DeliveryShop shop)
		{
		}

		public void PlayOrderSubmittedAnim()
		{
		}

		public void Reorder(DeliveryReceipt receipt)
		{
		}

		public bool CanReorder(DeliveryReceipt receipt, out string reason)
		{
			reason = null;
			return false;
		}

		public float GetDeliveryCost(DeliveryReceipt receipt)
		{
			return 0f;
		}

		private void CreateDeliveryStatusDisplay(DeliveryInstance instance)
		{
		}

		private void DeliveryCompleted(DeliveryInstance instance)
		{
		}

		private void SortStatusDisplays()
		{
		}

		private void RefreshNoDeliveriesIndicator()
		{
		}

		public static void RefreshLayoutGroupsImmediateAndRecursive(GameObject root)
		{
		}

		public DeliveryShop GetShop(string shopName)
		{
			return null;
		}

		public void SetIsAvailable(ShopInterface matchingShop, bool available)
		{
		}

		private void OnTabChange(int index)
		{
		}

		private void UpdatePastDeliveries()
		{
		}

		private bool IsValidReceipt(DeliveryReceipt receipt)
		{
			return false;
		}

		private void RefreshNotifications()
		{
		}
	}
}
