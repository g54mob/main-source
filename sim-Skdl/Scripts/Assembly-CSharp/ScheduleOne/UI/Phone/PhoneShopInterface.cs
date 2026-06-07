using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.Messaging;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI.Phone
{
	public class PhoneShopInterface : MonoBehaviour
	{
		[Serializable]
		public class Listing
		{
			public StorableItemDefinition Item;

			public float Price => 0f;

			public Listing(StorableItemDefinition item)
			{
			}
		}

		[Serializable]
		public class CartEntry
		{
			public Listing Listing;

			public int Quantity;

			public CartEntry(Listing listing, int quantity)
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CDelaySelectPanel_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PhoneShopInterface _003C_003E4__this;

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
			public _003CDelaySelectPanel_003Ed__29(int _003C_003E1__state)
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

		public RectTransform EntryPrefab;

		public Color ValidAmountColor;

		public Color InvalidAmountColor;

		[Header("References")]
		public GameObject Container;

		public Text TitleLabel;

		public Text SubtitleLabel;

		public RectTransform EntryContainer;

		public Text OrderTotalLabel;

		public Text OrderLimitLabel;

		public Text DebtLabel;

		public Button ConfirmButton;

		public GameObject ItemLimitContainer;

		public Text ItemLimitLabel;

		[Header("Custom UI")]
		public UIScreen uiScreen;

		public UIPanel uiPanel;

		private List<RectTransform> _entries;

		private List<Listing> _items;

		private List<CartEntry> _cart;

		private float orderLimit;

		private Action<List<CartEntry>, float> orderConfirmedCallback;

		private MSGConversation conversation;

		public bool IsOpen { get; private set; }

		private void Start()
		{
		}

		public void Open(string title, string subtitle, MSGConversation _conversation, List<Listing> listings, float _orderLimit, float debt, Action<List<CartEntry>, float> _orderConfirmedCallback)
		{
		}

		[IteratorStateMachine(typeof(_003CDelaySelectPanel_003Ed__29))]
		private IEnumerator DelaySelectPanel()
		{
			return null;
		}

		public void Close()
		{
		}

		public void Exit(ExitAction action)
		{
		}

		private void ChangeListingQuantity(Listing listing, int change)
		{
		}

		private void CartChanged()
		{
		}

		private void ConfirmOrderPressed()
		{
		}

		private bool CanConfirmOrder()
		{
			return false;
		}

		private void UpdateOrderTotal()
		{
		}

		private float GetOrderTotal(out int itemCount)
		{
			itemCount = default(int);
			return 0f;
		}
	}
}
