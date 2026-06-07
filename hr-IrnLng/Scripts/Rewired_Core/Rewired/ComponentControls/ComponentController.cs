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
		private sealed class VPaFSPCRHGlUEQlTFnWSYuTPOcKM : IEnumerator<object>, IDisposable, IEnumerator
		{
			private object WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			public ComponentController GxphHAMqMhNBLjnlhXuBQmXaALiE;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			private bool MoveNext()
			{
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 0:
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
					WCNlIsEdYuVTqbNYvICUPcTebLU = null;
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
					return true;
				case 1:
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
					GxphHAMqMhNBLjnlhXuBQmXaALiE.zptlECrQiHzwILTuMWcaXVcgZFC();
					break;
				}
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
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public VPaFSPCRHGlUEQlTFnWSYuTPOcKM(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
			}
		}

		[NonSerialized]
		private bool rXobafaxvUDrItlgWahiaYSKJqn;

		[NonSerialized]
		private bool MiSexzdwxtpRdMgXwPzvhUxarph;

		private List<IComponentControl> _controls = new List<IComponentControl>(10);

		internal bool initialized => rXobafaxvUDrItlgWahiaYSKJqn;

		[CustomObfuscation(rename = false)]
		internal ComponentController()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Awake()
		{
			MiSexzdwxtpRdMgXwPzvhUxarph = true;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Update()
		{
			if (!rXobafaxvUDrItlgWahiaYSKJqn)
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
			if (!MiSexzdwxtpRdMgXwPzvhUxarph)
			{
				StartCoroutine(kjffjqbaNIFxRdwPcsIndzmiWLkf());
				MiSexzdwxtpRdMgXwPzvhUxarph = true;
			}
			else
			{
				zptlECrQiHzwILTuMWcaXVcgZFC();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDisable()
		{
			if (rXobafaxvUDrItlgWahiaYSKJqn)
			{
				EryQQjAUaPnoItWfLGLmyUsSpHl();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnValidate()
		{
			if (rXobafaxvUDrItlgWahiaYSKJqn)
			{
				MxNDYRdNWvbuwnEvdAejdyZphUD();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDestroy()
		{
			_controls.Clear();
		}

		internal virtual bool yTsKtkkrFvbLTmEALJcKJZadFG()
		{
			return true;
		}

		internal virtual void dJZdkEnsfJibdbIbYyjwTTIGMtqV()
		{
			EryQQjAUaPnoItWfLGLmyUsSpHl();
		}

		internal virtual void EryQQjAUaPnoItWfLGLmyUsSpHl()
		{
		}

		private void PfGLNFkDHbSnqTqzUDkGwFOPaniG(IComponentControl P_0)
		{
			if (!P_0.IsNullOrDestroyed())
			{
				ListTools.AddIfUnique(_controls, P_0);
			}
		}

		void IRegistrar<IComponentControl>.Register(IComponentControl P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in PfGLNFkDHbSnqTqzUDkGwFOPaniG
			this.PfGLNFkDHbSnqTqzUDkGwFOPaniG(P_0);
		}

		private void mednlCKZFZumiMNxDzMgGjgUFhz(IComponentControl P_0)
		{
			if (!P_0.IsNullOrDestroyed())
			{
				_controls.Remove(P_0);
			}
		}

		void IRegistrar<IComponentControl>.Deregister(IComponentControl P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in mednlCKZFZumiMNxDzMgGjgUFhz
			this.mednlCKZFZumiMNxDzMgGjgUFhz(P_0);
		}

		public virtual void ClearControlValues()
		{
			if (!rXobafaxvUDrItlgWahiaYSKJqn)
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

		private void zptlECrQiHzwILTuMWcaXVcgZFC()
		{
			if (yTsKtkkrFvbLTmEALJcKJZadFG())
			{
				rXobafaxvUDrItlgWahiaYSKJqn = true;
				dJZdkEnsfJibdbIbYyjwTTIGMtqV();
			}
		}

		private void MxNDYRdNWvbuwnEvdAejdyZphUD()
		{
			_ = initialized;
		}

		private IEnumerator kjffjqbaNIFxRdwPcsIndzmiWLkf()
		{
			VPaFSPCRHGlUEQlTFnWSYuTPOcKM vPaFSPCRHGlUEQlTFnWSYuTPOcKM = new VPaFSPCRHGlUEQlTFnWSYuTPOcKM(0);
			vPaFSPCRHGlUEQlTFnWSYuTPOcKM.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			return vPaFSPCRHGlUEQlTFnWSYuTPOcKM;
		}
	}
}
