using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	public abstract class BaseBattleUnit : MonoBehaviour
	{
		[Tooltip("出現範囲のオフセット")]
		public Vector2 offset;

		[Header("-------------------")]
		[Header("プランナー担当設定項目：ユニットパラメータ設定")]
		[Header("-------------------")]
		[Space]
		public UnitInfo unitInfo;

		[Header("子オブジェクトをアタッチ")]
		public SpriteAnimation spriteAnimation;

		protected bool alive;

		protected bool isMoveAble;

		protected eSpawnDirection spawnDirection;

		protected Vector2 spawnPosision;

		protected Vector2 targetPoint;

		protected float degree;

		protected int targetWaypointIndex;

		protected int prevTargetWaypointIndex;

		protected List<Vector3> unitWps;

		protected BaseEnemy targetEnemy;

		protected bool isAdulation;

		protected bool throwCollision;

		protected float waitTimer;

		public bool IsMoveAble
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public eSpawnDirection SpawnDirection
		{
			get
			{
				return default(eSpawnDirection);
			}
			set
			{
			}
		}

		public Vector2 SpawnPosision
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public Vector3 TargetPoint
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public float Degree
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public BaseEnemy TargetEnemy
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public abstract void Initialize();

		public abstract void HitEnemyAction(BaseEnemy _enemy);

		public abstract void DestroyUnit();
	}
}
