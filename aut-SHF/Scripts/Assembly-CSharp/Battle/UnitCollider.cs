using System;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	[Serializable]
	public class UnitCollider
	{
		[Label("当たり判定")]
		public CircleCollider2D circleCollider;

		[Label("有効：連続ヒット")]
		[Tooltip("同じ敵にヒットするようになる。hitIntervalはその時の貫通頻度")]
		public bool enabledPenetrate;

		[Label("ヒット頻度(s)")]
		public double hitInterval;

		[Label("有効：同敵ヒット")]
		[Tooltip("無効にした場合一度判定から離れた敵でもヒットしなくなる")]
		public bool sameEnemyHit;

		[Header("複数ヒット用設定")]
		[Label("グループリーダー上書き")]
		[Tooltip("シーサーペントなど複数で１個体としている場合に胴体へのヒットを頭にヒットしたことにすることができる")]
		public bool overwriteGroupRoot;

		private double _nextHitAbleTime;

		private int? enterEnemyId;

		private const int BATTLE_ENEMY_LAYER = 8;

		private static readonly LayerMask enemyLayer;

		public double NextHitAbleTime
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public void InitParameter(UnitCollider collider)
		{
		}

		public bool CollisionEnterProcess(Vector3 position, out Collider2D hit)
		{
			hit = null;
			return false;
		}

		public bool SearchMultiAttackCircle(Vector3 searchOrigin, float radius, out List<GameObject> hits, bool? exchangeGroupRoot = null)
		{
			hits = null;
			return false;
		}

		public bool SearchStraightLine(Vector3 startPos, Vector3 dir, float length, float tickness, out List<GameObject> battleObjs, bool? exchangeGroupRoot = null)
		{
			battleObjs = null;
			return false;
		}
	}
}
