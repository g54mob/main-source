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
		private sealed class NsPUuNHvbotSrhfqjuZWUbiohnaR : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int mpUnqXtynvRNrUthHcHdsPXFhuXp;

			private object qOKMHmqViNftILicqasdwnXknzMc;

			public ComponentController uXgNFFTPGhneVqBwcBeidiStwzeq;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return qOKMHmqViNftILicqasdwnXknzMc;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return qOKMHmqViNftILicqasdwnXknzMc;
				}
			}

			[DebuggerHidden]
			public NsPUuNHvbotSrhfqjuZWUbiohnaR(int P_0)
			{
				mpUnqXtynvRNrUthHcHdsPXFhuXp = P_0;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = mpUnqXtynvRNrUthHcHdsPXFhuXp;
				ComponentController componentController = uXgNFFTPGhneVqBwcBeidiStwzeq;
				switch (num)
				{
				default:
					return false;
				case 0:
					mpUnqXtynvRNrUthHcHdsPXFhuXp = -1;
					qOKMHmqViNftILicqasdwnXknzMc = null;
					mpUnqXtynvRNrUthHcHdsPXFhuXp = 1;
					return true;
				case 1:
					mpUnqXtynvRNrUthHcHdsPXFhuXp = -1;
					componentController.KZuybILvfecJRZJwegDadOaLdzfy();
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
		private bool uSBOFasFCHWZmZnPagmyCsYNJhtn;

		[NonSerialized]
		private bool QmMDFsDCfjHyHgzyXNTNYHtSgGWsA;

		private List<IComponentControl> _controls = new List<IComponentControl>(10);

		internal bool OjwyyShaVZddEAIgczmdLpCXEwvO => uSBOFasFCHWZmZnPagmyCsYNJhtn;

		[CustomObfuscation(rename = false)]
		internal ComponentController()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Awake()
		{
			QmMDFsDCfjHyHgzyXNTNYHtSgGWsA = true;
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Update()
		{
			if (!uSBOFasFCHWZmZnPagmyCsYNJhtn)
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
			if (!QmMDFsDCfjHyHgzyXNTNYHtSgGWsA)
			{
				StartCoroutine(OMHCoUnrSHBGqQBQGgTdFNXDaboGA());
				QmMDFsDCfjHyHgzyXNTNYHtSgGWsA = true;
			}
			else
			{
				KZuybILvfecJRZJwegDadOaLdzfy();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDisable()
		{
			if (uSBOFasFCHWZmZnPagmyCsYNJhtn)
			{
				qjtGMThbqhwbqndEpiIqbPGhYhZZB();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnValidate()
		{
			if (uSBOFasFCHWZmZnPagmyCsYNJhtn)
			{
				MUMLCppDcdfMHNvcHjcyaEtqcQrG();
			}
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDestroy()
		{
			_controls.Clear();
		}

		internal virtual bool PGFtMgCcUTxuZUebGhlQEzGbHtDRA()
		{
			return true;
		}

		internal virtual void oCKTnYDkoWLDySiPBgTkAYDsOrzh()
		{
			qjtGMThbqhwbqndEpiIqbPGhYhZZB();
		}

		internal virtual void qjtGMThbqhwbqndEpiIqbPGhYhZZB()
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
			if (!uSBOFasFCHWZmZnPagmyCsYNJhtn)
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

		private void KZuybILvfecJRZJwegDadOaLdzfy()
		{
			if (PGFtMgCcUTxuZUebGhlQEzGbHtDRA())
			{
				uSBOFasFCHWZmZnPagmyCsYNJhtn = true;
				oCKTnYDkoWLDySiPBgTkAYDsOrzh();
			}
		}

		private void MUMLCppDcdfMHNvcHjcyaEtqcQrG()
		{
			_ = OjwyyShaVZddEAIgczmdLpCXEwvO;
		}

		[IteratorStateMachine(typeof(NsPUuNHvbotSrhfqjuZWUbiohnaR))]
		private IEnumerator OMHCoUnrSHBGqQBQGgTdFNXDaboGA()
		{
			return new NsPUuNHvbotSrhfqjuZWUbiohnaR(0)
			{
				uXgNFFTPGhneVqBwcBeidiStwzeq = this
			};
		}
	}
}
