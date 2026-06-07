using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

namespace FractureField.Rocks
{
	public class DamageText : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CAnimateDamageText_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DamageText _003C_003E4__this;

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
			public _003CAnimateDamageText_003Ed__18(int _003C_003E1__state)
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
		public TextMeshProUGUI damageText;

		[Header("Animation Settings")]
		public float animationDuration;

		public float moveDistance;

		public AnimationCurve moveYCurve;

		public AnimationCurve scaleCurve;

		public AnimationCurve alphaCurve;

		[Header("Critical Hit Settings")]
		public float critScaleMultiplier;

		public Color normalColor;

		public Color critColor;

		public Color megaCritColor;

		private Vector3 startLocalPosition;

		private Vector3 startScale;

		private bool isCrit;

		private bool isMegaCrit;

		private Coroutine animationCoroutine;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void Initialize(float damage, bool isCritical, bool isMegaCritical, Vector3 worldPosition)
		{
		}

		[IteratorStateMachine(typeof(_003CAnimateDamageText_003Ed__18))]
		private IEnumerator AnimateDamageText()
		{
			return null;
		}
	}
}
