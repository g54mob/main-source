using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	public abstract class ComponentController : MonoBehaviour, IRegistrar<IComponentControl>, IComponentController
	{
		private sealed class OdzNFXmrMiKGJCozvaOxiwJxjZPJ : IEnumerator<object>, IDisposable, IEnumerator
		{
			private object BkCCsqltFMRNvCZoZtUjDVFIQQJ;

			private int NnUDqRnSfwXnBFHmcGVSTSfluHA;

			public ComponentController TiaUIShtPVkFOKyDFxywSfPUjyv;

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
			public OdzNFXmrMiKGJCozvaOxiwJxjZPJ(int _003C_003E1__state)
			{
			}
		}

		[NonSerialized]
		private bool aLzbAjHdyinuPAkYilYZkIGyBOc;

		[NonSerialized]
		private bool TUPvapCUmFSRuvJvEdvErJpSGTk;

		private List<IComponentControl> _controls;

		internal bool initialized => false;

		[CustomObfuscation]
		internal ComponentController()
		{
		}

		[CustomObfuscation]
		internal virtual void Awake()
		{
		}

		[CustomObfuscation]
		internal virtual void Update()
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
		internal virtual void OnValidate()
		{
		}

		[CustomObfuscation]
		internal virtual void OnDestroy()
		{
		}

		internal virtual bool vTErMpFqqbrJIuisyHNZEKHQiIJk()
		{
			return false;
		}

		internal virtual void icQxdQEDgrvBqfMTuplRHxKgMmr()
		{
		}

		internal virtual void NdtcFvGfnnZoRnENbmFXoawgFosU()
		{
		}

		private void MBBfAFdZYFHrhocHiLcrbaKidUfP(IComponentControl P_0)
		{
		}

		void IRegistrar<IComponentControl>.Register(IComponentControl P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in MBBfAFdZYFHrhocHiLcrbaKidUfP
			this.MBBfAFdZYFHrhocHiLcrbaKidUfP(P_0);
		}

		private void vawgaGKrAhIqlOfFdCbXDAsKqEiy(IComponentControl P_0)
		{
		}

		void IRegistrar<IComponentControl>.Deregister(IComponentControl P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in vawgaGKrAhIqlOfFdCbXDAsKqEiy
			this.vawgaGKrAhIqlOfFdCbXDAsKqEiy(P_0);
		}

		public virtual void ClearControlValues()
		{
		}

		private void kFgyZKEvDYhtdqUfYSYVoMNQuBC()
		{
		}

		private void DDSYIBWFCFbxtAeyTbUKilaTRGQv()
		{
		}

		private IEnumerator jRkLowJnAuGdOFmvSfCUDzgAuafI()
		{
			return null;
		}
	}
}
