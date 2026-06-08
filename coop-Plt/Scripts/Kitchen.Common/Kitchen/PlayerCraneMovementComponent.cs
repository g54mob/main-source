using Controllers;
using Platforms;
using UnityEngine;

namespace Kitchen
{
	public class PlayerCraneMovementComponent : PlayerMovementComponent
	{
		[SerializeField]
		[Header("Configuration")]
		private float MovementDeadzone = 0.5f;

		[SerializeField]
		private float TopForceFactor = 2f;

		[SerializeField]
		private float MouseMaxSecondsToGoalForce = 0.2f;

		[Header("References")]
		[SerializeField]
		private Rigidbody Rigidbody;

		[SerializeField]
		private Rigidbody TopRigidbody;

		[Header("State")]
		private bool IsPaused;

		private bool IsMyPlayer;

		private Vector3 MovementVector;

		private bool UseMouseTarget;

		private Vector2 RecentMousePosition;

		private Vector3 MouseTargetVector;

		private Camera MainCamera;

		private void Awake()
		{
			if (InputSourceIdentifier.DefaultInputSource != null)
			{
				RecentMousePosition = InputSourceIdentifier.DefaultInputSource.GetMousePosition();
			}
			MainCamera = Camera.main;
		}

		public override void UpdateData(bool is_paused)
		{
			IsPaused = is_paused;
		}

		public override Vector3 GetCurrentPosition()
		{
			if (UseMouseTarget)
			{
				return MouseTargetVector;
			}
			return base.GetCurrentPosition();
		}

		private bool IsIssuingMouseTarget(int player_id)
		{
			if (!MainCamera)
			{
				return false;
			}
			Preferences.TryGet<bool>(Pref.SpeedrunMode, out var value);
			if (value)
			{
				return false;
			}
			if ((InputSourceIdentifier.DefaultInputSource.GetCurrentController(player_id) & ControllerType.Keyboard) == 0)
			{
				return false;
			}
			Vector2 mousePosition = InputSourceIdentifier.DefaultInputSource.GetMousePosition();
			if ((mousePosition - RecentMousePosition).sqrMagnitude < 10f)
			{
				return false;
			}
			RecentMousePosition = mousePosition;
			Vector3 vector = MainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 1f));
			Ray ray = new Ray(MainCamera.transform.position, vector - MainCamera.transform.position);
			if (!new Plane(new Vector3(0f, 1f, 0f), Vector3.zero).Raycast(ray, out var enter) || enter <= 0f)
			{
				return false;
			}
			Vector3 vector2 = ray.GetPoint(enter);
			if (!GameInfo.GetCurrentPlayableBounds().Contains(vector2))
			{
				vector2 = GameInfo.RestrictToPlayableBounds(vector2);
			}
			MouseTargetVector = vector2;
			return true;
		}

		public override void UpdateMovement(bool is_my_player, int player_id, CInputData inputs, float speed_factor, float base_speed)
		{
			if (IsPaused)
			{
				return;
			}
			var (vector, vector2) = PlayerMovementComponent.GetCameraVectors();
			RootTransform.rotation = default(Quaternion);
			bool flag = false;
			if (is_my_player && InputSourceIdentifier.DefaultInputSource != null && InputSourceIdentifier.DefaultInputSource.GetCurrentInputData(player_id, out var input_state) && !inputs.IsCaptured)
			{
				if (IsIssuingMouseTarget(player_id))
				{
					UseMouseTarget = true;
				}
				else if (!UseMouseTarget || input_state.Movement.magnitude > MovementDeadzone)
				{
					UseMouseTarget = false;
					MovementVector = vector * input_state.Movement.y + vector2 * input_state.Movement.x;
					flag = input_state.StopMoving == ButtonState.Held || input_state.StopMoving == ButtonState.Pressed;
				}
				if (UseMouseTarget)
				{
					Vector3 vector3 = MouseTargetVector - Rigidbody.position;
					MovementVector = vector3.normalized;
					flag = vector3.sqrMagnitude < 0.01f;
				}
			}
			else
			{
				MovementVector = vector * inputs.State.Movement.y + vector2 * inputs.State.Movement.x;
				flag = inputs.State.StopMoving == ButtonState.Held || inputs.State.StopMoving == ButtonState.Pressed;
			}
			IsMoving = false;
			if (MovementVector != Vector3.zero && MovementVector.magnitude > MovementDeadzone && !flag)
			{
				IsMoving = true;
				float num = base_speed;
				if (UseMouseTarget)
				{
					num *= 8f;
					float magnitude = (MouseTargetVector - Rigidbody.position).magnitude;
					num = Mathf.Clamp(num, 0f, MouseMaxSecondsToGoalForce * 1000f * magnitude / Time.deltaTime);
				}
				Vector3 vector4 = MovementVector * (num * Time.deltaTime);
				vector4.y = 0f;
				Rigidbody.AddForce(vector4);
				TopRigidbody.AddForce(vector4 * TopForceFactor);
			}
			Bounds currentPlayableBounds = GameInfo.GetCurrentPlayableBounds(expand_slightly: true, contract_slightly: true);
			if (!currentPlayableBounds.Contains(Rigidbody.position))
			{
				Rigidbody.MovePosition(currentPlayableBounds.ClosestPoint(Rigidbody.position));
			}
		}
	}
}
