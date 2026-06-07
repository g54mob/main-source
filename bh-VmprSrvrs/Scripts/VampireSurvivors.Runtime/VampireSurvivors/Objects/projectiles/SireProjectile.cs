using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.VFX.Shatter;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class SireProjectile : Projectile
	{
		private Transform _playerCachedTransform;

		private ShatterVFX _shatterVfx;

		private MultiTargetTween[] _tweens;

		private float _globalScale;

		private bool _eraseItems;

		protected SireWeapon _trueWeapon;

		private float[] _offsets;

		private string[] _frames;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void OnRecycle()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void EraseRandomEnemy(SfxType sfx, int index = 0, int detune = 0, float offset = 0f)
		{
		}

		private void MoonDamage(EnemyController target, int index = 0)
		{
		}

		protected void EraseEnemies()
		{
		}

		private void DrawSymbol()
		{
		}

		private void Shatter()
		{
		}

		public override void Despawn()
		{
		}

		private void InitShatterVfx()
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
