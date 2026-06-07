using UnityEngine;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Lapiste1_Weapon : Weapon
	{
		[SerializeField]
		private bool _UseAltAnimation;

		public float YPosOffset => 0f;

		public bool UseAltAnimation => false;

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		public override void Fire(bool skipTriggers = false)
		{
		}
	}
}
