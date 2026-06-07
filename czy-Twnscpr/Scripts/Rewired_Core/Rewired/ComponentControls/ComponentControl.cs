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
		private sealed class IcFoqVXimGOtRIIhVWhGEpIfYRf : IEnumerator<object>, IDisposable, IEnumerator
		{
			private object BkCCsqltFMRNvCZoZtUjDVFIQQJ;

			private int NnUDqRnSfwXnBFHmcGVSTSfluHA;

			public ComponentControl TiaUIShtPVkFOKyDFxywSfPUjyv;

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
			public IcFoqVXimGOtRIIhVWhGEpIfYRf(int _003C_003E1__state)
			{
			}
		}

		private IComponentController _controller;

		[NonSerialized]
		private bool aLzbAjHdyinuPAkYilYZkIGyBOc;

		[NonSerialized]
		private bool TUPvapCUmFSRuvJvEdvErJpSGTk;

		private int _lastUpdateFrame;

		internal abstract bool hasController { get; }

		internal bool initialized => false;

		[CustomObfuscation]
		internal ComponentControl()
		{
		}

		public abstract void ClearValue();

		private void xzVgocHrivoQvNzrTWEIMArCfyRN()
		{
		}

		void IComponentControl.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in xzVgocHrivoQvNzrTWEIMArCfyRN
			this.xzVgocHrivoQvNzrTWEIMArCfyRN();
		}

		[CustomObfuscation]
		internal virtual void Awake()
		{
		}

		[CustomObfuscation]
		internal virtual void Start()
		{
		}

		[CustomObfuscation]
		internal virtual void OnEnable()
		{
		}

		[CustomObfuscation]
		internal virtual void OnDisable()
		{
		}

		[CustomObfuscation]
		internal virtual void OnDestroy()
		{
		}

		[CustomObfuscation]
		internal virtual void OnValidate()
		{
		}

		[CustomObfuscation]
		internal virtual void OnCanvasGroupChanged()
		{
		}

		[CustomObfuscation]
		internal virtual void OnTransformParentChanged()
		{
		}

		[CustomObfuscation]
		internal virtual void OnDidApplyAnimationProperties()
		{
		}

		[CustomObfuscation]
		internal virtual void Reset()
		{
		}

		internal virtual void PSFeJyfveNnRLRnWPckAdcFQFXH()
		{
		}

		internal virtual bool vTErMpFqqbrJIuisyHNZEKHQiIJk()
		{
			return false;
		}

		internal virtual void blNkBfNwSvZZbdQdqHqFicHdwJW()
		{
		}

		internal virtual void icQxdQEDgrvBqfMTuplRHxKgMmr()
		{
		}

		internal virtual void NdtcFvGfnnZoRnENbmFXoawgFosU()
		{
		}

		internal virtual void DDSYIBWFCFbxtAeyTbUKilaTRGQv()
		{
		}

		internal virtual void dfIfTakAbrHDwHdgPNSyWCKumHlK()
		{
		}

		internal virtual void EUAcigCVtcdNGimfhNGKNDeeSwJn()
		{
		}

		internal bool OikdATkuqFcAluqmCfyoSugbMIkC()
		{
			return false;
		}

		internal bool ZnGHFUrDgbqjSSwELkGXpIGOQwq()
		{
			return false;
		}

		internal IComponentController ydjeIaTtBllFZDPnKhGsSMUhTUT()
		{
			return null;
		}

		[CustomObfuscation]
		internal abstract IComponentController FindController();

		[CustomObfuscation]
		internal abstract Type GetRequiredControllerType();

		private IEnumerator bUtwujgAqxGEgYJHgyYPCEPEqFj()
		{
			return null;
		}

		private void kFgyZKEvDYhtdqUfYSYVoMNQuBC()
		{
		}

		private bool bWTPODPMLJvssWnAiQfrNIGyopH(bool P_0, bool P_1)
		{
			return false;
		}

		private void kckhtUMxbCHYHtoyNtsHEKeNtSU()
		{
		}

		private void oOyadHcvmKoUbEMUymSTWwhajMJM()
		{
		}
	}
}
