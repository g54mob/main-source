using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Battle
{
	public class BattleUnit : MonoBehaviour
	{
		[HideInInspector]
		[Tooltip("出現場所を決めるためのType。詳細はeSallyPositionTypeファイル参照")]
		public eSallyPositionType sallyPositionType;

		[Tooltip("ONなら完全ランダム.OFFなら一番少ないエリアに出現")]
		[HideInInspector]
		public bool randomSally;

		[Tooltip("出現範囲のオフセット")]
		[HideInInspector]
		public Vector2 offset;

		[Tooltip("出現タイプがSquereの場合：オフセットを中心とした「最大出現位置:右上」と「最小出現位置:左下」で作成した四角形線上に出現。Randomの場合：Squereと同じように作成された四角形内のランダムな場所に出現する")]
		[HideInInspector]
		public Vector2 topRight;

		[HideInInspector]
		public Vector2 bottomLeft;

		[HideInInspector]
		public List<eSpawnDirection> enabledDirection;

		[Range(-180f, 180f)]
		[Tooltip("topRightとbottomLeftで作成した四角形を回転させた位置に出現させる")]
		[HideInInspector]
		public float offsetRotation;

		[Tooltip("offsetを原点に円状に出現")]
		[HideInInspector]
		public float radius;

		[HideInInspector]
		public List<AngleRange> angleRange;

		[HideInInspector]
		[Tooltip("サークルで出現した位置の角度と同じ向きにする(シーサーペントなどに利用)")]
		public bool rotationBySpawnDegree;

		[HideInInspector]
		public Vector2 manualPosition;

		public UnitInfo unitInfo;

		[Tooltip("自動：子オブジェクトをアタッチ")]
		[HideInInspector]
		public SpriteAnimation spriteAnimation;

		[Tooltip("自動：子トランスフォームをアタッチ")]
		[HideInInspector]
		public Transform childTransform;

		[Tooltip("自動：DOTweenPathをアタッチ")]
		[HideInInspector]
		public DOTweenPath path;

		private bool alive;

		private eUnit unitType;

		private double unitEndLifeTime;

		private bool endStartAction;

		private double waitEndTime;

		private bool isWait;

		private bool isMoveStop;

		private bool searchWaitMode;

		private bool interceptMode;

		private bool targetDeathTrigger;

		private Vector2 directionVector;

		private bool isMoveAble;

		private Vector3 prevPosition;

		private BaseEnemy targetEnemy;

		private int? targetInstanceId;

		private double penetrateTimer;

		private double prevStayDeltaTime;

		private bool throwCollision;

		private Queue<Collider2D> hitEnemyQueue;

		private CircleCollider2D collider2D;

		public eUnit UnitType
		{
			get
			{
				return default(eUnit);
			}
			set
			{
			}
		}

		public eSpawnDirection SpawnDirection { get; private set; }

		public Vector2 SpawnPosition { get; private set; }

		public int circleAreaIndex { get; private set; }

		public Vector2 UnitOrigin => default(Vector2);

		public float Degree { get; private set; }

		public Vector3 SettingRotation()
		{
			return default(Vector3);
		}

		private Vector2 GetSquareLinePosition(eSpawnDirection _direction)
		{
			return default(Vector2);
		}

		private Vector2 GetCircleLinePosition(bool isRandom)
		{
			return default(Vector2);
		}

		private Vector2 GetTargetPosition(Vector2 origin)
		{
			return default(Vector2);
		}

		private List<BaseEnemy> SearchAliveTargetInCircle(Vector2 origin, float radius)
		{
			return null;
		}

		private eSpawnDirection GetRandomSpawnDirection()
		{
			return default(eSpawnDirection);
		}

		public void LookAtPath()
		{
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public void UpdateUnit(double deltaTime)
		{
		}

		private void LateUpdate()
		{
		}

		private void MovePosition(Vector3 velocity)
		{
		}

		public void ChangeScaleTween()
		{
		}

		private void CheckTarget()
		{
		}

		private bool IsNearTown(Vector2 comparator, Vector2 myPosition)
		{
			return false;
		}

		private void CheckLifeTime()
		{
		}

		private void CheckSearchEnemyInAttackRadius()
		{
		}

		private void WaitMove()
		{
		}

		private void SetStopMove(float stopTime)
		{
		}

		public void StartSpawn()
		{
		}

		public void StartAction()
		{
		}

		public void StartMoveAnimation()
		{
		}

		public void CreateAdditionalUnit()
		{
		}

		public void Reflection(Collider2D collision)
		{
		}

		private void CalcInspectDirection(Vector2 targetPosition, float deltaTime)
		{
		}

		private void MultiAttack()
		{
		}

		public void DisplayAttackRange(Vector3 displayPosition, float radius)
		{
		}

		private void KnockBackUnit(BaseEnemy enemy)
		{
		}

		private void HitEnemyAction(BaseEnemy _enemy)
		{
		}

		private void PostEnemyDead(BaseEnemy _enemy)
		{
		}

		private void CollisionEnterProcess()
		{
		}

		public void DestroyUnit()
		{
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
		}

		public void OnAttackEvent()
		{
		}

		private void OnTriggerStay2D(Collider2D collision)
		{
		}

		private void OnDisable()
		{
		}
	}
}
