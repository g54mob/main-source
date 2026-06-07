using UnityEngine;

namespace VRTK.Controllables.PhysicsBased
{
	[AddComponentMenu("VRTK/Scripts/Interactables/Controllables/Physics/VRTK_PhysicsPusher")]
	public class VRTK_PhysicsPusher : VRTK_BasePhysicsControllable
	{
		[Header("Pusher Settings")]
		[Tooltip("The local space distance along the `Operate Axis` until the pusher reaches the pressed position.")]
		public float pressedDistance = 0.1f;

		[Tooltip("If this is checked then the pusher will stay in the pressed position when it reaches the maximum position.")]
		public bool stayPressed;

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
		public float positionTarget;

		[Tooltip("The amount of force to apply to push the pusher towards the intended target position.")]
		public float targetForce = 10f;

		protected ConfigurableJoint controlJoint;

		protected bool createControlJoint;

		protected Vector3 previousLocalPosition;

		protected bool pressedDown;

		protected float previousPositionTarget;

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

		public virtual ConfigurableJoint GetControlJoint()
		{
			return controlJoint;
		}

		protected override void OnDrawGizmosSelected()
		{
			base.OnDrawGizmosSelected();
			Vector3 vector = AxisDirection(local: true) * (base.transform.lossyScale[(int)operateAxis] * 0.5f);
			Vector3 vector2 = base.transform.position + vector * Mathf.Sign(pressedDistance);
			Vector3 vector3 = vector2 + AxisDirection(local: true) * pressedDistance;
			Gizmos.DrawLine(vector2, vector3);
			Gizmos.DrawSphere(vector3, 0.01f);
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			SetupJoint();
			previousLocalPosition = Vector3.one * float.MaxValue;
			pressedDown = false;
		}

		protected override void OnDisable()
		{
			if (stayPressed && pressedDown)
			{
				previousPositionTarget = positionTarget;
				positionTarget = 1f;
			}
			if (createControlJoint)
			{
				Object.Destroy(controlJoint);
			}
			base.OnDisable();
		}

		protected virtual void FixedUpdate()
		{
			SetRigidbodyVelocity(Vector3.zero);
			ForceLocalPosition();
		}

		protected virtual void Update()
		{
			CheckUnpress();
			SetTargetPosition();
			EmitEvents();
			if (!pressedDown && stayPressed && AtMaxLimit())
			{
				StayPressed();
			}
		}

		protected override void ConfigueRigidbody()
		{
			SetRigidbodyGravity(useGravity: false);
			SetRigidbodyCollisionDetectionMode(CollisionDetectionMode.ContinuousDynamic);
			SetRigidbodyConstraints(RigidbodyConstraints.FreezeRotation);
		}

		protected override void EmitEvents()
		{
			bool flag = !VRTK_SharedMethods.Vector3ShallowCompare(base.transform.localPosition, previousLocalPosition, equalityFidelity);
			if (!flag && positionTarget == 1f && !VRTK_SharedMethods.Vector3ShallowCompare(base.transform.localPosition, base.transform.localPosition + pressedDistance * AxisDirection(), equalityFidelity))
			{
				Vector3 zero = Vector3.zero;
				for (int i = 0; i < 3; i++)
				{
					zero[i] = ((i == (int)operateAxis) ? (originalLocalPosition[i] + pressedDistance) : base.transform.localPosition[i]);
				}
				base.transform.localPosition = zero;
				flag = true;
			}
			if (flag)
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
					StayPressed();
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
			if (IsResting())
			{
				OnRestingPointReached(EventPayload());
			}
			previousLocalPosition = base.transform.localPosition;
		}

		protected virtual void ForceLocalPosition()
		{
			float x = ((operateAxis == OperatingAxis.xAxis) ? base.transform.localPosition.x : originalLocalPosition.x);
			float y = ((operateAxis == OperatingAxis.yAxis) ? base.transform.localPosition.y : originalLocalPosition.y);
			float z = ((operateAxis == OperatingAxis.zAxis) ? base.transform.localPosition.z : originalLocalPosition.z);
			base.transform.localPosition = new Vector3(x, y, z);
		}

		protected virtual void CheckUnpress()
		{
			if (!stayPressed && pressedDown)
			{
				SetRigidbodyConstraints(RigidbodyConstraints.FreezeRotation);
				positionTarget = previousPositionTarget;
				pressedDown = false;
			}
		}

		protected virtual void SetTargetPosition()
		{
			if (controlJoint != null)
			{
				controlJoint.targetPosition = AxisDirection() * Mathf.Sign(pressedDistance) * Mathf.Lerp(controlJoint.linearLimit.limit, 0f - controlJoint.linearLimit.limit, positionTarget);
			}
		}

		protected virtual Vector3 PressedPosition()
		{
			return originalLocalPosition + AxisDirection() * pressedDistance;
		}

		protected virtual void SetupJoint()
		{
			base.transform.localPosition = originalLocalPosition + AxisDirection() * (pressedDistance * 0.5f);
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
				JointDrive jointDrive = new JointDrive
				{
					positionSpring = 1000f,
					positionDamper = 10f,
					maximumForce = targetForce
				};
				controlJoint.xDrive = jointDrive;
				controlJoint.yDrive = jointDrive;
				controlJoint.zDrive = jointDrive;
				SoftJointLimit linearLimit = new SoftJointLimit
				{
					limit = Mathf.Abs(pressedDistance * 0.5f)
				};
				controlJoint.linearLimit = linearLimit;
				controlJoint.connectedBody = connectedTo;
			}
		}

		protected virtual void StayPressed()
		{
			if (stayPressed)
			{
				SetRigidbodyConstraints(RigidbodyConstraints.FreezeAll);
				pressedDown = true;
			}
		}
	}
}
