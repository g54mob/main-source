using UnityEngine;
using UnityEngine.Rendering;

namespace Battle
{
	public class NestChild : BaseEnemy
	{
		private float _shadowPosZ;

		private SortingGroup _sortGroup;

		public Vector3 Start { get; set; }

		public Vector3 Goal { get; set; }

		public Vector3 Control { get; set; }

		public override void Init()
		{
		}

		public override void EnemyUpdate(double deltaTime)
		{
		}

		public override void BillboardRotation()
		{
		}
	}
}
