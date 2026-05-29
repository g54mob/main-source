using System;
using DG.Tweening;
using UnityEngine;

namespace Battle
{
	public class Hawk : BaseEnemy
	{
		private enum HawkActionState
		{
			None = 0,
			Spawn = 1,
			PreAttackWait = 2,
			Attack = 3,
			PostAttackWait = 4,
			Warp = 5,
			WarpEnd = 6
		}

		[Serializable]
		private class HpAction
		{
			[Range(0f, 1f)]
			[Label("HP割合(%)")]
			[Tooltip("大きい順に登録")]
			public float actionHp;

			[Label("移行アクション")]
			public HawkActionState actionType;

			private bool isFinish;

			public bool IsFinish
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public bool IsReached(float currentHp, float maxHp)
			{
				return false;
			}
		}

		[Header("Hawk固有")]
		[SerializeField]
		[Label("攻撃までの待機時間(最少)(s)")]
		private float _minPreAttackWaitTime;

		[SerializeField]
		[Label("攻撃までの待機時間(最大)(s)")]
		private float _maxPreAttackWaitTime;

		[SerializeField]
		[Label("飛行時間(s)")]
		private float _flightTime;

		public BulletSetting bullet;

		[SerializeField]
		[Label("一度の発射時間")]
		[Tooltip("ホークは寿命＝発射時間ではないので設定する")]
		private float _duration;

		[SerializeField]
		[Label("目標インターバル")]
		[Tooltip("bulletの発射時間終了時点のインターバル。今は上昇曲線はリニア")]
		private float endInterval;

		[SerializeField]
		[Label("弾の広がり具合")]
		public float bulletWidth;

		[SerializeField]
		[Label("Hpアクション")]
		private HpAction[] _hpActions;

		public LoopEffect atk;

		public HitEffect jump;

		private double _nextActionTime;

		private HawkActionState _nextAction;

		private HawkActionState _nowAction;

		private Vector3 _defaultShadowScale;

		private Tween _waitShadow;

		private int _maxHp;

		private double _shootedTime;

		private float _defaultInterval;

		public HawkMaster Master { get; set; }

		private float AttackWaitTime => 0f;

		private void RegisterNextAction(double waitTime, HawkActionState action)
		{
		}

		public override void Init()
		{
		}

		public override void EnemyUpdate(double deltaTime)
		{
		}

		private void StartMotion()
		{
		}

		public bool CheckMasterAlive()
		{
			return false;
		}

		public void CheckHpAction()
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

		public void IncreaseShootCount()
		{
		}

		private void Warp()
		{
		}

		private void WarpEnd()
		{
		}

		public override void DestroyObj()
		{
		}

		public override bool IsOverKill(bool plusStatus = false)
		{
			return false;
		}

		private void OnDestroy()
		{
		}
	}
}
