using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Rewired.Utils;
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
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			[DebuggerHidden]
			public QpFJYBYDXMDgcsGHKfdYGyUrmGgG(int P_0)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
				ComponentController gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				switch (gwbUsvLqBorYvZEWvPDttSzVhFNo)
				{
				default:
					return false;
				case 0:
					GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
					USjDTWbJtWhEBdYYYfLUglTcnnGrA = null;
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
					return true;
				case 1:
					GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
					gZXxEqHwrHYIyUJtInpLwgTukJaY.zBFbVgFivIFkRriBBSLwgWJemDVY();
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

		[NonSerialized]
		private bool juAmOHdlEuZcdEbopfsigKMAJgtHb;

		[NonSerialized]
		private bool CmiBUFsLMHUgAlaHTFsrJVtqAftp;

		private List<IComponentControl> _controls = new List<IComponentControl>(10);

		internal bool qumTafanxrjKbDduWdypwIzXqmiP => juAmOHdlEuZcdEbopfsigKMAJgtHb;

		[CustomObfuscation(rename = false)]
		internal ComponentController()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Awake()
		{
			CmiBUFsLMHUgAlaHTFsrJVtqAftp = true;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Update()
		{
			if (!juAmOHdlEuZcdEbopfsigKMAJgtHb)
			{
				return;
			}
			for (int num = _controls.Count - 1; num >= 0; num--)
			{
				IComponentControl componentControl = _controls[num];
				if (componentControl.IsNullOrDestroyed())
				{
					_controls.RemoveAt(num);
				}
				else
				{
					componentControl.Update();
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnEnable()
		{
			if (!CmiBUFsLMHUgAlaHTFsrJVtqAftp)
			{
				StartCoroutine(oIJZAQnbeycmsJfVDhBvXlqkKBaV());
				CmiBUFsLMHUgAlaHTFsrJVtqAftp = true;
			}
			else
			{
				zBFbVgFivIFkRriBBSLwgWJemDVY();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDisable()
		{
			if (juAmOHdlEuZcdEbopfsigKMAJgtHb)
			{
				KhQueZDBBtkbvKkxubYmYxeSHJrfA();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnValidate()
		{
			if (juAmOHdlEuZcdEbopfsigKMAJgtHb)
			{
				CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDestroy()
		{
			_controls.Clear();
		}

		internal virtual bool qrhyEDreMhRqasASvGWwEiXwPpSPA()
		{
			return true;
		}

		internal virtual void pmxmOeyRAlBoCxmllQyaxtECbvcr()
		{
			KhQueZDBBtkbvKkxubYmYxeSHJrfA();
		}

		internal virtual void KhQueZDBBtkbvKkxubYmYxeSHJrfA()
		{
		}

		void IRegistrar<IComponentControl>.Register(IComponentControl control)
		{
			if (!control.IsNullOrDestroyed())
			{
				ListTools.AddIfUnique(_controls, control);
			}
		}

		void IRegistrar<IComponentControl>.Deregister(IComponentControl control)
		{
			if (!control.IsNullOrDestroyed())
			{
				_controls.Remove(control);
			}
		}

		public virtual void ClearControlValues()
		{
			if (!juAmOHdlEuZcdEbopfsigKMAJgtHb)
			{
				return;
			}
			for (int num = _controls.Count - 1; num >= 0; num--)
			{
				if (_controls[num].IsNullOrDestroyed())
				{
					_controls.RemoveAt(num);
				}
				else
				{
					_controls[num].ClearValue();
				}
			}
		}

		private void zBFbVgFivIFkRriBBSLwgWJemDVY()
		{
			if (qrhyEDreMhRqasASvGWwEiXwPpSPA())
			{
				juAmOHdlEuZcdEbopfsigKMAJgtHb = true;
				pmxmOeyRAlBoCxmllQyaxtECbvcr();
			}
		}

		private void CbvCdtcgkXIqLYOKEKJdhBmfrjFcB()
		{
			_ = qumTafanxrjKbDduWdypwIzXqmiP;
		}

		private IEnumerator oIJZAQnbeycmsJfVDhBvXlqkKBaV()
		{
			return new QpFJYBYDXMDgcsGHKfdYGyUrmGgG(0)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this
			};
		}
	}
}
