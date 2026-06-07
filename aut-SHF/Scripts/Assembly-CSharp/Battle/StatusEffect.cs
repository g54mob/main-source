using System;
using UnityEngine;

namespace Battle
{
	[Serializable]
	public class StatusEffect
	{
		[Header("減速効果")]
		[Label("有効：減速効果")]
		public bool enabledSlow;

		[Label("スロータイプ")]
		[Tooltip("出現するエフェクトが変わる")]
		public eSlowType slowType;

		[Tooltip("もし敵の遅延耐性が0なら、この値がそのまま敵のスピードから引かれる")]
		public float slowPoint;

		[Label("付与時間")]
		public float slowTime;

		[Header("火炎ダメージ")]
		[Label("有効：火炎ダメージ")]
		public bool enabledFire;

		public float firePoint;

		private int _fireDamage;

		private int _fireStackPoint;

		private int _firstFireDamagePlus;

		[Header("停止")]
		[Label("有効:停止状態")]
		public bool enabledStopEffect;

		[Label("ストップタイプ")]
		public eStopType stopType;

		[Label("付与停止時間")]
		public float stopTime;

		[Label("停止付与閾値")]
		[Tooltip("敵側にも閾値が設定できるようになっており、この値で強などを表現する。この値が敵の閾値より低ければ効果を与えられない")]
		public int stopThreshold;

		[Header("出血")]
		[Label("有効：出血")]
		public bool enabledBleeding;

		[Label("出血付与p")]
		public int bleedingPoint;

		[Header("引力")]
		[Label("有効：引力")]
		public bool enabledMagnet;

		[Label("強さ")]
		public float magnetPoint;

		public int FireDamage => 0;

		public int FireStackPoint => 0;

		public int FirstFireDamagePlus => 0;

		public void MagnetEffect(BaseEnemy enemy, Vector3 origin)
		{
		}

		public void InitParameter(StatusEffect statusEffect)
		{
		}

		public void BuffPlus(BuffSet<eAbilityEffectId> buff)
		{
		}
	}
}
