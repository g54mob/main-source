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
		private sealed class QpFJYBYDXMDgcsGHKfdYGyUrmGgG : IDisposable, IEnumerator, IEnumerator<object>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private object USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			public ComponentController GZXxEqHwrHYIyUJtInpLwgTukJaY;

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
			public QpFJYBYDXMDgcsGHKfdYGyUrmGgG(int P_0)
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
		private bool juAmOHdlEuZcdEbopfsigKMAJgtHb;

		[NonSerialized]
		private bool CmiBUFsLMHUgAlaHTFsrJVtqAftp;

		private List<IComponentControl> _controls;

		internal bool qumTafanxrjKbDduWdypwIzXqmiP => false;

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

		internal virtual bool qrhyEDreMhRqasASvGWwEiXwPpSPA()
		{
			return false;
		}

		internal virtual void pmxmOeyRAlBoCxmllQyaxtECbvcr()
		{
		}

		internal virtual void KhQueZDBBtkbvKkxubYmYxeSHJrfA()
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

		private void zBFbVgFivIFkRriBBSLwgWJemDVY()
		{
		}

		private void CbvCdtcgkXIqLYOKEKJdhBmfrjFcB()
		{
		}

		private IEnumerator oIJZAQnbeycmsJfVDhBvXlqkKBaV()
		{
			return null;
		}
	}
}
