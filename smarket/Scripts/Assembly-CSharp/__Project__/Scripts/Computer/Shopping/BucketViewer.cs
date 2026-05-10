using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using __Project__.Scripts.ControllerInputModule;

namespace __Project__.Scripts.Computer.Shopping
{
	public class BucketViewer : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CDelayedGamepadCheck_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BucketViewer _003C_003E4__this;

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
			public _003CDelayedGamepadCheck_003Ed__18(int _003C_003E1__state)
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

		[Header("UI")]
		[SerializeField]
		private Transform m_ProductsContent;

		[SerializeField]
		private PaintSalesItem m_BucketSalesItemPrefab;

		[Header("Components")]
		[SerializeField]
		private MarketShoppingCart m_ShoppingCart;

		[SerializeField]
		private WindowTab m_tab;

		private List<PaintSalesItem> m_BucketSalesItems;

		[SerializeField]
		private GameObject m_LockedUI;

		[SerializeField]
		private GameObject m_UnlockedUI;

		[SerializeField]
		private GamepadSelectableParent m_gamepadSelectableParent;

		public MarketShoppingCart ShoppingCart => null;

		private bool m_UpgradedStore => false;

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		private void SpawnBuckets()
		{
		}

		private void OnSectionPurchased(int _)
		{
		}

		private void UpdateUI()
		{
		}

		private void GamepadCheck()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedGamepadCheck_003Ed__18))]
		private IEnumerator DelayedGamepadCheck()
		{
			return null;
		}

		private void InstantGamepadCheck()
		{
		}
	}
}
