using System;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	[Serializable]
	public class StatusEffectReceive
	{
		public StatusEffectGroup effectGroup;

		[Header("減速効果")]
		[Label("最大減速量(%)")]
		[Tooltip("最大n%まで遅くなる")]
		[Range(0f, 1f)]
		public float maxSlow;

		[Label("耐性(～%Cut)")]
		[Range(0f, 1f)]
		public float slowResistance;

		private eSlowType _nowSlowType;

		[Header("火炎")]
		[Label("受付:火炎ダメージ")]
		public bool receiveFire;

		[Label("耐性(～%Cut)")]
		[Range(0f, 1f)]
		public float fireResistance;

		[Label("Overkill計上上限(s)")]
		[Tooltip("0以下で無効。ターゲットのExpectOverKillの計算に乗る炎上効果の上限値。(n / 炎上ダメージ間隔(固定))")]
		public int plusOverKillFirePoint;

		private double nextFireTime;

		private int? _limitPlusFireDamage;

		[Header("停止")]
		[Label("受付切替")]
		public bool enableStop;

		[Label("受付：停止(閾値)")]
		public int receiveStop;

		[Label("耐性(～%Cut)")]
		[Range(0f, 1f)]
		public float stopResistance;

		[Label("最大停止時間")]
		public float maxStopTime;

		private double NextMoveAble;

		public Action<eStopType> IrregularStopAction;

		public Action<eStopType> ReleaseIrregularStopAction;

		[Header("ノックバック")]
		[Label("受付：ノックバック")]
		public bool receiveKnockBack;

		[Label("跳ね返す")]
		public bool enableBounce;

		[Label("跳ね返す力上乗せ")]
		public float enemyKnockPower;

		[Label("有効：ノック減衰")]
		[Tooltip("無効なら耐性曲線のx軸0の地点を利用")]
		public bool enableKnockAttenuation;

		[Label("最大ノック回数")]
		[Tooltip("ノック減衰有効ならこの値が有効。ノック回数がこの値に近づくほど耐性が上がる")]
		public int maxKnockCount;

		[Label("耐性曲線")]
		[Tooltip("x軸(0 ~ 1が有効) = ノック回数 / 最大ノック数")]
		public AnimationCurve knockBackResistanceCurve;

		[Header("出血")]
		[Label("受付：出血")]
		public bool receiveBleeding;

		[Label("ダメージカット(最低でも1は受ける)")]
		[Tooltip("イグニスなどに設定。ダメージ計算時に適用")]
		public int bleedingCutDamage;

		[Header("引力")]
		[Label("受付：引力")]
		public bool enabledMagnet;

		private double _releaseMagnetTime;

		[Header("演出停止")]
		[Label("受付許可")]
		public ePlannedStopLevel enablePlannedStop;

		public bool Stopping => false;

		public List<eStatusEffect> receivedEffects { get; private set; }

		public float StackSlow { get; private set; }

		public double NextSlowRecoveryTime { get; private set; }

		public int StackFire { get; private set; }

		public bool IsFire => false;

		private int LimitPlusFireDamage => 0;

		public bool IsStop => false;

		public eStopType StopType { get; set; }

		public bool IsKnock { get; set; }

		public int KnockCount { get; private set; }

		public int BleedingStack { get; private set; }

		public bool HasBleeding => false;

		public Vector2 MagnetStack { get; private set; }

		public bool HasMagnet => false;

		public bool PlannedStop { get; set; }

		public ePlannedStopLevel PlannedStopLevel { get; set; }

		public void UpdateStatusEffect(BaseEnemy enemy, double deltatime)
		{
		}

		public void HitReceiveStatusEffect(StatusEffect effect, BaseEnemy enemy)
		{
		}

		public bool HasStatus(eStatusEffect effect)
		{
			return false;
		}

		public void RefreshStatus()
		{
		}

		public void ReceiveAdditionalDamage(BaseEnemy enemy, eLuggage giverLuggage, bool displayDamage = true)
		{
		}

		public void ReceiveSlow(StatusEffect effect)
		{
		}

		public void UpdateSlow()
		{
		}

		public void ReceiveFire(StatusEffect effect)
		{
		}

		public void UpdateFire(BaseEnemy enemy)
		{
		}

		public void ReceiveStop(StatusEffect effect, BaseEnemy enemy)
		{
		}

		public void UpdateStop(BaseEnemy enemy)
		{
		}

		public float GetKnockResistance(float minusBonus = 0f)
		{
			return 0f;
		}

		public void CountKnock()
		{
		}

		public void ResetKnockCount()
		{
		}

		public void ReceiveBleeding(StatusEffect effect)
		{
		}

		public int GetBleedingDamagePoint()
		{
			return 0;
		}

		public void ReceiveMagnet(Vector2 magnetDir)
		{
		}

		public void UpdateMagnet(BaseEnemy enemy)
		{
		}

		public void ReceivePlannedStop(ePlannedStopLevel stopLevel)
		{
		}

		public void ReleasePlannedStop(ePlannedStopLevel stopLevel)
		{
		}

		public int PredictStatusDamage(BaseEnemy enemy)
		{
			return 0;
		}

		public static int SumDecrementForZero(int x, int y, int step = -1)
		{
			return 0;
		}
	}
}
