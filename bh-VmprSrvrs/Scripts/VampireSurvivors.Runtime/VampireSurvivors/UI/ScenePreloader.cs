using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI
{
	public class ScenePreloader : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CDelayedLoadMainMenuRoutine_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

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
			public _003CDelayedLoadMainMenuRoutine_003Ed__8(int _003C_003E1__state)
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

		public RawImage _loadingBackground;

		public GameObject _loadingIcon;

		public GameObject _loadingText;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void TransitionGameplayIntoGameplay()
		{
		}

		private void TransitionMainMenuIntoGameplay()
		{
		}

		private void TransitionGameplayIntoMainMenu()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedLoadMainMenuRoutine_003Ed__8))]
		private IEnumerator DelayedLoadMainMenuRoutine()
		{
			return null;
		}

		private void ReleaseGameplay()
		{
		}

		private void HideVisuals()
		{
		}
	}
}
