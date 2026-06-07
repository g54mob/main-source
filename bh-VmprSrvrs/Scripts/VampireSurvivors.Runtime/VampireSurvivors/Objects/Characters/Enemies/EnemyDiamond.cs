using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyDiamond : EnemyController
	{
		public float selfDuration;

		public int gridX;

		public int gridY;

		protected int _hitsTaken;

		protected bool _isInvul;

		protected bool _canBreak;

		protected MultiTargetTween _onEnterTween;

		protected float _selfTime;

		protected string _defaultFrame;

		protected string[] _availableFrames;

		protected virtual bool UseStandardLootTable => false;

		protected virtual float InvulDelay => 0f;

		protected virtual float ItemChance => 0f;

		protected virtual float Volume_breaking => 0f;

		protected virtual float Volume_gotHit => 0f;

		protected virtual SfxType Sfx_breaking => default(SfxType);

		protected virtual SfxType Sfx_gotHit => default(SfxType);

		protected virtual bool IsImmovable => false;

		protected virtual bool ChangeFramesOnHit => false;

		protected virtual bool DoBaseUpdate => false;

		protected virtual string _textureName => null;

		protected virtual string DefaultFrame
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected virtual string[] AvailableFrames
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public virtual void OnSpawnDone()
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		public override void GetDamagedSpecial(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true, Vector3? damagePosition = null)
		{
		}

		protected virtual void ChangeFrame()
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void Die()
		{
		}

		private void StandardLoot()
		{
		}

		protected virtual void CustomLoot()
		{
		}

		public override void Disappear()
		{
		}
	}
}
