using UnityEngine;
using UnityEngine.Serialization;

namespace Kitchen
{
	public abstract class PlayerMovementComponent : MonoBehaviour
	{
		[Header("References")]
		[FormerlySerializedAs("RotationTransform")]
		[SerializeField]
		protected Transform RootTransform;

		[Header("State")]
		public bool IsMoving;

		public virtual void UpdateData(bool is_paused)
		{
		}

		public virtual void UpdateMovement(bool is_my_player, int player_id, CInputData inputs, float speed_factor, float base_speed)
		{
		}

		public virtual Vector3 GetCurrentPosition()
		{
			return RootTransform.position;
		}

		protected static (Vector3 camera_up, Vector3 camera_right) GetCameraVectors()
		{
			Camera main = Camera.main;
			bool num = main != null;
			Vector3 normalized = Vector3.ProjectOnPlane(num ? main.transform.forward : Vector3.forward, Vector3.up).normalized;
			Vector3 normalized2 = Vector3.ProjectOnPlane(num ? main.transform.right : Vector3.right, Vector3.up).normalized;
			return (camera_up: normalized, camera_right: normalized2);
		}
	}
}
