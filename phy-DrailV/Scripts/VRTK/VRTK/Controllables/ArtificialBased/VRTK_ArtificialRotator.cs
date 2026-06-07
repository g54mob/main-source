using UnityEngine;
using VRTK.GrabAttachMechanics;
using VRTK.SecondaryControllerGrabActions;

namespace VRTK.Controllables.ArtificialBased
{
	[AddComponentMenu("VRTK/Scripts/Interactables/Controllables/Artificial/VRTK_ArtificialRotator")]
	public class VRTK_ArtificialRotator : VRTK_BaseControllable
	{
		[Header("Hinge Settings")]
		[Tooltip("A Transform that denotes the position where the rotator will rotate around.")]
		public Transform hingePoint;

		[Tooltip("The minimum and maximum angle the rotator can rotate to.")]
		public Limits2D angleLimits = new Limits2D(-180f, 180f);

		[Tooltip("The angle at which the rotator rotation can be within the minimum or maximum angle before the minimum or maximum angles are considered reached.")]
		public float minMaxThresholdAngle = 1f;

		[Tooltip("The angle at which will be considered as the resting position of the rotator.")]
		public float restingAngle;

		[Tooltip("The threshold angle from the `Resting Angle` that the current angle of the rotator needs to be within to snap the rotator back to the `Resting Angle`.")]
		public float forceRestingAngleThreshold = 1f;

		[Tooltip("The target angle to rotate the rotator to.")]
		[SerializeField]
		protected float angleTarget;

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
		[Tooltip("If this is checked then when the Interact Grab grabs the Interactable Object, it will grab it with precision and pick it up at the particular point on the Interactable Object that the Interact Touch is touching.")]
		public bool precisionGrab = true;

		[Tooltip("The maximum distance the grabbing object is away from the rotator before it is automatically released.")]
		public float detachDistance = 1f;

		[Tooltip("Determines how the rotation of the object is calculated based on the action of the grabbing object.")]
		public VRTK_RotateTransformGrabAttach.RotationType rotationAction;

		[Tooltip("The simulated friction when the rotator is grabbed.")]
		public float grabbedFriction = 1f;

		[Tooltip("The simulated friction when the rotator is released.")]
		public float releasedFriction = 1f;

		[Tooltip("A collection of GameObjects that will be used as the valid collisions to determine if the rotator can be interacted with.")]
		public GameObject[] onlyInteractWith = new GameObject[0];

		protected VRTK_InteractableObject controlInteractableObject;

		protected VRTK_RotateTransformGrabAttach controlGrabAttach;

		protected VRTK_SwapControllerGrabAction controlSecondaryGrabAction;

		protected bool createInteractableObject;

		protected GameObject rotatorContainer;

		protected bool rotationReset;

		protected bool stillResting;

		protected float previousValue;

		protected float previousAngleTarget;

		protected Transform savedParent;

		public override float GetValue()
		{
			if (!(controlGrabAttach != null))
			{
				return 0f;
			}
			return controlGrabAttach.GetAngle();
		}

		public override float GetNormalizedValue()
		{
			return VRTK_SharedMethods.NormalizeValue(GetValue(), angleLimits.minimum, angleLimits.maximum);
		}

		public override void SetValue(float value)
		{
			SetAngleTarget(value);
		}

		public virtual GameObject GetContainer()
		{
			return rotatorContainer;
		}

		public virtual float GetStepValue(float currentValue)
		{
			return Mathf.Round(Mathf.Lerp(stepValueRange.minimum, stepValueRange.maximum, VRTK_SharedMethods.NormalizeValue(currentValue, angleLimits.minimum, angleLimits.maximum)) / stepSize) * stepSize;
		}

		public virtual void SetAngleTargetWithStepValue(float givenStepValue)
		{
			angleTarget = SetAngleWithNormalizedValue(VRTK_SharedMethods.NormalizeValue(givenStepValue, stepValueRange.minimum, stepValueRange.maximum));
			previousAngleTarget = angleTarget;
		}

		public virtual void SetRestingAngleWithStepValue(float givenStepValue)
		{
			restingAngle = VRTK_SharedMethods.NormalizeValue(givenStepValue, stepValueRange.minimum, stepValueRange.maximum);
		}

		public virtual float GetAngleFromStepValue(float givenStepValue)
		{
			float value = VRTK_SharedMethods.NormalizeValue(givenStepValue, stepValueRange.minimum, stepValueRange.maximum);
			if (!(controlGrabAttach != null))
			{
				return 0f;
			}
			return Mathf.Lerp(controlGrabAttach.angleLimits.minimum, controlGrabAttach.angleLimits.maximum, Mathf.Clamp01(value));
		}

		public virtual void SetAngleTarget(float newAngle)
		{
			if (controlGrabAttach != null)
			{
				newAngle = Mathf.Clamp(newAngle, angleLimits.minimum, angleLimits.maximum);
				angleTarget = newAngle;
				SetRotation(angleTarget, 0f);
			}
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
			SetValue(storedValue);
			ResetParentContainer();
			base.OnEnable();
			rotatorContainer = base.gameObject;
			rotationReset = false;
			previousValue = float.MaxValue;
			SetupParentContainer();
			SetupInteractableObject();
			SetAngleTarget(angleTarget);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			ManageInteractableListeners(state: false);
			ManageGrabbableListeners(state: false);
			if (createInteractableObject)
			{
				Object.Destroy(controlInteractableObject);
			}
			RemoveParentContainer();
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

		protected virtual void SetupParentContainer()
		{
			if (hingePoint != null)
			{
				hingePoint.transform.SetParent(base.transform.parent);
				Vector3 localScale = base.transform.localScale;
				rotatorContainer = new GameObject(VRTK_SharedMethods.GenerateVRTKObjectName(true, base.name, "Controllable", "ArtificialBased", "RotatorContainer"));
				rotatorContainer.transform.SetParent(base.transform.parent);
				rotatorContainer.transform.localPosition = base.transform.localPosition;
				rotatorContainer.transform.localRotation = base.transform.localRotation;
				rotatorContainer.transform.localScale = Vector3.one;
				base.transform.SetParent(rotatorContainer.transform);
				rotatorContainer.transform.localPosition = hingePoint.localPosition;
				base.transform.localPosition = -hingePoint.localPosition;
				base.transform.localScale = localScale;
				hingePoint.transform.SetParent(base.transform);
			}
		}

		protected virtual void RemoveParentContainer()
		{
			if (rotatorContainer != null)
			{
				savedParent = rotatorContainer.transform.parent;
			}
		}

		protected virtual void ResetParentContainer()
		{
			if (savedParent != null)
			{
				base.transform.SetParent(savedParent);
				Object.Destroy(rotatorContainer);
			}
		}

		protected virtual void SetupInteractableObject()
		{
			controlInteractableObject = GetComponent<VRTK_InteractableObject>();
			if (controlInteractableObject == null)
			{
				controlInteractableObject = rotatorContainer.AddComponent<VRTK_InteractableObject>();
				controlInteractableObject.isGrabbable = true;
				controlInteractableObject.ignoredColliders = ((onlyInteractWith.Length != 0) ? VRTK_SharedMethods.ColliderExclude(GetComponentsInChildren<Collider>(includeInactive: true), VRTK_SharedMethods.GetCollidersInGameObjects(onlyInteractWith, searchChildren: true, includeInactive: true)) : new Collider[0]);
				SetupGrabMechanic();
				SetupSecondaryAction();
			}
			ManageInteractableListeners(state: true);
		}

		protected virtual void SetupGrabMechanic()
		{
			if (controlInteractableObject != null)
			{
				controlGrabAttach = controlInteractableObject.gameObject.AddComponent<VRTK_RotateTransformGrabAttach>();
				SetGrabMechanicParameters();
				controlInteractableObject.grabAttachMechanicScript = controlGrabAttach;
				ManageGrabbableListeners(state: true);
			}
		}

		protected virtual void SetGrabMechanicParameters()
		{
			if (controlGrabAttach != null)
			{
				controlGrabAttach.precisionGrab = precisionGrab;
				controlGrabAttach.detachDistance = detachDistance;
				controlGrabAttach.rotationAction = rotationAction;
				controlGrabAttach.rotateAround = (VRTK_RotateTransformGrabAttach.RotationAxis)operateAxis;
				controlGrabAttach.rotationFriction = grabbedFriction;
				controlGrabAttach.releaseDecelerationDamper = releasedFriction;
				controlGrabAttach.angleLimits = angleLimits;
			}
		}

		protected virtual void SetupSecondaryAction()
		{
			if (controlInteractableObject != null)
			{
				controlSecondaryGrabAction = controlInteractableObject.gameObject.AddComponent<VRTK_SwapControllerGrabAction>();
				controlInteractableObject.secondaryGrabActionScript = controlSecondaryGrabAction;
			}
		}

		protected virtual void ManageInteractableListeners(bool state)
		{
			if (controlInteractableObject != null)
			{
				if (state)
				{
					controlInteractableObject.InteractableObjectGrabbed += InteractableObjectGrabbed;
					controlInteractableObject.InteractableObjectUngrabbed += InteractableObjectUngrabbed;
				}
				else
				{
					controlInteractableObject.InteractableObjectGrabbed -= InteractableObjectGrabbed;
					controlInteractableObject.InteractableObjectUngrabbed -= InteractableObjectUngrabbed;
				}
			}
		}

		protected virtual void InteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
		{
			CheckLock();
		}

		protected virtual void InteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
		{
			rotationReset = false;
			ForceRestingPosition();
			ForceSnapToStep();
		}

		protected virtual void CheckLock()
		{
			if (controlGrabAttach != null)
			{
				SetGrabMechanicParameters();
				controlGrabAttach.angleLimits = (isLocked ? Limits2D.zero : angleLimits);
			}
		}

		protected virtual void ManageGrabbableListeners(bool state)
		{
			if (controlGrabAttach != null)
			{
				if (state)
				{
					controlGrabAttach.AngleChanged += GrabMechanicAngleChanged;
				}
				else
				{
					controlGrabAttach.AngleChanged -= GrabMechanicAngleChanged;
				}
			}
		}

		protected virtual void GrabMechanicAngleChanged(object sender, RotateTransformGrabAttachEventArgs e)
		{
			if (controlInteractableObject != null && !controlInteractableObject.IsGrabbed())
			{
				ForceRestingPosition();
				ForceSnapToStep();
			}
			if (processAtEndOfFrame == null)
			{
				EmitEvents();
			}
		}

		protected virtual float SetAngleWithNormalizedValue(float normalizedTargetAngle)
		{
			if (controlGrabAttach != null)
			{
				float num = Mathf.Lerp(controlGrabAttach.angleLimits.minimum, controlGrabAttach.angleLimits.maximum, Mathf.Clamp01(normalizedTargetAngle));
				SetRotation(num, releasedFriction * 0.1f);
				return num;
			}
			return 0f;
		}

		protected virtual void ForceRestingPosition()
		{
			if (!rotationReset && controlGrabAttach != null)
			{
				float value = GetValue();
				if (value <= restingAngle + forceRestingAngleThreshold && value >= restingAngle - forceRestingAngleThreshold)
				{
					SetRotation(restingAngle, releasedFriction * 0.1f);
				}
			}
		}

		protected virtual void ForceSnapToStep()
		{
			bool num = snapToStep && controlGrabAttach != null && !IsGrabbed() && !rotationReset;
			bool flag = Mathf.Abs(GetValue() - GetAngleFromStepValue(GetStepValue(GetValue()))) >= equalityFidelity;
			if (num && flag)
			{
				SetAngleTargetWithStepValue(GetStepValue(GetValue()));
			}
		}

		protected virtual void SetRotation(float newAngle, float speed)
		{
			rotationReset = true;
			controlGrabAttach.SetRotation(newAngle, speed);
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
