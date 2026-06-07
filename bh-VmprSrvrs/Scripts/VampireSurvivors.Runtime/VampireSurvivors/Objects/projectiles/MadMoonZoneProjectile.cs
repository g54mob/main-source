using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Projectiles
{
	public class MadMoonZoneProjectile : Projectile
	{
		[CompilerGenerated]
		private sealed class _003CDamageEnemyLoop_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public EnemyController enemy;

			public float amount;

			public MadMoonZoneProjectile _003C_003E4__this;

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
			public _003CDamageEnemyLoop_003Ed__31(int _003C_003E1__state)
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

		private Camera _camera;

		private float alpha;

		public MadMoonProjectile symbol;

		public float2 playerPos;

		private MadMoonSymbol effect;

		private int reel;

		public float buffMultiplier;

		private static List<EnemyController>[] effectedEnemies;

		private static List<Gem>[] effectedGems;

		private static List<TreasureChest>[] effectedTreasures;

		private static List<Coin>[] effectedCoins;

		private static List<Destructible>[] effectedLights;

		private int level;

		private MultiTargetTween _scaleTween;

		private Timer anforaDisappearTimer;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void AfterInit(MadMoonProjectile symbol, float time, int level, int reel, MadMoonSymbol effect, float value = 1f, bool specialBonus = false)
		{
		}

		private Color getColor(MadMoonSymbol madMoonSymbol)
		{
			return default(Color);
		}

		public void CheckObjects(float mult = 1f, bool specialBonus = false)
		{
		}

		private void SpawnSkelegems()
		{
		}

		private void SpawnAnforaCluster()
		{
		}

		private void SpawnReapers()
		{
		}

		public void AddGemEffect(Gem gem)
		{
		}

		public void AddTreasureEffect(TreasureChest treasure, float valueLuck = 1f)
		{
		}

		public void AddCoinEffect(Coin coin)
		{
		}

		public void AddLightEffect(Destructible destructible, float valueLuck = 1f)
		{
		}

		public void AddEnemyEffect(EnemyController enemy, float valueCurse = 1f)
		{
		}

		public void OnEnemyKilled(GameplaySignals.EnemyKilledImmediateSignal signal)
		{
		}

		public void OnDestructibleDestroyed(GameplaySignals.DestructibleDestroyed signal)
		{
		}

		private void DoVFX(float2 position)
		{
		}

		public void OnItemPickedUp(Pickup pickup)
		{
		}

		[IteratorStateMachine(typeof(_003CDamageEnemyLoop_003Ed__31))]
		private IEnumerator DamageEnemyLoop(EnemyController enemy, float amount)
		{
			return null;
		}

		private bool ObjectOverlaps(float2 objectPos)
		{
			return false;
		}

		public override void Despawn()
		{
		}

		public void RemoveGemEffect(Gem gem, int level)
		{
		}

		public void RemoveTreasureEffect(TreasureChest treasure, int level)
		{
		}

		public void RemoveCoinEffect(Coin coin, int level)
		{
		}

		public void RemoveLightEffect(Destructible p, int level)
		{
		}

		public void RemoveEnemyEffect(EnemyController enemy)
		{
		}
	}
}
