using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	public class FamilyMaster : BaseEnemy
	{
		[Header("固有設定")]
		public Family familyPrefab;

		[Label("子機の数")]
		public int childCount;

		[Label("関節の距離間")]
		public float familyDistance;

		[Label("出現間隔(s)")]
		public EffectInterval sallyInterval;

		[Label("子機のHp(%)")]
		[Tooltip("親に対して～%のHpを持つ")]
		public float childHpRatio;

		[Tooltip("何秒前の位置を見るか(s)")]
		public double adulationTime;

		[Label("切り替えし距離")]
		public float turnRadius;

		private EnemyBaseInfo _copyInfo;

		private bool _enterTown;

		private double _adulationTimer;

		private Vector3 _turnPos;

		private Vector3 _initSallyPos;

		public List<Family> Children { get; private set; }

		public Vector3 PrevPos { get; private set; }

		public override void Init()
		{
		}

		public override void EnemyUpdate(double deltaTime)
		{
		}

		private void CreateChild(int childIndex)
		{
		}

		private void RegisterPos(double deltatime)
		{
		}

		protected override void AttackTown()
		{
		}

		public override void DestroyObj()
		{
		}

		private void SetNextTurn()
		{
		}

		private bool CheckArriveTurn()
		{
			return false;
		}
	}
}
