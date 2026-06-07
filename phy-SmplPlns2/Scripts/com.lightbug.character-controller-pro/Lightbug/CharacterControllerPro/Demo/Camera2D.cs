using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	[AddComponentMenu("Character Controller Pro/Demo/Camera/Camera 2D")]
	public class Camera2D : MonoBehaviour
	{
		[Header("Target")]
		[SerializeField]
		private Transform target;

		[Header("Camera size")]
		[SerializeField]
		private Vector2 cameraAABBSize = new Vector2(3f, 4f);

		[SerializeField]
		private Vector2 targetAABBSize = new Vector2(1f, 1f);

		[Header("Position")]
		[SerializeField]
		private CameraTargetMode targetMode;

		[SerializeField]
		private Vector3 offset = new Vector3(0f, 0f, -10f);

		[SerializeField]
		private float smoothTargetTime = 0.25f;

		[Header("Rotation")]
		[SerializeField]
		private bool followRotation = true;

		[Min(0.1f)]
		[SerializeField]
		private float rotationSlerpSpeed = 5f;

		[Header("Look ahead")]
		[Condition("targetMode", ConditionAttribute.ConditionType.IsEqualTo, ConditionAttribute.VisibilityType.Hidden, 0f)]
		[SerializeField]
		private float lookAheadSpeed = 4f;

		[Condition("targetMode", ConditionAttribute.ConditionType.IsEqualTo, ConditionAttribute.VisibilityType.Hidden, 0f)]
		[SerializeField]
		private float xLookAheadAmount = 1f;

		[Condition("targetMode", ConditionAttribute.ConditionType.IsEqualTo, ConditionAttribute.VisibilityType.Hidden, 0f)]
		[SerializeField]
		private float yLookAheadAmount = 1f;

		private float xCurrentLookAheadAmount;

		private float yCurrentLookAheadAmount;

		private Vector3 targetCameraPosition;

		private Vector3 smoothDampVelocity;

		private Bounds cameraAABB;

		private Bounds targetBounds;

		private void Start()
		{
			if (target == null)
			{
				Debug.Log("Missing camera target");
			}
			Vector3 position = target.position;
			position.z = base.transform.position.z;
			base.transform.position = position;
			targetBounds = new Bounds(target.position, new Vector3(targetAABBSize.x, targetAABBSize.y, 1f));
			targetBounds.center = target.position;
			cameraAABB = new Bounds(target.position, new Vector3(cameraAABBSize.x, cameraAABBSize.y, 1f));
			targetCameraPosition = new Vector3(cameraAABB.center.x, cameraAABB.center.y, base.transform.position.z);
		}

		private void OnDrawGizmos()
		{
			if (!(target == null) && targetMode == CameraTargetMode.Bounds)
			{
				Gizmos.color = new Color(0f, 0f, 1f, 0.2f);
				Bounds bounds = new Bounds(target.position, new Vector3(cameraAABBSize.x, cameraAABBSize.y, 1f));
				Gizmos.DrawCube(bounds.center, new Vector3(bounds.size.x, bounds.size.y, 1f));
			}
		}

		private void LateUpdate()
		{
			if (!(target == null))
			{
				float deltaTime = Time.deltaTime;
				UpdateTargetAABB();
				UpdateCameraAABB(deltaTime);
				if (followRotation)
				{
					UpdateRotation(deltaTime);
				}
				UpdatePosition(deltaTime);
			}
		}

		private void UpdateTargetAABB()
		{
			targetBounds.center = target.position;
		}

		private void UpdateCameraAABB(float dt)
		{
			float num = lookAheadSpeed * dt;
			if (targetBounds.max.x > cameraAABB.max.x)
			{
				float num2 = targetBounds.max.x - cameraAABB.max.x;
				cameraAABB.center += Vector3.right * num2;
				if (xCurrentLookAheadAmount < xLookAheadAmount)
				{
					xCurrentLookAheadAmount += num;
					xCurrentLookAheadAmount = Mathf.Clamp(xCurrentLookAheadAmount, 0f - xLookAheadAmount, xLookAheadAmount);
				}
			}
			else if (targetBounds.min.x < cameraAABB.min.x)
			{
				float num3 = cameraAABB.min.x - targetBounds.min.x;
				cameraAABB.center -= Vector3.right * num3;
				if (xCurrentLookAheadAmount > 0f - xLookAheadAmount)
				{
					xCurrentLookAheadAmount -= num;
					xCurrentLookAheadAmount = Mathf.Clamp(xCurrentLookAheadAmount, 0f - xLookAheadAmount, xLookAheadAmount);
				}
			}
			if (targetBounds.max.y > cameraAABB.max.y)
			{
				float num4 = targetBounds.max.y - cameraAABB.max.y;
				cameraAABB.center += Vector3.up * num4;
				if (yCurrentLookAheadAmount < yLookAheadAmount)
				{
					yCurrentLookAheadAmount += num;
					yCurrentLookAheadAmount = Mathf.Clamp(yCurrentLookAheadAmount, 0f - yLookAheadAmount, yLookAheadAmount);
				}
			}
			else if (targetBounds.min.y < cameraAABB.min.y)
			{
				float num5 = cameraAABB.min.y - targetBounds.min.y;
				cameraAABB.center -= Vector3.up * num5;
				if (yCurrentLookAheadAmount > 0f - yLookAheadAmount)
				{
					yCurrentLookAheadAmount -= num;
					yCurrentLookAheadAmount = Mathf.Clamp(yCurrentLookAheadAmount, 0f - yLookAheadAmount, yLookAheadAmount);
				}
			}
			targetCameraPosition.x = cameraAABB.center.x + xCurrentLookAheadAmount;
			targetCameraPosition.y = cameraAABB.center.y + yCurrentLookAheadAmount;
		}

		private void UpdatePosition(float dt)
		{
			Vector3 zero = Vector3.zero;
			zero = ((targetMode != CameraTargetMode.Bounds) ? Vector3.SmoothDamp(base.transform.position, target.position + base.transform.TransformVector(offset), ref smoothDampVelocity, smoothTargetTime) : Vector3.SmoothDamp(base.transform.position, targetCameraPosition + base.transform.TransformVector(offset), ref smoothDampVelocity, smoothTargetTime));
			base.transform.position = zero;
		}

		private void UpdateRotation(float dt)
		{
			Vector3 to = Vector3.ProjectOnPlane(target.up, Vector3.forward);
			Quaternion b = Quaternion.AngleAxis(Vector3.SignedAngle(base.transform.up, to, Vector3.forward), Vector3.forward);
			base.transform.rotation *= Quaternion.Slerp(Quaternion.identity, b, rotationSlerpSpeed * dt);
		}
	}
}
