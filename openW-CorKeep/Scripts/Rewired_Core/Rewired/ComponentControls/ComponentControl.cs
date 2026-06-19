using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Utils;
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
					return BUmIJnfhGNhceyXTCgAicgTWFivS;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return BUmIJnfhGNhceyXTCgAicgTWFivS;
				}
			}

			[DebuggerHidden]
			public ojPfSVeXivBmgyfiAGerSpqnDyQsA(int P_0)
			{
				aePOSKcOodirNZXNGYUjNwiNMSAh = P_0;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				aePOSKcOodirNZXNGYUjNwiNMSAh = -2;
			}

			private bool MoveNext()
			{
				int num = aePOSKcOodirNZXNGYUjNwiNMSAh;
				ComponentControl iLXnwhrJWHcYcUefKjmgkHxKtmYp = ILXnwhrJWHcYcUefKjmgkHxKtmYp;
				switch (num)
				{
				default:
					return false;
				case 0:
					aePOSKcOodirNZXNGYUjNwiNMSAh = -1;
					BUmIJnfhGNhceyXTCgAicgTWFivS = null;
					aePOSKcOodirNZXNGYUjNwiNMSAh = 1;
					return true;
				case 1:
					aePOSKcOodirNZXNGYUjNwiNMSAh = -1;
					if (!iLXnwhrJWHcYcUefKjmgkHxKtmYp.FBTWPzcXpWlDMTGvkvxpkZYxUkml())
					{
						return false;
					}
					iLXnwhrJWHcYcUefKjmgkHxKtmYp.OnEnable();
					return false;
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}
		}

		private IComponentController _controller;

		[NonSerialized]
		private bool ZUjObZaAkzTTxUmyRJjbWVMVsXrN;

		[NonSerialized]
		private bool cAYyWReWYubyxutlYPWazcgOYegV;

		private int _lastUpdateFrame = -1;

		internal abstract bool lHrmyZFsaDtMgFwuiNoBbdveNATp { get; }

		internal bool kCCUxJdqnJEDkElVVvKpRTWHmWjo => ZUjObZaAkzTTxUmyRJjbWVMVsXrN;

		[CustomObfuscation(rename = false)]
		internal ComponentControl()
		{
		}

		public abstract void ClearValue();

		void IComponentControl.Update()
		{
			int frameCount = Time.frameCount;
			if (_lastUpdateFrame != frameCount)
			{
				_lastUpdateFrame = frameCount;
				ZadSFFqddMfzbdzzllVuUFOpUuig();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Awake()
		{
			cAYyWReWYubyxutlYPWazcgOYegV = true;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Start()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnEnable()
		{
			if (!cAYyWReWYubyxutlYPWazcgOYegV)
			{
				ZUjObZaAkzTTxUmyRJjbWVMVsXrN = false;
				StartCoroutine(JTaCbGOPXPJbRgqcuaNTjRFuwxTL());
				cAYyWReWYubyxutlYPWazcgOYegV = true;
			}
			else if (Application.isPlaying)
			{
				FaXXTrDaffLVaQtamnPmaedMSBtS();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDisable()
		{
			if (Application.isPlaying)
			{
				uKIITLZiVdQQQzYhEoIIzfZpEMqm();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDestroy()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnValidate()
		{
			if (ZUjObZaAkzTTxUmyRJjbWVMVsXrN)
			{
				ODYwhAdCAVZRuczWbPMnFNUIVtcY();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnCanvasGroupChanged()
		{
			if (ZUjObZaAkzTTxUmyRJjbWVMVsXrN)
			{
				orIQZCFoyHanAJKypEcWbSvmBhwK(false, false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnTransformParentChanged()
		{
			if (ZUjObZaAkzTTxUmyRJjbWVMVsXrN)
			{
				orIQZCFoyHanAJKypEcWbSvmBhwK(false, false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDidApplyAnimationProperties()
		{
			_ = ZUjObZaAkzTTxUmyRJjbWVMVsXrN;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Reset()
		{
			_ = ZUjObZaAkzTTxUmyRJjbWVMVsXrN;
		}

		internal virtual void ZadSFFqddMfzbdzzllVuUFOpUuig()
		{
		}

		internal virtual bool udELxkqKqBssyvTXjSbiAnMcBXWcA()
		{
			ZUjObZaAkzTTxUmyRJjbWVMVsXrN = false;
			if (!orIQZCFoyHanAJKypEcWbSvmBhwK(true, true))
			{
				return false;
			}
			_controller.Register(this);
			return true;
		}

		internal virtual void uKIITLZiVdQQQzYhEoIIzfZpEMqm()
		{
			ClearValue();
			if (!_controller.IsNullOrDestroyed())
			{
				_controller.Deregister(this);
			}
			tRUIvEemdCHZwaLBzjeyJKBqGxexA();
			ZUjObZaAkzTTxUmyRJjbWVMVsXrN = false;
		}

		internal virtual void DhnkarFdLNbxthygTakzNjfHljXY()
		{
			if (!_controller.IsNullOrDestroyed())
			{
				tRUIvEemdCHZwaLBzjeyJKBqGxexA();
			}
		}

		internal virtual void tRUIvEemdCHZwaLBzjeyJKBqGxexA()
		{
			_controller.IsNullOrDestroyed();
		}

		internal virtual void YmRcFnSGPDloZzprndIQeqXQHaodA()
		{
			if (ZUjObZaAkzTTxUmyRJjbWVMVsXrN)
			{
				ODYwhAdCAVZRuczWbPMnFNUIVtcY();
			}
		}

		internal virtual void tKEdjOKSEgjEZYzXhFqUMeyYYOhKA()
		{
			_ = ZUjObZaAkzTTxUmyRJjbWVMVsXrN;
		}

		internal virtual void hJieezuYDvMkgetfgmvBUlvxhTPM()
		{
		}

		internal bool FBTWPzcXpWlDMTGvkvxpkZYxUkml()
		{
			return UnityTools.IsActiveAndEnabled(this);
		}

		internal bool wKvhLKFRvAbHXozRyoceEhlYYSUT()
		{
			return this == null;
		}

		internal IComponentController sClGEFfbbXANcdfstmWlzrKevXHi()
		{
			return _controller;
		}

		[CustomObfuscation(rename = false)]
		internal abstract IComponentController FindController();

		[CustomObfuscation(rename = false)]
		internal abstract Type GetRequiredControllerType();

		[IteratorStateMachine(typeof(ojPfSVeXivBmgyfiAGerSpqnDyQsA))]
		private IEnumerator JTaCbGOPXPJbRgqcuaNTjRFuwxTL()
		{
			return new ojPfSVeXivBmgyfiAGerSpqnDyQsA(0)
			{
				ILXnwhrJWHcYcUefKjmgkHxKtmYp = this
			};
		}

		private void FaXXTrDaffLVaQtamnPmaedMSBtS()
		{
			if (udELxkqKqBssyvTXjSbiAnMcBXWcA())
			{
				hJieezuYDvMkgetfgmvBUlvxhTPM();
				ZUjObZaAkzTTxUmyRJjbWVMVsXrN = true;
				DhnkarFdLNbxthygTakzNjfHljXY();
			}
		}

		private bool orIQZCFoyHanAJKypEcWbSvmBhwK(bool P_0, bool P_1)
		{
			bool flag = false;
			try
			{
				IComponentController componentController = FindController();
				if (!_controller.IsNullOrDestroyed() && _controller != componentController)
				{
					flag = true;
				}
				_controller = componentController;
				if (_controller == null)
				{
					Type type = GetRequiredControllerType();
					if (type == null)
					{
						type = typeof(IComponentController);
					}
					if (P_1)
					{
						Logger.LogError(type.Name + " could not be found. You must have a component that extends from " + type.Name + " on this or a parent GameObject.");
					}
					throw new Exception();
				}
				if (!P_0 && flag)
				{
					FaXXTrDaffLVaQtamnPmaedMSBtS();
				}
				return true;
			}
			catch
			{
				uKIITLZiVdQQQzYhEoIIzfZpEMqm();
				return false;
			}
		}

		private void ODYwhAdCAVZRuczWbPMnFNUIVtcY()
		{
			orIQZCFoyHanAJKypEcWbSvmBhwK(false, true);
		}

		private void McTBMvUJUEQHWnDbNEDgtCcnNSFU()
		{
			if (!wKvhLKFRvAbHXozRyoceEhlYYSUT() && FBTWPzcXpWlDMTGvkvxpkZYxUkml())
			{
				ZadSFFqddMfzbdzzllVuUFOpUuig();
			}
		}
	}
}
