using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Malphas_Character : TP_Character
	{
		[SerializeField]
		private Vector2 _whipOffset;

		[SerializeField]
		private float _spriteWhipOffset;

		private SpriteRenderer _back2Sprite;

		private SpriteAnimation _back2Anim;

		private Weapon StartingWeapon;

		private Weapon HiddenWeapon;

		private float _baseWeaponPower;

		private WeaponType WeaponT1;

		private WeaponType WeaponT2;

		public override bool NeedsCart => false;

		public override float2 GetVectorWhipOffset => default(float2);

		public override float GetSpriteWhipOffset => 0f;

		public override bool ShouldCollideWithWalls()
		{
			return false;
		}

		protected override void OnStop()
		{
		}

		public override void AfterFullInitialization()
		{
		}

		public override void LevelUp()
		{
		}
	}
}
