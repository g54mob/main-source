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
		private sealed class DUSnnoENgIJmNKthjzNFQfyUcLL : IEnumerator<object>, IDisposable, IEnumerator
		{
			private object YDjDCBVmlkHQnKMyHwfXVborvEXS;

			private int KjzQtaNmLSFADNQocZpcbdUSqwW;

			public ComponentController OLVemnFdjzUkQSlFFFIOsrknazt;

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
			public DUSnnoENgIJmNKthjzNFQfyUcLL(int _003C_003E1__state)
			{
			}
		}

		[NonSerialized]
		private bool fjUzJMvfKUtkXCOEoCUtEkxLMZg;

		[NonSerialized]
		private bool WxwIROoIvtQQuhfdWYioNKebEOs;

		private List<IComponentControl> _controls;

		internal bool initialized => false;

		[CustomObfuscation(rename = false)]
		internal ComponentController()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Awake()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Update()
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
		internal virtual void OnValidate()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDestroy()
		{
		}

		internal virtual bool kCtpTQnECPegKfokmmotHswhcCLu()
		{
			return false;
		}

		internal virtual void zZvUXvigSJSyudmZqKMfzEpXBSj()
		{
		}

		internal virtual void ARKxKpVNqBlBYALxhmjYIBkRyuM()
		{
		}

		private void TCoamvbkTfebwaTFsPJoChfAYxQ(IComponentControl P_0)
		{
		}

		void IRegistrar<IComponentControl>.Register(IComponentControl P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in TCoamvbkTfebwaTFsPJoChfAYxQ
			this.TCoamvbkTfebwaTFsPJoChfAYxQ(P_0);
		}

		private void gbTKtRLwhLbbWvNjzCxMyNkXWsu(IComponentControl P_0)
		{
		}

		void IRegistrar<IComponentControl>.Deregister(IComponentControl P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in gbTKtRLwhLbbWvNjzCxMyNkXWsu
			this.gbTKtRLwhLbbWvNjzCxMyNkXWsu(P_0);
		}

		public virtual void ClearControlValues()
		{
		}

		private void poVnOvkmteayheSbSBjtUjavYwU()
		{
		}

		private void ILfKseeIovFotfIwVedwwNJgiCCt()
		{
		}

		private IEnumerator iwFWcLrHsKAwENtbSOrqBAFdtyv()
		{
			return null;
		}
	}
}
