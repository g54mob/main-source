using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_SpiritTornado2_Projectile : Projectile
	{
		[SerializeField]
		private Transform _VenusTransform;

		private Animator _VenusAnimator;

		private const float VenusMeshScale = 1f;

		private Transform _playerCachedTransform;

		private ExplodeFragments _explodeFragments;

		private MultiTargetTween[] _tweens;

		protected TP_SpiritTornado2_Weapon _trueWeapon;

		private readonly float[] _gemOffsets;

		private readonly string[] _gemFrames;

		private readonly int[] _moonBeatDetunes;

		private const float _moonBeatOffset1 = 600f;

		private const float _moonBeatOffset2 = 300f;

		private const float _moonBeatOffset3 = 150f;

		private const WeaponType WType = WeaponType.TP_SPIRITTORNADO2;

		private List<Gem> _gems;

		private bool _storeGemXP;

		private bool _spiritGemsCanExplode;

		private Timer _vacuumTimer;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void ConvertGemsToSpiritGems()
		{
		}

		private void TweenIn()
		{
		}

		private void DoMoonBeatSequence()
		{
		}

		private void EraseRandomEnemies(SfxType sfx, int index = 0, int detune = 0, float offset = 0f, bool scaleVenus = true)
		{
		}

		private void MoonDamage(EnemyController target, int index = 0)
		{
		}

		protected void EraseEnemies(bool makeHearts)
		{
		}

		private void MakeLittleHeart(Vector2 pos)
		{
		}

		private void MakeSpiritGem(Vector2 pos, float xp, bool canExplode)
		{
		}

		private int GetEnemyXPValue(EnemyController enemy)
		{
			return 0;
		}

		private void StartShatterSequence()
		{
		}

		private void Shatter()
		{
		}

		private void DespawnAllSpiritGems()
		{
		}

		public override void Despawn()
		{
		}

		private void KillTweens()
		{
		}

		private static void KillTween(MultiTargetTween[] tweens)
		{
		}
	}
}
