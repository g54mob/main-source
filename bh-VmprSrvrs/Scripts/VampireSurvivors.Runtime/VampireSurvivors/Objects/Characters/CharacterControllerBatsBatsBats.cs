using UnityEngine;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters
{
	public class CharacterControllerBatsBatsBats : CharacterController
	{
		private Battilia2Weapon Battilia2Weapon;

		private float _baseWeaponPower;

		private SpriteRenderer _back2Sprite;

		private SpriteRenderer _front2Sprite;

		private SpriteRenderer _back3Sprite;

		private SpriteRenderer _front3Sprite;

		private SpriteAnimation _back2Anim;

		private SpriteAnimation _front2Anim;

		private SpriteAnimation _back3Anim;

		private SpriteAnimation _front3Anim;

		private int _followers;

		public override bool NeedsCart => false;

		public override float PAmount()
		{
			return 0f;
		}

		protected override void OnStop()
		{
		}

		public override void AfterFullInitialization()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void LevelUp()
		{
		}

		public override void Revive(float percentage = 1f, bool instantRevival = false)
		{
		}

		public override void DoPostRevivalActions(CharacterController revived, bool instantRevival = false)
		{
		}
	}
}
