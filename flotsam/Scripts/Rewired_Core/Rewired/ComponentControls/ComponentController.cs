using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	public abstract class ComponentController : MonoBehaviour, IComponentController, IRegistrar<IComponentControl>
	{
		private sealed class gfxvLvJjeeFZqQSpNqjxGZBEbtno : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int RFaQHbbrqdcEodPabYrEucmnPwEv;

			private object DvmxdloOzgaEughDOOnVoAHWznmd;

			public ComponentController NyWgphVOJvmLGDtxUSsBvCpDdkpi;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return DvmxdloOzgaEughDOOnVoAHWznmd;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return DvmxdloOzgaEughDOOnVoAHWznmd;
				}
			}

			[DebuggerHidden]
			public gfxvLvJjeeFZqQSpNqjxGZBEbtno(int P_0)
			{
				RFaQHbbrqdcEodPabYrEucmnPwEv = P_0;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				RFaQHbbrqdcEodPabYrEucmnPwEv = -2;
			}

			private bool MoveNext()
			{
				int rFaQHbbrqdcEodPabYrEucmnPwEv = RFaQHbbrqdcEodPabYrEucmnPwEv;
				ComponentController nyWgphVOJvmLGDtxUSsBvCpDdkpi = NyWgphVOJvmLGDtxUSsBvCpDdkpi;
				switch (rFaQHbbrqdcEodPabYrEucmnPwEv)
				{
				default:
					return false;
				case 0:
					RFaQHbbrqdcEodPabYrEucmnPwEv = -1;
					DvmxdloOzgaEughDOOnVoAHWznmd = null;
					RFaQHbbrqdcEodPabYrEucmnPwEv = 1;
					return true;
				case 1:
					RFaQHbbrqdcEodPabYrEucmnPwEv = -1;
					nyWgphVOJvmLGDtxUSsBvCpDdkpi.vWUSAcZoomeUQFobCBnFefXAlpyLc();
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
		private bool DDtNsQuQTBmMzyzSEsOTUEfjcnoHA;

		[NonSerialized]
		private bool rLoGcIgGkzHjCoUxdPforFCgCGBnA;

		private List<IComponentControl> _controls = new List<IComponentControl>(10);

		internal bool lMQvZchYGBtoHdgdKoOEVBrzUuoV => DDtNsQuQTBmMzyzSEsOTUEfjcnoHA;

		[CustomObfuscation(rename = false)]
		internal ComponentController()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Awake()
		{
			rLoGcIgGkzHjCoUxdPforFCgCGBnA = true;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Update()
		{
			if (!DDtNsQuQTBmMzyzSEsOTUEfjcnoHA)
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
			if (!rLoGcIgGkzHjCoUxdPforFCgCGBnA)
			{
				StartCoroutine(jDnfDanEHTEujtfXmFjIRBmhIbvZ());
				rLoGcIgGkzHjCoUxdPforFCgCGBnA = true;
			}
			else
			{
				vWUSAcZoomeUQFobCBnFefXAlpyLc();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDisable()
		{
			if (DDtNsQuQTBmMzyzSEsOTUEfjcnoHA)
			{
				VJRDzvCdjdbgjqIVXzkJaTfwrvYzA();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnValidate()
		{
			if (DDtNsQuQTBmMzyzSEsOTUEfjcnoHA)
			{
				boKcRQzInbmMkwonAHLCsQAbaaqA();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDestroy()
		{
			_controls.Clear();
		}

		internal virtual bool krxxzIAhHFWdGztieUXdjadLCxEZ()
		{
			return true;
		}

		internal virtual void JRyMOyJzrCKMjnPElRCJYJoGVKwo()
		{
			VJRDzvCdjdbgjqIVXzkJaTfwrvYzA();
		}

		internal virtual void VJRDzvCdjdbgjqIVXzkJaTfwrvYzA()
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
			if (!DDtNsQuQTBmMzyzSEsOTUEfjcnoHA)
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

		void IComponentController.ClearControlValues()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ClearControlValues
			this.ClearControlValues();
		}

		private void vWUSAcZoomeUQFobCBnFefXAlpyLc()
		{
			if (krxxzIAhHFWdGztieUXdjadLCxEZ())
			{
				DDtNsQuQTBmMzyzSEsOTUEfjcnoHA = true;
				JRyMOyJzrCKMjnPElRCJYJoGVKwo();
			}
		}

		private void boKcRQzInbmMkwonAHLCsQAbaaqA()
		{
			_ = lMQvZchYGBtoHdgdKoOEVBrzUuoV;
		}

		[IteratorStateMachine(typeof(gfxvLvJjeeFZqQSpNqjxGZBEbtno))]
		private IEnumerator jDnfDanEHTEujtfXmFjIRBmhIbvZ()
		{
			return new gfxvLvJjeeFZqQSpNqjxGZBEbtno(0)
			{
				NyWgphVOJvmLGDtxUSsBvCpDdkpi = this
			};
		}
	}
}
