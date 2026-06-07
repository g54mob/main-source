using UnityEngine;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects
{
	public class PetInstance
	{
		public Equipment _baseEquipment;

		public Equipment _hiddenWeapon;

		public SpriteRenderer _petSprite;

		public VampireSurvivors.Objects.Characters.CharacterController Owner;

		public float _petOffset;

		private Vector2 _currentDirection;

		protected float _offsetY;

		protected float _runSpeed;

		private float GetOffsetX()
		{
			return 0f;
		}

		private float DistanceSquared(Vector2 vec1, Vector2 vec2)
		{
			return 0f;
		}

		public void InternalPetUpdate()
		{
		}
	}
}
