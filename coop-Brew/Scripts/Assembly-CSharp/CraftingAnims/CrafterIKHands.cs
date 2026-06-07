using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace CraftingAnims
{
	public class CrafterIKHands : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003C_BlendIK_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CrafterIKHands _003C_003E4__this;

			public float delay;

			public bool blendOn;

			public float timeToBlend;

			private float _003Ct_003E5__2;

			private int _003CblendTo_003E5__3;

			private int _003CblendFrom_003E5__4;

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
			public _003C_BlendIK_003Ed__11(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003C_SetIKPause_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CrafterIKHands _003C_003E4__this;

			public float pauseTime;

			private float _003Ct_003E5__2;

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
			public _003C_SetIKPause_003Ed__13(int _003C_003E1__state)
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

		public Transform leftHandObj;

		public Transform attachLeft;

		[Range(0f, 1f)]
		public float leftHandPositionWeight;

		[Range(0f, 1f)]
		public float leftHandRotationWeight;

		private Transform blendToTransform;

		private Coroutine co;

		private Animator animator;

		private CrafterController crafterController;

		private void Awake()
		{
		}

		private void OnAnimatorIK(int layerIndex)
		{
		}

		public void BlendIK(bool blendOn, float delay, float timeToBlend)
		{
		}

		[IteratorStateMachine(typeof(_003C_BlendIK_003Ed__11))]
		private IEnumerator _BlendIK(bool blendOn, float delay, float timeToBlend)
		{
			return null;
		}

		public void SetIKPause(float pauseTime)
		{
		}

		[IteratorStateMachine(typeof(_003C_SetIKPause_003Ed__13))]
		private IEnumerator _SetIKPause(float pauseTime)
		{
			return null;
		}

		private void GetCurrentAttachPoint()
		{
		}
	}
}
