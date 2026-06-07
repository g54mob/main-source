using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FractureField.Shared.Enums;
using FractureField.UI.Components;
using Reactivity;
using Reactivity.Unity.Components;
using UnityEngine;

namespace FractureField.Currencies.UI
{
	public class CurrencyContainer : RComponent
	{
		[CompilerGenerated]
		private sealed class _003CRemoveAfterSecondsCoroutine_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float seconds;

			public CurrencyContainer _003C_003E4__this;

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
			public _003CRemoveAfterSecondsCoroutine_003Ed__20(int _003C_003E1__state)
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
		[SerializeField]
		private CurrencyType _currencyType;

		public CurrencyIcon CurrencyIcon;

		[Header("References")]
		[SerializeField]
		private Animator _animator;

		[SerializeField]
		private RText _text;

		private CFloat _available;

		public Ref<CurrencyType> CurrencyType { get; }

		public CFloat Available => null;

		private Stackabool HasPendingCurrency { get; set; }

		protected override void Awake()
		{
		}

		private void Setup()
		{
		}

		protected override void OnDestroy()
		{
		}

		public void AddPendingCurrency()
		{
		}

		public void RemovePendingCurrency()
		{
		}

		public void RemoveAfterSeconds(float seconds)
		{
		}

		[IteratorStateMachine(typeof(_003CRemoveAfterSecondsCoroutine_003Ed__20))]
		private IEnumerator RemoveAfterSecondsCoroutine(float seconds)
		{
			return null;
		}
	}
}
