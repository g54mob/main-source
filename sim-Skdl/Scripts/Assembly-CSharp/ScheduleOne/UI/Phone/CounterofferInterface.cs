using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ScheduleOne.DevUtilities;
using ScheduleOne.Messaging;
using ScheduleOne.Product;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI.Phone
{
	public class CounterofferInterface : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CDelaySelectPanel_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CounterofferInterface _003C_003E4__this;

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
			public _003CDelaySelectPanel_003Ed__33(int _003C_003E1__state)
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

		public const int COUNTEROFFER_SUCCESS_XP = 5;

		public const int MinQuantity = 1;

		public int MaxQuantity;

		public const float MinPrice = 1f;

		public const float MaxPrice = 9999f;

		public float IconAlignment;

		public GameObject ProductEntryPrefab;

		[Header("References")]
		public GameObject Container;

		public Text TitleLabel;

		public Button ConfirmButton;

		public Image ProductIcon;

		public Text ProductLabel;

		public RectTransform ProductLabelRect;

		public InputField PriceInput;

		public Text FairPriceLabel;

		public CounterOfferProductSelector ProductSelector;

		[Header("Custom UI")]
		public UIScreen uiScreen;

		public UIPanel uiPanel;

		private Action<ProductDefinition, int, float> orderConfirmedCallback;

		private ProductDefinition selectedProduct;

		private int quantity;

		private float price;

		private Dictionary<ProductDefinition, RectTransform> productEntries;

		private bool mouseUp;

		private MSGConversation conversation;

		public bool IsOpen { get; private set; }

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void Open(ProductDefinition product, int quantity, float price, MSGConversation _conversation, Action<ProductDefinition, int, float> _orderConfirmedCallback)
		{
		}

		[IteratorStateMachine(typeof(_003CDelaySelectPanel_003Ed__33))]
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

		public void Send()
		{
		}

		private void UpdateFairPrice()
		{
		}

		private void SetProduct(ProductDefinition newProduct)
		{
		}

		private void DisplayProduct(ProductDefinition tempProduct)
		{
		}

		public void ChangeQuantity(int change)
		{
		}

		private void UpdatePriceQuantityLabel(string productName)
		{
		}

		public void ChangePrice(float change)
		{
		}

		public void PriceSubmitted(string value)
		{
		}

		public void OpenProductSelector()
		{
		}
	}
}
