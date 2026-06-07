using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemySpin : EnemyController
	{
		private float _spinAngle;

		private float _radius;

		private Tween _radiusTween;

		private Tween _scaleTween;

		private Bounds _camBounds;

		public int? DepthOverride { get; set; }

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void UpdateDepth()
		{
		}
	}
}
