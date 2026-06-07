using Coherence.Toolkit;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyLegionSection : EnemyController
	{
		private EnemyLegion _parentBoss;

		private int2 _direction;

		private bool _isFalling;

		private float _fallTimer;

		[Command]
		public void OnlineSetupSection(CoherenceSync boss, Vector2 direction)
		{
		}

		public void SetupLegionSection(EnemyLegion parentBoss, int2 direction)
		{
		}

		public void SetOutlineColour(Color c)
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		public bool IsMiddleSection()
		{
			return false;
		}

		public override void Disappear()
		{
		}

		protected override void Die()
		{
		}

		protected override void OnUpdate()
		{
		}

		public void UpdateSection()
		{
		}
	}
}
