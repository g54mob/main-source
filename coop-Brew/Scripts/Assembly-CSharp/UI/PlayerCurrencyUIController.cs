using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Player;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
	[RequireComponent(typeof(UIDocument))]
	public class PlayerCurrencyUIController : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CRetryValueCheck_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PlayerCurrencyUIController _003C_003E4__this;

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
			public _003CRetryValueCheck_003Ed__15(int _003C_003E1__state)
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

		[Header("Debug Settings")]
		[SerializeField]
		private bool m_ShowDebugLogs;

		[SerializeField]
		private float m_DebugLogInterval;

		private float m_LastDebugLogTime;

		private Label currencyAmountLabel;

		private Label currencyIconLabel;

		private VisualElement currencyContainer;

		private PlayerCurrency playerCurrency;

		private float previousAmount;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void SetupUI()
		{
		}

		private void FindPlayerCurrency()
		{
		}

		private void OnClientConnected(ulong clientId)
		{
		}

		[IteratorStateMachine(typeof(_003CRetryValueCheck_003Ed__15))]
		private IEnumerator RetryValueCheck()
		{
			return null;
		}

		private void OnDestroy()
		{
		}

		private void OnDollarsChanged(float newAmount)
		{
		}

		private void UpdateCurrencyDisplay(float amount)
		{
		}

		private void AnimateCurrencyChange(bool isGain, float difference = 0f)
		{
		}

		private void LogDebugInfo()
		{
		}

		[ContextMenu("Refresh Display")]
		public void RefreshDisplay()
		{
		}

		[ContextMenu("Test Gain Animation")]
		private void TestGainAnimation()
		{
		}

		[ContextMenu("Test Spend Animation")]
		private void TestSpendAnimation()
		{
		}
	}
}
