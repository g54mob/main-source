using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	public abstract class ComponentControl : MonoBehaviour, IComponentControl
	{
		private sealed class dTpcXtKWJJGNmdBXtbXXBrayugRGb : IDisposable, IEnumerator, IEnumerator<object>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private object vjnbYLtrPMftzpjohNfommerCnGo;

			public ComponentControl zITtixdgVFWlEnpDnrTdnZsdTFkt;

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
			public dTpcXtKWJJGNmdBXtbXXBrayugRGb(int P_0)
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
				ComponentControl componentControl = zITtixdgVFWlEnpDnrTdnZsdTFkt;
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
					if (!componentControl.uITeqmergHcifeDewaJvLHRSazjqA())
					{
						return false;
					}
					componentControl.OnEnable();
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
		private bool UKOJIKREswByZtkIQEUQJcfFaZxF;

		[NonSerialized]
		private bool zveWMGCGsXLfiCRtikKTUHGvYznT;

		private int _lastUpdateFrame = -1;

		internal abstract bool UTvbNmLtOtvCXnKmzpVoOCmLyTeb { get; }

		internal bool DlyzgeEtPbGSRivIvEmZhBSIEqiU => UKOJIKREswByZtkIQEUQJcfFaZxF;

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
				vjhEkIpbiwZRwstmkNxqMDjviCZ();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Awake()
		{
			zveWMGCGsXLfiCRtikKTUHGvYznT = true;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Start()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnEnable()
		{
			if (!zveWMGCGsXLfiCRtikKTUHGvYznT)
			{
				UKOJIKREswByZtkIQEUQJcfFaZxF = false;
				StartCoroutine(VTAGTEaSbuuhWzPbGTlHjpkrVRKE());
				zveWMGCGsXLfiCRtikKTUHGvYznT = true;
			}
			else if (Application.isPlaying)
			{
				EfZYTxAmPOLzlDbwclhSLCyvTxPf();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDisable()
		{
			if (Application.isPlaying)
			{
				HApQuzDqCOpDoQUCNydAXROgZJPA();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDestroy()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnValidate()
		{
			if (UKOJIKREswByZtkIQEUQJcfFaZxF)
			{
				QCTiHbMbjMBiDhGopGJUAtTEkvFmB();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnCanvasGroupChanged()
		{
			if (UKOJIKREswByZtkIQEUQJcfFaZxF)
			{
				VVilVmPMVTHSapxdAhwgqdXLBNUd(false, false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnTransformParentChanged()
		{
			if (UKOJIKREswByZtkIQEUQJcfFaZxF)
			{
				VVilVmPMVTHSapxdAhwgqdXLBNUd(false, false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDidApplyAnimationProperties()
		{
			_ = UKOJIKREswByZtkIQEUQJcfFaZxF;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Reset()
		{
			_ = UKOJIKREswByZtkIQEUQJcfFaZxF;
		}

		internal virtual void vjhEkIpbiwZRwstmkNxqMDjviCZ()
		{
		}

		internal virtual bool BUnNPMFoanNJCVAmWibAzWafnjUk()
		{
			UKOJIKREswByZtkIQEUQJcfFaZxF = false;
			if (!VVilVmPMVTHSapxdAhwgqdXLBNUd(true, true))
			{
				return false;
			}
			_controller.Register(this);
			return true;
		}

		internal virtual void HApQuzDqCOpDoQUCNydAXROgZJPA()
		{
			ClearValue();
			if (!_controller.IsNullOrDestroyed())
			{
				_controller.Deregister(this);
			}
			tDIDrACtxdHSRUhHLVoEeNTZdDjmA();
			UKOJIKREswByZtkIQEUQJcfFaZxF = false;
		}

		internal virtual void OCbTyrEcaxLtyGXBEYyEklZHhUaE()
		{
			if (!_controller.IsNullOrDestroyed())
			{
				tDIDrACtxdHSRUhHLVoEeNTZdDjmA();
			}
		}

		internal virtual void tDIDrACtxdHSRUhHLVoEeNTZdDjmA()
		{
			_controller.IsNullOrDestroyed();
		}

		internal virtual void jebsoqOBGHhJxfFgdjbRaKVujtZwA()
		{
			if (UKOJIKREswByZtkIQEUQJcfFaZxF)
			{
				QCTiHbMbjMBiDhGopGJUAtTEkvFmB();
			}
		}

		internal virtual void XetDzXgLfjrusCzyhbGhxGxLsdqi()
		{
			_ = UKOJIKREswByZtkIQEUQJcfFaZxF;
		}

		internal virtual void kvtAMBhXvoFvKTDvbPnZAgXAnVeob()
		{
		}

		internal bool uITeqmergHcifeDewaJvLHRSazjqA()
		{
			return UnityTools.IsActiveAndEnabled(this);
		}

		internal bool foxxfopNBfWqtdkSbRJWMrXhhLjd()
		{
			return this == null;
		}

		internal IComponentController EeYfqFPkRpVrFkmpuxsjzylIxkOL()
		{
			return _controller;
		}

		[CustomObfuscation(rename = false)]
		internal abstract IComponentController FindController();

		[CustomObfuscation(rename = false)]
		internal abstract Type GetRequiredControllerType();

		private IEnumerator VTAGTEaSbuuhWzPbGTlHjpkrVRKE()
		{
			return new dTpcXtKWJJGNmdBXtbXXBrayugRGb(0)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this
			};
		}

		private void EfZYTxAmPOLzlDbwclhSLCyvTxPf()
		{
			if (BUnNPMFoanNJCVAmWibAzWafnjUk())
			{
				kvtAMBhXvoFvKTDvbPnZAgXAnVeob();
				UKOJIKREswByZtkIQEUQJcfFaZxF = true;
				OCbTyrEcaxLtyGXBEYyEklZHhUaE();
			}
		}

		private bool VVilVmPMVTHSapxdAhwgqdXLBNUd(bool P_0, bool P_1)
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
					if ((object)type == null)
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
					EfZYTxAmPOLzlDbwclhSLCyvTxPf();
				}
				return true;
			}
			catch
			{
				HApQuzDqCOpDoQUCNydAXROgZJPA();
				return false;
			}
		}

		private void QCTiHbMbjMBiDhGopGJUAtTEkvFmB()
		{
			VVilVmPMVTHSapxdAhwgqdXLBNUd(false, true);
		}

		private void IoPBHeHjgYoepTpIGIpITPQFgrKfb()
		{
			if (!foxxfopNBfWqtdkSbRJWMrXhhLjd() && uITeqmergHcifeDewaJvLHRSazjqA())
			{
				vjhEkIpbiwZRwstmkNxqMDjviCZ();
			}
		}
	}
}
