using System.Collections;
using UnityEngine;

namespace VRTK.Controllables.ArtificialBased
{
	[AddComponentMenu("VRTK/Scripts/Interactables/Controllables/Artificial/VRTK_ArtificialPusher")]
	public class VRTK_ArtificialPusher : VRTK_BaseControllable
	{
		[Header("Pusher Settings")]
		[Tooltip("The distance along the `Operate Axis` until the pusher reaches the pressed position.")]
		public float pressedDistance = 0.1f;

		[Tooltip("If this is checked then the pusher will stay in the pressed position when it reaches the pressed position.")]
		[SerializeField]
		protected bool stayPressed;

		[Tooltip("The threshold in which the pusher's current normalized position along the `Operate Axis` has to be within the minimum and maximum limits of the pusher.")]
		[Range(0f, 1f)]
		public float minMaxLimitThreshold = 0.01f;

		[Tooltip("The normalized position of the pusher between the original position and the pressed position that will be considered as the resting position for the pusher.")]
		[Range(0f, 1f)]
		public float restingPosition;

		[Tooltip("The normalized value that the pusher can be from the `Resting Position` before the pusher is considered to be resting when not being interacted with.")]
		[Range(0f, 1f)]
		public float restingPositionThreshold = 0.01f;

		[Tooltip("The normalized position of the pusher between the original position and the pressed position. `0f` will set the pusher position to the original position, `1f` will set the pusher position to the pressed position.")]
		[Range(0f, 1f)]
		[SerializeField]
		protected float positionTarget;

		[Tooltip("The speed in which the pusher moves towards to the `Pressed Distance` position.")]
		public float pressSpeed = 10f;

		[Tooltip("The speed in which the pusher will return to the `Target Position` of the pusher.")]
		public float returnSpeed = 10f;

		protected Coroutine positionLerpRoutine;

		protected Coroutine setTargetPositionRoutine;

		protected float vectorEqualityThreshold = 0.001f;

		protected bool isPressed;

		protected bool isMoving;

		protected bool isTouched;

		public override float GetValue()
		{
			return base.transform.localPosition[(int)operateAxis];
		}

		public override float GetNormalizedValue()
		{
			return VRTK_SharedMethods.NormalizeValue(GetValue(), originalLocalPosition[(int)operateAxis], PressedPosition()[(int)operateAxis]);
		}

		public override void SetValue(float value)
		{
		}

		public override bool IsResting()
		{
			float normalizedValue = GetNormalizedValue();
			if (interactingCollider == null)
			{
				if (normalizedValue < restingPosition + restingPositionThreshold)
				{
					return normalizedValue > restingPosition - restingPositionThreshold;
				}
				return false;
			}
			return false;
		}

		public virtual void SetStayPressed(bool state)
		{
			stayPressed = state;
			if (!stayPressed && AtPressedPosition())
			{
				SetToRestingPosition();
			}
		}

		public virtual void SetPositionTarget(float normalizedTarget)
		{
			positionTarget = Mathf.Clamp01(normalizedTarget);
			SetTargetPosition();
		}

		protected override void OnDrawGizmosSelected()
		{
			base.OnDrawGizmosSelected();
			Vector3 vector = AxisDirection(local: true) * (base.transform.lossyScale[(int)operateAxis] * 0.5f);
			Vector3 vector2 = actualTransformPosition + vector * Mathf.Sign(pressedDistance);
			Vector3 vector3 = vector2 + AxisDirection(local: true) * pressedDistance;
			Gizmos.DrawLine(vector2, vector3);
			Gizmos.DrawSphere(vector3, 0.01f);
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			isPressed = false;
			isMoving = false;
			isTouched = false;
			setTargetPositionRoutine = StartCoroutine(SetTargetPositionAtEndOfFrame());
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			CancelPositionLerp();
			CancelSetTargetPosition();
		}

		protected override void EmitEvents()
		{
			float normalizedValue = GetNormalizedValue();
			ControllableEventArgs e = EventPayload();
			OnValueChanged(e);
			float num = minMaxLimitThreshold;
			float num2 = 1f - minMaxLimitThreshold;
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
			if (IsResting())
			{
				OnRestingPointReached(e);
			}
		}

		protected override void OnTouched(Collider collider)
		{
			if ((VRTK_PlayerObject.IsPlayerObject(collider.gameObject) && !VRTK_PlayerObject.IsPlayerObject(collider.gameObject, VRTK_PlayerObject.ObjectTypes.Controller)) || (bool)collider.GetComponent<VRTK_InteractNearTouchCollider>())
			{
				return;
			}
			base.OnTouched(collider);
			if (!isMoving)
			{
				Vector3 targetPosition = ((!stayPressed && AtPressedPosition()) ? originalLocalPosition : PressedPosition());
				float moveSpeed = ((!stayPressed && AtPressedPosition()) ? returnSpeed : pressSpeed);
				if (!AtTargetPosition(targetPosition))
				{
					positionLerpRoutine = StartCoroutine(PositionLerp(targetPosition, moveSpeed));
				}
			}
			isTouched = true;
		}

		protected override void OnUntouched(Collider collider)
		{
			isTouched = false;
		}

		protected virtual void SetTargetPosition()
		{
			base.transform.localPosition = Vector3.Lerp(originalLocalPosition, PressedPosition(), (stayPressed && AtPressedPosition()) ? 1f : positionTarget);
			EmitEvents();
		}

		protected virtual Vector3 PressedPosition()
		{
			return originalLocalPosition + AxisDirection() * pressedDistance;
		}

		protected virtual void CancelPositionLerp()
		{
			if (positionLerpRoutine != null)
			{
				StopCoroutine(positionLerpRoutine);
			}
			positionLerpRoutine = null;
		}

		protected virtual void CancelSetTargetPosition()
		{
			if (setTargetPositionRoutine != null)
			{
				StopCoroutine(setTargetPositionRoutine);
			}
			setTargetPositionRoutine = null;
		}

		protected virtual IEnumerator PositionLerp(Vector3 targetPosition, float moveSpeed)
		{
			while (!VRTK_SharedMethods.Vector3ShallowCompare(base.transform.localPosition, targetPosition, vectorEqualityThreshold))
			{
				yield return null;
				isMoving = true;
				base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, targetPosition, moveSpeed * Time.deltaTime);
				EmitEvents();
			}
			base.transform.localPosition = targetPosition;
			isMoving = false;
			EmitEvents();
			ManageAtPressedPosition();
			ManageAtOriginPosition();
		}

		protected virtual IEnumerator SetTargetPositionAtEndOfFrame()
		{
			yield return new WaitForEndOfFrame();
			SetTargetPosition();
		}

		protected virtual void ManageAtPressedPosition()
		{
			if (AtPressedPosition())
			{
				if (stayPressed)
				{
					ResetInteractor();
				}
				else
				{
					SetToRestingPosition();
				}
			}
		}

		protected virtual void ManageAtOriginPosition()
		{
			if (AtOriginPosition() && !isTouched)
			{
				ResetInteractor();
			}
		}

		protected virtual bool AtOriginPosition()
		{
			return VRTK_SharedMethods.Vector3ShallowCompare(base.transform.localPosition, originalLocalPosition, vectorEqualityThreshold);
		}

		protected virtual bool AtPressedPosition()
		{
			return VRTK_SharedMethods.Vector3ShallowCompare(base.transform.localPosition, PressedPosition(), vectorEqualityThreshold);
		}

		public virtual bool AtTargetPosition(Vector3 targetPosition)
		{
			return VRTK_SharedMethods.Vector3ShallowCompare(base.transform.localPosition, targetPosition, vectorEqualityThreshold);
		}

		protected virtual void ResetInteractor()
		{
			interactingCollider = null;
			interactingTouchScript = null;
		}

		protected virtual void SetToRestingPosition()
		{
			positionLerpRoutine = StartCoroutine(PositionLerp(Vector3.Lerp(originalLocalPosition, PressedPosition(), restingPosition), returnSpeed));
		}
	}
}
