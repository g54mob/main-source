using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Doozy.Engine.Soundy
{
	[DefaultExecutionOrder(-100)]
	public class SoundyPooler : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CKillIdleControllersEnumerator_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SoundyPooler _003C_003E4__this;

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
			public _003CKillIdleControllersEnumerator_003Ed__29(int _003C_003E1__state)
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

		private static List<SoundyController> s_pool;

		private Coroutine m_idleCheckCoroutine;

		private WaitForSecondsRealtime m_idleCheckIntervalWaitForSecondsRealtime;

		private SoundyController m_tempController;

		public static SoundyPooler Instance => null;

		private static List<SoundyController> Pool
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static bool AutoKillIdleControllers => false;

		public static float ControllerIdleKillDuration => 0f;

		public static float IdleCheckInterval => 0f;

		public static int MinimumNumberOfControllers => 0;

		private bool DebugComponent => false;

		private void Reset()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public static void ClearPool(bool keepMinimumNumberOfControllers = false)
		{
		}

		public static SoundyController GetControllerFromPool()
		{
			return null;
		}

		public static void PopulatePool(int numberOfControllers)
		{
		}

		public static void PutControllerInPool(SoundyController controller)
		{
		}

		private void StartIdleCheckInterval()
		{
		}

		private void StopIdleCheckInterval()
		{
		}

		private static void RemoveNullControllersFromThePool()
		{
		}

		[IteratorStateMachine(typeof(_003CKillIdleControllersEnumerator_003Ed__29))]
		private IEnumerator KillIdleControllersEnumerator()
		{
			return null;
		}
	}
}
