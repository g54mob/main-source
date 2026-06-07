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
		private sealed class jQwvusFgsusvHulzjgMhLNIewDxw : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int vpkurtowoalriIBSdEyddbSMtxnL;

			private object CBHcSAvUIpgVLxWpDEsEIlfHZAaB;

			public ComponentControl BBaIWWvoWAcBRFiufgWcKaJXWNfP;

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
			public jQwvusFgsusvHulzjgMhLNIewDxw(int P_0)
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
		private bool WxQEBisVmcHUMNgnsMNbwooAWwCN;

		[NonSerialized]
		private bool pFvdugceMtxxOthujpqkIPGHwDDiA;

		private int _lastUpdateFrame;

		internal abstract bool wKSJYuNWaWSPZSUdNoUHPyLlCbep { get; }

		internal bool nupFXudRnKEERXEMoxkvlOuQkxWo => false;

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

		internal virtual void UjYAamsdzBByKqJeCzTogWwkpzPq()
		{
		}

		internal virtual bool pSfLXLykqGsrHeXOKVHkoiqvAwzcA()
		{
			return false;
		}

		internal virtual void xlshkLiVaPQfkaubhIUDfrmClVY()
		{
		}

		internal virtual void YPIpAATaLSbyQilpgKOjbXBAhEqXA()
		{
		}

		internal virtual void wKtlVbgqdJHWDjRQWgYcGuxfgWDxA()
		{
		}

		internal virtual void PCavBKUOTQxjogDkKkwMMvzHZTRh()
		{
		}

		internal virtual void uejyLnYLOhZNmitUQHKQQMEZdrEY()
		{
		}

		internal virtual void qtZqEKmcBeznBvpwZlLBySPsIsmM()
		{
		}

		internal bool KumenAicfBvAvvOgJjJtpMqkIdLrA()
		{
			return false;
		}

		internal bool fbMrllBqvZAEgxfELaKoJyFHJrfgA()
		{
			return false;
		}

		internal IComponentController xTQkisfrUGLJnijnYWdfNshhGakc()
		{
			return null;
		}

		[CustomObfuscation(rename = false)]
		internal abstract IComponentController FindController();

		[CustomObfuscation(rename = false)]
		internal abstract Type GetRequiredControllerType();

		[IteratorStateMachine(typeof(jQwvusFgsusvHulzjgMhLNIewDxw))]
		private IEnumerator GqLRBpOsBEyoevIpNpTBVettXluG()
		{
			return null;
		}

		private void QfsCrGBNzeuQXEDhPltecGLJcwGpA()
		{
		}

		private bool vHhgmbVYyIdnbYGhScfYVnTxixXi(bool P_0, bool P_1)
		{
			return false;
		}

		private void DCrgFnihSKUORstVQxazizoHWOZWA()
		{
		}

		private void RxmxxIOASPIZteDowNdkBLGaftqu()
		{
		}
	}
}
