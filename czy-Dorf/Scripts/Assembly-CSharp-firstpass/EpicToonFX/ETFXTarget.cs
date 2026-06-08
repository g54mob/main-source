using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace EpicToonFX
{
	public class ETFXTarget : MonoBehaviour
	{
		private sealed class _003CRespawn_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ETFXTarget _003C_003E4__this;

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
			public _003CRespawn_003Ed__7(int _003C_003E1__state)
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
				ETFXTarget eTFXTarget = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E2__current = new WaitForSeconds(3f);
					_003C_003E1__state = 1;
					return true;
				case 1:
					_003C_003E1__state = -1;
					eTFXTarget.SpawnTarget();
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

		public GameObject hitParticle;

		public GameObject respawnParticle;

		private Renderer targetRenderer;

		private Collider targetCollider;

		private void Start()
		{
			targetRenderer = GetComponent<Renderer>();
			targetCollider = GetComponent<Collider>();
		}

		private void SpawnTarget()
		{
			targetRenderer.enabled = true;
			targetCollider.enabled = true;
			UnityEngine.Object.Destroy(UnityEngine.Object.Instantiate(respawnParticle, base.transform.position, base.transform.rotation), 3.5f);
		}

		private void OnTriggerEnter(Collider col)
		{
			if (col.tag == "Missile" && (bool)hitParticle)
			{
				UnityEngine.Object.Destroy(UnityEngine.Object.Instantiate(hitParticle, base.transform.position, base.transform.rotation), 2f);
				targetRenderer.enabled = false;
				targetCollider.enabled = false;
				StartCoroutine(Respawn());
			}
		}

		private IEnumerator Respawn()
		{
			return new _003CRespawn_003Ed__7(0)
			{
				_003C_003E4__this = this
			};
		}
	}
}
