using UnityEngine;

namespace Battle
{
	public class FrostLaserSymbol : BaseMiracleSymbol
	{
		private Vector3 _hitLocalPos;

		public override bool UpdateOk => false;

		public override void Init(MiracleInfo miracleInfo)
		{
		}

		public override double UpdateMiracle(double deltatime, RaycastHit hit)
		{
			return 0.0;
		}

		public double Shot()
		{
			return 0.0;
		}
	}
}
