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
		private sealed class byOHamSfNidHEmdYyQntzWsbFKdB : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int CEXTwmyYxryjNNKcAMOAXFzMOezI;

			private object CMPTjmvDXavEBGatxMjNNXNjQFJU;

			public ComponentController YJlhsoSPCllMnnbpnlzFGegsEVEcA;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return CMPTjmvDXavEBGatxMjNNXNjQFJU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return CMPTjmvDXavEBGatxMjNNXNjQFJU;
				}
			}

			[DebuggerHidden]
			public byOHamSfNidHEmdYyQntzWsbFKdB(int P_0)
			{
				CEXTwmyYxryjNNKcAMOAXFzMOezI = P_0;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int cEXTwmyYxryjNNKcAMOAXFzMOezI = CEXTwmyYxryjNNKcAMOAXFzMOezI;
				ComponentController yJlhsoSPCllMnnbpnlzFGegsEVEcA = YJlhsoSPCllMnnbpnlzFGegsEVEcA;
				switch (cEXTwmyYxryjNNKcAMOAXFzMOezI)
				{
				default:
					return false;
				case 0:
					CEXTwmyYxryjNNKcAMOAXFzMOezI = -1;
					CMPTjmvDXavEBGatxMjNNXNjQFJU = null;
					CEXTwmyYxryjNNKcAMOAXFzMOezI = 1;
					return true;
				case 1:
					CEXTwmyYxryjNNKcAMOAXFzMOezI = -1;
					yJlhsoSPCllMnnbpnlzFGegsEVEcA.wLnSJtOjdkgurCndfOzXWUlWFgTC();
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
		private bool MBADaPnhMVZyIKoGbqlZvCcIfLZZ;

		[NonSerialized]
		private bool qxRknPHvtlZQzahiOQvauXhPcWmE;

		private List<IComponentControl> _controls = new List<IComponentControl>(10);

		internal bool aVrFdNyTWVUeoPzBhtEtmuMUQPob => MBADaPnhMVZyIKoGbqlZvCcIfLZZ;

		[CustomObfuscation(rename = false)]
		internal ComponentController()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Awake()
		{
			qxRknPHvtlZQzahiOQvauXhPcWmE = true;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Update()
		{
			if (!MBADaPnhMVZyIKoGbqlZvCcIfLZZ)
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
			if (!qxRknPHvtlZQzahiOQvauXhPcWmE)
			{
				StartCoroutine(ifMgpjyiADCiYcXFNOOUjghQdZSDb());
				qxRknPHvtlZQzahiOQvauXhPcWmE = true;
			}
			else
			{
				wLnSJtOjdkgurCndfOzXWUlWFgTC();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDisable()
		{
			if (MBADaPnhMVZyIKoGbqlZvCcIfLZZ)
			{
				UvofaosyXbMDCgHukBdPkCwNVybJ();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnValidate()
		{
			if (MBADaPnhMVZyIKoGbqlZvCcIfLZZ)
			{
				cqTzcKaHXrMAjCMeYEeFHmRtDABW();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDestroy()
		{
			_controls.Clear();
		}

		internal virtual bool zMetDDwGNeNhdJkVLipdWuoGPxCb()
		{
			return true;
		}

		internal virtual void SQRbGbEVsSfaUTCQMaxJAnffpgTGb()
		{
			UvofaosyXbMDCgHukBdPkCwNVybJ();
		}

		internal virtual void UvofaosyXbMDCgHukBdPkCwNVybJ()
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
			if (!MBADaPnhMVZyIKoGbqlZvCcIfLZZ)
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

		private void wLnSJtOjdkgurCndfOzXWUlWFgTC()
		{
			if (zMetDDwGNeNhdJkVLipdWuoGPxCb())
			{
				MBADaPnhMVZyIKoGbqlZvCcIfLZZ = true;
				SQRbGbEVsSfaUTCQMaxJAnffpgTGb();
			}
		}

		private void cqTzcKaHXrMAjCMeYEeFHmRtDABW()
		{
			_ = aVrFdNyTWVUeoPzBhtEtmuMUQPob;
		}

		[IteratorStateMachine(typeof(byOHamSfNidHEmdYyQntzWsbFKdB))]
		private IEnumerator ifMgpjyiADCiYcXFNOOUjghQdZSDb()
		{
			return new byOHamSfNidHEmdYyQntzWsbFKdB(0)
			{
				YJlhsoSPCllMnnbpnlzFGegsEVEcA = this
			};
		}
	}
}
