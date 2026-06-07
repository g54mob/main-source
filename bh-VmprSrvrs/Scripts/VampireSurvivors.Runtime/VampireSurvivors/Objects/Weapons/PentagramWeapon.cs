using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class PentagramWeapon : Weapon
	{
		[SerializeField]
		private SpriteRenderer _WhiteDot;

		public float _R;

		public float _G;

		public float _B;

		public float _A;

		private MultiTargetTween _rgbTween;

		private MultiTargetTween _alphaTween;

		private Timer _levelOneFireTimer;

		private bool _restoreInitialFire;

		private bool _canFlash;

		public SpriteRenderer WhiteDot => null;

		protected override bool UseOnlineTimer => false;

		public bool EraseItems { get; private set; }

		public override float PInterval()
		{
			return 0f;
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public void FirePentagram(bool eraseItems, bool skipTriggers)
		{
		}

		private void PerformFire(bool skipTriggers)
		{
		}

		private void MakeWhiteDot()
		{
		}

		public override void SetVisible(bool visible)
		{
		}

		protected override void MakeLevelOne()
		{
		}

		private void RunInitialFire()
		{
		}
	}
}
