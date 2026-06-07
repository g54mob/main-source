using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Stages
{
	public class BackgroundDevilRoom : BackgroundManager
	{
		[CompilerGenerated]
		private sealed class _003C_PlayDarkassoCutscene_003Ed__52 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BackgroundDevilRoom _003C_003E4__this;

			private float _003CspiralT_003E5__2;

			private float _003CstartRadius_003E5__3;

			private float _003CstartAngle_003E5__4;

			private float _003CintermediateRadius_003E5__5;

			private float _003CendRadius_003E5__6;

			private float _003CanimationTime_003E5__7;

			private float _003CspinCount_003E5__8;

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
			public _003C_PlayDarkassoCutscene_003Ed__52(int _003C_003E1__state)
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

		private TileSprite _carpet;

		private TileSprite _Tile_H_Plain;

		private TileSprite _Tile_V_Deco;

		private TileSprite _Tile_V_Deco2;

		private TileSprite _Tile_H_Border;

		private TileSprite _Tile_V_Border;

		private int[] _cachedPlayerCharm;

		private List<int> tresholds;

		private List<EnemyType?> enemies;

		private List<EnemyType?> bosses;

		private List<EnemyType?> _secondPhaseBosses;

		private List<EnemyType?> _secondPhaseEnemies;

		public int currentLevel;

		private List<PhaserSprite> walls;

		private List<Vector2> darkassoLoc;

		private BackgroundDevilRoom_Helper _helper;

		private PickupRelic _darkassoPickup;

		private bool _hasTriggeredDarkassoCutscene;

		private List<Rectangle> _darkassoCutsceneTriggerZones;

		private VampireSurvivors.Objects.Characters.CharacterController _darkassoTargetPlayer;

		private Timer skullsTimer;

		private bool _isSendingAdvanceLevel;

		private int _lastEnemies;

		private float _lastSeconds;

		public Camera MainCamera => null;

		public Bounds CamBounds => default(Bounds);

		public List<Vector2> WallEyesLocations { get; set; }

		public List<Vector2> LeftEyesLocations { get; set; }

		public List<Vector2> RightEyesLocations { get; set; }

		public override void Create()
		{
		}

		public override void CustomPreload(Action onComplete)
		{
		}

		private void OnRemoteItemInstantiated(Pickup pickup)
		{
		}

		public override void OnInitCompleted()
		{
		}

		protected override void OnUpdate()
		{
		}

		private void SearchForDarkasso()
		{
		}

		private bool CheckLevel()
		{
			return false;
		}

		public void AdvanceLevel()
		{
		}

		private void LateUpdate()
		{
		}

		private void ResumeEnemyWaves()
		{
		}

		private void SpawnDarkasso(Vector2 location)
		{
		}

		private void OnDarkassoSpawned()
		{
		}

		private void CheckForDarkassoCutscene()
		{
		}

		public void TriggerCutscene(VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}

		[IteratorStateMachine(typeof(_003C_PlayDarkassoCutscene_003Ed__52))]
		private IEnumerator _PlayDarkassoCutscene()
		{
			return null;
		}

		private void SpawnArcanaChestAt(Vector2 position)
		{
		}

		public override void CheckMinute(int minute)
		{
		}

		private void ExpandBounds(int level)
		{
		}

		private void CheckStageCosmetics(int level)
		{
		}

		private void UpdateKillRatio(int level)
		{
		}

		public override float GetKillRatio()
		{
			return 0f;
		}

		public override void Cleanup()
		{
		}

		public override void EnableMovingBackground()
		{
		}

		public override void DisableMovingBackground()
		{
		}

		public override bool ShouldPlayNormalMusic()
		{
			return false;
		}
	}
}
