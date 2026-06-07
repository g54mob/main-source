using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace EpicToonFX
{
	public class ETFXEffectCycler : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CEffectLoop_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ETFXEffectCycler _003C_003E4__this;

			private GameObject _003CinstantiatedEffect_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CEffectLoop_003Ed__8(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
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
			}
		}

		public List<GameObject> listOfEffects;

		private int effectIndex;

		[Header("Spawn Settings")]
		[SerializeField]
		[Space(10f)]
		public float loopLength;

		public float startDelay;

		public bool disableLights;

		public bool disableSound;

		private void Start()
		{
		}

		public void PlayEffect()
		{
		}

		[IteratorStateMachine(typeof(_003CEffectLoop_003Ed__8))]
		private IEnumerator EffectLoop()
		{
			return null;
		}
	}
}
