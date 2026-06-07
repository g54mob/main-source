using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyDiamondTint_Path : EnemyDiamondTint
	{
		private PhaserSpline _spline;

		private float _curveTime;

		private float _maxPathWidth;

		private float _maxPathHeight;

		protected Vector2 _positionOffset;

		private float CurveSpeed;

		private float PathDuration;

		private readonly List<float> Curve2Data;

		protected override float ItemChance => 0f;

		protected override bool IsImmovable => false;

		protected override bool IsAxe => false;

		protected override bool IsSnake => false;

		protected override bool DoBaseUpdate => false;

		protected override uint[] TintProgression => null;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		protected override void OnRecycleEnemy()
		{
		}

		protected override void OnUpdate()
		{
		}

		public void InitPath()
		{
		}

		public void PositionRelativeToCenter()
		{
		}
	}
}
