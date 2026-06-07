using System.Collections;
using UnityEngine;

namespace VRTK.GrabAttachMechanics
{
	[AddComponentMenu("VRTK/Scripts/Interactions/Interactables/Grab Attach Mechanics/VRTK_MoveTransformGrabAttach")]
	public class VRTK_MoveTransformGrabAttach : VRTK_BaseGrabAttach
	{
		[Tooltip("The maximum distance the grabbing object is away from the Interactable Object before it is automatically released.")]
		public float detachDistance = 1f;

		[Header("Movement Settings")]
		[Tooltip("The speed in which to track the grabbed Interactable Object to the interacting object.")]
		public float trackingSpeed = 10f;

		[Tooltip("If this is checked then it will force the rigidbody on the Interactable Object to be `Kinematic` when the grab occurs.")]
		public bool forceKinematicOnGrab = true;

		[Tooltip("The damper in which to slow the Interactable Object down when released to simulate continued momentum. The higher the number, the faster the Interactable Object will come to a complete stop on release.")]
		public float releaseDecelerationDamper = 5f;

		[Tooltip("The speed in which the Interactable Object returns to it's origin position when released. If the `Reset To Orign On Release Speed` is `0f` then the position will not be reset.")]
		public float resetToOrignOnReleaseSpeed;

		[Header("Position Limit Settings")]
		[Tooltip("The minimum and maximum limits the Interactable Object can be moved along the x axis.")]
		public Limits2D xAxisLimits = Limits2D.zero;

		[Tooltip("The minimum and maximum limits the Interactable Object can be moved along the y axis.")]
		public Limits2D yAxisLimits = Limits2D.zero;

		[Tooltip("The minimum and maximum limits the Interactable Object can be moved along the z axis.")]
		public Limits2D zAxisLimits = Limits2D.zero;

		[Tooltip("The threshold the position value needs to be within to register a min or max position value.")]
		public float minMaxThreshold = 0.01f;

		[Tooltip("The threshold the normalized position value needs to be within to register a min or max normalized position value.")]
		[Range(0f, 0.99f)]
		public float minMaxNormalizedThreshold = 0.01f;

		[HideInInspector]
		public Vector3 localOrigin;

		protected bool previousKinematicState;

		protected bool[] limitsReached = new bool[6];

		protected Limits2D xOriginLimits;

		protected Limits2D yOriginLimits;

		protected Limits2D zOriginLimits;

		protected Vector3 previousPosition;

		protected Vector3 movementVelocity;

		protected Coroutine resetPositionRoutine;

		protected Coroutine deceleratePositionRoutine;

		public event MoveTransformGrabAttachEventHandler TransformPositionChanged;

		public event MoveTransformGrabAttachEventHandler XAxisMinLimitReached;

		public event MoveTransformGrabAttachEventHandler XAxisMinLimitExited;

		public event MoveTransformGrabAttachEventHandler XAxisMaxLimitReached;

		public event MoveTransformGrabAttachEventHandler XAxisMaxLimitExited;

		public event MoveTransformGrabAttachEventHandler YAxisMinLimitReached;

		public event MoveTransformGrabAttachEventHandler YAxisMinLimitExited;

		public event MoveTransformGrabAttachEventHandler YAxisMaxLimitReached;

		public event MoveTransformGrabAttachEventHandler YAxisMaxLimitExited;

		public event MoveTransformGrabAttachEventHandler ZAxisMinLimitReached;

		public event MoveTransformGrabAttachEventHandler ZAxisMinLimitExited;

		public event MoveTransformGrabAttachEventHandler ZAxisMaxLimitReached;

		public event MoveTransformGrabAttachEventHandler ZAxisMaxLimitExited;

		public virtual void OnTransformPositionChanged(MoveTransformGrabAttachEventArgs e)
		{
			if (this.TransformPositionChanged != null)
			{
				this.TransformPositionChanged(this, e);
			}
		}

		public virtual void OnXAxisMinLimitReached(MoveTransformGrabAttachEventArgs e)
		{
			if (this.XAxisMinLimitReached != null)
			{
				this.XAxisMinLimitReached(this, e);
			}
		}

		public virtual void OnXAxisMinLimitExited(MoveTransformGrabAttachEventArgs e)
		{
			if (this.XAxisMinLimitExited != null)
			{
				this.XAxisMinLimitExited(this, e);
			}
		}

		public virtual void OnXAxisMaxLimitReached(MoveTransformGrabAttachEventArgs e)
		{
			if (this.XAxisMaxLimitReached != null)
			{
				this.XAxisMaxLimitReached(this, e);
			}
		}

		public virtual void OnXAxisMaxLimitExited(MoveTransformGrabAttachEventArgs e)
		{
			if (this.XAxisMaxLimitExited != null)
			{
				this.XAxisMaxLimitExited(this, e);
			}
		}

		public virtual void OnYAxisMinLimitReached(MoveTransformGrabAttachEventArgs e)
		{
			if (this.YAxisMinLimitReached != null)
			{
				this.YAxisMinLimitReached(this, e);
			}
		}

		public virtual void OnYAxisMinLimitExited(MoveTransformGrabAttachEventArgs e)
		{
			if (this.YAxisMinLimitExited != null)
			{
				this.YAxisMinLimitExited(this, e);
			}
		}

		public virtual void OnYAxisMaxLimitReached(MoveTransformGrabAttachEventArgs e)
		{
			if (this.YAxisMaxLimitReached != null)
			{
				this.YAxisMaxLimitReached(this, e);
			}
		}

		public virtual void OnYAxisMaxLimitExited(MoveTransformGrabAttachEventArgs e)
		{
			if (this.YAxisMaxLimitExited != null)
			{
				this.YAxisMaxLimitExited(this, e);
			}
		}

		public virtual void OnZAxisMinLimitReached(MoveTransformGrabAttachEventArgs e)
		{
			if (this.ZAxisMinLimitReached != null)
			{
				this.ZAxisMinLimitReached(this, e);
			}
		}

		public virtual void OnZAxisMinLimitExited(MoveTransformGrabAttachEventArgs e)
		{
			if (this.ZAxisMinLimitExited != null)
			{
				this.ZAxisMinLimitExited(this, e);
			}
		}

		public virtual void OnZAxisMaxLimitReached(MoveTransformGrabAttachEventArgs e)
		{
			if (this.ZAxisMaxLimitReached != null)
			{
				this.ZAxisMaxLimitReached(this, e);
			}
		}

		public virtual void OnZAxisMaxLimitExited(MoveTransformGrabAttachEventArgs e)
		{
			if (this.ZAxisMaxLimitExited != null)
			{
				this.ZAxisMaxLimitExited(this, e);
			}
		}

		public override bool StartGrab(GameObject grabbingObject, GameObject givenGrabbedObject, Rigidbody givenControllerAttachPoint)
		{
			CancelResetPosition();
			CancelDeceleratePosition();
			bool result = base.StartGrab(grabbingObject, givenGrabbedObject, givenControllerAttachPoint);
			if (grabbedObjectRigidBody != null)
			{
				previousKinematicState = grabbedObjectRigidBody.isKinematic;
				grabbedObjectRigidBody.isKinematic = forceKinematicOnGrab || previousKinematicState;
			}
			limitsReached = new bool[6];
			return result;
		}

		public override void StopGrab(bool applyGrabbingObjectVelocity)
		{
			base.StopGrab(applyGrabbingObjectVelocity);
			if (grabbedObjectRigidBody != null)
			{
				grabbedObjectRigidBody.isKinematic = previousKinematicState;
			}
			if (resetToOrignOnReleaseSpeed > 0f)
			{
				ResetPosition();
			}
			else if (releaseDecelerationDamper > 0f)
			{
				CancelDeceleratePosition();
				deceleratePositionRoutine = StartCoroutine(DeceleratePosition());
			}
		}

		public override Transform CreateTrackPoint(Transform controllerPoint, GameObject currentGrabbedObject, GameObject currentGrabbingObject, ref bool customTrackPoint)
		{
			Transform transform = null;
			transform = base.CreateTrackPoint(controllerPoint, currentGrabbedObject, currentGrabbingObject, ref customTrackPoint);
			if (!precisionGrab)
			{
				transform.position = currentGrabbedObject.transform.position;
			}
			transform.rotation = Quaternion.identity;
			transform.localScale = Vector3.one;
			return transform;
		}

		public override void ProcessUpdate()
		{
			if (trackPoint != null)
			{
				if (Vector3.Distance(trackPoint.position, initialAttachPoint.position) > detachDistance && grabbedObjectScript.IsDroppable())
				{
					ForceReleaseGrab();
					return;
				}
				Vector3 localPosition = base.transform.localPosition;
				Vector3 b = localPosition + Vector3.Scale(base.transform.InverseTransformPoint(controllerAttachPoint.transform.position) - base.transform.InverseTransformPoint(grabbedObjectScript.GetPrimaryAttachPoint().position), base.transform.localScale);
				Vector3 newPosition = Vector3.Lerp(localPosition, b, trackingSpeed * Time.deltaTime);
				previousPosition = base.transform.localPosition;
				UpdatePosition(newPosition, additive: false);
				movementVelocity = base.transform.localPosition - previousPosition;
			}
		}

		public virtual Vector3 GetPosition()
		{
			return VRTK_SharedMethods.VectorHeading(localOrigin, base.transform.localPosition);
		}

		public virtual Vector3 GetNormalizedPosition()
		{
			return NormalizePosition(GetPosition());
		}

		public virtual Vector3 GetCurrentDirection()
		{
			return VRTK_SharedMethods.VectorDirection(previousPosition, base.transform.localPosition);
		}

		public virtual Vector3 GetDirectionFromOrigin()
		{
			return VRTK_SharedMethods.VectorDirection(localOrigin, base.transform.localPosition);
		}

		public virtual void SetCurrentPosition(Vector3 newPosition, float speed)
		{
			if (speed > 0f)
			{
				CancelResetPosition();
				resetPositionRoutine = StartCoroutine(MoveToPosition(newPosition, speed));
			}
			else
			{
				UpdatePosition(newPosition, additive: false);
			}
		}

		public virtual void ResetPosition()
		{
			SetCurrentPosition(localOrigin, resetToOrignOnReleaseSpeed);
		}

		public virtual Limits2D[] GetWorldLimits()
		{
			return new Limits2D[3] { xOriginLimits, yOriginLimits, zOriginLimits };
		}

		protected virtual void OnEnable()
		{
			ResetState();
		}

		protected virtual void OnDisable()
		{
			CancelResetPosition();
			CancelDeceleratePosition();
		}

		protected override void Initialise()
		{
			tracked = false;
			climbable = false;
			kinematic = true;
			SetupOrigin();
		}

		protected virtual void SetupOrigin()
		{
			CheckAxisLimits();
			localOrigin = base.transform.localPosition;
			xOriginLimits = new Limits2D(localOrigin.x + xAxisLimits.minimum, localOrigin.x + xAxisLimits.maximum);
			yOriginLimits = new Limits2D(localOrigin.y + yAxisLimits.minimum, localOrigin.y + yAxisLimits.maximum);
			zOriginLimits = new Limits2D(localOrigin.z + zAxisLimits.minimum, localOrigin.z + zAxisLimits.maximum);
			previousPosition = localOrigin;
		}

		protected virtual float ClampAxis(Limits2D limits, float axisValue)
		{
			axisValue = ((axisValue < limits.minimum + minMaxThreshold) ? limits.minimum : axisValue);
			axisValue = ((axisValue > limits.maximum - minMaxThreshold) ? limits.maximum : axisValue);
			return Mathf.Clamp(axisValue, limits.minimum, limits.maximum);
		}

		protected virtual void ClampPosition()
		{
			base.transform.localPosition = new Vector3(ClampAxis(xOriginLimits, base.transform.localPosition.x), ClampAxis(yOriginLimits, base.transform.localPosition.y), ClampAxis(zOriginLimits, base.transform.localPosition.z));
		}

		protected virtual Vector3 NormalizePosition(Vector3 givenHeading)
		{
			return new Vector3(VRTK_SharedMethods.NormalizeValue(givenHeading.x, xAxisLimits.minimum, xAxisLimits.maximum, minMaxNormalizedThreshold), VRTK_SharedMethods.NormalizeValue(givenHeading.y, yAxisLimits.minimum, yAxisLimits.maximum, minMaxNormalizedThreshold), VRTK_SharedMethods.NormalizeValue(givenHeading.z, zAxisLimits.minimum, zAxisLimits.maximum, minMaxNormalizedThreshold));
		}

		protected virtual void CancelResetPosition()
		{
			if (resetPositionRoutine != null)
			{
				StopCoroutine(resetPositionRoutine);
			}
		}

		protected virtual void CancelDeceleratePosition()
		{
			if (deceleratePositionRoutine != null)
			{
				StopCoroutine(deceleratePositionRoutine);
			}
		}

		protected virtual void UpdatePosition(Vector3 newPosition, bool additive, bool forceClamp = true)
		{
			base.transform.localPosition = (additive ? (base.transform.localPosition + newPosition) : newPosition);
			if (forceClamp)
			{
				ClampPosition();
			}
			EmitEvents();
		}

		protected virtual IEnumerator MoveToPosition(Vector3 targetPosition, float speed)
		{
			while (base.transform.localPosition != targetPosition)
			{
				UpdatePosition(Vector3.Lerp(base.transform.localPosition, targetPosition, speed * Time.deltaTime), additive: false, forceClamp: false);
				yield return null;
			}
			UpdatePosition(targetPosition, additive: false);
		}

		protected virtual IEnumerator DeceleratePosition()
		{
			while (movementVelocity != Vector3.zero)
			{
				movementVelocity = Vector3.Slerp(movementVelocity, Vector3.zero, releaseDecelerationDamper * Time.deltaTime);
				UpdatePosition(movementVelocity, additive: true);
				yield return null;
			}
			movementVelocity = Vector3.zero;
		}

		protected virtual void CheckAxisLimits()
		{
			xAxisLimits = FixAxisLimits(xAxisLimits);
			yAxisLimits = FixAxisLimits(yAxisLimits);
			zAxisLimits = FixAxisLimits(zAxisLimits);
		}

		protected virtual Limits2D FixAxisLimits(Limits2D givenLimits)
		{
			givenLimits.minimum = ((givenLimits.minimum > 0f) ? (givenLimits.minimum * -1f) : givenLimits.minimum);
			givenLimits.maximum = ((givenLimits.maximum < 0f) ? (givenLimits.maximum * -1f) : givenLimits.maximum);
			return givenLimits;
		}

		protected virtual void EmitEvents()
		{
			MoveTransformGrabAttachEventArgs e = SetEventPayload();
			if (base.transform.localPosition != previousPosition)
			{
				OnTransformPositionChanged(e);
			}
			Vector3 normalizedPosition = GetNormalizedPosition();
			if (normalizedPosition.x == 0f && !limitsReached[0])
			{
				OnXAxisMinLimitReached(e);
				limitsReached[0] = true;
			}
			else if (normalizedPosition.x == 1f && !limitsReached[1])
			{
				OnXAxisMaxLimitReached(e);
				limitsReached[1] = true;
			}
			else if (normalizedPosition.x > 0f && normalizedPosition.x < 1f)
			{
				if (limitsReached[0])
				{
					OnXAxisMinLimitExited(e);
				}
				if (limitsReached[1])
				{
					OnXAxisMaxLimitExited(e);
				}
				limitsReached[0] = false;
				limitsReached[1] = false;
			}
			if (normalizedPosition.y == 0f && !limitsReached[2])
			{
				OnYAxisMinLimitReached(e);
				limitsReached[2] = true;
			}
			else if (normalizedPosition.y == 1f && !limitsReached[3])
			{
				OnYAxisMaxLimitReached(e);
				limitsReached[3] = true;
			}
			else if (normalizedPosition.y > 0f && normalizedPosition.y < 1f)
			{
				if (limitsReached[2])
				{
					OnYAxisMinLimitExited(e);
				}
				if (limitsReached[3])
				{
					OnYAxisMaxLimitExited(e);
				}
				limitsReached[2] = false;
				limitsReached[3] = false;
			}
			if (normalizedPosition.z == 0f && !limitsReached[4])
			{
				OnZAxisMinLimitReached(e);
				limitsReached[4] = true;
			}
			else if (normalizedPosition.z == 1f && !limitsReached[5])
			{
				OnZAxisMaxLimitReached(e);
				limitsReached[5] = true;
			}
			else if (normalizedPosition.z > 0f && normalizedPosition.z < 1f)
			{
				if (limitsReached[4])
				{
					OnZAxisMinLimitExited(e);
				}
				if (limitsReached[5])
				{
					OnZAxisMaxLimitExited(e);
				}
				limitsReached[4] = false;
				limitsReached[5] = false;
			}
		}

		protected virtual MoveTransformGrabAttachEventArgs SetEventPayload()
		{
			MoveTransformGrabAttachEventArgs result = default(MoveTransformGrabAttachEventArgs);
			result.interactingObject = ((grabbedObjectScript != null) ? grabbedObjectScript.GetGrabbingObject() : null);
			result.position = GetPosition();
			result.normalizedPosition = GetNormalizedPosition();
			result.currentDirection = GetCurrentDirection();
			result.originDirection = GetDirectionFromOrigin();
			return result;
		}
	}
}
