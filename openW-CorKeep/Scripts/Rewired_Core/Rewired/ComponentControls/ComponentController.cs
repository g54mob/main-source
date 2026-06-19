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
		private sealed class ebxuVopvGydHSzDPYCgMaZPrsqzLA : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int TIwuZcXdWfoAIKUEqnajroyGdvKu;

			private object TAeAruOjkiokIJpTXLUafAMpeeiO;

			public ComponentController BTOeMgbbBlynqiNDZPRmszPsgWtE;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return TAeAruOjkiokIJpTXLUafAMpeeiO;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return TAeAruOjkiokIJpTXLUafAMpeeiO;
				}
			}

			[DebuggerHidden]
			public ebxuVopvGydHSzDPYCgMaZPrsqzLA(int P_0)
			{
				TIwuZcXdWfoAIKUEqnajroyGdvKu = P_0;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				TIwuZcXdWfoAIKUEqnajroyGdvKu = -2;
			}

			private bool MoveNext()
			{
				int tIwuZcXdWfoAIKUEqnajroyGdvKu = TIwuZcXdWfoAIKUEqnajroyGdvKu;
				ComponentController bTOeMgbbBlynqiNDZPRmszPsgWtE = BTOeMgbbBlynqiNDZPRmszPsgWtE;
				switch (tIwuZcXdWfoAIKUEqnajroyGdvKu)
				{
				default:
					return false;
				case 0:
					TIwuZcXdWfoAIKUEqnajroyGdvKu = -1;
					TAeAruOjkiokIJpTXLUafAMpeeiO = null;
					TIwuZcXdWfoAIKUEqnajroyGdvKu = 1;
					return true;
				case 1:
					TIwuZcXdWfoAIKUEqnajroyGdvKu = -1;
					bTOeMgbbBlynqiNDZPRmszPsgWtE.jzYOGjxcWaEGyiZJZPumgiJIfceuA();
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
		private bool RArbiZkSnFGOHtLmBODkuXbCDieSA;

		[NonSerialized]
		private bool lMkEyXsSSjuvwnOFiJoZOJGJiNBN;

		private List<IComponentControl> _controls = new List<IComponentControl>(10);

		internal bool nOUrFzHwiRQsdKlDZbDjWmtAGxuU => RArbiZkSnFGOHtLmBODkuXbCDieSA;

		[CustomObfuscation(rename = false)]
		internal ComponentController()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Awake()
		{
			lMkEyXsSSjuvwnOFiJoZOJGJiNBN = true;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Update()
		{
			if (!RArbiZkSnFGOHtLmBODkuXbCDieSA)
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
			if (!lMkEyXsSSjuvwnOFiJoZOJGJiNBN)
			{
				StartCoroutine(tEhtpdTtsRENNIlEtgsjSmCGyPpC());
				lMkEyXsSSjuvwnOFiJoZOJGJiNBN = true;
			}
			else
			{
				jzYOGjxcWaEGyiZJZPumgiJIfceuA();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDisable()
		{
			if (RArbiZkSnFGOHtLmBODkuXbCDieSA)
			{
				HKZIjcNrZbeuHbqxOZfsSZtHhcAP();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnValidate()
		{
			if (RArbiZkSnFGOHtLmBODkuXbCDieSA)
			{
				hxwcVUZZwhiBsRRWwETefDUpnjgj();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDestroy()
		{
			_controls.Clear();
		}

		internal virtual bool qnnOhHqUbTJfaKJMvhSGkKfgNwIo()
		{
			return true;
		}

		internal virtual void VwaVUxjMTSiSBOiayDTcbJgrpHuyA()
		{
			HKZIjcNrZbeuHbqxOZfsSZtHhcAP();
		}

		internal virtual void HKZIjcNrZbeuHbqxOZfsSZtHhcAP()
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
			if (!RArbiZkSnFGOHtLmBODkuXbCDieSA)
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

		private void jzYOGjxcWaEGyiZJZPumgiJIfceuA()
		{
			if (qnnOhHqUbTJfaKJMvhSGkKfgNwIo())
			{
				RArbiZkSnFGOHtLmBODkuXbCDieSA = true;
				VwaVUxjMTSiSBOiayDTcbJgrpHuyA();
			}
		}

		private void hxwcVUZZwhiBsRRWwETefDUpnjgj()
		{
			_ = nOUrFzHwiRQsdKlDZbDjWmtAGxuU;
		}

		[IteratorStateMachine(typeof(ebxuVopvGydHSzDPYCgMaZPrsqzLA))]
		private IEnumerator tEhtpdTtsRENNIlEtgsjSmCGyPpC()
		{
			return new ebxuVopvGydHSzDPYCgMaZPrsqzLA(0)
			{
				BTOeMgbbBlynqiNDZPRmszPsgWtE = this
			};
		}
	}
}
