using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	public class Nest : BaseEnemy
	{
		public NestChild childPrefab;

		public EffectInterval attackInterval;

		[Label("子を放出する範囲")]
		public float radius;

		public float height;

		[Header("子のレベル別ステータス")]
		[SerializeField]
		private List<ChildLevelStatus> childLevelStatus;

		private EnemyBaseInfo _childLevelStatus;

		public override void Init()
		{
		}

		public override void EnemyUpdate(double deltaTime)
		{
		}

		private void CreateChild()
		{
		}

		public override void DestroyObj()
		{
		}
	}
}
