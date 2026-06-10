using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	public abstract class ComponentControl : MonoBehaviour, IComponentControl
	{
		private sealed class RTsWQolSYmauRUOjRIHicRvADbl : IEnumerator<object>, IDisposable, IEnumerator
		{
			private object YDjDCBVmlkHQnKMyHwfXVborvEXS;

			private int KjzQtaNmLSFADNQocZpcbdUSqwW;

			public ComponentControl OLVemnFdjzUkQSlFFFIOsrknazt;

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

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public RTsWQolSYmauRUOjRIHicRvADbl(int _003C_003E1__state)
			{
			}
		}

		private IComponentController _controller;

		[NonSerialized]
		private bool fjUzJMvfKUtkXCOEoCUtEkxLMZg;

		[NonSerialized]
		private bool WxwIROoIvtQQuhfdWYioNKebEOs;

		private int _lastUpdateFrame;

		internal abstract bool hasController { get; }

		internal bool initialized => false;

		[CustomObfuscation(rename = false)]
		internal ComponentControl()
		{
		}

		public abstract void ClearValue();

		private void iwmCPINYHsLxLhpZPxsnkEvnsFy()
		{
		}

		void IComponentControl.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in iwmCPINYHsLxLhpZPxsnkEvnsFy
			this.iwmCPINYHsLxLhpZPxsnkEvnsFy();
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

		internal virtual void UvjCYqPOLWYwPPujGcXEXxRteLL()
		{
		}

		internal virtual bool kCtpTQnECPegKfokmmotHswhcCLu()
		{
			return false;
		}

		internal virtual void gWQCCekjWwRWRAlSwjsIGMLCXyOE()
		{
		}

		internal virtual void zZvUXvigSJSyudmZqKMfzEpXBSj()
		{
		}

		internal virtual void ARKxKpVNqBlBYALxhmjYIBkRyuM()
		{
		}

		internal virtual void ILfKseeIovFotfIwVedwwNJgiCCt()
		{
		}

		internal virtual void uljBdNGgTHBIuJdsRFrEMcxJEVjD()
		{
		}

		internal virtual void RwvSBPnVuQMkWanLZtawvVoluWr()
		{
		}

		internal bool RwTcqOIEadTAxcsSUNPGILsWAle()
		{
			return false;
		}

		internal bool ELxAruBthFYpfWBgTtXpPfnpnIu()
		{
			return false;
		}

		internal IComponentController vJGduRfajRrKFPHpCMpSuwrQEYL()
		{
			return null;
		}

		[CustomObfuscation(rename = false)]
		internal abstract IComponentController FindController();

		[CustomObfuscation(rename = false)]
		internal abstract Type GetRequiredControllerType();

		private IEnumerator ugYDELSVuKfRSkIPqJPoturnocDq()
		{
			return null;
		}

		private void poVnOvkmteayheSbSBjtUjavYwU()
		{
		}

		private bool wTexrctSqtvimCbhwLxZnCxLMaL(bool P_0, bool P_1)
		{
			return false;
		}

		private void bvTAFhqERolFHfOeXbNxGuHwuYYG()
		{
		}

		private void xqRVGmVCGoPBzOUtgfCrMeYFMzP()
		{
		}
	}
}
