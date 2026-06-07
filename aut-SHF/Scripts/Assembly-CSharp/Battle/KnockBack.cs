using System;
using UnityEngine;

namespace Battle
{
	[Serializable]
	public class KnockBack
	{
		[Label("有効：ノックバック")]
		public bool enabledKnockBack;

		[Label("ノックバック後スタン秒数")]
		public float knockBackStanSecond;

		[Label("ノックバック量")]
		public float knockBackPower;

		[Label("来た方向にノック(敵)")]
		public bool comeFrom;

		[Label("有効：ノックバック(自分)")]
		public bool enabledMyKnockBack;

		[Label("ノックバック量(自分)")]
		[Tooltip("0より大きい場合、相手にノックバック属性がなくても自分がノックを与えるときに自分もノックバック量を受ける")]
		public float myKnockBackPower;

		[Label("来た方向にノック(自分)")]
		public bool myComeFrom;

		[Label("同じ敵へ連続ノックする")]
		public bool enabledSameEnemyKnock;

		private float _minusRegistance;

		private int _lastKnockBackID;

		public void InitParameter(KnockBack knockBack)
		{
		}

		public void PlayKnockBack(BaseEnemy enemy, BaseUnit _hero)
		{
		}

		public void PlayKnockBack(BaseEnemy enemy, Vector2 direction)
		{
		}

		public void PlayKnockBack(BaseEnemy enemy, BaseMiracle miracle)
		{
		}

		public void BuffPlus(BuffSet<eAbilityEffectId> buffSet)
		{
		}
	}
}
