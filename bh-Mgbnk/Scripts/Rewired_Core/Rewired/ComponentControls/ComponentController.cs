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
		private sealed class fvIFvFhYGxdEloaGpEMMbSrmYVUn : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int GNNGxTdPKuJXvCVFePIvWFEVZKhDB;

			private object YpLVQDQmojfYnUkYanYgTyiiLhJh;

			public ComponentController MWrOaHpnMolbRzOJevKiEZGlJuIE;

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
			public fvIFvFhYGxdEloaGpEMMbSrmYVUn(int P_0)
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
		private bool QYQbImJEnYgNkSYdgGvyedFFOJRsA;

		[NonSerialized]
		private bool mqBrYwowSousTwsUDGIZcrmWemmn;

		private List<IComponentControl> _controls;

		internal bool qDfffMLSiSQvOXmYgcdlmgLFwWHU => false;

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

		internal virtual bool rjQJHucPbYJcRVnREFcEEEXpbVnAA()
		{
			return false;
		}

		internal virtual void IzXasWjsPBhTqjNhVojyvvKyIkFZ()
		{
		}

		internal virtual void GIwlJZRSZgetsqmmxaDeFkBMgXbyA()
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

		private void eefHgIzbWdEFJJKMybMuIQbDFVJOB()
		{
		}

		private void ccDEnxRnwahBFAVJFgYcHIgyAyBj()
		{
		}

		[IteratorStateMachine(typeof(fvIFvFhYGxdEloaGpEMMbSrmYVUn))]
		private IEnumerator eiIDdOBzQUTZuZolCCKnsCoXTxCd()
		{
			return null;
		}
	}
}
