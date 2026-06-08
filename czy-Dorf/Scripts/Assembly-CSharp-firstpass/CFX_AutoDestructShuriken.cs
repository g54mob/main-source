using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class CFX_AutoDestructShuriken : MonoBehaviour
{
	private sealed class _003CCheckIfAlive_003Ed__2 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CFX_AutoDestructShuriken _003C_003E4__this;

		private ParticleSystem _003Cps_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CCheckIfAlive_003Ed__2(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			CFX_AutoDestructShuriken cFX_AutoDestructShuriken = _003C_003E4__this;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				_003C_003E1__state = -1;
				if (!_003Cps_003E5__2.IsAlive(withChildren: true))
				{
					if (cFX_AutoDestructShuriken.OnlyDeactivate)
					{
						cFX_AutoDestructShuriken.gameObject.SetActive(value: false);
					}
					else
					{
						UnityEngine.Object.Destroy(cFX_AutoDestructShuriken.gameObject);
					}
					goto IL_008b;
				}
			}
			else
			{
				_003C_003E1__state = -1;
				_003Cps_003E5__2 = cFX_AutoDestructShuriken.GetComponent<ParticleSystem>();
			}
			if (_003Cps_003E5__2 != null)
			{
				_003C_003E2__current = new WaitForSeconds(0.5f);
				_003C_003E1__state = 1;
				return true;
			}
			goto IL_008b;
			IL_008b:
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
	}

	public bool OnlyDeactivate;

	private void OnEnable()
	{
		StartCoroutine("CheckIfAlive");
	}

	private IEnumerator CheckIfAlive()
	{
		return new _003CCheckIfAlive_003Ed__2(0)
		{
			_003C_003E4__this = this
		};
	}
}
