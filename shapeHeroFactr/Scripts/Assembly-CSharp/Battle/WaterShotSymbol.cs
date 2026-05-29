using UnityEngine;

namespace Battle
{
	public class WaterShotSymbol : BaseMiracleSymbol
	{
		private Vector3 _hitLocalPos;

		private double _intervalTimer;

		public override bool UpdateOk => false;

		public override void Init(MiracleInfo miracleInfo)
		{
		}

		public override double UpdateMiracle(double deltatime, RaycastHit hit)
		{
			return 0.0;
		}

		public void Shot()
		{
		}
	}
}
