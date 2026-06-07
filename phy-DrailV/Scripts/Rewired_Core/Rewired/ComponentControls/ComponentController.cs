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
		private sealed class dmPrQOwCvGXyEBXypuBoVKLsiiucA : IDisposable, IEnumerator, IEnumerator<object>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private object vjnbYLtrPMftzpjohNfommerCnGo;

			public ComponentController zITtixdgVFWlEnpDnrTdnZsdTFkt;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			[DebuggerHidden]
			public dmPrQOwCvGXyEBXypuBoVKLsiiucA(int P_0)
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
				ComponentController componentController = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				switch (num)
				{
				default:
					return false;
				case 0:
					hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
					vjnbYLtrPMftzpjohNfommerCnGo = null;
					hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
					return true;
				case 1:
					hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
					componentController.EfZYTxAmPOLzlDbwclhSLCyvTxPf();
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
		private bool UKOJIKREswByZtkIQEUQJcfFaZxF;

		[NonSerialized]
		private bool zveWMGCGsXLfiCRtikKTUHGvYznT;

		private List<IComponentControl> _controls = new List<IComponentControl>(10);

		internal bool DlyzgeEtPbGSRivIvEmZhBSIEqiU => UKOJIKREswByZtkIQEUQJcfFaZxF;

		[CustomObfuscation(rename = false)]
		internal ComponentController()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Awake()
		{
			zveWMGCGsXLfiCRtikKTUHGvYznT = true;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Update()
		{
			if (!UKOJIKREswByZtkIQEUQJcfFaZxF)
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
			if (!zveWMGCGsXLfiCRtikKTUHGvYznT)
			{
				StartCoroutine(PsBnYBNcIeaNOjkbmYhFhSLpETkmA());
				zveWMGCGsXLfiCRtikKTUHGvYznT = true;
			}
			else
			{
				EfZYTxAmPOLzlDbwclhSLCyvTxPf();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDisable()
		{
			if (UKOJIKREswByZtkIQEUQJcfFaZxF)
			{
				tDIDrACtxdHSRUhHLVoEeNTZdDjmA();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnValidate()
		{
			if (UKOJIKREswByZtkIQEUQJcfFaZxF)
			{
				jebsoqOBGHhJxfFgdjbRaKVujtZwA();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDestroy()
		{
			_controls.Clear();
		}

		internal virtual bool BUnNPMFoanNJCVAmWibAzWafnjUk()
		{
			return true;
		}

		internal virtual void OCbTyrEcaxLtyGXBEYyEklZHhUaE()
		{
			tDIDrACtxdHSRUhHLVoEeNTZdDjmA();
		}

		internal virtual void tDIDrACtxdHSRUhHLVoEeNTZdDjmA()
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
			if (!UKOJIKREswByZtkIQEUQJcfFaZxF)
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

		private void EfZYTxAmPOLzlDbwclhSLCyvTxPf()
		{
			if (BUnNPMFoanNJCVAmWibAzWafnjUk())
			{
				UKOJIKREswByZtkIQEUQJcfFaZxF = true;
				OCbTyrEcaxLtyGXBEYyEklZHhUaE();
			}
		}

		private void jebsoqOBGHhJxfFgdjbRaKVujtZwA()
		{
			_ = DlyzgeEtPbGSRivIvEmZhBSIEqiU;
		}

		private IEnumerator PsBnYBNcIeaNOjkbmYhFhSLpETkmA()
		{
			return new dmPrQOwCvGXyEBXypuBoVKLsiiucA(0)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this
			};
		}
	}
}
