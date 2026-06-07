using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Chauve2_Projectile : TP_Chauve1_Projectile
	{
		[SerializeField]
		private Transform _BeamSpawnPoint;

		private Timer _animTimer;

		private float _beamXOffset;

		private TP_Chauve2_Weapon _trueWeapon;

		protected override bool IsEvo => false;

		protected override string SpriteName => null;

		protected override string SpriteObjectName => null;

		protected override uint Tint => 0u;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void CheckForCrit()
		{
		}

		protected override void MakeCritProjectile()
		{
		}

		private void DoCritAnim()
		{
		}

		public override void Despawn()
		{
		}
	}
}
