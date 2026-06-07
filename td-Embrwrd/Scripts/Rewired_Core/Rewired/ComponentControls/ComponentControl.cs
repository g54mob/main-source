using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	public abstract class ComponentControl : MonoBehaviour, IComponentControl
	{
		private sealed class wCpqRgGeAjUiHICwQbeJBYGSwJcY : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int iGlJwrxLGlWMasENIyUHxRQyruik;

			private object JaIIqYhkyPpVLRBFIasGsWvpBBLoA;

			public ComponentControl UizWXUcxcHsLZtrdMugYIqLhLpcL;

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
			public wCpqRgGeAjUiHICwQbeJBYGSwJcY(int P_0)
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

		private IComponentController _controller;

		[NonSerialized]
		private bool HSNXSkvZCldZYrRwFjrZuougqLRK;

		[NonSerialized]
		private bool mWcymOnghgESNHlIEQAFFGSxNWOb;

		private int _lastUpdateFrame;

		internal abstract bool hfVCEuGZIVyxNuWswaHtTENTcblo { get; }

		internal bool yByeToaMNRCpRClHBZCJtlqiVdJz => false;

		[CustomObfuscation(rename = false)]
		internal ComponentControl()
		{
		}

		public abstract void ClearValue();

		void IComponentControl.Update()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Awake()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Start()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnEnable()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDisable()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDestroy()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnValidate()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnCanvasGroupChanged()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnTransformParentChanged()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDidApplyAnimationProperties()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Reset()
		{
		}

		internal virtual void TaJJysfcXGOLIYrzfRlEkosEbnMcA()
		{
		}

		internal virtual bool qAgXOZxzQNKqPAuHppaSytuDgzcg()
		{
			return false;
		}

		internal virtual void mqqFywHOtfqoveOfhUkaFBrTGhWLb()
		{
		}

		internal virtual void PDJYvOSVfJDBKJNuJgaVVBNgWtxL()
		{
		}

		internal virtual void xroVZfvuVIfFNJbBpfsGuofJYYUm()
		{
		}

		internal virtual void MPxPpCPVtBLCgEKzdjWmMHtdnZGk()
		{
		}

		internal virtual void bFeVhzFgykusySbDzeNuCRErjfHH()
		{
		}

		internal virtual void nGKIeWxqdnUtNJvRqnXhmJyYsngc()
		{
		}

		internal bool RxOzMbhZgAjlogzEuzTYSgBIzCKb()
		{
			return false;
		}

		internal bool iIZlHdAWTMtroRcPmgICieJzbtgm()
		{
			return false;
		}

		internal IComponentController eITCswGoXZEgVYKytGkJjPucXCjYB()
		{
			return null;
		}

		[CustomObfuscation(rename = false)]
		internal abstract IComponentController FindController();

		[CustomObfuscation(rename = false)]
		internal abstract Type GetRequiredControllerType();

		[IteratorStateMachine(typeof(wCpqRgGeAjUiHICwQbeJBYGSwJcY))]
		private IEnumerator NwGqDtFehBzNuNkuksBfPqtRBtnk()
		{
			return null;
		}

		private void LxrhEaARZfxLgrowoXYVWNrpyNvB()
		{
		}

		private bool asgIifAlOLyKjkFmfjQqEJBRPkCYA(bool P_0, bool P_1)
		{
			return false;
		}

		private void YewRjbkuGRxHlDWitETuvylxESBc()
		{
		}

		private void MCxifIBKgMImtMlbDHPMATYMNrdkA()
		{
		}
	}
}
