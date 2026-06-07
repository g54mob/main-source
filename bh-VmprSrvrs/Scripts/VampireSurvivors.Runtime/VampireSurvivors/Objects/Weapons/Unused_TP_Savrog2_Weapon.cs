using UnityEngine;

namespace VampireSurvivors.Objects.Weapons
{
	public class Unused_TP_Savrog2_Weapon : TP_Savrog_Weapon
	{
		public Color[] _SpriteColours;

		public Color[] _TrailColours;

		private Trapano2Weapon _trapanoWeapon;

		private bool _totalDamageCalculated;

		protected override void Awake()
		{
		}

		protected override void OnStart()
		{
		}

		private void SetupTrapanoWeapon()
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void SetVisible(bool visible)
		{
		}

		public override void Cleanup()
		{
		}

		public override float CalculateTotalDamage()
		{
			return 0f;
		}
	}
}
