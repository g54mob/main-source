using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Coherence.Toolkit;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Weapons
{
	public class MadMoonWeapon : Weapon
	{
		[CompilerGenerated]
		private sealed class _003CSpinning_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float duration;

			public MadMoonWeapon _003C_003E4__this;

			public int reel;

			private float _003CstartTime_003E5__2;

			private float _003CpausedTime_003E5__3;

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
			public _003CSpinning_003Ed__30(int _003C_003E1__state)
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

		private Bounds camBounds;

		private float2 playerPos;

		private Camera _camera;

		private BulletPool _reelZonePool;

		[SerializeField]
		protected Projectile _reelZonePrefab;

		public int numOfReels;

		public int symbolsPerReel;

		private float spinTime;

		private float delayBetweenReels;

		public Vector2 slotMachineSize;

		public Vector2 slotMachinePos;

		private MadMoonReelState[] reelStates;

		private MadMoonProjectile[] landedProjectiles;

		public MadMoonSymbol[] finalSymbols;

		private float[] symbolWeights;

		private float timeBetweenZones;

		[SerializeField]
		private GameObject blackBar;

		private Tween _blackbarTween;

		private Tween _reelDelayTween;

		[SerializeField]
		[Range(0f, 1f)]
		private float winChance;

		private bool hasWinningSymbols;

		private bool _emitterBuilt;

		private ParticleSystem _EmitterCoins;

		private ParticleSystem _EmitterSkulls;

		private ParticleSystem _EmitterGems;

		private ParticleSystem _EmitterClovers;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public void StartSpinning(int reel)
		{
		}

		[IteratorStateMachine(typeof(_003CSpinning_003Ed__30))]
		private IEnumerator Spinning(int reel, float duration)
		{
			return null;
		}

		public void Stopping(int reel)
		{
		}

		public void SpawnZone(int reel)
		{
		}

		private void Restart()
		{
		}

		private void FadeBlackBar(bool fadeOn)
		{
		}

		private void updateWeights()
		{
		}

		private static float map(float value, float fromLow, float fromHigh, float toLow, float toHigh)
		{
			return 0f;
		}

		private float2 getSlotMachinePos()
		{
			return default(float2);
		}

		private float2 getTopLeftSymbolPos()
		{
			return default(float2);
		}

		public void setFinalSymbols(bool won)
		{
		}

		public MadMoonSymbol getRandomSymbol(bool weighted = false, bool includeWilds = true)
		{
			return default(MadMoonSymbol);
		}

		[Command]
		public void SyncFinalSymbols(string serializedFinalSymbols)
		{
		}

		public string SerializeFinalSymbols(MadMoonSymbol[] symbols)
		{
			return null;
		}

		public MadMoonSymbol[] DeserializeFinalSymbols(string str)
		{
			return null;
		}

		public void OnSpinRemotely(OnlineSignals.MadMoonSpin sig)
		{
		}

		private void BuildEmitter()
		{
		}

		public void PlayParticleVFXAt(Vector3 finalPos, MadMoonSymbol mmSymbol)
		{
		}

		protected override void OnDestroy()
		{
		}
	}
}
