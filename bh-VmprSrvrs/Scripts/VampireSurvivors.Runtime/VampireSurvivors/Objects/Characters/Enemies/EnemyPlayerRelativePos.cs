using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyPlayerRelativePos : EnemyController
	{
		private PhaserSpline _spline;

		private float _curveTime;

		private float _maxPathWidth;

		private float _maxPathHeight;

		protected Vector2 _positionOffset;

		public float CurveSpeed;

		public float PathDuration;

		private readonly List<float> CurveData;

		private readonly List<float> Curve2Data;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		protected override void OnRecycleEnemy()
		{
		}

		public void InitPath()
		{
		}

		protected override void OnUpdate()
		{
		}

		public void PositionRelativeToCenter()
		{
		}
	}
}
