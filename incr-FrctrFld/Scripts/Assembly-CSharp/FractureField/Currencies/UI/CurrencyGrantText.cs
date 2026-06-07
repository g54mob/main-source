using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FractureField.Shared.Enums;
using TMPro;
using UnityEngine;

namespace FractureField.Currencies.UI
{
	public class CurrencyGrantText : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CAnimateCurrencyText_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CurrencyGrantText _003C_003E4__this;

			private float _003Celapsed_003E5__2;

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
			public _003CAnimateCurrencyText_003Ed__12(int _003C_003E1__state)
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

		[Header("References")]
		public TextMeshProUGUI grantText;

		[Header("Animation Settings")]
		public float animationDuration;

		public float moveDistance;

		public float initialYOffset;

		public AnimationCurve scaleCurve;

		public AnimationCurve moveYCurve;

		private Vector3 startLocalPosition;

		private Vector3 startScale;

		private Coroutine animationCoroutine;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void Initialize(float amount, CurrencyType currencyType, Vector3 worldPosition)
		{
		}

		[IteratorStateMachine(typeof(_003CAnimateCurrencyText_003Ed__12))]
		private IEnumerator AnimateCurrencyText()
		{
			return null;
		}
	}
}
