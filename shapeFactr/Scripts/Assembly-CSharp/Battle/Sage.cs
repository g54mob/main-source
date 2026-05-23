using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	public class Sage : BaseUnit
	{
		public CircleSpawn sallyPoint;

		public BulletSetting bullet;

		public StatusEffect statusEffect;

		[Header("賢者固有")]
		[SerializeField]
		[Label("出現数")]
		private int splitCount;

		[Label("発動距離")]
		[Tooltip("賢者の出現位置からどれだけ外にダメージフィールドを出すか。ダメージ半径分は自動適用")]
		public float effectDistance;

		[Label("ダメージ半径")]
		public float damageRadius;

		[Label("ダメージ間隔")]
		public float damageInterval;

		[Label("ダメージdelay")]
		public float damageDelay;

		[Label("出現間隔(度)")]
		public float anglarSpace;

		public LoopEffect chargeEffect;

		private int[] angleRange;

		private float[] splitAngles;

		private Vector3[] _orbPoints;

		private static List<Sage> sageList;

		private static int sageIndex;

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

		private Vector2 BulletSallyPositionSetting(int count)
		{
			return default(Vector2);
		}

		public override void UpdateUnit(double deltatime)
		{
		}

		public override void HitEnemy(GameObject enemyObj)
		{
		}

		public override void CheckLifeTime()
		{
		}

		public override void DestroyObj()
		{
		}

		private Vector3 ExchangeSage()
		{
			return default(Vector3);
		}

		private Vector2 GetSageAngle()
		{
			return default(Vector2);
		}

		private Vector3[] CalcOrbPoint(int value)
		{
			return null;
		}

		public override void BuffPlus(BuffSet<eAbilityEffectId> buffSet)
		{
		}

		private void OnApplicationQuit()
		{
		}
	}
}
