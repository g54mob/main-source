using Controllers;
using UnityEngine;

namespace Kitchen
{
	public class PlayerWalkingComponent : PlayerMovementComponent
	{
		[Header("Configuration")]
		[SerializeField]
		private float RotationSpeed = 1080f;

		[SerializeField]
		private float MovementDeadzone = 0.5f;

		[SerializeField]
		private float MaximumFacingSpread = 60f;

		[Header("References")]
		[SerializeField]
		private Rigidbody Rigidbody;

		[SerializeField]
		private Animator Animator;

		[Header("State")]
		private bool IsMyPlayer;

		private Vector3 MovementVector;

		private static readonly int AnimHashMovementSpeed = Animator.StringToHash("MovementSpeed");

		public override void UpdateMovement(bool is_my_player, int player_id, CInputData inputs, float speed_factor, float base_speed)
		{
			if (Mathf.Abs(RootTransform.position.y) > 0.001f)
			{
				Transform rootTransform = RootTransform;
				Vector3 position = rootTransform.position;
				position.y = 0f;
				rootTransform.position = position;
			}
			(Vector3 camera_up, Vector3 camera_right) cameraVectors = PlayerMovementComponent.GetCameraVectors();
			Vector3 item = cameraVectors.camera_up;
			Vector3 item2 = cameraVectors.camera_right;
			bool flag = false;
			if (is_my_player && InputSourceIdentifier.DefaultInputSource != null && InputSourceIdentifier.DefaultInputSource.GetCurrentInputData(player_id, out var input_state) && !inputs.IsCaptured)
			{
				MovementVector = item * input_state.Movement.y + item2 * input_state.Movement.x;
				flag = input_state.StopMoving == ButtonState.Held || input_state.StopMoving == ButtonState.Pressed;
			}
			else
			{
				MovementVector = item * inputs.State.Movement.y + item2 * inputs.State.Movement.x;
				flag = inputs.State.StopMoving == ButtonState.Held || inputs.State.StopMoving == ButtonState.Pressed;
			}
			IsMoving = false;
			if (MovementVector != Vector3.zero)
			{
				Quaternion to = Quaternion.LookRotation(MovementVector, Vector3.up);
				RootTransform.rotation = Quaternion.RotateTowards(RootTransform.rotation, to, RotationSpeed * speed_factor * Time.deltaTime);
				if (MovementVector.magnitude > MovementDeadzone && !flag && Vector3.Angle(RootTransform.forward, MovementVector) < MaximumFacingSpread)
				{
					IsMoving = true;
					float num = base_speed * speed_factor;
					Vector3 force = RootTransform.forward * (num * Time.deltaTime);
					force.y = 0f;
					Rigidbody.AddForce(force);
				}
			}
			Animator.SetFloat(AnimHashMovementSpeed, IsMoving ? 1 : 0);
		}

		public override void UpdateData(bool is_paused)
		{
			Rigidbody.isKinematic = is_paused;
		}
	}
}
