using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.VFX.Shatter;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class PentagramProjectile : Projectile
	{
		private Transform _playerCachedTransform;

		private ShatterVFX _shatterVfx;

		private MultiTargetTween[] _tweens;

		private float _globalScale;

		private bool _eraseItems;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		protected void EraseEnemies(bool erase = false)
		{
		}

		protected void EraseItems()
		{
		}

		public override void InternalUpdate()
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

		private void KillTween(MultiTargetTween[] tweens)
		{
		}

		private PentagramType GetPentType()
		{
			return default(PentagramType);
		}
	}
}
