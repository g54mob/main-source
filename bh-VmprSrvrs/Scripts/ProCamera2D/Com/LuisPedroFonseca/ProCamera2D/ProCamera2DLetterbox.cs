using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	[ExecuteInEditMode]
	public class ProCamera2DLetterbox : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CTweenToRoutine_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ProCamera2DLetterbox _003C_003E4__this;

			public float duration;

			public float targetAmount;

			private float _003CinitialAmount_003E5__2;

			private float _003Ct_003E5__3;

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
			public _003CTweenToRoutine_003Ed__13(int _003C_003E1__state)
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

		[Range(0f, 0.5f)]
		public float Amount;

		public Color Color;

		private Material _material;

		private int TopPropertyID;

		private int BottomPropertyID;

		private int ColorPropertyID;

		private float _previousAmount;

		private Material material => null;

		private void OnEnable()
		{
		}

		private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
		{
		}

		private void OnDisable()
		{
		}

		public void TweenTo(float targetAmount, float duration)
		{
		}

		[IteratorStateMachine(typeof(_003CTweenToRoutine_003Ed__13))]
		private IEnumerator TweenToRoutine(float targetAmount, float duration)
		{
			return null;
		}
	}
}
