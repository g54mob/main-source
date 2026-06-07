using System.Collections;
using UnityEngine;

namespace VRTK.GrabAttachMechanics
{
	[AddComponentMenu("VRTK/Scripts/Interactions/Interactables/Grab Attach Mechanics/VRTK_RotateTransformGrabAttach")]
	public class VRTK_RotateTransformGrabAttach : VRTK_BaseGrabAttach
	{
		public enum RotationAxis
		{
			xAxis = 0,
			yAxis = 1,
			zAxis = 2
		}

		public enum RotationType
		{
			FollowAttachPoint = 0,
			FollowLongitudinalAxis = 1,
			FollowLateralAxis = 2,
			FollowPerpendicularAxis = 3
		}

		[Header("Detach Settings")]
		[Tooltip("The maximum distance the grabbing object is away from the Interactable Object before it is automatically dropped.")]
		public float detachDistance = 1f;

		[Tooltip("The distance between grabbing object and the centre of Interactable Object that is considered to be non grabbable. If the grabbing object is within the `Origin Deadzone` distance then it will be automatically ungrabbed.")]
		public float originDeadzone;

		[Header("Rotation Settings")]
		[Tooltip("The local axis in which to rotate the object around.")]
		public RotationAxis rotateAround;

		[Tooltip("Determines how the rotation of the object is calculated based on the action of the grabbing object.")]
		public RotationType rotationAction;

		[Tooltip("The amount of friction to apply when rotating, simulates a tougher rotation.")]
		[Range(1f, 32f)]
		public float rotationFriction = 1f;

		[Tooltip("The damper in which to slow the Interactable Object's rotation down when released to simulate continued momentum. The higher the number, the faster the Interactable Object will come to a complete stop on release.")]
		public float releaseDecelerationDamper = 1f;

		[Tooltip("The speed in which the Interactable Object returns to it's origin rotation when released. If the `Reset To Orign On Release Speed` is `0f` then the rotation will not be reset.")]
		public float resetToOrignOnReleaseSpeed;

		[Header("Rotation Limits")]
		[Tooltip("The negative and positive limits the axis can be rotated to.")]
		public Limits2D angleLimits = new Limits2D(-180f, 180f);

		[Tooltip("The threshold the rotation value needs to be within to register a min or max rotation value.")]
		public float minMaxThreshold = 1f;

		[Tooltip("The threshold the normalized rotation value needs to be within to register a min or max normalized rotation value.")]
		[Range(0f, 0.99f)]
		public float minMaxNormalizedThreshold = 0.01f;

		[HideInInspector]
		public Quaternion originRotation;

		protected Vector3 previousAttachPointPosition;

		protected Vector3 currentRotation;

		protected Bounds grabbedObjectBounds;

		protected Vector3 currentRotationSpeed;

		protected Coroutine updateRotationRoutine;

		protected Coroutine decelerateRotationRoutine;

		protected bool[] limitsReached = new bool[2];

		protected VRTK_ControllerReference grabbingObjectReference;

		public event RotateTransformGrabAttachEventHandler AngleChanged;

		public event RotateTransformGrabAttachEventHandler MinAngleReached;

		public event RotateTransformGrabAttachEventHandler MinAngleExited;

		public event RotateTransformGrabAttachEventHandler MaxAngleReached;

		public event RotateTransformGrabAttachEventHandler MaxAngleExited;

		public virtual void OnAngleChanged(RotateTransformGrabAttachEventArgs e)
		{
			if (this.AngleChanged != null)
			{
				this.AngleChanged(this, e);
			}
		}

		public virtual void OnMinAngleReached(RotateTransformGrabAttachEventArgs e)
		{
			if (this.MinAngleReached != null)
			{
				this.MinAngleReached(this, e);
			}
		}

		public virtual void OnMinAngleExited(RotateTransformGrabAttachEventArgs e)
		{
			if (this.MinAngleExited != null)
			{
				this.MinAngleExited(this, e);
			}
		}

		public virtual void OnMaxAngleReached(RotateTransformGrabAttachEventArgs e)
		{
			if (this.MaxAngleReached != null)
			{
				this.MaxAngleReached(this, e);
			}
		}

		public virtual void OnMaxAngleExited(RotateTransformGrabAttachEventArgs e)
		{
			if (this.MaxAngleExited != null)
			{
				this.MaxAngleExited(this, e);
			}
		}

		public override bool StartGrab(GameObject grabbingObject, GameObject givenGrabbedObject, Rigidbody givenControllerAttachPoint)
		{
			CancelUpdateRotation();
			CancelDecelerateRotation();
			bool result = base.StartGrab(grabbingObject, givenGrabbedObject, givenControllerAttachPoint);
			previousAttachPointPosition = controllerAttachPoint.transform.position;
			grabbedObjectBounds = VRTK_SharedMethods.GetBounds(givenGrabbedObject.transform);
			limitsReached = new bool[2];
			CheckAngleLimits();
			grabbingObjectReference = VRTK_ControllerReference.GetControllerReference(grabbingObject);
			return result;
		}

		public override void StopGrab(bool applyGrabbingObjectVelocity)
		{
			base.StopGrab(applyGrabbingObjectVelocity);
			if (resetToOrignOnReleaseSpeed > 0f)
			{
				ResetRotation();
			}
			else if (releaseDecelerationDamper > 0f)
			{
				CancelDecelerateRotation();
				decelerateRotationRoutine = StartCoroutine(DecelerateRotation());
			}
		}

		public override void ProcessUpdate()
		{
			if (trackPoint != null)
			{
				float num = Vector3.Distance(base.transform.position, controllerAttachPoint.transform.position);
				if (StillTouching() && num >= originDeadzone)
				{
					Vector3 newRotation = GetNewRotation();
					previousAttachPointPosition = controllerAttachPoint.transform.position;
					currentRotationSpeed = newRotation;
					UpdateRotation(newRotation, additive: true, updateCurrentRotation: true);
				}
				else if (grabbedObjectScript.IsDroppable())
				{
					ForceReleaseGrab();
				}
			}
		}

		public virtual void SetRotation(float newAngle, float transitionTime = 0f)
		{
			newAngle = Mathf.Clamp(newAngle, angleLimits.minimum, angleLimits.maximum);
			Vector3 vector = currentRotation;
			switch (rotateAround)
			{
			case RotationAxis.xAxis:
				vector = new Vector3(newAngle, currentRotation.y, currentRotation.z);
				break;
			case RotationAxis.yAxis:
				vector = new Vector3(currentRotation.x, newAngle, currentRotation.z);
				break;
			case RotationAxis.zAxis:
				vector = new Vector3(currentRotation.x, currentRotation.y, newAngle);
				break;
			}
			if (transitionTime > 0f)
			{
				CancelUpdateRotation();
				updateRotationRoutine = StartCoroutine(RotateToAngle(vector, VRTK_SharedMethods.DividerToMultiplier(transitionTime)));
			}
			else
			{
				UpdateRotation(vector, additive: false, updateCurrentRotation: false);
				currentRotation = vector;
			}
		}

		public virtual void ResetRotation(bool ignoreTransition = false)
		{
			CancelDecelerateRotation();
			if (resetToOrignOnReleaseSpeed > 0f && !ignoreTransition)
			{
				CancelUpdateRotation();
				updateRotationRoutine = StartCoroutine(RotateToAngle(Vector3.zero, resetToOrignOnReleaseSpeed));
			}
			else
			{
				UpdateRotation(originRotation.eulerAngles, additive: false, updateCurrentRotation: false);
				currentRotation = Vector3.zero;
				currentRotationSpeed = Vector3.zero;
			}
		}

		public virtual float GetAngle()
		{
			switch (rotateAround)
			{
			case RotationAxis.xAxis:
				return currentRotation.x;
			case RotationAxis.yAxis:
				return currentRotation.y;
			case RotationAxis.zAxis:
				return currentRotation.z;
			default:
				return -0f;
			}
		}

		public virtual float GetNormalizedAngle()
		{
			if (!(angleLimits.minimum > float.MinValue) || !(angleLimits.maximum < float.MaxValue))
			{
				return 0f;
			}
			return VRTK_SharedMethods.NormalizeValue(GetAngle(), angleLimits.minimum, angleLimits.maximum, minMaxNormalizedThreshold);
		}

		public virtual Vector3 GetRotationSpeed()
		{
			return currentRotationSpeed;
		}

		protected virtual void OnDisable()
		{
			CancelUpdateRotation();
			CancelDecelerateRotation();
		}

		protected override void Initialise()
		{
			tracked = false;
			climbable = false;
			kinematic = true;
			precisionGrab = true;
			originRotation = base.transform.localRotation;
			currentRotation = Vector3.zero;
		}

		protected virtual Vector3 GetNewRotation()
		{
			Vector3 vector = Vector3.zero;
			if (VRTK_ControllerReference.IsValid(grabbingObjectReference))
			{
				vector = VRTK_DeviceFinder.GetControllerAngularVelocity(grabbingObjectReference) * VRTK_SharedMethods.DividerToMultiplier(rotationFriction);
			}
			switch (rotationAction)
			{
			case RotationType.FollowAttachPoint:
				return CalculateAngle(base.transform.position, previousAttachPointPosition, controllerAttachPoint.transform.position);
			case RotationType.FollowLongitudinalAxis:
				return BuildFollowAxisVector(vector.x);
			case RotationType.FollowPerpendicularAxis:
				return BuildFollowAxisVector(vector.y);
			case RotationType.FollowLateralAxis:
				return BuildFollowAxisVector(vector.z);
			default:
				return Vector3.zero;
			}
		}

		protected virtual Vector3 BuildFollowAxisVector(float givenAngle)
		{
			float x = ((rotateAround == RotationAxis.xAxis) ? givenAngle : 0f);
			float y = ((rotateAround == RotationAxis.yAxis) ? givenAngle : 0f);
			float z = ((rotateAround == RotationAxis.zAxis) ? givenAngle : 0f);
			return new Vector3(x, y, z);
		}

		protected virtual Vector3 CalculateAngle(Vector3 originPoint, Vector3 originalGrabPoint, Vector3 currentGrabPoint)
		{
			float num = ((rotateAround == RotationAxis.xAxis) ? CalculateAngle(originPoint, originalGrabPoint, currentGrabPoint, base.transform.right) : 0f);
			float num2 = ((rotateAround == RotationAxis.yAxis) ? CalculateAngle(originPoint, originalGrabPoint, currentGrabPoint, base.transform.up) : 0f);
			float num3 = ((rotateAround == RotationAxis.zAxis) ? CalculateAngle(originPoint, originalGrabPoint, currentGrabPoint, base.transform.forward) : 0f);
			float num4 = VRTK_SharedMethods.DividerToMultiplier(rotationFriction);
			return new Vector3(num * num4, num2 * num4, num3 * num4);
		}

		protected virtual float CalculateAngle(Vector3 originPoint, Vector3 previousPoint, Vector3 currentPoint, Vector3 direction)
		{
			Vector3 v = previousPoint - originPoint;
			Vector3 v2 = VRTK_SharedMethods.VectorDirection(originPoint, currentPoint);
			return AngleSigned(v, v2, direction);
		}

		protected virtual void UpdateRotation(Vector3 newRotation, bool additive, bool updateCurrentRotation)
		{
			if (WithinRotationLimit(currentRotation + newRotation))
			{
				if (updateCurrentRotation)
				{
					currentRotation += newRotation;
				}
				base.transform.localRotation = (additive ? (base.transform.localRotation * Quaternion.Euler(newRotation)) : Quaternion.Euler(newRotation));
				EmitEvents();
			}
		}

		protected virtual bool WithinRotationLimit(Vector3 rotationCheck)
		{
			switch (rotateAround)
			{
			case RotationAxis.xAxis:
				return angleLimits.WithinLimits(rotationCheck.x);
			case RotationAxis.yAxis:
				return angleLimits.WithinLimits(rotationCheck.y);
			case RotationAxis.zAxis:
				return angleLimits.WithinLimits(rotationCheck.z);
			default:
				return false;
			}
		}

		protected virtual float AngleSigned(Vector3 v1, Vector3 v2, Vector3 n)
		{
			return Mathf.Atan2(Vector3.Dot(n, Vector3.Cross(v1, v2)), Vector3.Dot(v1, v2)) * 57.29578f;
		}

		protected virtual bool StillTouching()
		{
			float num = Vector3.Distance(controllerAttachPoint.transform.position, initialAttachPoint.position);
			if (!grabbedObjectBounds.Contains(controllerAttachPoint.transform.position))
			{
				return num <= detachDistance;
			}
			return true;
		}

		protected virtual void CancelUpdateRotation()
		{
			if (updateRotationRoutine != null)
			{
				StopCoroutine(updateRotationRoutine);
			}
		}

		protected virtual void CancelDecelerateRotation()
		{
			if (decelerateRotationRoutine != null)
			{
				StopCoroutine(decelerateRotationRoutine);
			}
		}

		protected virtual IEnumerator RotateToAngle(Vector3 targetAngle, float rotationSpeed)
		{
			Vector3 previousRotation = currentRotation;
			currentRotationSpeed = Vector3.zero;
			while (currentRotation != targetAngle)
			{
				currentRotation = Vector3.Lerp(currentRotation, targetAngle, rotationSpeed * Time.deltaTime);
				UpdateRotation(currentRotation - previousRotation, additive: true, updateCurrentRotation: false);
				previousRotation = currentRotation;
				yield return null;
			}
			UpdateRotation(targetAngle, additive: false, updateCurrentRotation: false);
			currentRotation = targetAngle;
		}

		protected virtual IEnumerator DecelerateRotation()
		{
			while (currentRotationSpeed != Vector3.zero)
			{
				currentRotationSpeed = Vector3.Slerp(currentRotationSpeed, Vector3.zero, releaseDecelerationDamper * Time.deltaTime);
				UpdateRotation(currentRotationSpeed, additive: true, updateCurrentRotation: true);
				yield return null;
			}
		}

		protected virtual float GetLimitedAngle(float angle)
		{
			if (!(angle > 180f))
			{
				return angle;
			}
			return angle - 360f;
		}

		protected virtual void CheckAngleLimits()
		{
			angleLimits.minimum = ((angleLimits.minimum > 0f) ? (angleLimits.minimum * -1f) : angleLimits.minimum);
			angleLimits.maximum = ((angleLimits.maximum < 0f) ? (angleLimits.maximum * -1f) : angleLimits.maximum);
		}

		protected virtual void EmitEvents()
		{
			OnAngleChanged(SetEventPayload());
			float angle = GetAngle();
			float num = angleLimits.minimum + minMaxThreshold;
			float num2 = angleLimits.maximum - minMaxThreshold;
			if (angle <= num && !limitsReached[0])
			{
				limitsReached[0] = true;
				OnMinAngleReached(SetEventPayload());
			}
			else if (angle >= num2 && !limitsReached[1])
			{
				limitsReached[1] = true;
				OnMaxAngleReached(SetEventPayload());
			}
			else if (angle > num && angle < num2)
			{
				if (limitsReached[0])
				{
					OnMinAngleExited(SetEventPayload());
				}
				if (limitsReached[1])
				{
					OnMaxAngleExited(SetEventPayload());
				}
				limitsReached[0] = false;
				limitsReached[1] = false;
			}
		}

		protected virtual RotateTransformGrabAttachEventArgs SetEventPayload()
		{
			RotateTransformGrabAttachEventArgs result = default(RotateTransformGrabAttachEventArgs);
			result.interactingObject = ((grabbedObjectScript != null) ? grabbedObjectScript.GetGrabbingObject() : null);
			result.currentAngle = GetAngle();
			result.normalizedAngle = GetNormalizedAngle();
			result.rotationSpeed = currentRotationSpeed;
			return result;
		}
	}
}
