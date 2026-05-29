using UnityEngine;

namespace Battle
{
	public class SirenBullet : UnitBaseBullet
	{
		public LoopEffect song;

		private Siren _siren;

		private KnockBack _knockback;

		private float _timeRate;

		private float _playbackTime;

		private float _goal;

		private Vector3 _defaultSize;

		private float _multiHitDelay;

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

		public override void LastUpdate()
		{
		}

		public override void DestroyObj()
		{
		}
	}
}
