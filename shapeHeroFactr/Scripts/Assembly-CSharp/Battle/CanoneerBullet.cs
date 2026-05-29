using UnityEngine;

namespace Battle
{
	public class CanoneerBullet : UnitBaseBullet
	{
		private Canoneer _canoneer;

		private float _changeScale;

		private float _scaleAdditionalValue;

		private float _flightTime;

		private const float _gravity = -9.8f;

		private float _lateTime;

		private float _t;

		private Vector3 _startPos;

		private float _vn;

		private Vector3 _targetPoint;

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

		private float GetComplementary()
		{
			return 0f;
		}
	}
}
