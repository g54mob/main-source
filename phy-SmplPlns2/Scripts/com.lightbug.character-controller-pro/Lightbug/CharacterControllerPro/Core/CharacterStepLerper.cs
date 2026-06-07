using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Core
{
	[AddComponentMenu("Character Controller Pro/Core/Character Graphics/Step Lerper")]
	[DefaultExecutionOrder(20)]
	public class CharacterStepLerper : CharacterGraphics
	{
		[Tooltip("How fast the step up interpolation is going to be.")]
		[SerializeField]
		private float positiveDisplacementSpeed = 20f;

		[Tooltip("How fast the step down interpolation is going to be.")]
		[SerializeField]
		private float negativeDisplacementSpeed = 40f;

		[Tooltip("Having a character that is being interpolated all the time is not ideal, especially when walking on slopes, being not grounded, or maybe using a moving platform. For those cases, the character should be allowed to smoothly go back to its original local position over time. This field represents the duration of this process (in seconds).")]
		[SerializeField]
		private float recoveryDuration = 1f;

		[Tooltip("The maximum speed used for the recovery process (see recoveryDuration tooltip).")]
		[SerializeField]
		private float maxRecoverySpeed = 200f;

		private Vector3 previousPosition;

		private bool teleportFlag;

		private float recoveryTimer;

		protected override void OnValidate()
		{
			base.OnValidate();
			CustomUtilities.SetPositive(ref positiveDisplacementSpeed);
			CustomUtilities.SetPositive(ref negativeDisplacementSpeed);
		}

		private void Start()
		{
			previousPosition = base.transform.position;
		}

		private void OnEnable()
		{
			base.CharacterActor.OnTeleport += OnTeleport;
		}

		private void OnDisable()
		{
			base.CharacterActor.OnTeleport -= OnTeleport;
		}

		private void Update()
		{
			if (base.CharacterActor == null)
			{
				base.enabled = false;
				return;
			}
			float deltaTime = Time.deltaTime;
			HandleVerticalDisplacement(deltaTime);
			if (teleportFlag)
			{
				teleportFlag = false;
			}
		}

		private void OnTeleport(Vector3 position, Quaternion rotation)
		{
			teleportFlag = true;
		}

		private void HandleVerticalDisplacement(float dt)
		{
			if (teleportFlag)
			{
				previousPosition = base.transform.position;
				base.transform.position = base.CharacterActor.Position;
				return;
			}
			Vector3 vector = Vector3.ProjectOnPlane(base.CharacterActor.transform.position - previousPosition, base.CharacterActor.Up);
			Vector3 vector2 = Vector3.Project(base.CharacterActor.transform.position - previousPosition, base.CharacterActor.Up);
			if (Mathf.Abs(base.CharacterActor.transform.InverseTransformVectorUnscaled(base.CharacterActor.GroundProbingDisplacement).y) < 0.01f)
			{
				recoveryTimer += dt;
			}
			else
			{
				recoveryTimer = 0f;
			}
			float num = ((base.CharacterActor.transform.InverseTransformVectorUnscaled(vector2).y >= 0f) ? positiveDisplacementSpeed : negativeDisplacementSpeed);
			float num2 = Mathf.Min(num + (maxRecoverySpeed - num) / recoveryDuration * recoveryTimer, maxRecoverySpeed);
			base.transform.position = previousPosition + vector + Vector3.Lerp(Vector3.zero, vector2, num2 * dt);
			previousPosition = base.transform.position;
		}
	}
}
