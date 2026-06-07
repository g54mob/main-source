using System;

namespace Battle
{
	[Serializable]
	public class MiracleInfo
	{
		public eMiracle miracleType;

		public UnitBuffSet buffSet;

		private MstMiracleDataEntities _mstMiracleData;

		public int RemainBullet { get; set; }

		public MstMiracleDataEntities MstMiracleData => null;

		public int AttackPoint => 0;

		public float Radius => 0f;

		public float MaxCoolTime => 0f;

		public int HitCount => 0;

		public float Speed => 0f;

		public double LifeTime => 0.0;

		public int Endurance => 0;

		public MiracleInfo(eMiracle id)
		{
		}
	}
}
