using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace EpicToonFX
{
	public class ETFXLoopScript : MonoBehaviour
	{
		private sealed class _003CEffectLoop_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ETFXLoopScript _003C_003E4__this;

			private GameObject _003CeffectPlayer_003E5__2;

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
			public _003CEffectLoop_003Ed__6(int _003C_003E1__state)
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
				ETFXLoopScript eTFXLoopScript = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003CeffectPlayer_003E5__2 = UnityEngine.Object.Instantiate(eTFXLoopScript.chosenEffect, eTFXLoopScript.transform.position, eTFXLoopScript.transform.rotation);
					if (eTFXLoopScript.spawnWithoutLight = _003CeffectPlayer_003E5__2.GetComponent<Light>())
					{
						_003CeffectPlayer_003E5__2.GetComponent<Light>().enabled = false;
					}
					if (eTFXLoopScript.spawnWithoutSound = _003CeffectPlayer_003E5__2.GetComponent<AudioSource>())
					{
						_003CeffectPlayer_003E5__2.GetComponent<AudioSource>().enabled = false;
					}
					_003C_003E2__current = new WaitForSeconds(eTFXLoopScript.loopTimeLimit);
					_003C_003E1__state = 1;
					return true;
				case 1:
					_003C_003E1__state = -1;
					UnityEngine.Object.Destroy(_003CeffectPlayer_003E5__2);
					eTFXLoopScript.PlayEffect();
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

		public GameObject chosenEffect;

		public float loopTimeLimit = 2f;

		public bool spawnWithoutLight = true;

		public bool spawnWithoutSound = true;

		private void Start()
		{
			PlayEffect();
		}

		public void PlayEffect()
		{
			StartCoroutine("EffectLoop");
		}

		private IEnumerator EffectLoop()
		{
			return new _003CEffectLoop_003Ed__6(0)
			{
				_003C_003E4__this = this
			};
		}
	}
}
