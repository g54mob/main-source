using System;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	public class Dryad : BaseUnit
	{
		[Serializable]
		public class ThornLevel
		{
			public LoopEffect thorn;

			public int splitCount;
		}

		public KnockBack knockBack;

		public StatusEffect statusEffect;

		public EffectInterval attackInterval;

		public int dryadCount;

		[Label("一つの層の範囲")]
		public float thornRadius;

		public float thornOffsetRadius;

		public List<ThornLevel> thornLevel;

		public HitEffect atk;

		private static Dryad[] dryads;

		private float[] _splitDegree;

		public BulletSetting bullet;

		public int MyIdx { get; set; }

		public bool IsSymbol { get; set; }

		public Dryad GetSymbolObj => null;

		public LoopEffect ThornEffect { get; set; }

		public List<GameObject> Enemies { get; set; }

		protected override void InitAdditionalParameter(BaseUnit unit)
		{
		}

		public override void Init()
		{
		}

		public override Vector2 SallyPositionSetting()
		{
			return default(Vector2);
		}

		private Vector2 SallyPositionThornBullet(int value, int total)
		{
			return default(Vector2);
		}

		public override void UpdateUnit(double deltatime)
		{
		}

		public void ChangeThorn()
		{
		}

		public void ThornOut()
		{
		}

		public void EffectThorn()
		{
		}

		public override void HitEnemy(GameObject enemyObj)
		{
		}

		public override void DestroyObj()
		{
		}
	}
}
