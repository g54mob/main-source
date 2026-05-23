using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DG.Tweening;
using UnityEngine;

namespace Battle
{
	public class LastBoss : BaseEnemy
	{
		public enum LastBossAction
		{
			None = 0,
			Wait = 1,
			Laser = 2,
			Laugh = 3,
			Breath = 4,
			SummonNormal = 5,
			SummonBoss = 6,
			Punch = 7,
			EnergyBullet = 8,
			Angry = 9
		}

		[Serializable]
		private struct HandPosSet
		{
			public LastBossAction label;

			public Vector3 goalPos;

			public float duration;

			public float angryDuration;

			public float Duration(bool isAngly)
			{
				return 0f;
			}
		}

		[Serializable]
		private struct SummonEnemySet
		{
			public eEnemy enemy;

			public int value;

			public List<Vector2> summonPos;
		}

		[Serializable]
		private struct TurnMinusSet
		{
			public string label;

			[Label("通常時ターン減衰")]
			public float normalMinusTime;

			[Label("怒り時ターン減衰")]
			public float angryMinusTime;

			[Label("通常時ターン減衰下限")]
			public float normalLimit;

			[Label("怒り時ターン減衰下限")]
			public float angryLimit;
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CCreateEnemy_003Ed__82 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public BaseEnemy createObj;

			public int count;

			public Vector2 baseSallyPoint;

			public LastBoss _003C_003E4__this;

			private AsyncInstantiateOperation<BaseEnemy> _003Chandler_003E5__2;

			private AsyncInstantiateOperation<BaseEnemy>.Awaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[Header("以下ラスボス固有")]
		[Header("全体設定")]
		[Label("縦揺れ値")]
		public float floatingY;

		public GameObject handsRoot;

		[Label("タイムライン設定")]
		public ActionTimeline<LastBossAction> timeline;

		[SerializeField]
		private LastBossHand handL;

		[SerializeField]
		private LastBossHand handR;

		[SerializeField]
		private List<HandPosSet> handsPosSet;

		[Label("ターン減衰設定")]
		[SerializeField]
		private List<TurnMinusSet> turnMinusList;

		[Header("レーザー設定")]
		[Label("影響：全エリア")]
		[SerializeField]
		private bool isAllArea;

		[Header("エネルギー弾設定")]
		[SerializeField]
		private LastBossBulletBall bulletBall;

		[SerializeField]
		private BulletSetting energyBullet;

		[SerializeField]
		private float bulletSpawnX;

		[SerializeField]
		private float randomOffsetRange;

		[Header("パンチ設定")]
		[Label("溜めに入る位置")]
		public float sinkRadius;

		[Label("パンチ溜め秒数")]
		public float sinkTime;

		[Label("パンチをやめるhp割合")]
		[SerializeField]
		[Range(0f, 1f)]
		private float cancelPunchRatio;

		[SerializeField]
		private Vector3 breathEffectHandPos;

		[Header("石化ブレス")]
		[Label("石化有効ランク")]
		[SerializeField]
		private List<eUnitRank> pertrifactionRank;

		[Label("石化持続時間(s)")]
		[SerializeField]
		private double pertrifactionTime;

		[Header("召喚")]
		[SerializeField]
		private List<SpriteAnimation> normalGateList;

		[SerializeField]
		private SummonEnemySet normalSummon;

		[SerializeField]
		[Tooltip("設定した敵が元々でない場合にのみこのレベルが適用される")]
		private int normalSummonLevel;

		[SerializeField]
		private List<SpriteAnimation> bossGateList;

		[SerializeField]
		private SummonEnemySet bossSummon;

		[Label("1箇所の召喚範囲")]
		[SerializeField]
		private float summonRadius;

		[Header("怒り")]
		[Label("怒り状態に移行するHP割合")]
		[SerializeField]
		private float angerHpRatio;

		[Label("怒り時毎パンチシールド付与")]
		[SerializeField]
		private int angryShield;

		[Header("エフェクト関係")]
		[SerializeField]
		private HitEffect chargeLaser;

		[SerializeField]
		private HitEffect laser;

		[SerializeField]
		private HitEffect chargePertrifaction;

		[SerializeField]
		private HitEffect pertrifaction;

		[SerializeField]
		private List<Vector3> energyBallPositions;

		[SerializeField]
		private HitEffect angry;

		[SerializeField]
		private Material angryMaterial;

		private List<Vector2> _summonPosCache;

		private List<BaseEnemy> _summonEnemies;

		private BaseEnemy _summonNormalEnemy;

		private BaseEnemy _summonBossEnemy;

		private Dictionary<GameObject, Tween> _shakeTween;

		private bool _isAngry;

		private double _gearCache;

		private int _cancelPunchDamage;

		private int _transitionAngryHp;

		private bool _returnPunch;

		private int _cancelPunchHpPoint;

		private int _damageStopHp;

		private Material _initMaterial;

		private Sequence _movehandSequence;

		private static readonly int PROPERTY_DISSOLVE;

		private static readonly int ManagedSequenceId;

		public Sequence CreateManagedSequene()
		{
			return null;
		}

		private void ChangeSequenceGear()
		{
		}

		public override void EnemyUpdate(double deltaTime)
		{
		}

		public override void Init()
		{
		}

		public void Wait()
		{
		}

		public void Laser()
		{
		}

		public void Laugh()
		{
		}

		public void Breath()
		{
		}

		public void SummonNormal()
		{
		}

		public void SummonBoss()
		{
		}

		public void Punch()
		{
		}

		public void PunchUpdate(double deltaTime)
		{
		}

		private bool CancelPunch()
		{
			return false;
		}

		public void EnergyBullet()
		{
		}

		public void Angry()
		{
		}

		private void PreAttackMotion()
		{
		}

		private void PostAttackMotion(bool playLaugh = false)
		{
		}

		private void PlayAnimationAll(string animationName, Action callback = null, float? duration = null)
		{
		}

		private void PlayAnimationAll(string parentAnimationName, string childAnimationName, Action parentCallback = null, Action childCallback = null, float? duration = null)
		{
		}

		private void VerticalShake(GameObject target, float delay = 0f)
		{
		}

		private void StopVerticalShake(GameObject target)
		{
		}

		public Sequence SetMoveHand(LastBossAction key, bool managed = true)
		{
			return null;
		}

		private Sequence SetMoveHand(Vector3 goal, float duration, bool managed = true)
		{
			return null;
		}

		public void HandBillboardRotation()
		{
		}

		private void MinusTime(int turnCount)
		{
		}

		private void StopLaugh()
		{
		}

		private void VanishHeroLaser()
		{
		}

		private bool PertrifactionHero()
		{
			return false;
		}

		private void SummonEnemy(SummonEnemySet summonSet, BaseEnemy createObj)
		{
		}

		[AsyncStateMachine(typeof(_003CCreateEnemy_003Ed__82))]
		private void CreateEnemy(BaseEnemy createObj, int count, Vector2 baseSallyPoint)
		{
		}

		private void CreateBossEnemy(BaseEnemy createObj, int count, Vector2 baseSallyPoint)
		{
		}

		private List<Vector2> GetPointsInCircle(int count, float radius)
		{
			return null;
		}

		private void ChangeMaterial(bool angly)
		{
		}

		public override bool ReceiveDamage(int unitAttackPoint, eLuggage giverLuggage, bool displayDamage = true, bool isAdditionalDamage = true)
		{
			return false;
		}

		public override bool ReceiveStatusDamage(int damagePoint, eLuggage giverLuggage, SpriteNo.eDamageType damageType, bool displayDamage = true)
		{
			return false;
		}

		public override void DestroyObj()
		{
		}

		private void PetrifactionProcess(eStopType type)
		{
		}

		private void ReleasePetrifaction(eStopType type)
		{
		}

		public void ResetLastBoss(MstEnemyLevelEntities entity = null)
		{
		}
	}
}
