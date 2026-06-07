using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ScheduleOne.UI;
using UnityEngine;

namespace ScheduleOne.Combat
{
	public class ReticleController : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CDoRecticleFade_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ReticleController _003C_003E4__this;

			public float duration;

			public float endAlpha;

			private float _003CstartAlpha_003E5__2;

			private float _003Celapsed_003E5__3;

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
			public _003CDoRecticleFade_003Ed__10(int _003C_003E1__state)
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

		[SerializeField]
		[Header("Components")]
		private ReticleUI _reticleUI;

		[Header("Settings")]
		[SerializeField]
		private float _fadeDuration;

		private bool _isActive;

		private Coroutine _fadeCo;

		public bool IsActive => false;

		private void Awake()
		{
		}

		public void ShowReticle(float duration = -1f)
		{
		}

		public void HideReticle(float duration = -1f)
		{
		}

		public void SetReticle(float spreadAngle)
		{
		}

		[IteratorStateMachine(typeof(_003CDoRecticleFade_003Ed__10))]
		private IEnumerator DoRecticleFade(float endAlpha, float duration)
		{
			return null;
		}
	}
}
