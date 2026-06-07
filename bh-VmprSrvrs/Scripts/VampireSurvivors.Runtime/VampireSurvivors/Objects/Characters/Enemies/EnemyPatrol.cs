using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyPatrol : EnemyController
	{
		private Tween _scaleTween;

		private Tween _sineTween;

		private float _patrolDuration;

		private float _sineF;

		protected Pickup _ownerAsPickup;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public override void SetOwner(GameObject owner)
		{
		}

		protected override void OnUpdate()
		{
		}
	}
}
