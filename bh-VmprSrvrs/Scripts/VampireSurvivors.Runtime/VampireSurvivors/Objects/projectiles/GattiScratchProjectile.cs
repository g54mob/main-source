using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class GattiScratchProjectile : Projectile
	{
		[SerializeField]
		private FrameConfig[] _configs;

		private GattiWeapon _trueWeapon;

		private MultiTargetTween _entryTween;

		private MultiTargetTween _exitTween;

		private int _cfgIndex;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}
	}
}
