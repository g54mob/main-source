using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Objects;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Characters.Enemies;

namespace VampireSurvivors.Objects.Stages
{
	public class DopplegangerGate : GameMonoBehaviour
	{
		private enum GateState
		{
			ClosedDoorsOpen = 0,
			ClosedAndReady = 1,
			Opening = 2,
			Open = 3,
			Closing = 4,
			ClosedForever = 5
		}

		[CompilerGenerated]
		private sealed class _003CRunClosingAnimation_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DopplegangerGate _003C_003E4__this;

			private float _003CopenAmount_003E5__2;

			private float _003CdoorOpeningDistance_003E5__3;

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
			public _003CRunClosingAnimation_003Ed__32(int _003C_003E1__state)
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
		private sealed class _003CRunOpeningAnimation_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DopplegangerGate _003C_003E4__this;

			private float _003CfullRotationAmount_003E5__2;

			private float _003CdoorOpeningDistance_003E5__3;

			private float _003CfullOpeningTime_003E5__4;

			private float _003CrotationStartPoint_003E5__5;

			private float _003CopeningTimeBeforeEachDoor_003E5__6;

			private float _003CopeningTimer_003E5__7;

			private float _003ClastEffectiveOpeningTimer_003E5__8;

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
			public _003CRunOpeningAnimation_003Ed__30(int _003C_003E1__state)
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
		private sealed class _003C_CloseDoors_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DopplegangerGate _003C_003E4__this;

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
			public _003C_CloseDoors_003Ed__25(int _003C_003E1__state)
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
		private sealed class _003C_OpenDoors_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DopplegangerGate _003C_003E4__this;

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
			public _003C_OpenDoors_003Ed__27(int _003C_003E1__state)
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

		public PhaserSprite _gatePortal;

		private PhaserSprite _gateMask;

		private PhaserSprite _gateRainbow;

		private List<PhaserSprite> _gateDoors;

		private GateState _gateState;

		private int _howManyGates;

		private PhaserSprite _openingLight;

		private PhaserSprite _fullscreenLight;

		private List<PhaserSprite> _doorBlocks;

		private List<Vector2> _doorLocations;

		private Rectangle _doorTriggerArea;

		private Rectangle _hardBoundsArea;

		private Rect? _originalHardBounds;

		private Rectangle _cameraLimitsRectangle;

		private List<EnemyDoppleganger> _liveDopplegangers;

		private float _fightTimer;

		private MapToken _mapToken;

		public void SetupGate(float2 position, float scale)
		{
		}

		private void OnRemoteEnemySpawned(EnemyController enemy)
		{
		}

		private void StopRegularSpawning()
		{
		}

		private void ResumeRegularSpawning()
		{
		}

		protected override void OnUpdate()
		{
		}

		public void CloseDoors()
		{
		}

		public void OpenDoors()
		{
		}

		[IteratorStateMachine(typeof(_003C_CloseDoors_003Ed__25))]
		private IEnumerator _CloseDoors()
		{
			return null;
		}

		private void AwardChest(float2 location)
		{
		}

		[IteratorStateMachine(typeof(_003C_OpenDoors_003Ed__27))]
		private IEnumerator _OpenDoors()
		{
			return null;
		}

		private void SetDoorOpenAmount(float amount, int doorID)
		{
		}

		public void StartOpening()
		{
		}

		[IteratorStateMachine(typeof(_003CRunOpeningAnimation_003Ed__30))]
		private IEnumerator RunOpeningAnimation()
		{
			return null;
		}

		private void SpawnDopplegangers()
		{
		}

		[IteratorStateMachine(typeof(_003CRunClosingAnimation_003Ed__32))]
		private IEnumerator RunClosingAnimation()
		{
			return null;
		}

		public void OnDopplegangerDied(EnemyDoppleganger doppleganger)
		{
		}

		protected override void OnDestroy()
		{
		}
	}
}
