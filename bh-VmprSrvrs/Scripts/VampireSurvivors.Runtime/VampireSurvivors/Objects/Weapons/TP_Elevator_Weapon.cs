using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Elevator_Weapon : TP_Clockwork_Weapon
	{
		private Transform _cachedCameraTransform;

		private Vector2 _leftOffset;

		private Vector2 _rightOffset;

		private Tween cableTween1;

		private Tween cableTween2;

		public TileSprite ChainSpriteL { get; set; }

		public TileSprite ChainSpriteR { get; set; }

		public Transform RightTransform { get; set; }

		public Transform LeftTransform { get; set; }

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void FireProjectiles(Vector2 pos)
		{
		}

		public override void Cleanup()
		{
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
