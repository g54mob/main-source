using System.Collections;
using DV.CabControls.Spec;
using DV.HUD;
using DV.Interaction;
using UnityEngine;

namespace DV.CabControls
{
	public abstract class WheelBase : ControlImplBase, IScrollable
	{
		private const float INIT_WAIT = 0.5f;

		private const float CHECK_VALUE_CHANGED_PERIOD = 0.02f;

		protected HingeJoint hj;

		protected HingeJointAngleFix hjaf;

		private Coroutine valueChangeCheckCoroutine;

		private float prevAngle;

		protected float diffThreshold = 1f;

		private Quaternion initialLocalRotation;

		protected Wheel spec;

		protected float springStrength = 5f;

		private float scrollWheelHoverScroll;

		private Rigidbody rigidBody;

		private ControlNameHolderBase nameHolder;

		private bool isInitialized;

		protected override InteractionHandPoses GenericHandPoses { get; } = new InteractionHandPoses(HandPose.PreGrab, HandPose.PreGrab, HandPose.Grab);

		protected virtual void Awake()
		{
			initialLocalRotation = base.transform.localRotation;
			spec = GetComponent<Wheel>();
			rigidBody = base.gameObject.AddComponent<Rigidbody>();
			rigidBody.mass = spec.mass;
			rigidBody.angularDrag = spec.angularDrag;
			rigidBody.useGravity = false;
			if (spec.zeroCenterOfMass)
			{
				rigidBody.centerOfMass = Vector3.zero;
			}
			hj = base.gameObject.AddComponent<HingeJoint>();
			ResetParent(forced: true);
			JointSpring spring = new JointSpring
			{
				spring = spec.jointSpring,
				damper = spec.springDamper,
				targetPosition = spec.jointStartingPos
			};
			hj.spring = spring;
			hj.useSpring = spec.useSpring;
			JointLimits limits = new JointLimits
			{
				min = Mathf.Clamp(spec.jointLimitMin, -177f, 177f),
				max = Mathf.Clamp(spec.jointLimitMax, -177f, 177f),
				bounciness = spec.bounciness,
				bounceMinVelocity = spec.bounceMinVelocity
			};
			hj.limits = limits;
			hj.useLimits = spec.useLimits;
			hj.axis = spec.jointAxis;
			hjaf = base.gameObject.AddComponent<HingeJointAngleFix>();
			hjaf.invertPercentage = spec.invertDirection;
			if ((bool)spec.drag && (bool)spec.limitHit)
			{
				LeverAudio leverAudio = base.gameObject.AddComponent<LeverAudio>();
				leverAudio.hitToleranceAngle = spec.hitTolerance;
				leverAudio.dragClip = spec.drag;
				leverAudio.hitClip = spec.limitHit;
			}
			scrollWheelHoverScroll = spec.scrollWheelHoverScroll;
			nameHolder = GetComponent<ControlNameHolderBase>();
			isInitialized = true;
		}

		public override void ResetParent(bool forced = false)
		{
			if (isInitialized || forced)
			{
				hj.connectedBody = base.transform.parent.GetComponentInParentIncludingInactive<Rigidbody>();
			}
		}

		private void OnEnable()
		{
			valueChangeCheckCoroutine = StartCoroutine(CheckValueChange(0.02f));
		}

		private void OnDisable()
		{
			StopAllCoroutines();
		}

		private IEnumerator CheckValueChange(float timeout)
		{
			yield return WaitFor.Seconds(0.5f);
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
				yield return WaitFor.Seconds(timeout);
				float angle = hjaf.Angle;
				if (Mathf.Abs(angle - prevAngle) > diffThreshold)
				{
					prevAngle = angle;
					float num2 = Mathf.InverseLerp(minAngle, maxAngle, angle);
					if (spec.invertDirection)
					{
						num2 = 1f - num2;
					}
					RequestValueUpdate(num2);
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

		public override void BlockControl(bool setBlock)
		{
			base.InteractionAllowed = !setBlock;
		}

		private void SetSpringStrength(float strength)
		{
			JointSpring spring = hj.spring;
			spring.spring = strength;
			hj.spring = spring;
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
				SetSpringStrength(springStrength);
				float num = Mathf.InverseLerp(hj.limits.min, hj.limits.max, hjaf.Angle);
				if (spec.invertDirection)
				{
					num = 1f - num;
				}
				AcceptSetValue(num);
			}
			else
			{
				base.LastSetValueSource = SetValueSource.Default;
				if (base.InteractionAllowed)
				{
					SetSpringStrength(0f);
					rigidBody.AddRelativeTorque(spec.jointAxis * scrollWheelHoverScroll * action.IsPositive().ToDir(), ForceMode.Impulse);
				}
			}
		}

		public bool IsAtEnd(ScrollAction action)
		{
			bool flag = action.IsPositive();
			if (scrollWheelHoverScroll < 0f)
			{
				flag = !flag;
			}
			return Mathf.Approximately(hjaf.Angle, flag ? hj.limits.max : hj.limits.min);
		}
	}
}
