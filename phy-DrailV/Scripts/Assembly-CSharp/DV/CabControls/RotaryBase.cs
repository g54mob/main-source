using System.Collections;
using DV.CabControls.Spec;
using DV.HUD;
using DV.Interaction;
using UnityEngine;

namespace DV.CabControls
{
	public abstract class RotaryBase : ControlImplBase, IScrollable
	{
		private const float CHECK_VALUE_CHANGED_PERIOD = 0.02f;

		private const float SCROLLING_TARGET_POSITION_RANGE_EXTENDER = 10f;

		private const float MAX_SCROLL_ANGLE_DELTA = 150f;

		protected bool isInitialized;

		protected HingeJoint hj;

		protected HingeJointAngleFix hjaf;

		private float prevAngle;

		protected float diffThreshold = 1f;

		protected Rigidbody rb;

		protected bool isScrollingBlocked;

		private float scrollWheelHoverScroll = 1f;

		private float springStrength;

		private SteppedJoint steppedJoint;

		private Quaternion initialLocalRotation;

		private ControlNameHolderBase nameHolder;

		public Rotary Spec { get; private set; }

		protected override InteractionHandPoses GenericHandPoses { get; } = new InteractionHandPoses(HandPose.Pinch, HandPose.Pinch, HandPose.Pinch);

		protected virtual void Awake()
		{
			nameHolder = GetComponent<ControlNameHolderBase>();
			Spec = GetComponent<Rotary>();
		}

		protected virtual void OnEnable()
		{
			if (!isInitialized)
			{
				StartCoroutine(Initialize());
			}
			StartCoroutine(CheckValueChange());
		}

		private void OnDisable()
		{
			StopAllCoroutines();
		}

		private IEnumerator Initialize()
		{
			if (!base.transform.parent.GetComponentInParent<Rigidbody>())
			{
				yield return null;
			}
			initialLocalRotation = base.transform.localRotation;
			rb = base.gameObject.AddComponent<Rigidbody>();
			rb.mass = Spec.rigidbodyMass;
			rb.angularDrag = Spec.rigidbodyAngularDrag;
			rb.useGravity = false;
			if (Spec.zeroCenterOfMass)
			{
				rb.centerOfMass = Vector3.zero;
			}
			hj = base.gameObject.AddComponent<HingeJoint>();
			ResetParent(forced: true);
			JointSpring spring = new JointSpring
			{
				spring = Spec.jointSpring,
				damper = Spec.jointDamper,
				targetPosition = Spec.jointStartingPos
			};
			hj.spring = spring;
			hj.useSpring = Spec.useSpring;
			JointLimits limits = default(JointLimits);
			if (Spec.useLimits)
			{
				limits.min = Mathf.Clamp(Spec.jointLimitMin, -177f, 177f);
				limits.max = Mathf.Clamp(Spec.jointLimitMax, -177f, 177f);
			}
			limits.bounciness = Spec.bounciness;
			limits.bounceMinVelocity = Spec.bounceMinVelocity;
			hj.limits = limits;
			hj.useLimits = Spec.useLimits;
			hj.axis = Spec.jointAxis;
			hjaf = base.gameObject.AddComponent<HingeJointAngleFix>();
			hjaf.invertPercentage = Spec.invertDirection;
			if (Spec.useSteppedJoint)
			{
				steppedJoint = base.gameObject.AddComponent<SteppedJoint>();
				steppedJoint.notches = Spec.notches;
				steppedJoint.invertDirection = Spec.invertDirection;
				steppedJoint.PositionChanged += OnSteppedJointValueChanged;
				steppedJoint.useInnerLimitSpring = Spec.useInnerLimitSpring;
				steppedJoint.innerLimitMinNotch = Spec.innerLimitMinNotch;
				steppedJoint.innerLimitMaxNotch = Spec.innerLimitMaxNotch;
			}
			if ((bool)Spec.notch && Spec.useSteppedJoint)
			{
				base.gameObject.AddComponent<RotaryAudio>().notchClip = Spec.notch;
			}
			if ((bool)Spec.drag && (bool)Spec.limitHit)
			{
				LeverAudio leverAudio = base.gameObject.AddComponent<LeverAudio>();
				leverAudio.dragClip = Spec.drag;
				leverAudio.hitClip = Spec.limitHit;
			}
			springStrength = Spec.jointSpring;
			scrollWheelHoverScroll = Spec.scrollWheelHoverScroll;
			isInitialized = true;
		}

		public override void ResetParent(bool forced = false)
		{
			if (isInitialized || forced)
			{
				hj.connectedBody = base.transform.parent.GetComponentInParentIncludingInactive<Rigidbody>();
			}
		}

		private IEnumerator CheckValueChange()
		{
			while (Spec == null || !isInitialized)
			{
				yield return null;
			}
			if (Spec.useSteppedJoint)
			{
				yield break;
			}
			float minAngle = hj.limits.min;
			float maxAngle = hj.limits.max;
			float num = Mathf.InverseLerp(minAngle, maxAngle, hjaf.Angle);
			if (Spec.invertDirection)
			{
				num = 1f - num;
			}
			RequestValueUpdate(num);
			prevAngle = hjaf.Angle;
			while (true)
			{
				yield return WaitFor.Seconds(0.02f);
				float angle = hjaf.Angle;
				float num2 = Mathf.Abs(angle - prevAngle);
				if (num2 > diffThreshold || (num2 > 0f && (angle == minAngle || angle == maxAngle)))
				{
					prevAngle = angle;
					float num3 = Mathf.InverseLerp(minAngle, maxAngle, angle);
					if (Spec.invertDirection)
					{
						num3 = 1f - num3;
					}
					RequestValueUpdate(num3);
				}
			}
		}

		private void OnSteppedJointValueChanged(ValueChangedEventArgs e)
		{
			float num = e.newValue / (float)(Spec.notches + (hj.useLimits ? (-1) : 0));
			if (Spec.invertDirection)
			{
				num = 1f - num;
			}
			RequestValueUpdate(num);
		}

		protected override void AcceptSetValue(float newValue)
		{
			if (isInitialized && !IsGrabbed())
			{
				if (Spec.invertDirection)
				{
					newValue = 1f - newValue;
				}
				JointSpring spring = hj.spring;
				float num = Mathf.Lerp(hj.limits.min, hj.limits.max, newValue);
				base.transform.localRotation = initialLocalRotation * Quaternion.AngleAxis(num, hj.axis);
				spring.targetPosition = num;
				prevAngle = num;
				hj.spring = spring;
			}
		}

		public override void BlockControl(bool setBlock)
		{
			if (setBlock)
			{
				rb.angularDrag = Spec.blockAngularDrag;
			}
			else
			{
				rb.angularDrag = Spec.rigidbodyAngularDrag;
			}
		}

		private void ScrollWheelRotate(float direction)
		{
			if (!isInitialized)
			{
				return;
			}
			float num = scrollWheelHoverScroll;
			if (steppedJoint != null)
			{
				num = steppedJoint.SingleNotchAngle * scrollWheelHoverScroll;
			}
			if (Spec.invertDirection)
			{
				num = 0f - num;
			}
			num *= direction;
			float num2 = Mathf.Sign(num);
			float num3 = hj.spring.targetPosition;
			if (Spec.useLimits)
			{
				if (num2 == 1f && num3 < Spec.jointLimitMin)
				{
					num3 = Spec.jointLimitMin;
				}
				if (num2 == -1f && num3 > Spec.jointLimitMax)
				{
					num3 = Spec.jointLimitMax;
				}
			}
			if (!Spec.useLimits || (num2 < 0f && num3 >= Spec.jointLimitMin - 10f) || (num2 > 0f && num3 <= Spec.jointLimitMax + 10f))
			{
				num3 += num;
			}
			SetSpringTarget(num3);
		}

		private void SetSpringTarget(float target)
		{
			JointSpring spring = hj.spring;
			float num = target;
			if (Spec.useLimits)
			{
				num = Mathf.Clamp(num, -177f, 177f);
			}
			else if (num > 180f)
			{
				num -= 360f;
			}
			else if (num < -180f)
			{
				num += 360f;
			}
			spring.targetPosition = Mathf.MoveTowardsAngle(hjaf.Angle, num, 150f);
			hj.spring = spring;
		}

		private void SetSpringStrength(float strength)
		{
			JointSpring spring = hj.spring;
			spring.spring = strength;
			hj.spring = spring;
		}

		private IEnumerator ForceAwakenRigidbody()
		{
			yield return WaitFor.FixedUpdate;
			if (rb == null)
			{
				yield break;
			}
			rb.WakeUp();
			yield return WaitFor.FixedUpdate;
			if (!(rb == null))
			{
				rb.WakeUp();
				yield return WaitFor.FixedUpdate;
				if (!(rb == null))
				{
					rb.WakeUp();
				}
			}
		}

		public override (string value, string unit) GetCurrentPositionName()
		{
			if ((bool)nameHolder)
			{
				return nameHolder.GetName();
			}
			return (value: "", unit: "");
		}

		public void Scroll(ScrollAction action, ScrollSource source = ScrollSource.Mouse)
		{
			if (action == ScrollAction.Release)
			{
				if (!Spec.scrollWheelUseSpringRotation)
				{
					SetSpringStrength(springStrength);
				}
				if (!Spec.useSteppedJoint)
				{
					SetSpringTarget(Spec.jointStartingPos);
				}
				if (base.gameObject.activeInHierarchy)
				{
					StartCoroutine(ForceAwakenRigidbody());
				}
			}
			else
			{
				base.LastSetValueSource = SetValueSource.Default;
				AttemptScroll(action.IsPositive().ToDir());
			}
		}

		private void AttemptScroll(int direction)
		{
			if (!isScrollingBlocked)
			{
				if (Spec.scrollWheelUseSpringRotation)
				{
					ScrollWheelRotate(direction);
					return;
				}
				SetSpringStrength(0f);
				rb.AddRelativeTorque(Spec.jointAxis * scrollWheelHoverScroll * direction, ForceMode.Impulse);
			}
		}

		public bool IsAtEnd(ScrollAction action)
		{
			if (!Spec.useLimits)
			{
				return false;
			}
			bool flag = action.IsPositive();
			if (scrollWheelHoverScroll < 0f)
			{
				flag = !flag;
			}
			return Mathf.Approximately(hjaf.Angle, flag ? hj.limits.max : hj.limits.min);
		}
	}
}
