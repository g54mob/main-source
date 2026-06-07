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
		private sealed class cEaUKBKEpnItBczycsYDjIaAShCU : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int JanYOJuxSewHNZdgEMOyVZTdyvzc;

			private object LJdQeBzhHbWCPSIihnppLSrOvWLL;

			public ComponentController HrPgtRdKEuhQjPtmlsbtoYGNXfMQ;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return LJdQeBzhHbWCPSIihnppLSrOvWLL;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return LJdQeBzhHbWCPSIihnppLSrOvWLL;
				}
			}

			[DebuggerHidden]
			public cEaUKBKEpnItBczycsYDjIaAShCU(int P_0)
			{
				JanYOJuxSewHNZdgEMOyVZTdyvzc = P_0;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int janYOJuxSewHNZdgEMOyVZTdyvzc = JanYOJuxSewHNZdgEMOyVZTdyvzc;
				ComponentController hrPgtRdKEuhQjPtmlsbtoYGNXfMQ = HrPgtRdKEuhQjPtmlsbtoYGNXfMQ;
				switch (janYOJuxSewHNZdgEMOyVZTdyvzc)
				{
				default:
					return false;
				case 0:
					JanYOJuxSewHNZdgEMOyVZTdyvzc = -1;
					LJdQeBzhHbWCPSIihnppLSrOvWLL = null;
					JanYOJuxSewHNZdgEMOyVZTdyvzc = 1;
					return true;
				case 1:
					JanYOJuxSewHNZdgEMOyVZTdyvzc = -1;
					hrPgtRdKEuhQjPtmlsbtoYGNXfMQ.xIXDROAcjpyRfGfmxgGjWcsrPvJN();
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
		private bool VujmKrUCMsCBERDpztrfSchjZtc;

		[NonSerialized]
		private bool rwhfEeDgbuDHdgwwYHEIoebozYwR;

		private List<IComponentControl> _controls = new List<IComponentControl>(10);

		internal bool vVBMHOaiZSIwaPgabflmyrUvnkZp => VujmKrUCMsCBERDpztrfSchjZtc;

		[CustomObfuscation(rename = false)]
		internal ComponentController()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Awake()
		{
			rwhfEeDgbuDHdgwwYHEIoebozYwR = true;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Update()
		{
			if (!VujmKrUCMsCBERDpztrfSchjZtc)
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
			if (!rwhfEeDgbuDHdgwwYHEIoebozYwR)
			{
				StartCoroutine(lFajwMwgQWdgMFTQPZSmpeRdanCqA());
				rwhfEeDgbuDHdgwwYHEIoebozYwR = true;
			}
			else
			{
				xIXDROAcjpyRfGfmxgGjWcsrPvJN();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDisable()
		{
			if (VujmKrUCMsCBERDpztrfSchjZtc)
			{
				BrYsCHknmsSsEufEcJfpwvYujXfg();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnValidate()
		{
			if (VujmKrUCMsCBERDpztrfSchjZtc)
			{
				dlbNxdsDXgFWdCvjMbwtFHjUGiRib();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDestroy()
		{
			_controls.Clear();
		}

		internal virtual bool sPkmSmDAUKcXrXAnJqkTKtIVIjdw()
		{
			return true;
		}

		internal virtual void HMvTWDIodFaaSNPNAbMfnNGGUOLd()
		{
			BrYsCHknmsSsEufEcJfpwvYujXfg();
		}

		internal virtual void BrYsCHknmsSsEufEcJfpwvYujXfg()
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
			if (!VujmKrUCMsCBERDpztrfSchjZtc)
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

		private void xIXDROAcjpyRfGfmxgGjWcsrPvJN()
		{
			if (sPkmSmDAUKcXrXAnJqkTKtIVIjdw())
			{
				VujmKrUCMsCBERDpztrfSchjZtc = true;
				HMvTWDIodFaaSNPNAbMfnNGGUOLd();
			}
		}

		private void dlbNxdsDXgFWdCvjMbwtFHjUGiRib()
		{
			_ = vVBMHOaiZSIwaPgabflmyrUvnkZp;
		}

		[IteratorStateMachine(typeof(cEaUKBKEpnItBczycsYDjIaAShCU))]
		private IEnumerator lFajwMwgQWdgMFTQPZSmpeRdanCqA()
		{
			return new cEaUKBKEpnItBczycsYDjIaAShCU(0)
			{
				HrPgtRdKEuhQjPtmlsbtoYGNXfMQ = this
			};
		}
	}
}
