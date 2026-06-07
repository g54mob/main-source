using UnityEngine;
using VRTK.GrabAttachMechanics;
using VRTK.SecondaryControllerGrabActions;

namespace VRTK.Controllables.PhysicsBased
{
	[AddComponentMenu("VRTK/Scripts/Interactables/Controllables/Physics/VRTK_PhysicsSlider")]
	public class VRTK_PhysicsSlider : VRTK_BasePhysicsControllable
	{
		[Header("Slider Settings")]
		[Tooltip("The maximum length that the slider can be moved from the origin position across the `Operate Axis`. A negative value will allow it to move the opposite way.")]
		public float maximumLength = 0.1f;

		[Tooltip("The normalized position the slider can be within the minimum or maximum slider positions before the minimum or maximum positions are considered reached.")]
		public float minMaxThreshold = 0.01f;

		[Tooltip("The target position to move the slider towards given in a normalized value of `0f` (start point) to `1f` (end point).")]
		[Range(0f, 1f)]
		public float positionTarget;

		[Tooltip("The position the slider when it is at the default resting point given in a normalized value of `0f` (start point) to `1f` (end point).")]
		[Range(0f, 1f)]
		public float restingPosition;

		[Tooltip("The normalized threshold value the slider has to be within the `Resting Position` before the slider is forced back to the `Resting Position` if it is not grabbed.")]
		[Range(0f, 1f)]
		public float forceRestingPositionThreshold;

		[Header("Value Step Settings")]
		[Tooltip("The minimum and the maximum step values for the slider to register along the `Operate Axis`.")]
		public Limits2D stepValueRange = new Limits2D(0f, 1f);

		[Tooltip("The increments the slider value will change in between the `Step Value Range`.")]
		public float stepSize = 0.1f;

		[Tooltip("If this is checked then the value for the slider will be the step value and not the absolute position of the slider Transform.")]
		public bool useStepAsValue = true;

		[Header("Snap Settings")]
		[Tooltip("If this is checked then the slider will snap to the position of the nearest step along the value range.")]
		public bool snapToStep;

		[Tooltip("The speed in which the slider will snap to the relevant point along the `Operate Axis`")]
		public float snapForce = 10f;

		[Header("Interaction Settings")]
		[Tooltip("If this is checked then when the Interact Grab grabs the Interactable Object, it will grab it with precision and pick it up at the particular point on the Interactable Object that the Interact Touch is touching.")]
		public bool precisionGrab = true;

		[Tooltip("The maximum distance the grabbing object is away from the slider before it is automatically released.")]
		public float detachDistance = 1f;

		[Tooltip("The amount of friction to the slider Rigidbody when it is released.")]
		public float releaseFriction = 10f;

		[Tooltip("A collection of GameObjects that will be used as the valid collisions to determine if the door can be interacted with.")]
		public GameObject[] onlyInteractWith = new GameObject[0];

		protected ConfigurableJoint controlJoint;

		protected bool createControlJoint;

		protected VRTK_InteractableObject controlInteractableObject;

		protected VRTK_TrackObjectGrabAttach controlGrabAttach;

		protected VRTK_SwapControllerGrabAction controlSecondaryGrabAction;

		protected bool createControlInteractableObject;

		protected Vector3 previousLocalPosition;

		protected float previousPositionTarget;

		protected bool stillResting;

		public override float GetValue()
		{
			return base.transform.localPosition[(int)operateAxis];
		}

		public override float GetNormalizedValue()
		{
			return VRTK_SharedMethods.NormalizeValue(GetValue(), originalLocalPosition[(int)operateAxis], MaximumLength()[(int)operateAxis]);
		}

		public override void SetValue(float value)
		{
			Vector3 vector = default(Vector3);
			vector = base.transform.localPosition;
			vector[(int)operateAxis] = value;
			base.transform.localPosition = vector;
			positionTarget = VRTK_SharedMethods.NormalizeValue(value, originalLocalPosition[(int)operateAxis], MaximumLength()[(int)operateAxis]);
			SetPositionWithNormalizedValue(positionTarget);
		}

		public virtual float GetStepValue(float currentValue)
		{
			return Mathf.Round((stepValueRange.minimum + Mathf.Clamp01(currentValue / maximumLength) * (stepValueRange.maximum - stepValueRange.minimum)) / stepSize) * stepSize;
		}

		public virtual void SetPositionTargetWithStepValue(float givenStepValue)
		{
			positionTarget = VRTK_SharedMethods.NormalizeValue(givenStepValue, stepValueRange.minimum, stepValueRange.maximum);
			SetPositionWithNormalizedValue(positionTarget);
		}

		public virtual void SetRestingPositionWithStepValue(float givenStepValue)
		{
			restingPosition = VRTK_SharedMethods.NormalizeValue(givenStepValue, stepValueRange.minimum, stepValueRange.maximum);
		}

		public virtual float GetPositionFromStepValue(float givenStepValue)
		{
			float value = VRTK_SharedMethods.NormalizeValue(givenStepValue, stepValueRange.minimum, stepValueRange.maximum);
			return Mathf.Lerp(controlJoint.linearLimit.limit, 0f - controlJoint.linearLimit.limit, Mathf.Clamp01(value));
		}

		public override bool IsResting()
		{
			float normalizedValue = GetNormalizedValue();
			if (!IsGrabbed() && normalizedValue <= restingPosition + forceRestingPositionThreshold)
			{
				return normalizedValue >= restingPosition - forceRestingPositionThreshold;
			}
			return false;
		}

		public virtual ConfigurableJoint GetControlJoint()
		{
			return controlJoint;
		}

		public virtual VRTK_InteractableObject GetControlInteractableObject()
		{
			return controlInteractableObject;
		}

		protected override void OnDrawGizmosSelected()
		{
			Vector3 position = base.transform.position;
			base.OnDrawGizmosSelected();
			Vector3 vector = position + AxisDirection(local: true) * maximumLength;
			Gizmos.DrawLine(position, vector);
			Gizmos.DrawSphere(position, 0.01f);
			Gizmos.DrawSphere(vector, 0.01f);
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			SetupInteractableObject();
			SetupJoint();
			previousLocalPosition = Vector3.one * float.MaxValue;
			previousPositionTarget = float.MaxValue;
			stillResting = false;
			SetValue(storedValue);
		}

		protected override void OnDisable()
		{
			storedValue = GetValue();
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
			if (createControlJoint)
			{
				Object.Destroy(controlJoint);
			}
			base.OnDisable();
		}

		protected virtual void Update()
		{
			ForceRestingPosition();
			ForcePositionTarget();
			ForceSnapToStep();
			EmitEvents();
		}

		protected override void ConfigueRigidbody()
		{
			SetRigidbodyGravity(useGravity: false);
			controlRigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
			controlRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
		}

		protected override void EmitEvents()
		{
			bool flag = !VRTK_SharedMethods.Vector3ShallowCompare(base.transform.localPosition, previousLocalPosition, equalityFidelity);
			if (flag)
			{
				float normalizedValue = GetNormalizedValue();
				float num = minMaxThreshold;
				float num2 = 1f - minMaxThreshold;
				stillResting = false;
				ControllableEventArgs e = EventPayload();
				OnValueChanged(e);
				if (normalizedValue >= num2 && !AtMaxLimit())
				{
					atMaxLimit = true;
					OnMaxLimitReached(e);
				}
				else if (normalizedValue <= num && !AtMinLimit())
				{
					atMinLimit = true;
					OnMinLimitReached(e);
				}
				else if (normalizedValue > num && normalizedValue < num2)
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
			}
			if (!stillResting && IsResting() && !flag)
			{
				OnRestingPointReached(EventPayload());
				stillResting = true;
			}
			previousLocalPosition = base.transform.localPosition;
		}

		protected override ControllableEventArgs EventPayload()
		{
			ControllableEventArgs result = base.EventPayload();
			result.value = (useStepAsValue ? GetStepValue(GetValue()) : GetValue());
			return result;
		}

		protected virtual void ForceRestingPosition()
		{
			if (forceRestingPositionThreshold > 0f && !IsGrabbed() && Mathf.Abs(restingPosition - GetNormalizedValue()) <= forceRestingPositionThreshold)
			{
				SetPositionWithNormalizedValue(restingPosition);
				EnableJointDriver();
			}
		}

		protected virtual void ForcePositionTarget()
		{
			if (!IsGrabbed() && positionTarget != previousPositionTarget)
			{
				SetPositionWithNormalizedValue(positionTarget);
				EnableJointDriver();
			}
			previousPositionTarget = positionTarget;
		}

		protected virtual void ForceSnapToStep()
		{
			if (snapToStep && controlJoint != null && !IsGrabbed() && controlJoint.targetPosition == Vector3.zero && Mathf.Abs(GetValue() - GetPositionFromStepValue(GetStepValue(GetValue()))) >= equalityFidelity)
			{
				SetPositionTargetWithStepValue(GetStepValue(GetValue()));
			}
		}

		protected virtual void SetPositionWithNormalizedValue(float givenTargetPosition)
		{
			float positionOnAxis = Mathf.Lerp(controlJoint.linearLimit.limit, 0f - controlJoint.linearLimit.limit, Mathf.Clamp01(givenTargetPosition));
			SnapToPosition(positionOnAxis);
		}

		protected virtual void SnapToPosition(float positionOnAxis)
		{
			if (controlJoint != null)
			{
				controlJoint.targetPosition = AxisDirection() * Mathf.Sign(maximumLength) * positionOnAxis;
			}
		}

		protected virtual Vector3 MaximumLength()
		{
			return originalLocalPosition + AxisDirection() * maximumLength;
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
			controlGrabAttach = controlInteractableObject.gameObject.AddComponent<VRTK_TrackObjectGrabAttach>();
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

		protected virtual void SetupJoint()
		{
			base.transform.localPosition = originalLocalPosition + AxisDirection() * (maximumLength * 0.5f);
			controlJoint = GetComponent<ConfigurableJoint>();
			createControlJoint = false;
			if (controlJoint == null)
			{
				controlJoint = base.gameObject.AddComponent<ConfigurableJoint>();
				createControlJoint = true;
				controlJoint.angularXMotion = ConfigurableJointMotion.Locked;
				controlJoint.angularYMotion = ConfigurableJointMotion.Locked;
				controlJoint.angularZMotion = ConfigurableJointMotion.Locked;
				controlJoint.xMotion = ((operateAxis == OperatingAxis.xAxis) ? ConfigurableJointMotion.Limited : ConfigurableJointMotion.Locked);
				controlJoint.yMotion = ((operateAxis == OperatingAxis.yAxis) ? ConfigurableJointMotion.Limited : ConfigurableJointMotion.Locked);
				controlJoint.zMotion = ((operateAxis == OperatingAxis.zAxis) ? ConfigurableJointMotion.Limited : ConfigurableJointMotion.Locked);
				SoftJointLimit linearLimit = new SoftJointLimit
				{
					limit = Mathf.Abs(maximumLength * 0.5f)
				};
				controlJoint.linearLimit = linearLimit;
				controlJoint.connectedBody = connectedTo;
				EnableJointDriver();
			}
		}

		protected virtual void EnableJointDriver()
		{
			SetJointDrive(snapForce);
		}

		protected virtual void DisableJointDriver()
		{
			SetJointDrive(0f);
		}

		protected virtual void SetJointDrive(float driverForce)
		{
			JointDrive jointDrive = new JointDrive
			{
				positionSpring = 1000f,
				positionDamper = 100f,
				maximumForce = driverForce
			};
			controlJoint.xDrive = jointDrive;
			controlJoint.yDrive = jointDrive;
			controlJoint.zDrive = jointDrive;
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
			if (GetControlActivatorContainer() != null)
			{
				AttemptMove();
			}
		}

		protected virtual void InteractableObjectUntouched(object sender, InteractableObjectEventArgs e)
		{
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
			SetRigidbodyDrag(0f);
			DisableJointDriver();
		}

		protected virtual void AttemptRelease()
		{
			SetRigidbodyDrag(releaseFriction);
			if (snapToStep)
			{
				SetPositionTargetWithStepValue(GetStepValue(GetValue()));
				EnableJointDriver();
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
