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
		private sealed class gidLuJHgoZEyIqlaQjyUDQSLBNkC : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int ZWsTbNvaaOKPKTzyaHdlhMtymKPW;

			private object BGwgrJasYJtlEKCdJgAwVjPFqRjmA;

			public ComponentController HUKQcTFQRMKvmbglXIMaissYCBwib;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return BGwgrJasYJtlEKCdJgAwVjPFqRjmA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return BGwgrJasYJtlEKCdJgAwVjPFqRjmA;
				}
			}

			[DebuggerHidden]
			public gidLuJHgoZEyIqlaQjyUDQSLBNkC(int P_0)
			{
				ZWsTbNvaaOKPKTzyaHdlhMtymKPW = P_0;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int zWsTbNvaaOKPKTzyaHdlhMtymKPW = ZWsTbNvaaOKPKTzyaHdlhMtymKPW;
				ComponentController hUKQcTFQRMKvmbglXIMaissYCBwib = HUKQcTFQRMKvmbglXIMaissYCBwib;
				switch (zWsTbNvaaOKPKTzyaHdlhMtymKPW)
				{
				default:
					return false;
				case 0:
					ZWsTbNvaaOKPKTzyaHdlhMtymKPW = -1;
					BGwgrJasYJtlEKCdJgAwVjPFqRjmA = null;
					ZWsTbNvaaOKPKTzyaHdlhMtymKPW = 1;
					return true;
				case 1:
					ZWsTbNvaaOKPKTzyaHdlhMtymKPW = -1;
					hUKQcTFQRMKvmbglXIMaissYCBwib.bMUKEQDkVFTZmUfWRnkqqYnmThxe();
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
		private bool JhtyDuuMLuRcVGxSFOHoXvkyNitK;

		[NonSerialized]
		private bool fZamyXUwVGqwRulNkhJnYVAvqMiB;

		private List<IComponentControl> _controls = new List<IComponentControl>(10);

		internal bool npUXsKbOEynGhJdlZSjtANusWkzh => JhtyDuuMLuRcVGxSFOHoXvkyNitK;

		[CustomObfuscation(rename = false)]
		internal ComponentController()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Awake()
		{
			fZamyXUwVGqwRulNkhJnYVAvqMiB = true;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Update()
		{
			if (!JhtyDuuMLuRcVGxSFOHoXvkyNitK)
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
			if (!fZamyXUwVGqwRulNkhJnYVAvqMiB)
			{
				StartCoroutine(hzxqzUfWRgFHJBgLhcvjEMhwpRmLA());
				fZamyXUwVGqwRulNkhJnYVAvqMiB = true;
			}
			else
			{
				bMUKEQDkVFTZmUfWRnkqqYnmThxe();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDisable()
		{
			if (JhtyDuuMLuRcVGxSFOHoXvkyNitK)
			{
				NTahPGjxAhzZJkVWasyXKifnJZlA();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnValidate()
		{
			if (JhtyDuuMLuRcVGxSFOHoXvkyNitK)
			{
				rrcEarhfOMDbmuMoaAPsapDALCjaB();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDestroy()
		{
			_controls.Clear();
		}

		internal virtual bool gtprIgCABgcKcToifLuQoNiSJmJG()
		{
			return true;
		}

		internal virtual void HjqYjOFqjzPiBFsMoKCkBGrJDcvO()
		{
			NTahPGjxAhzZJkVWasyXKifnJZlA();
		}

		internal virtual void NTahPGjxAhzZJkVWasyXKifnJZlA()
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
			if (!JhtyDuuMLuRcVGxSFOHoXvkyNitK)
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

		private void bMUKEQDkVFTZmUfWRnkqqYnmThxe()
		{
			if (gtprIgCABgcKcToifLuQoNiSJmJG())
			{
				JhtyDuuMLuRcVGxSFOHoXvkyNitK = true;
				HjqYjOFqjzPiBFsMoKCkBGrJDcvO();
			}
		}

		private void rrcEarhfOMDbmuMoaAPsapDALCjaB()
		{
			_ = npUXsKbOEynGhJdlZSjtANusWkzh;
		}

		[IteratorStateMachine(typeof(gidLuJHgoZEyIqlaQjyUDQSLBNkC))]
		private IEnumerator hzxqzUfWRgFHJBgLhcvjEMhwpRmLA()
		{
			return new gidLuJHgoZEyIqlaQjyUDQSLBNkC(0)
			{
				HUKQcTFQRMKvmbglXIMaissYCBwib = this
			};
		}
	}
}
