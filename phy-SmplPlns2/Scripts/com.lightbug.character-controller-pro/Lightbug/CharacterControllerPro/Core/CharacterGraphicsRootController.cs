using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Core
{
	[AddComponentMenu("Character Controller Pro/Core/Character Graphics/Graphics Root Controller (obsolete)")]
	[DefaultExecutionOrder(20)]
	public class CharacterGraphicsRootController : CharacterGraphics
	{
		[HelpBox("This component is obsolete. It has been separated into two new components: Step Lerper and Rotation Lerper.", HelpBoxMessageType.Warning)]
		[Tooltip("Whether or not interpolate the rotation of the character.")]
		[SerializeField]
		private bool lerpRotation;

		[Condition("lerpRotation", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.NotEditable, 0f)]
		[SerializeField]
		private float rotationLerpSpeed = 25f;

		[Space(10f)]
		[Tooltip("Whether or not to interpolate the vertical displacement change of the character. A vertical displacement happens everytime the character increase/decrease its vertical position (slopes, step up, step down, etc.). This feature does not work with rigidbodies (if this is required use the new VerticalDisplacementLerper component instead).")]
		[SerializeField]
		private bool lerpVerticalDisplacement = true;

		[Tooltip("How fast the step up interpolation is going to be.")]
		[SerializeField]
		private float positiveDisplacementSpeed = 10f;

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

		private Quaternion previousRotation;

		private Vector3 initialLocalForward;

		private bool teleportFlag;

		private float recoveryTimer;

		protected override void OnValidate()
		{
			base.OnValidate();
			CustomUtilities.SetPositive(ref rotationLerpSpeed);
			CustomUtilities.SetPositive(ref positiveDisplacementSpeed);
			CustomUtilities.SetPositive(ref negativeDisplacementSpeed);
		}

		private void Start()
		{
			initialLocalForward = base.CharacterActor.transform.InverseTransformDirection(base.transform.forward);
			previousPosition = base.transform.position;
			previousRotation = base.transform.rotation;
		}

		private void OnEnable()
		{
			base.CharacterActor.OnTeleport += OnTeleport;
		}

		private void OnDisable()
		{
			base.CharacterActor.OnTeleport -= OnTeleport;
		}

		private void OnTeleport(Vector3 position, Quaternion rotation)
		{
			teleportFlag = true;
		}

		private void Update()
		{
			if (base.CharacterActor == null)
			{
				base.enabled = false;
				return;
			}
			float deltaTime = Time.deltaTime;
			HandleRotation(deltaTime);
			HandleVerticalDisplacement(deltaTime);
			if (teleportFlag)
			{
				teleportFlag = false;
			}
		}

		private void HandleVerticalDisplacement(float dt)
		{
			if (!lerpVerticalDisplacement)
			{
				return;
			}
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

		private void HandleRotation(float dt)
		{
			if (lerpRotation)
			{
				if (teleportFlag)
				{
					base.transform.localRotation = Quaternion.identity;
					previousRotation = base.transform.rotation;
				}
				else
				{
					base.transform.rotation = Quaternion.Slerp(previousRotation, base.CharacterActor.Rotation, rotationLerpSpeed * dt);
					previousRotation = base.transform.rotation;
				}
			}
		}
	}
}
