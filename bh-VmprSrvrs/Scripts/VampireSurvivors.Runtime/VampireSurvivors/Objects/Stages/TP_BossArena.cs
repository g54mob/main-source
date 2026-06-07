using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Coherence;
using Coherence.Toolkit;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Objects;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Stages
{
	public class TP_BossArena : GameMonoBehaviour
	{
		private enum ArenaState
		{
			Unactivated = 0,
			Locked = 1,
			Complete = 2
		}

		[CompilerGenerated]
		private sealed class _003CWaitForAcksAndLoadBoss_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TP_BossArena _003C_003E4__this;

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
			public _003CWaitForAcksAndLoadBoss_003Ed__28(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003C_CloseDoors_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TP_BossArena _003C_003E4__this;

			private float _003CopenAmount_003E5__2;

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
			public _003C_CloseDoors_003Ed__32(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003C_OpenDoors_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TP_BossArena _003C_003E4__this;

			private float _003CopenAmount_003E5__2;

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
			public _003C_OpenDoors_003Ed__33(int _003C_003E1__state)
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

		private EnemyType _enemyType;

		private float2 _spawnPosition;

		private List<PhaserSprite> _doorBlocks;

		private List<Vector2> _doorLocations;

		private Rectangle _doorTriggerArea;

		private Rectangle _hardBoundsArea;

		private Rect? _originalHardBounds;

		private Rectangle _cameraLimitsRectangle;

		private ArenaState _state;

		private EnemyController _enemy;

		private CoherenceSync _sync;

		private int _loadAcks;

		private float _ackTimeout;

		private bool _isChangingState;

		private const float MaxAckTimeout = 1.5f;

		private MapToken _mapToken;

		[NonSerialized]
		[Sync]
		public bool _fadeToSilenceInsteadOfMusic;

		private const string BOSS_CACHE_GROUP_NAME = "TP_BOSS";

		private void Awake()
		{
		}

		public void Setup(EnemyType enemyType, string bossName)
		{
		}

		[Command]
		public void PerformSetup(int enemy, string bossName)
		{
		}

		protected override void OnUpdate()
		{
		}

		[Command]
		public void SwitchToCompletedState()
		{
		}

		[Command]
		public void SwitchToLockedState()
		{
		}

		private void LoadBossTextureAndSpawn()
		{
		}

		private void SpawnBoss()
		{
		}

		[Command(defaultRouting = MessageTarget.AuthorityOnly)]
		public void AckTake()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForAcksAndLoadBoss_003Ed__28))]
		private IEnumerator WaitForAcksAndLoadBoss()
		{
			return null;
		}

		public void CloseDoors()
		{
		}

		public void OpenDoors()
		{
		}

		protected override void OnDestroy()
		{
		}

		[IteratorStateMachine(typeof(_003C_CloseDoors_003Ed__32))]
		private IEnumerator _CloseDoors()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003C_OpenDoors_003Ed__33))]
		private IEnumerator _OpenDoors()
		{
			return null;
		}

		private void SetDoorOpenAmount(float amount, int doorID)
		{
		}

		private void StopRegularSpawning()
		{
		}

		private void ResumeRegularSpawning()
		{
		}
	}
}
