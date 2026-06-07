using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class SwipecardProjectile : Projectile
	{
		private float _volume;

		private float _timer;

		private int _swipeCounter;

		private int _minimumSwipes;

		private float _swipeSpeed;

		private bool _resettingSwipe;

		private bool _isFinished;

		private List<SfxType> _swipeSounds;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void PlayRandomSwipe()
		{
		}

		private void UpdatePosition()
		{
		}

		public override void InternalUpdate()
		{
		}
	}
}
