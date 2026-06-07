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
		private sealed class ojPfSVeXivBmgyfiAGerSpqnDyQsA : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int aePOSKcOodirNZXNGYUjNwiNMSAh;

			private object BUmIJnfhGNhceyXTCgAicgTWFivS;

			public ComponentControl ILXnwhrJWHcYcUefKjmgkHxKtmYp;

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
			public ojPfSVeXivBmgyfiAGerSpqnDyQsA(int P_0)
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
		private bool ZUjObZaAkzTTxUmyRJjbWVMVsXrN;

		[NonSerialized]
		private bool cAYyWReWYubyxutlYPWazcgOYegV;

		private int _lastUpdateFrame;

		internal abstract bool lHrmyZFsaDtMgFwuiNoBbdveNATp { get; }

		internal bool kCCUxJdqnJEDkElVVvKpRTWHmWjo => false;

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

		internal virtual void ZadSFFqddMfzbdzzllVuUFOpUuig()
		{
		}

		internal virtual bool udELxkqKqBssyvTXjSbiAnMcBXWcA()
		{
			return false;
		}

		internal virtual void uKIITLZiVdQQQzYhEoIIzfZpEMqm()
		{
		}

		internal virtual void DhnkarFdLNbxthygTakzNjfHljXY()
		{
		}

		internal virtual void tRUIvEemdCHZwaLBzjeyJKBqGxexA()
		{
		}

		internal virtual void YmRcFnSGPDloZzprndIQeqXQHaodA()
		{
		}

		internal virtual void tKEdjOKSEgjEZYzXhFqUMeyYYOhKA()
		{
		}

		internal virtual void hJieezuYDvMkgetfgmvBUlvxhTPM()
		{
		}

		internal bool FBTWPzcXpWlDMTGvkvxpkZYxUkml()
		{
			return false;
		}

		internal bool wKvhLKFRvAbHXozRyoceEhlYYSUT()
		{
			return false;
		}

		internal IComponentController sClGEFfbbXANcdfstmWlzrKevXHi()
		{
			return null;
		}

		[CustomObfuscation(rename = false)]
		internal abstract IComponentController FindController();

		[CustomObfuscation(rename = false)]
		internal abstract Type GetRequiredControllerType();

		[IteratorStateMachine(typeof(ojPfSVeXivBmgyfiAGerSpqnDyQsA))]
		private IEnumerator JTaCbGOPXPJbRgqcuaNTjRFuwxTL()
		{
			return null;
		}

		private void FaXXTrDaffLVaQtamnPmaedMSBtS()
		{
		}

		private bool orIQZCFoyHanAJKypEcWbSvmBhwK(bool P_0, bool P_1)
		{
			return false;
		}

		private void ODYwhAdCAVZRuczWbPMnFNUIVtcY()
		{
		}

		private void McTBMvUJUEQHWnDbNEDgtCcnNSFU()
		{
		}
	}
}
