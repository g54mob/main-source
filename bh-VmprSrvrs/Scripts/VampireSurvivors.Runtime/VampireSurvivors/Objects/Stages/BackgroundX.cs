using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Graphics.RenderPass;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Characters.Enemies;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Stages
{
	[UsedImplicitly]
	public class BackgroundX : BackgroundManager
	{
		[CompilerGenerated]
		private sealed class _003CInitFishEye_003Ed__47 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BackgroundX _003C_003E4__this;

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
			public _003CInitFishEye_003Ed__47(int _003C_003E1__state)
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

		private float _wind;

		private float _fireTimer;

		private bool _hasRosaryBeenTriggered;

		private bool _saveOption;

		private FishEyeRenderFeature _fishEyeRenderFeature;

		private ShootingEyesManager _shootingEyesManager;

		private Pickup _rosary;

		private Transform _spritesRootTransform;

		private TileSprite _skyBlue;

		private TileSprite _cloudsBlue;

		private TileSprite _cloudsWhite;

		private TileSprite _cloudsAddBlue;

		private TileSprite _cloudsAddRed;

		private TileSprite _cloudsRed;

		private TileSprite _skyRed;

		private SpriteRenderer _whiteFader;

		private SpriteRenderer _shootingRay;

		private SpriteRenderer _shootingRing;

		private ParticleEmitterManager _particleEmitterManager;

		private ParticleEmitterManager _particleEmitterManagerRed;

		private ParticleSystem _pfxEmitterRed1;

		private ParticleSystem _pfxEmitterRed2;

		private ParticleEmitterManager _particleEmitterManagerRedBelow;

		private ParticleSystem _pfxEmitterBelow1;

		private ParticleSystem _pfxEmitterBelow2;

		private EnemyMaddener _enemyMaddener;

		private Timer _tweenExplosionsTimer;

		private int _tweenExplosionsTimerRepeatCount;

		private Tween _tweenExplosions;

		private List<Timer> _timers;

		private Timer _checkRosaryTimer;

		private int _checkRosaryTimerRepeatCount;

		private Sequence _permanentVfxTween;

		private static readonly int Intensity;

		private static readonly int Radius;

		private static readonly int Mode;

		private static readonly int TexSize;

		private static readonly int Center;

		public override void Awake()
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void OnDestroy()
		{
		}

		public override void CustomPreload(Action onComplete)
		{
		}

		public override void Create()
		{
		}

		private void OnRemoteItemInstantiated(Pickup item)
		{
		}

		private void OnRemoteEnemySpawned(EnemyController enemy)
		{
		}

		public override void Cleanup()
		{
		}

		public override void RosaryTriggered()
		{
		}

		[IteratorStateMachine(typeof(_003CInitFishEye_003Ed__47))]
		private IEnumerator InitFishEye()
		{
			return null;
		}

		private void TweenFishEye(TweenCallback callback)
		{
		}

		private void InitShootingEyesManager()
		{
		}

		private void GenerateSprites()
		{
		}

		private void AddYellowParticles()
		{
		}

		private void OnYellowRelicFound(PickupRelic found)
		{
		}

		private void AddRedParticles()
		{
		}

		private void AddRedParticlesBelow()
		{
		}

		private void AddRosary()
		{
		}

		private bool RemoveEggs()
		{
			return false;
		}

		private void RemovePowers()
		{
		}

		private void SetupCharacterAnimation(VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}

		private void UpdatePlayerOptions()
		{
		}

		private void SetupTimers()
		{
		}

		private void ToggleBlue(bool visible)
		{
		}

		private void ToggleRed(bool visible)
		{
		}

		private void ToggleAlias()
		{
		}

		private void RemoveTimer()
		{
		}

		private void ShootVfx()
		{
		}

		private void ShootEyes(int times, float delay, float radiusMul)
		{
		}

		private void PermanentVfx()
		{
		}

		private void CheckDistanceFromRosary()
		{
		}

		private void StopAllTimers()
		{
		}

		private void StopRedEmitters()
		{
		}

		private void MoveStoppedParticles(ParticleSystem ps)
		{
		}
	}
}
