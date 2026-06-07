using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Coherence.Toolkit;
using DG.Tweening;
using I2.Loc;
using Rewired;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
using VampireSurvivors.App.Objects;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Characters.Enemies;
using VampireSurvivors.Objects.Items;

namespace VampireSurvivors
{
	public class DraculaCutscene : GameMonoBehaviour
	{
		protected enum CutsceneState
		{
			Inactive = 0,
			EnteredPlatformingArea = 1,
			DraculaAndRichterDialogue = 2,
			CoffinSpawned = 3,
			DeathDialogue = 4,
			TransitionToDeathFight = 5,
			CutsceneOver = 6
		}

		public enum DialogueCharacter
		{
			None = 0,
			Richter = 1,
			Dracula = 2,
			Death = 3
		}

		[Serializable]
		public struct TPCutsceneDialogue
		{
			public DialogueCharacter Character;

			public LocalizedString DialogueLocKey;

			public float EnglishShowTime { get; private set; }

			public int EnglishCharacterCount { get; private set; }

			public void SetEnglishTextValues(float englishShowTime, int englishCharacterCount)
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass88_0
		{
			public bool snapped;

			public DraculaCutscene _003C_003E4__this;

			internal void _003CPlayCutscene_003Eb__1()
			{
			}

			internal bool _003CPlayCutscene_003Eb__2()
			{
				return false;
			}

			internal void _003CPlayCutscene_003Eb__3()
			{
			}

			internal bool _003CPlayCutscene_003Eb__4()
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass98_0
		{
			public Enemy_TP_Death death;

			internal void _003CPlayDeathScream_003Eb__0()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CCameraZoom_003Ed__80 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float startSize;

			public float endSize;

			public float duration;

			private float _003Ctimer_003E5__2;

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
			public _003CCameraZoom_003Ed__80(int _003C_003E1__state)
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
		private sealed class _003CPlayCutscene_003Ed__88 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DraculaCutscene _003C_003E4__this;

			private _003C_003Ec__DisplayClass88_0 _003C_003E8__1;

			private int _003Cindex_003E5__2;

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
			public _003CPlayCutscene_003Ed__88(int _003C_003E1__state)
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
		private sealed class _003CPlayDeathDialogueCutscene_003Ed__90 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DraculaCutscene _003C_003E4__this;

			private Enemy_TP_Death _003CdeathEnemy_003E5__2;

			private int _003Cindex_003E5__3;

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
			public _003CPlayDeathDialogueCutscene_003Ed__90(int _003C_003E1__state)
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
		private sealed class _003CPlayDeathScream_003Ed__98 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Enemy_TP_Death death;

			public DraculaCutscene _003C_003E4__this;

			private _003C_003Ec__DisplayClass98_0 _003C_003E8__1;

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
			public _003CPlayDeathScream_003Ed__98(int _003C_003E1__state)
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
		private sealed class _003CRevealDeath_003Ed__81 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DraculaCutscene _003C_003E4__this;

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
			public _003CRevealDeath_003Ed__81(int _003C_003E1__state)
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
		private sealed class _003CScaleOutTile_003Ed__96 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DraculaCutscene _003C_003E4__this;

			public Vector3Int cellPosition;

			public int relativeXCoordinate;

			public int relativeYCoordinate;

			public Vector3 cameraPosition;

			private Quaternion _003CendRotation_003E5__2;

			private float _003Ct_003E5__3;

			private Vector3 _003CtoCentrePosition_003E5__4;

			private Vector3 _003CstartOffset_003E5__5;

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
			public _003CScaleOutTile_003Ed__96(int _003C_003E1__state)
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
		private sealed class _003CTransitionToDeathFight_003Ed__91 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DraculaCutscene _003C_003E4__this;

			public Enemy_TP_Death deathEnemy;

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
			public _003CTransitionToDeathFight_003Ed__91(int _003C_003E1__state)
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
		private sealed class _003CTweenCharactersToWaitPosition_003Ed__83 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DraculaCutscene _003C_003E4__this;

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
			public _003CTweenCharactersToWaitPosition_003Ed__83(int _003C_003E1__state)
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
		private sealed class _003CWaitForSecondsPausable_003Ed__100 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float seconds;

			private float _003Ctimer_003E5__2;

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
			public _003CWaitForSecondsPausable_003Ed__100(int _003C_003E1__state)
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
		protected TPCutsceneDialogueUI _CutsceneDialogueUIPrefab;

		[SerializeField]
		protected ArcadeSprite _DraculaSprite;

		[Header("Character Positions")]
		[SerializeField]
		private Vector2 _DebugTeleportPosition;

		[SerializeField]
		private Vector2 _WaitPosition;

		[SerializeField]
		private float _SpreadPerPlayerInCoOp;

		[SerializeField]
		private int _CharacterWalkTimeInMilliseconds;

		[SerializeField]
		protected Vector2 _DeathSpawnPosition;

		[Header("Camera")]
		[SerializeField]
		private Transform _CameraTargetTransform;

		[SerializeField]
		private float _CameraTransitionDuration;

		[SerializeField]
		private bool _DoCameraZoom;

		[SerializeField]
		private float _CameraZoomScreenSize;

		[SerializeField]
		private float _CameraZoomScreenSizePortrait;

		[SerializeField]
		private float _CameraZoomInDuration;

		[SerializeField]
		private float _CameraZoomOutDuration;

		[Header("Dialogue")]
		[SerializeField]
		protected TPCutsceneDialogue[] _CutsceneDialogue;

		[SerializeField]
		protected TPCutsceneDialogue[] _AfterCoffinCutsceneDialogue;

		[Header("Wine Glass Throw")]
		[SerializeField]
		protected DraculaCutsceneWineGlass _WineGlass;

		[SerializeField]
		private Vector2 _ThrowStartPosition;

		[SerializeField]
		private Vector2 _ThrowEndPosition;

		[SerializeField]
		private int _ThrowWineGlassDialogueIndex;

		[SerializeField]
		private float _ThrowWineGlassDelay;

		[Header("Coffin Teleport")]
		[SerializeField]
		private DraculaCutsceneTeleport _TeleportEffect;

		[SerializeField]
		private ArcadeSprite _DirecterHand;

		[SerializeField]
		private Vector2 _CoffinPosition;

		[SerializeField]
		private float _DelayBeforePlayingDirecterSnap;

		[Header("Death Transition")]
		[SerializeField]
		private float _BackgroundTileLerpOutDuration;

		[SerializeField]
		private float _ScreenShakeMagnitude;

		[SerializeField]
		private float _ScreenShakeDuration;

		[SerializeField]
		protected int _ScreenShakeRepeats;

		[Header("Other")]
		[SerializeField]
		private bool _showLetterBox;

		protected Player _player;

		protected TPCutsceneDialogueUI _cutsceneDialogueUI;

		protected List<VampireSurvivors.Objects.Characters.CharacterController> _characterControllers;

		protected Tilemap _backgroundTilemap;

		private Coroutine _cutsceneCoroutine;

		protected Coroutine _cameraZoomCoroutine;

		private Rectangle _platformingArea;

		private Rectangle _cutsceneArea;

		private Rect? _originalHardBounds;

		private Rectangle _platformingHardBounds;

		private Rectangle _cutsceneHardBounds;

		private Rectangle _cutsceneCameraLimits;

		private float _preZoomCameraSize;

		protected bool _isAnyCharacterRichter;

		private bool _coffinSpawnTeleportComplete;

		private bool _backgroundRemoveComplete;

		protected CutsceneState _currentCutsceneState;

		protected MapToken _mapToken;

		private bool _deathCutsceneTriggered;

		protected PickupCoffin _draculaCoffin;

		private const string WalkAnimName = "walk";

		protected const string MeleeAnimName = "meleeA";

		protected CoherenceSync _sync;

		private bool _changingState;

		private const string PlatformingAreaBoundsName = "CutscenePlatformingZone";

		private const string CutsceneAreaBoundsName = "Cutscene";

		private const string CutsceneCameraLimitsName = "CutsceneCameraLimits";

		private const string DraculaIdleAnimationName = "idle";

		private const string EnemiesMTextureName = "enemiesM";

		private const string HandSnapAnimPrefix = "hand_snap_";

		private const string SnapDoAnimName = "snap";

		private const string SnapStartAnimName = "snap_start";

		private float CameraZoomScreenSize => 0f;

		protected virtual void Start()
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void OnDestroy()
		{
		}

		private bool CheckAllPlayersInRectangle(Rectangle rectangle)
		{
			return false;
		}

		protected void SetupCutsceneAreas()
		{
		}

		[Command]
		public void OnEnterPlatformingArea()
		{
		}

		[Command]
		public void OnEnterCutsceneArea()
		{
		}

		protected void DisableAllInput()
		{
		}

		protected void EnableAllInput()
		{
		}

		private void BeginCutscene()
		{
		}

		protected void InitDracula()
		{
		}

		protected void InitDirecterHand()
		{
		}

		private void PlayDirecterSnap(Action onSnap = null)
		{
		}

		[IteratorStateMachine(typeof(_003CCameraZoom_003Ed__80))]
		private IEnumerator CameraZoom(float startSize, float endSize, float duration)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CRevealDeath_003Ed__81))]
		protected IEnumerator RevealDeath()
		{
			return null;
		}

		private void DisableGameplayOnEnterPlatformingArea()
		{
		}

		[IteratorStateMachine(typeof(_003CTweenCharactersToWaitPosition_003Ed__83))]
		private IEnumerator TweenCharactersToWaitPosition()
		{
			return null;
		}

		private void AddMoveToPositionTween(VampireSurvivors.Objects.Characters.CharacterController character, float halfSpread, int positionIndex, TweenCallback onComplete)
		{
		}

		protected void EnableMovementAfterCutscene()
		{
		}

		private void LockPlayerMovementToCameraBounds()
		{
		}

		private void LockPlayerMovementToPlatformingAreaBounds()
		{
		}

		[IteratorStateMachine(typeof(_003CPlayCutscene_003Ed__88))]
		private IEnumerator PlayCutscene()
		{
			return null;
		}

		private void OnTeleportFromThroneComplete()
		{
		}

		[IteratorStateMachine(typeof(_003CPlayDeathDialogueCutscene_003Ed__90))]
		protected virtual IEnumerator PlayDeathDialogueCutscene()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CTransitionToDeathFight_003Ed__91))]
		private IEnumerator TransitionToDeathFight(Enemy_TP_Death deathEnemy)
		{
			return null;
		}

		private void SpawnDraculaCoffin()
		{
		}

		private void OnCharacterFoundScreenClosed()
		{
		}

		private void MakeAllBackgroundsInvisible()
		{
		}

		protected void RemoveBackground()
		{
		}

		[IteratorStateMachine(typeof(_003CScaleOutTile_003Ed__96))]
		private IEnumerator ScaleOutTile(Vector3 cameraPosition, Vector3Int cellPosition, int relativeXCoordinate, int relativeYCoordinate)
		{
			return null;
		}

		protected void RemoveWalls()
		{
		}

		[IteratorStateMachine(typeof(_003CPlayDeathScream_003Ed__98))]
		protected IEnumerator PlayDeathScream(Enemy_TP_Death death)
		{
			return null;
		}

		private void PlayDeathScreamAudio()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForSecondsPausable_003Ed__100))]
		private IEnumerator WaitForSecondsPausable(float seconds)
		{
			return null;
		}

		protected void DeathScreenShake(int repeats)
		{
		}

		protected float2 ConvertLocalV3ToWorldFloat2(Vector3 vector3)
		{
			return default(float2);
		}
	}
}
