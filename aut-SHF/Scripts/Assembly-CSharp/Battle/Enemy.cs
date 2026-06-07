using DG.Tweening;
using UnityEngine;

namespace Battle
{
	public class Enemy : MonoBehaviour
	{
		public class EnemyInfo
		{
			public eEnemy id;

			public int townAttack;

			public int exp;

			public eEnemyType type;

			public int currentHp;

			public float townDistance;

			public EnemyInfo(MstEnemyDataEntities mstEnemyDataEntities)
			{
			}
		}

		public EnemyInfo enemyInfo;

		[Label("スピード")]
		[Tooltip("マスタにまだ存在していないのでここで設定する")]
		public float speed;

		public SpriteAnimation spriteAnimation;

		public Transform childTransform;

		public StatusEffectReceive statusReceive;

		private bool alive;

		private CircleCollider2D circleCollider2d;

		private bool finishInit;

		private bool isTarget;

		private static readonly int PROPERTY_ADDITIVE_COLOR;

		[SerializeField]
		private SpriteRenderer _renderer;

		private Material _material;

		private Sequence _seq;

		private int debugDamagePoint;

		public bool Alive
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool FinishInit
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsTarget
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Transform tf { get; private set; }

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void EnemyUpdate(double deltaTime)
		{
		}

		private void LateUpdate()
		{
		}

		private void OnTriggerStay2D(Collider2D collision)
		{
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
		}

		public Vector2 GetSpeedVector()
		{
			return default(Vector2);
		}

		public bool Damage(int unitAttackPoint)
		{
			return false;
		}

		private void HitEffect()
		{
		}

		public void DestroyEnemy()
		{
		}

		private void PostEliminationProcess()
		{
		}

		public void NockBack(Vector2 velocity)
		{
		}

		private void MovePosition(Vector3 velocity)
		{
		}
	}
}
