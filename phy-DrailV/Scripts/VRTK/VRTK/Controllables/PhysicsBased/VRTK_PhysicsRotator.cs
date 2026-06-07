using UnityEngine;
using VRTK.GrabAttachMechanics;
using VRTK.SecondaryControllerGrabActions;

namespace VRTK.Controllables.PhysicsBased
{
	[AddComponentMenu("VRTK/Scripts/Interactables/Controllables/Physics/VRTK_PhysicsRotator")]
	public class VRTK_PhysicsRotator : VRTK_BasePhysicsControllable
	{
		public enum GrabMechanic
		{
			TrackObject = 0,
			RotatorTrack = 1
		}

		[Header("Hinge Settings")]
		[Tooltip("A Transform that denotes the position where the rotator hinge will be created.")]
		public Transform hingePoint;

		[Tooltip("The minimum and maximum angle the rotator can rotate to.")]
		[MinMaxRange(-180f, 180f)]
		public Limits2D angleLimits = new Limits2D(-180f, 180f);

		[Tooltip("The angle at which the rotator rotation can be within the minimum or maximum angle before the minimum or maximum angles are considered reached.")]
		public float minMaxThresholdAngle = 1f;

		[Tooltip("The angle at which will be considered as the resting position of the rotator.")]
		public float restingAngle;

		[Tooltip("The threshold angle from the `Resting Angle` that the current angle of the rotator needs to be within to snap the rotator back to the `Resting Angle`.")]
		public float forceRestingAngleThreshold = 1f;

		[Tooltip("The target angle to rotate the rotator to.")]
		public float angleTarget;

		[Tooltip("If this is checked then the rotator Rigidbody will have all rotations frozen.")]
		public bool isLocked;

		[Header("Value Step Settings")]
		[Tooltip("The minimum and the maximum step values for the rotator to register along the `Operate Axis`.")]
		public Limits2D stepValueRange = new Limits2D(0f, 1f);

		[Tooltip("The increments the rotator value will change in between the `Step Value Range`.")]
		public float stepSize = 0.1f;

		[Tooltip("If this is checked then the value for the rotator will be the step value and not the absolute rotation of the rotator Transform.")]
		public bool useStepAsValue = true;

		[Header("Snap Settings")]
		[Tooltip("If this is checked then the rotator will snap to the angle of the nearest step along the value range.")]
		public bool snapToStep;

		[Tooltip("The speed in which the rotator will snap to the relevant angle along the `Operate Axis`")]
		public float snapForce = 10f;

		[Header("Interaction Settings")]
		[Tooltip("The type of Interactable Object grab mechanic to use when operating the rotator.")]
		public GrabMechanic grabMechanic = GrabMechanic.RotatorTrack;

		[Tooltip("If this is checked then when the Interact Grab grabs the Interactable Object, it will grab it with precision and pick it up at the particular point on the Interactable Object that the Interact Touch is touching.")]
		public bool precisionGrab = true;

		[Tooltip("The maximum distance the grabbing object is away from the rotator before it is automatically released.")]
		public float detachDistance = 1f;

		[Tooltip("If this is checked then the `Grabbed Friction` value will be used as the Rigidbody drag value when the rotator is grabbed and the `Released Friction` value will be used as the Rigidbody drag value when the door is released.")]
		public bool useFrictionOverrides;

		[Tooltip("The Rigidbody drag value when the rotator is grabbed.")]
		public float grabbedFriction;

		[Tooltip("The Rigidbody drag value when the rotator is released.")]
		public float releasedFriction;

		[Tooltip("A collection of GameObjects that will be used as the valid collisions to determine if the rotator can be interacted with.")]
		public GameObject[] onlyInteractWith = new GameObject[0];

		protected VRTK_InteractableObject controlInteractableObject;

		protected VRTK_TrackObjectGrabAttach controlGrabAttach;

		protected VRTK_SwapControllerGrabAction controlSecondaryGrabAction;

		protected bool createControlInteractableObject;

		protected HingeJoint controlJoint;

		protected JointSpring controlJointSpring;

		protected JointLimits controlJointLimits;

		protected bool createControlJoint;

		protected RigidbodyConstraints savedConstraints;

		protected bool stillLocked;

		protected bool stillResting;

		protected float previousValue;

		protected float previousAngleTarget;

		public override float GetValue()
		{
			float num = base.transform.localEulerAngles[(int)operateAxis];
			return Quaternion.Angle(base.transform.localRotation, originalLocalRotation) * Mathf.Sign((num > 180f) ? (num - 360f) : num);
		}

		public override float GetNormalizedValue()
		{
			return VRTK_SharedMethods.NormalizeValue(GetValue(), angleLimits.minimum, angleLimits.maximum);
		}

		public override void SetValue(float value)
		{
			UpdateToAngle(value);
		}

		public virtual float GetStepValue(float currentValue)
		{
			return Mathf.Round(Mathf.Lerp(stepValueRange.minimum, stepValueRange.maximum, VRTK_SharedMethods.NormalizeValue(currentValue, angleLimits.minimum, angleLimits.maximum)) / stepSize) * stepSize;
		}

		public virtual void SetAngleTargetWithStepValue(float givenStepValue)
		{
			angleTarget = VRTK_SharedMethods.NormalizeValue(givenStepValue, stepValueRange.minimum, stepValueRange.maximum);
			SetAngleWithNormalizedValue(angleTarget);
			previousAngleTarget = angleTarget;
		}

		public virtual void SetRestingAngleWithStepValue(float givenStepValue)
		{
			restingAngle = VRTK_SharedMethods.NormalizeValue(givenStepValue, stepValueRange.minimum, stepValueRange.maximum);
		}

		public virtual float GetAngleFromStepValue(float givenStepValue)
		{
			float value = VRTK_SharedMethods.NormalizeValue(givenStepValue, stepValueRange.minimum, stepValueRange.maximum);
			if (!(controlJoint != null))
			{
				return 0f;
			}
			return Mathf.Lerp(controlJoint.limits.min, controlJoint.limits.max, Mathf.Clamp01(value));
		}

		public override bool IsResting()
		{
			float value = GetValue();
			if (!IsGrabbed())
			{
				if (value <= restingAngle + minMaxThresholdAngle)
				{
					return value >= restingAngle - minMaxThresholdAngle;
				}
				return false;
			}
			return false;
		}

		public virtual HingeJoint GetControlJoint()
		{
			return controlJoint;
		}

		public virtual VRTK_InteractableObject GetControlInteractableObject()
		{
			return controlInteractableObject;
		}

		protected override void OnDrawGizmosSelected()
		{
			base.OnDrawGizmosSelected();
			if (hingePoint != null)
			{
				Bounds bounds = VRTK_SharedMethods.GetBounds(base.transform, base.transform);
				Vector3 vector = base.transform.rotation * (AxisDirection() * bounds.size[(int)operateAxis] * 0.53f);
				Vector3 vector2 = hingePoint.transform.position - vector;
				Vector3 vector3 = hingePoint.transform.position + vector;
				Gizmos.DrawLine(vector2, vector3);
				Gizmos.DrawSphere(vector2, 0.01f);
				Gizmos.DrawSphere(vector3, 0.01f);
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			stillLocked = false;
			stillResting = false;
			previousAngleTarget = float.MaxValue;
			previousValue = float.MaxValue;
			savedConstraints = controlRigidbody.constraints;
			SetupInteractableObject();
			SetupJoint();
			SetFrictions(releasedFriction);
			CheckLock();
			SetValue(storedValue);
		}

		protected override void OnDisable()
		{
			storedValue = GetValue();
			if (createControlJoint)
			{
				Object.Destroy(controlJoint);
			}
			base.OnDisable();
			if (createControlInteractableObject)
			{
				ManageInteractableObjectListeners(state: false);
				Object.Destroy(controlSecondaryGrabAction);
				Object.Destroy(controlGrabAttach);
				Object.Destroy(controlInteractableObject);
			}
			else
			{
				ManageInteractableObjectListeners(state: false);
			}
		}

		protected virtual void Update()
		{
			ForceRestingPosition();
			ForceAngleTarget();
			ForceSnapToStep();
			SetJointLimits();
			EmitEvents();
		}

		protected override void EmitEvents()
		{
			bool flag = Mathf.Abs(GetValue() - previousValue) >= equalityFidelity;
			if (flag)
			{
				ControllableEventArgs e = EventPayload();
				float value = GetValue();
				float num = angleLimits.minimum + minMaxThresholdAngle;
				float num2 = angleLimits.maximum - minMaxThresholdAngle;
				stillResting = false;
				OnValueChanged(e);
				if (value >= num2 && !AtMaxLimit())
				{
					atMaxLimit = true;
					OnMaxLimitReached(e);
				}
				else if (value <= angleLimits.minimum + minMaxThresholdAngle && !AtMinLimit())
				{
					atMinLimit = true;
					OnMinLimitReached(e);
				}
				else if (value > num && value < num2)
				{
					if (AtMinLimit())
					{
						OnMinLimitExited(e);
					}
					if (AtMaxLimit())
					{
						OnMaxLimitExited(e);
					}
					atMinLimit = false;
					atMaxLimit = false;
				}
				previousValue = GetValue();
			}
			if (!stillResting && IsResting() && !flag)
			{
				OnRestingPointReached(EventPayload());
				stillResting = true;
			}
		}

		protected override ControllableEventArgs EventPayload()
		{
			ControllableEventArgs result = base.EventPayload();
			result.value = (useStepAsValue ? GetStepValue(GetValue()) : GetValue());
			return result;
		}

		protected virtual void SetupJoint()
		{
			createControlJoint = false;
			controlJoint = GetComponent<HingeJoint>();
			if (controlJoint == null && hingePoint != null)
			{
				controlJoint = base.gameObject.AddComponent<HingeJoint>();
				createControlJoint = true;
				controlJoint.axis = AxisDirection();
				controlJoint.connectedBody = connectedTo;
				hingePoint.SetParent(base.transform);
				controlJoint.anchor = ((hingePoint != null) ? hingePoint.localPosition : Vector3.zero);
				controlJoint.useLimits = true;
				SetJointLimits();
			}
		}

		protected virtual void SetJointLimits()
		{
			if (controlJoint != null)
			{
				controlJointLimits.min = angleLimits.minimum;
				controlJointLimits.max = angleLimits.maximum;
				controlJoint.limits = controlJointLimits;
			}
		}

		protected virtual void ManageSpring(bool activate, float springTarget)
		{
			if (controlJoint != null)
			{
				controlJoint.useSpring = activate;
				controlJointSpring.spring = 100f;
				controlJointSpring.damper = 10f;
				controlJointSpring.targetPosition = springTarget;
				controlJoint.spring = controlJointSpring;
			}
		}

		protected virtual void SetupInteractableObject()
		{
			createControlInteractableObject = false;
			controlInteractableObject = GetComponent<VRTK_InteractableObject>();
			if (controlInteractableObject == null)
			{
				controlInteractableObject = base.gameObject.AddComponent<VRTK_InteractableObject>();
				createControlInteractableObject = true;
				controlInteractableObject.isGrabbable = true;
				controlInteractableObject.ignoredColliders = ((onlyInteractWith.Length != 0) ? VRTK_SharedMethods.ColliderExclude(GetComponentsInChildren<Collider>(includeInactive: true), VRTK_SharedMethods.GetCollidersInGameObjects(onlyInteractWith, searchChildren: true, includeInactive: true)) : new Collider[0]);
				SetupGrabMechanic();
				SetupSecondaryAction();
				ManageInteractableObjectListeners(state: true);
			}
		}

		protected virtual void SetupGrabMechanic()
		{
			switch (grabMechanic)
			{
			case GrabMechanic.TrackObject:
				controlGrabAttach = controlInteractableObject.gameObject.AddComponent<VRTK_TrackObjectGrabAttach>();
				break;
			case GrabMechanic.RotatorTrack:
				controlGrabAttach = controlInteractableObject.gameObject.AddComponent<VRTK_RotatorTrackGrabAttach>();
				break;
			}
			SetGrabMechanicParameters();
			controlInteractableObject.grabAttachMechanicScript = controlGrabAttach;
		}

		protected virtual void SetGrabMechanicParameters()
		{
			if (controlGrabAttach != null)
			{
				controlGrabAttach.precisionGrab = precisionGrab;
				controlGrabAttach.detachDistance = detachDistance;
			}
		}

		protected virtual void SetupSecondaryAction()
		{
			controlSecondaryGrabAction = controlInteractableObject.gameObject.AddComponent<VRTK_SwapControllerGrabAction>();
			controlInteractableObject.secondaryGrabActionScript = controlSecondaryGrabAction;
		}

		protected virtual void ManageInteractableObjectListeners(bool state)
		{
			if (controlInteractableObject != null)
			{
				if (state)
				{
					controlInteractableObject.InteractableObjectTouched += InteractableObjectTouched;
					controlInteractableObject.InteractableObjectUntouched += InteractableObjectUntouched;
					controlInteractableObject.InteractableObjectGrabbed += InteractableObjectGrabbed;
					controlInteractableObject.InteractableObjectUngrabbed += InteractableObjectUngrabbed;
				}
				else
				{
					controlInteractableObject.InteractableObjectTouched -= InteractableObjectTouched;
					controlInteractableObject.InteractableObjectUntouched -= InteractableObjectUntouched;
					controlInteractableObject.InteractableObjectGrabbed -= InteractableObjectGrabbed;
					controlInteractableObject.InteractableObjectUngrabbed -= InteractableObjectUngrabbed;
				}
			}
		}

		protected virtual void InteractableObjectTouched(object sender, InteractableObjectEventArgs e)
		{
			CheckLock();
			if (GetControlActivatorContainer() != null)
			{
				AttemptMove();
			}
		}

		protected virtual void InteractableObjectUntouched(object sender, InteractableObjectEventArgs e)
		{
			CheckLock();
			if (GetControlActivatorContainer() != null)
			{
				AttemptRelease();
			}
		}

		protected virtual void InteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
		{
			SetGrabMechanicParameters();
			AttemptMove();
		}

		protected virtual void InteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
		{
			AttemptRelease();
		}

		protected virtual void AttemptMove()
		{
			SetFrictions(grabbedFriction);
			ManageSpring(activate: false, restingAngle);
		}

		protected virtual void AttemptRelease()
		{
			SetFrictions(releasedFriction);
		}

		protected virtual void SetFrictions(float frictionValue)
		{
			if (useFrictionOverrides)
			{
				SetRigidbodyDrag(frictionValue);
				SetRigidbodyAngularDrag(frictionValue);
			}
		}

		protected virtual void CheckLock()
		{
			if (controlRigidbody != null)
			{
				if (isLocked && !stillLocked)
				{
					savedConstraints = controlRigidbody.constraints;
					SetRigidbodyConstraints(RigidbodyConstraints.FreezeRotation);
					stillLocked = true;
				}
				else if (!isLocked && stillLocked)
				{
					SetRigidbodyConstraints(savedConstraints);
					stillLocked = false;
				}
			}
		}

		protected virtual void SetAngleWithNormalizedValue(float normalizedTargetAngle)
		{
			if (controlJoint != null)
			{
				float givenTargetAngle = Mathf.Lerp(controlJoint.limits.min, controlJoint.limits.max, Mathf.Clamp01(normalizedTargetAngle));
				UpdateToAngle(givenTargetAngle);
			}
		}

		protected virtual void UpdateToAngle(float givenTargetAngle)
		{
			bool activate = Mathf.Abs(GetValue() - givenTargetAngle) >= equalityFidelity;
			ManageSpring(activate, givenTargetAngle);
		}

		protected virtual void ForceRestingPosition()
		{
			bool num = controlJoint != null && !controlJoint.useSpring && !IsGrabbed() && (GetControlActivatorContainer() == null || !controlInteractableObject.IsTouched());
			float value = GetValue();
			float num2 = restingAngle - forceRestingAngleThreshold;
			float num3 = restingAngle + forceRestingAngleThreshold;
			if (num && value > num2 && value < num3)
			{
				ManageSpring(activate: true, restingAngle);
			}
		}

		protected virtual void ForceAngleTarget()
		{
			if (!IsGrabbed() && previousAngleTarget != angleTarget)
			{
				UpdateToAngle(angleTarget);
			}
			previousAngleTarget = angleTarget;
		}

		protected virtual void ForceSnapToStep()
		{
			bool num = snapToStep && controlJoint != null && !IsGrabbed() && !controlJoint.useSpring;
			bool flag = Mathf.Abs(GetValue() - GetAngleFromStepValue(GetStepValue(GetValue()))) >= equalityFidelity;
			if (num && flag)
			{
				SetAngleTargetWithStepValue(GetStepValue(GetValue()));
			}
		}

		protected virtual bool IsGrabbed()
		{
			if (controlInteractableObject != null)
			{
				return controlInteractableObject.IsGrabbed();
			}
			return false;
		}
	}
}
