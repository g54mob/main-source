using UnityEngine;

namespace Battle
{
	public class HarpyBullet : UnitBaseBullet
	{
		private Harpy _harpy;

		private float _timeRate;

		private float _playbackTime;

		private float _goal;

		private int _minAttack;

		private KnockBack _knockBack;

		public override void Init()
		{
		}

		protected override void InitAdditionalParameter(BaseBullet bullet)
		{
		}

		public override void UpdateBullet(double deltatime)
		{
		}

		public override void HitEnemy(GameObject enemyObj)
		{
		}

		public override void DestroyObj()
		{
		}
	}
}
