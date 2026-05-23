using UnityEngine;

namespace Assets.Scripts.Player.Movement
{
	public class PlayerMovementValues
	{
		private const float defaultMoveSpeed = 2700f;

		private const float defaultSwimSpeed = 10f;

		public const float defaultMaxSpeed = 10f;

		private const float defaultSlideForce = 200f;

		private const float defaultAirDeceleration = 0.003f;

		private const float defaultExtraGravity = 11f;

		private bool inited;

		private ECharacter currentCharacter;

		private float counterMovement;

		public float moveSpeed { get; private set; }

		public float maxRunSpeed { get; private set; }

		public float airDeceleration { get; private set; }

		public float slideForce { get; private set; }

		public float extraGravity { get; private set; }

		public float swimSpeed { get; private set; }

		private void Init(Rigidbody rb)
		{
		}

		public void CreateMovement(Rigidbody rb, ECharacter character)
		{
		}

		private static float GetCounterMovementMultiplier(ECharacter character)
		{
			return 0f;
		}

		private static float GetMoveSpeedMultiplier(ECharacter character)
		{
			return 0f;
		}

		public float GetCounterMovementMultiplier(FrictionModifier.EFrictionSurface surface)
		{
			return 0f;
		}

		public static float GetSlowdownMultiplier(FrictionModifier.EFrictionSurface surface, ECharacter character)
		{
			return 0f;
		}

		public float GetMoveSpeed(FrictionModifier.EFrictionSurface surface, bool grounded)
		{
			return 0f;
		}

		public float GetGravity(Rigidbody rb, ECharacter character)
		{
			return 0f;
		}

		public float GetMaxSpeed()
		{
			return 0f;
		}

		public float GetMaxSpeedNoMultiplier()
		{
			return 0f;
		}
	}
}
