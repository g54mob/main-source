using System.Collections;
using UnityEngine;
using VRTK.GrabAttachMechanics;
using VRTK.SecondaryControllerGrabActions;

namespace VRTK.Controllables.ArtificialBased
{
	[AddComponentMenu("VRTK/Scripts/Interactables/Controllables/Artificial/VRTK_ArtificialSlider")]
	public class VRTK_ArtificialSlider : VRTK_BaseControllable
	{
		[Header("Slider Settings")]
		[Tooltip("The maximum length that the slider can be moved from the origin position across the `Operate Axis`. A negative value will allow it to move the opposite way.")]
		public float maximumLength = 0.1f;

		[Tooltip("The normalized position the slider can be within the minimum or maximum slider positions before the minimum or maximum positions are considered reached.")]
		public float minMaxThreshold = 0.01f;

		[Tooltip("The target position to move the slider towards given in a normalized value of `0f` (start point) to `1f` (end point).")]
		[Range(0f, 1f)]
		[SerializeField]
		protected float positionTarget;

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
		[Tooltip("The speed in which to track the grabbed slider to the interacting object.")]
		public float trackingSpeed = 25f;

		[Tooltip("If this is checked then when the Interact Grab grabs the Interactable Object, it will grab it with precision and pick it up at the particular point on the Interactable Object that the Interact Touch is touching.")]
		public bool precisionGrab = true;

		[Tooltip("The maximum distance the grabbing object is away from the slider before it is automatically released.")]
		public float detachDistance = 1f;

		[Tooltip("The amount of friction to the slider Rigidbody when it is released.")]
		public float releaseFriction = 10f;

		[Tooltip("A collection of GameObjects that will be used as the valid collisions to determine if the door can be interacted with.")]
		public GameObject[] onlyInteractWith = new GameObject[0];

		protected VRTK_InteractableObject controlInteractableObject;

		protected VRTK_MoveTransformGrabAttach controlGrabAttach;

		protected VRTK_SwapControllerGrabAction controlSecondaryGrabAction;

		protected bool createInteractableObject;

		protected Limits2D axisLimits;

		protected Vector3 previousLocalPosition;

		protected Coroutine setPositionTargetAtEndOfFrameRoutine;

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
		}

		public virtual float GetStepValue(float currentValue)
		{
			return Mathf.Round((stepValueRange.minimum + Mathf.Clamp01(currentValue / maximumLength) * (stepValueRange.maximum - stepValueRange.minimum)) / stepSize) * stepSize;
		}

		public virtual void SetPositionTarget(float newPositionTarget, float speed)
		{
			positionTarget = newPositionTarget;
			SetPositionWithNormalizedValue(positionTarget, speed);
		}

		public virtual void SetPositionTargetWithStepValue(float givenStepValue, float speed)
		{
			SetPositionTarget(VRTK_SharedMethods.NormalizeValue(givenStepValue, stepValueRange.minimum, stepValueRange.maximum), speed);
		}

		public virtual void SetRestingPositionWithStepValue(float givenStepValue)
		{
			restingPosition = VRTK_SharedMethods.NormalizeValue(givenStepValue, stepValueRange.minimum, stepValueRange.maximum);
		}

		public virtual float GetPositionFromStepValue(float givenStepValue)
		{
			float value = VRTK_SharedMethods.NormalizeValue(givenStepValue, stepValueRange.minimum, stepValueRange.maximum);
			return Mathf.Lerp(axisLimits.minimum, axisLimits.maximum, Mathf.Clamp01(value));
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
			SetValue(storedValue);
			previousLocalPosition = Vector3.one * float.MaxValue;
			stillResting = false;
			SetupInteractableObject();
			setPositionTargetAtEndOfFrameRoutine = StartCoroutine(SetPositionTargetAtEndOfFrameRoutine());
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			ManageInteractableListeners(state: false);
			if (createInteractableObject)
			{
				Object.Destroy(controlInteractableObject);
			}
			if (setPositionTargetAtEndOfFrameRoutine != null)
			{
				StopCoroutine(setPositionTargetAtEndOfFrameRoutine);
			}
			base.transform.localPosition = Vector3.zero;
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

		protected virtual IEnumerator SetPositionTargetAtEndOfFrameRoutine()
		{
			yield return new WaitForEndOfFrame();
			SetPositionTarget(positionTarget, 0f);
			if (snapToStep)
			{
				SetPositionTargetWithStepValue(GetStepValue(GetValue()), snapForce);
			}
			EmitEvents();
		}

		protected virtual void SetupInteractableObject()
		{
			controlInteractableObject = GetComponent<VRTK_InteractableObject>();
			if (controlInteractableObject == null)
			{
				controlInteractableObject = base.gameObject.AddComponent<VRTK_InteractableObject>();
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
				controlGrabAttach = controlInteractableObject.gameObject.AddComponent<VRTK_MoveTransformGrabAttach>();
				SetGrabMechanicParameters();
				controlInteractableObject.grabAttachMechanicScript = controlGrabAttach;
				ManageGrabbableListeners(state: true);
				controlGrabAttach.ResetState();
			}
		}

		protected virtual void SetGrabMechanicParameters()
		{
			if (controlGrabAttach != null)
			{
				controlGrabAttach.precisionGrab = precisionGrab;
				controlGrabAttach.releaseDecelerationDamper = releaseFriction;
				axisLimits = new Limits2D(originalLocalPosition[(int)operateAxis], MaximumLength()[(int)operateAxis]);
				switch (operateAxis)
				{
				case OperatingAxis.xAxis:
					controlGrabAttach.xAxisLimits = axisLimits;
					break;
				case OperatingAxis.yAxis:
					controlGrabAttach.yAxisLimits = axisLimits;
					break;
				case OperatingAxis.zAxis:
					controlGrabAttach.zAxisLimits = axisLimits;
					break;
				}
				controlGrabAttach.trackingSpeed = trackingSpeed;
				controlGrabAttach.detachDistance = detachDistance;
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

		protected virtual Vector3 MaximumLength()
		{
			return originalLocalPosition + AxisDirection() * maximumLength;
		}

		protected virtual void SetPositionWithNormalizedValue(float givenTargetPosition, float speed)
		{
			float positionOnAxis = Mathf.Lerp(axisLimits.minimum, axisLimits.maximum, Mathf.Clamp01(givenTargetPosition));
			SnapToPosition(positionOnAxis, speed);
		}

		protected virtual void SnapToPosition(float positionOnAxis, float speed)
		{
			if (controlGrabAttach != null)
			{
				controlGrabAttach.SetCurrentPosition(AxisDirection() * Mathf.Sign(maximumLength) * positionOnAxis, speed);
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
			SetGrabMechanicParameters();
		}

		protected virtual void InteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
		{
			SetGrabMechanicParameters();
			if (snapToStep)
			{
				SetPositionTargetWithStepValue(GetStepValue(GetValue()), snapForce);
			}
			if (ForceRestingPosition())
			{
				SetPositionWithNormalizedValue(restingPosition, snapForce);
			}
		}

		protected virtual bool ForceRestingPosition()
		{
			if (forceRestingPositionThreshold > 0f && !IsGrabbed())
			{
				return Mathf.Abs(restingPosition - GetNormalizedValue()) <= forceRestingPositionThreshold;
			}
			return false;
		}

		protected virtual bool IsGrabbed()
		{
			if (controlInteractableObject != null)
			{
				return controlInteractableObject.IsGrabbed();
			}
			return false;
		}

		protected virtual void ManageGrabbableListeners(bool state)
		{
			if (controlGrabAttach != null)
			{
				if (state)
				{
					controlGrabAttach.TransformPositionChanged += GrabMechanicTransformPositionChanged;
				}
				else
				{
					controlGrabAttach.TransformPositionChanged -= GrabMechanicTransformPositionChanged;
				}
			}
		}

		protected virtual void GrabMechanicTransformPositionChanged(object sender, MoveTransformGrabAttachEventArgs e)
		{
			EmitEvents();
		}
	}
}
