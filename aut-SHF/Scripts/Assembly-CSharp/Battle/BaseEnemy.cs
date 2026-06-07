using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

namespace Battle
{
	public abstract class BaseEnemy : MonoBehaviour, IBattleCycle, IReceiveDamageable, IReceiveCollider, IReceiveTarget
	{
		[Serializable]
		public struct EnemyBaseInfo
		{
			public eEnemy id;

			public int unitAttack;

			public int townAttack;

			public float speed;

			public int exp;

			public eEnemyType type;

			public int currentHp;

			public int maxHp;

			public int shield;

			public int FullHp => 0;
		}

		[CompilerGenerated]
		private sealed class _003CAnyTimer_003Ed__173 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float time;

			public Action preAction;

			public Action postAction;

			public BaseEnemy _003C_003E4__this;

			private double _003CwaitEndTime_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CAnyTimer_003Ed__173(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public EnemyBaseInfo enemyInfo;

		public StatusEffectReceive statusReceive;

		[Header("その他設定")]
		[Label("敵同士衝突無効")]
		public bool throughEnemyCollision;

		[Label("敵同士衝突許容率")]
		[Range(0f, 1f)]
		public float enemyAcceptanceRate;

		[SerializeField]
		[Label("ダメージカット")]
		private int _cutDamage;

		[Label("ターゲット無効")]
		public bool invalidTarget;

		[Label("ターゲット占有優先度")]
		[Tooltip("当項目に設定したUnitからターゲットを受けた時、優先度が設定される。設定してないヒーローは「priority:0」扱い。※敵を狙う優先順位ではないので注意(敵を狙う優先順位付けはヒーローのターゲット>SearchOptionからSearchEnemyを選択)。※Priorityでフィルターをかけるためには別途ヒーロー側でターゲット>SearchOptionからPriorityIsBellowを選択※降順で登録お願いします。")]
		public IReceiveTarget.TargetPriority[] _targetPriorities;

		[Label("特殊ターゲットラベル")]
		public eSpecialTargetLabel targetLabel;

		[Header("衝突判定関係")]
		[SerializeField]
		private CircleCollider2D _collider;

		[SerializeField]
		[Label("衝突無効")]
		private bool _throughCollider;

		public Transform rotationPoint;

		[Header("HPバー")]
		[SerializeField]
		private EnemyHpBar enemyHpBar;

		[SerializeField]
		private Vector3 hpBarOffset;

		protected int enemyNumber;

		private List<Target.TargetObj> _targetUnit;

		protected Vector3 _prevLocalPosition;

		public bool trackingMode;

		public EffectInterval trackingInterval;

		private bool _isGroupMember;

		protected EnemyHpBar enemyHpBarObj;

		protected static readonly int PROPERTY_ADDITIVE_COLOR;

		public SpriteAnimation spriteAnimation;

		private bool _isSummonLastBattle;

		[SerializeField]
		protected Transform shadow;

		private MaterialPropertyBlock _propertyBlock;

		private SpriteRenderer _spriteRenderer;

		private Sequence _seq;

		private double _overrapCheckTime;

		private const int BATTLE_ENEMY_LAYER = 8;

		private static readonly LayerMask enemyLayer;

		public eBattleTag Tag => default(eBattleTag);

		public int TypeNum => 0;

		public int UniquTypeNum => 0;

		public bool Alive { get; protected set; }

		public bool FinishInit { get; protected set; }

		public bool Moveable { get; protected set; }

		public GameObject GameObj => null;

		public Transform Tf { get; set; }

		public virtual int AttackPoint => 0;

		public virtual int CurrentHp => 0;

		public virtual int MaxHp => 0;

		public virtual int Shield => 0;

		public virtual float Speed => 0f;

		public virtual double Lifetime => 0.0;

		public bool InvalidTarget => false;

		public bool IsTarget => false;

		public bool TargetOk => false;

		public int TargetCount => 0;

		public List<Target.TargetObj> TargetObjs
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public IReceiveTarget.TargetPriority[] TargetPriorities => null;

		public eSpecialTargetLabel SpecialTargetLabel => default(eSpecialTargetLabel);

		public List<Target.TargetObj> PriorityHero { get; set; }

		public int GetMaxPriority => 0;

		public int? TargetGroupId { get; set; }

		public BaseEnemy TargetGroupRoot { get; set; }

		public Vector2 DirectionVector { get; protected set; }

		public float SqrDistanceGate => 0f;

		public bool IsGroupMember
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Vector3 InitSpawnPos { get; set; }

		public bool IsSubEnemy { get; protected set; }

		public SpriteAnimation SpriteAnimation
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool ThroughCollider
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public CircleCollider2D Collider => null;

		public bool ReceiveOk => false;

		public Vector3 ColliderOrigin => default(Vector3);

		public int? ColliderGroupId { get; set; }

		public GameObject ColliderGroupRoot { get; set; }

		public int CutDamage
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float EffectedSpeed => 0f;

		public bool IsStop => false;

		public bool IsBookOut { get; set; }

		public bool IsSummonLastBattle
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool CheckGateCollision => false;

		public int GetTargetPriority(int uniquTypeNum)
		{
			return 0;
		}

		public virtual void OverWriteWithMstData(MstEnemyDataEntities mstEnemyDataEntities, EnemyCluster.EnemyLevelInfo levelData)
		{
		}

		public void OverWriteWithMstData(eEnemy id, eEnemyType type, MstEnemyLevelEntities levelData)
		{
		}

		private void Awake()
		{
		}

		public abstract void Init();

		public abstract void EnemyUpdate(double deltaTime);

		public virtual void LastUpdate()
		{
		}

		public virtual void BillboardRotation()
		{
		}

		protected Vector2 CollisionEnterEnemy(double deltatime)
		{
			return default(Vector2);
		}

		protected virtual void AttackTown()
		{
		}

		protected virtual int GetTownAttackPoint()
		{
			return 0;
		}

		public void SetTownVector()
		{
		}

		protected virtual void TrackingCheck()
		{
		}

		public virtual bool ReceiveDamage(int unitAttackPoint, eLuggage giverLuggage, bool displayDamage = true, bool isAdditionalDamage = true)
		{
			return false;
		}

		public virtual bool ReceiveStatusDamage(int damagePoint, eLuggage giverLuggage, SpriteNo.eDamageType damageType, bool displayDamage = true)
		{
			return false;
		}

		public virtual void ReceiveStatusEffect(StatusEffect statusEffect)
		{
		}

		public int BaseDamageUpCheck(int baseDamage)
		{
			return 0;
		}

		public void DisplayDamage(int damage, SpriteNo.eDamageType damageType = SpriteNo.eDamageType.None, Vector3? offset = null)
		{
		}

		public void DisplayDamage(int damage, Vector3 position, SpriteNo.eDamageType damageType = SpriteNo.eDamageType.None, Vector3? offset = null)
		{
		}

		protected virtual void HitEffect()
		{
		}

		public virtual void DestroyObj()
		{
		}

		protected void InactiveShadow()
		{
		}

		public virtual void Withdrawal()
		{
		}

		public void StopMove(float stopTime)
		{
		}

		[IteratorStateMachine(typeof(_003CAnyTimer_003Ed__173))]
		protected IEnumerator AnyTimer(float time, Action preAction = null, Action postAction = null)
		{
			return null;
		}

		public virtual void PostEliminationProcess()
		{
		}

		public virtual void NockBack(Vector2 velocity, float registanceMinus = 0f)
		{
		}

		public virtual void NockBack(float knockBackPower, float registanceMinus = 0f)
		{
		}

		public virtual Vector3 GetVelocity(float deltaTime)
		{
			return default(Vector3);
		}

		public virtual void FlipSprite()
		{
		}

		public virtual void MovePosition(Vector3 velocity)
		{
		}

		public virtual bool CheckOuterRect()
		{
			return false;
		}

		public virtual void CheckDestroyDistance()
		{
		}

		protected virtual void CreateHpBar(float maxHp, float msxShield = 0f)
		{
		}

		protected virtual void UpdateHpBar(float currentHp)
		{
		}

		protected void RegisterEliminated()
		{
		}

		public virtual bool IsOverKill(bool plusStatus = false)
		{
			return false;
		}

		public void ReceiveTarget(Target.TargetObj targetObj)
		{
		}

		public void SettingTargetGroup(BaseEnemy root)
		{
		}

		public void SettingColliderGroup(GameObject root)
		{
		}

		public void WaveEndProcess()
		{
		}

		protected EnemyBaseInfo GetApplyBuffInfo(EnemyBaseInfo info)
		{
			return default(EnemyBaseInfo);
		}

		public void PlayAppearSE()
		{
		}

		public void PlayDisappearSE()
		{
		}

		public void PlayHitSE()
		{
		}

		public void PlayChargeSE()
		{
		}

		public void PlayShootingSE()
		{
		}

		public void PlayUniqueAction01SE()
		{
		}

		public void PlayUniqueAction02SE()
		{
		}

		public void PlayUniqueAction03SE()
		{
		}

		public void PlayUniqueAction04SE()
		{
		}

		public void PlayUniqueAction05SE()
		{
		}

		public void PlayUniqueAction06SE()
		{
		}

		public void PlayUniqueAction07SE()
		{
		}

		public void PlayUniqueAction08SE()
		{
		}

		public void PlayUniqueAction09SE()
		{
		}

		public void PlayUniqueAction10SE()
		{
		}

		public void PlayUniqueAction11SE()
		{
		}

		public void PlayUniqueAction12SE()
		{
		}

		public void PlayUniqueAction13SE()
		{
		}

		public void PlayUniqueAction14SE()
		{
		}

		public void PlayUniqueAction15SE()
		{
		}

		public string DebugDetailLog()
		{
			return null;
		}
	}
}
