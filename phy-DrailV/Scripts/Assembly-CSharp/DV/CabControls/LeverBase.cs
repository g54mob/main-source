using System.Collections;
using DV.CabControls.Spec;
using DV.HUD;
using DV.Interaction;
using UnityEngine;

namespace DV.CabControls
{
	public abstract class LeverBase : ControlImplBase, IScrollable
	{
		private const float CHECK_VALUE_CHANGED_PERIOD = 0.02f;

		private const float MAX_SCROLL_ANGLE_DELTA = 150f;

		private const float SCROLLING_TARGET_POSITION_RANGE_EXTENDER = 10f;

		protected bool isInitialized;

		protected HingeJointAngleFix hjaf;

		protected HingeJoint hj;

		private float prevAngle;

		protected float diffThreshold = 1f;

		protected Lever spec;

		protected Rigidbody rb;

		private Quaternion initialLocalRotation;

		private SteppedJoint steppedJoint;

		private ControlNameHolderBase nameHolder;

		public bool IsScrollingBlocked { get; set; }

		public bool InvertScrollingDirection { get; set; }

		protected override InteractionHandPoses GenericHandPoses { get; } = new InteractionHandPoses(HandPose.PreGrab, HandPose.PreGrab, HandPose.Grab);

		protected virtual void Awake()
		{
			spec = GetComponent<Lever>();
			nameHolder = GetComponent<ControlNameHolderBase>();
		}

		protected virtual void OnEnable()
		{
			if (!isInitialized)
			{
				StartCoroutine(Initialize());
			}
			if (!spec.useSteppedJoint || !spec.steppedValueUpdate)
			{
				StartCoroutine(CheckValueChange());
			}
		}

		private void OnDisable()
		{
			StopAllCoroutines();
		}

		private IEnumerator Initialize()
		{
			yield return null;
			initialLocalRotation = base.transform.localRotation;
			rb = base.gameObject.AddComponent<Rigidbody>();
			rb.mass = spec.rigidbodyMass;
			rb.drag = spec.rigidbodyDrag;
			rb.angularDrag = spec.rigidbodyAngularDrag;
			rb.useGravity = false;
			if (spec.zeroCenterOfMass)
			{
				rb.centerOfMass = Vector3.zero;
			}
			hj = base.gameObject.AddComponent<HingeJoint>();
			JointSpring spring = new JointSpring
			{
				spring = spec.jointSpring,
				damper = spec.jointDamper
			};
			hj.spring = spring;
			hj.useSpring = spec.useSpring;
			JointLimits limits = new JointLimits
			{
				min = Mathf.Clamp(spec.jointLimitMin, -177f, 177f),
				max = Mathf.Clamp(spec.jointLimitMax, -177f, 177f)
			};
			hj.limits = limits;
			hj.useLimits = spec.useLimits;
			hj.axis = spec.jointAxis;
			ResetParent(forced: true);
			hjaf = base.gameObject.AddComponent<HingeJointAngleFix>();
			hjaf.invertPercentage = spec.invertDirection;
			if (spec.useSteppedJoint)
			{
				steppedJoint = base.gameObject.AddComponent<SteppedJoint>();
				steppedJoint.notches = spec.notches;
				steppedJoint.invertDirection = spec.invertDirection;
				if (spec.steppedValueUpdate)
				{
					steppedJoint.PositionChanged += OnSteppedJointValueChanged;
				}
				steppedJoint.useInnerLimitSpring = spec.useInnerLimitSpring;
				steppedJoint.innerLimitMinNotch = spec.innerLimitMinNotch;
				steppedJoint.innerLimitMaxNotch = spec.innerLimitMaxNotch;
			}
			LeverAudio leverAudio = base.gameObject.AddComponent<LeverAudio>();
			leverAudio.notchClip = spec.notch;
			leverAudio.dragClip = spec.drag;
			leverAudio.hitClip = spec.limitHit;
			leverAudio.hitVibration = spec.limitVibration;
			isInitialized = true;
		}

		public override void ResetParent(bool forced = false)
		{
			if (isInitialized || forced)
			{
				hj.connectedBody = base.transform.parent.GetComponentInParentIncludingInactive<Rigidbody>();
			}
		}

		private void OnSteppedJointValueChanged(ValueChangedEventArgs e)
		{
			float num = e.newValue / (float)(spec.notches + (hj.useLimits ? (-1) : 0));
			if (spec.invertDirection)
			{
				num = 1f - num;
			}
			RequestValueUpdate(num);
		}

		private IEnumerator CheckValueChange()
		{
			while (hjaf == null || hjaf.joint == null || !isInitialized)
			{
				yield return null;
			}
			float minAngle = hj.limits.min;
			float maxAngle = hj.limits.max;
			float num = Mathf.InverseLerp(minAngle, maxAngle, hjaf.Angle);
			if (spec.invertDirection)
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
					if (spec.invertDirection)
					{
						num3 = 1f - num3;
					}
					RequestValueUpdate(num3);
				}
			}
		}

		protected override void AcceptSetValue(float newValue)
		{
			if (isInitialized && !IsGrabbed())
			{
				if (spec.invertDirection)
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

		public void MoveLeverAndReset(float newValue)
		{
			JointSpring spring = hj.spring;
			AcceptSetValue(newValue);
			RequestValueUpdate(newValue);
			spring.targetPosition = 0f;
			hj.spring = spring;
		}

		public override void BlockControl(bool setBlock)
		{
			if (setBlock)
			{
				rb.drag = spec.blockDrag;
				rb.angularDrag = spec.blockAngularDrag;
			}
			else
			{
				rb.drag = spec.rigidbodyDrag;
				rb.angularDrag = spec.rigidbodyAngularDrag;
			}
		}

		private void ScrollWheelRotate(float direction)
		{
			if (!isInitialized)
			{
				return;
			}
			if (steppedJoint != null)
			{
				steppedJoint.isSpringActive = false;
			}
			float num = spec.scrollWheelHoverScroll;
			if (steppedJoint != null)
			{
				num = steppedJoint.SingleNotchAngle * spec.scrollWheelHoverScroll;
			}
			if (spec.invertDirection)
			{
				num = 0f - num;
			}
			num *= direction;
			float num2 = Mathf.Sign(num);
			float num3 = hj.spring.targetPosition;
			if (spec.useLimits)
			{
				if (num2 == 1f && num3 < spec.jointLimitMin)
				{
					num3 = spec.jointLimitMin;
				}
				if (num2 == -1f && num3 > spec.jointLimitMax)
				{
					num3 = spec.jointLimitMax;
				}
			}
			float num4 = spec.jointLimitMin - 10f;
			float num5 = spec.jointLimitMax + 10f;
			if (!spec.useLimits || (num2 < 0f && num3 >= num4) || (num2 > 0f && num3 <= num5))
			{
				num3 += num;
				num3 = Mathf.Clamp(num3, num4, num5);
			}
			if (spec.scrollWheelSpring != 0f)
			{
				SetSpringStrength(spec.scrollWheelSpring);
			}
			SetSpringTarget(num3);
		}

		private void SetSpringTarget(float target)
		{
			JointSpring spring = hj.spring;
			float num = target;
			if (spec.useLimits)
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
				if (!spec.useSteppedJoint)
				{
					SetSpringTarget(0f);
				}
				SetSpringStrength(spec.jointSpring);
				if (steppedJoint != null)
				{
					steppedJoint.isSpringActive = true;
				}
				if (base.gameObject.activeInHierarchy)
				{
					StartCoroutine(ForceAwakenRigidbody());
				}
			}
			else
			{
				base.LastSetValueSource = SetValueSource.Default;
				int num = action.IsPositive().ToDir() * InvertScrollingDirection.ToDir() * -1;
				if (!IsScrollingBlocked)
				{
					ScrollWheelRotate(num);
				}
			}
		}

		public bool IsAtEnd(ScrollAction action)
		{
			bool flag = action.IsPositive();
			if (spec.scrollWheelHoverScroll < 0f)
			{
				flag = !flag;
			}
			return Mathf.Approximately(hjaf.Angle, flag ? hj.limits.max : hj.limits.min);
		}
	}
}
