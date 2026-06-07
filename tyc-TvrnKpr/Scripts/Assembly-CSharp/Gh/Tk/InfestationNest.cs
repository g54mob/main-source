using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class InfestationNest : GameObjectX, IActorColliderInteraction
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass31_0
		{
			public InfestationNest _003C_003E4__this;

			public Staff staff;

			internal void _003CGetAvailableManualJobs_003Eb__0()
			{
			}

			internal bool _003CGetAvailableManualJobs_003Eb__1()
			{
				return false;
			}

			internal void _003CGetAvailableManualJobs_003Eb__2()
			{
			}

			internal bool _003CGetAvailableManualJobs_003Eb__3()
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetAvailableManualJobs_003Ed__31 : IEnumerable<ContextMenuItem>, IEnumerable, IEnumerator<ContextMenuItem>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private ContextMenuItem _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public InfestationNest _003C_003E4__this;

			private Staff staff;

			public Staff _003C_003E3__staff;

			private _003C_003Ec__DisplayClass31_0 _003C_003E8__1;

			private IEnumerator<ContextMenuItem> _003C_003E7__wrap1;

			ContextMenuItem IEnumerator<ContextMenuItem>.Current
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
			public _003CGetAvailableManualJobs_003Ed__31(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<ContextMenuItem> IEnumerable<ContextMenuItem>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private const int _maxNestsInLevel = 20;

		public static int MaxNestsPerRoom;

		public static HashSet<InfestationNest> AllInfestationNests;

		public ParticleSystem mainNestParticleSystem;

		[PersistenceOptIn]
		private float _spawnQueenDayF;

		private GametimeTimer _pauseParticlesTimer;

		protected GameObject _currentSelectionHighlight;

		public static event EventHandler InfestationNestsChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected static void RaiseInfestationNestsChanged()
		{
		}

		public override void Awake()
		{
		}

		public override void Start()
		{
		}

		public override void OnDestroy()
		{
		}

		private void RecalculateSpawnQueenTimer()
		{
		}

		private static float GetSpawnTimeDelayModifierBasedOnBalanceSettings()
		{
			return 0f;
		}

		protected override void UpdateInternal()
		{
		}

		private void SpawnQueen()
		{
		}

		public static bool ShouldSpawnInfestationNest(bool ignoreGameSettings = false)
		{
			return false;
		}

		private void CreateTimer()
		{
		}

		public static bool IsMaxInfestationNestsInLevelReached()
		{
			return false;
		}

		public static GameObject SpawnNest(Vector3 position, bool ignoreGameSettings = false)
		{
			return null;
		}

		public override void RestoreState(IDataStore data)
		{
		}

		public override void SaveState(IDataStore data)
		{
		}

		public void OnActorEnteredCollider(Actor actor)
		{
		}

		public void OnActorLeftCollider(Actor actor)
		{
		}

		public override bool IsHighlighted()
		{
			return false;
		}

		public override void AddHighlight(Color? color = null)
		{
		}

		public override void RemoveHighlight()
		{
		}

		public void FastForwardBuilding()
		{
		}

		[IteratorStateMachine(typeof(_003CGetAvailableManualJobs_003Ed__31))]
		public override IEnumerable<ContextMenuItem> GetAvailableManualJobs(Staff staff)
		{
			return null;
		}

		public static bool DoesCleanJobExistAlready(InfestationNest nest)
		{
			return false;
		}

		public static CleanNest_Job GetCleanNestJob(InfestationNest nest)
		{
			return null;
		}

		public override bool CanUseDirectly(Actor actor)
		{
			return false;
		}
	}
}
