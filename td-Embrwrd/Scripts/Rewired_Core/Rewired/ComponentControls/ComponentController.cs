using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	public abstract class ComponentController : MonoBehaviour, IComponentController, IRegistrar<IComponentControl>
	{
		private sealed class aYVBfDyUiqpvtIlZUwemvhxQaHNN : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int FGdNXMFevwKhrVMysnZZiMxKyuG;

			private object NACoHLFZIacWdklLDSJUJTgWuXWm;

			public ComponentController BxmbUBccDfLKFrJPHBTWgGTXWPFhb;

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
			public aYVBfDyUiqpvtIlZUwemvhxQaHNN(int P_0)
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

		[NonSerialized]
		private bool NxNWySPXZBuaJmuUDVGnpZdhPhIE;

		[NonSerialized]
		private bool rJEWFydMazRPXKABaeazgVogEofN;

		private List<IComponentControl> _controls;

		internal bool vmybvUKzWTeECxDTFFFLmSLjIMMJA => false;

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

		internal virtual bool uMJLSufFPDHRLbQQdnOsEiBJrFsM()
		{
			return false;
		}

		internal virtual void DrSuGCehGQihuvuqiFHElgOUyoEl()
		{
		}

		internal virtual void VJbZDNIelbgIwWhdWvrEgWPiKZeL()
		{
		}

		void IRegistrar<IComponentControl>.Register(IComponentControl control)
		{
		}

		void IRegistrar<IComponentControl>.Deregister(IComponentControl control)
		{
		}

		public virtual void ClearControlValues()
		{
		}

		private void xyccuEcjmuHwTsDJXMaSCInxHRIeA()
		{
		}

		private void raSPUvMWEjREPcIKyHCAXvyODIQBA()
		{
		}

		[IteratorStateMachine(typeof(aYVBfDyUiqpvtIlZUwemvhxQaHNN))]
		private IEnumerator hiFBZUUlXByucpOzbKqVgfInhVLAA()
		{
			return null;
		}
	}
}
