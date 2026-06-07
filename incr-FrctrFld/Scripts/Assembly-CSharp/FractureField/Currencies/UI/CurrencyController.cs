using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FractureField.Shared.Enums;
using FractureField.UI.Components;
using Reactivity.Unity.Components;
using UnityEngine;

namespace FractureField.Currencies.UI
{
	public class CurrencyController : RComponent
	{
		[CompilerGenerated]
		private sealed class _003CBatchCurrencyPopups_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CurrencyController _003C_003E4__this;

			private float _003CstartTime_003E5__2;

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
			public _003CBatchCurrencyPopups_003Ed__19(int _003C_003E1__state)
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

		[Header("Variables")]
		public CurrencyType Type;

		[Header("References")]
		[SerializeField]
		private RectTransform _rectTransform;

		[SerializeField]
		private CurrencyIcon _currencyIcon;

		[SerializeField]
		private RText _quantityText;

		[Header("Grant Animation")]
		[SerializeField]
		private GameObject pfCurrencyGrantText;

		[SerializeField]
		private Transform grantTextSpawnPoint;

		private Currency _currency;

		private float _pendingAmount;

		private Coroutine _batchCoroutine;

		private const float MAX_BATCH_INTERVAL = 0.5f;

		private const float IDLE_THRESHOLD = 0.15f;

		private float _lastAdditionTime;

		protected override void Awake()
		{
		}

		private void Setup()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected override void OnDisable()
		{
		}

		private void Cleanup()
		{
		}

		public void Setup(CurrencyType currencyType)
		{
		}

		private void OnCurrencyGranted(float amount)
		{
		}

		[IteratorStateMachine(typeof(_003CBatchCurrencyPopups_003Ed__19))]
		private IEnumerator BatchCurrencyPopups()
		{
			return null;
		}

		private void ShowCurrencyPopup(float amount)
		{
		}

		private bool IsVisibleInScrollView()
		{
			return false;
		}
	}
}
