using System;
using System.Collections;
using DV.CabControls.Spec;
using DV.HUD;
using DV.Interaction;
using DV.Utils;
using UnityEngine;

namespace DV.CabControls
{
	public abstract class ToggleSwitchBase : ControlImplBase, IScrollable
	{
		private const float SCROLL_DEBOUNCE_TIME = 0.25f;

		private HingeJoint joint;

		private HingeJointAngleFix hjaf;

		private ControlNameHolderBase nameHolder;

		protected ToggleSwitch spec;

		protected bool isInitialized;

		public float autoOffTimer;

		private float lastScrollInteractionTime;

		private Coroutine autoOffCoro;

		private HingeJoint hj;

		public bool IsOn => (double)base.Value >= 0.5;

		protected override InteractionHandPoses GenericHandPoses { get; } = new InteractionHandPoses(HandPose.Point, HandPose.Point, HandPose.Point);

		protected virtual void Awake()
		{
			spec = GetComponent<ToggleSwitch>();
			autoOffTimer = spec.autoOffTimer;
			if (autoOffTimer > 0f)
			{
				TrainCarInteriorObject componentInParent = base.transform.GetComponentInParent<TrainCarInteriorObject>();
				if (componentInParent != null)
				{
					componentInParent.actualTrainCar.InteriorAboutToBeUnloaded += OnInteriorAboutToBeUnloaded;
				}
			}
			nameHolder = GetComponent<ControlNameHolderBase>();
		}

		private void OnInteriorAboutToBeUnloaded(GameObject loadedInterior)
		{
			TrainCar trainCar = TrainCar.Resolve(base.transform);
			if (trainCar == null)
			{
				Debug.LogError("Unexpected state: OnInteriorAboutToBeUnloaded can't be executed, ToggleSwitchBase not part of car. Something is wrong!", base.gameObject);
				return;
			}
			trainCar.InteriorAboutToBeUnloaded -= OnInteriorAboutToBeUnloaded;
			if (autoOffCoro != null)
			{
				SingletonBehaviour<CoroutineManager>.Instance.Stop(autoOffCoro);
				autoOffCoro = null;
				AutoOff();
			}
		}

		protected override void Start()
		{
			Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
			rigidbody.mass = spec.rbMass;
			rigidbody.useGravity = false;
			if (spec.zeroCenterOfMass)
			{
				rigidbody.centerOfMass = Vector3.zero;
			}
			hj = base.gameObject.AddComponent<HingeJoint>();
			ResetParent(forced: true);
			JointSpring spring = new JointSpring
			{
				spring = 2000f
			};
			hj.spring = spring;
			hj.useSpring = true;
			JointLimits limits = new JointLimits
			{
				min = spec.jointLimitMin,
				max = spec.jointLimitMax
			};
			hj.limits = limits;
			hj.useLimits = true;
			hj.axis = spec.jointAxis;
			hjaf = base.gameObject.AddComponent<HingeJointAngleFix>();
			if ((bool)spec.toggle)
			{
				base.gameObject.AddComponent<ToggleSwitchAudio>().switchClip = spec.toggle;
			}
			joint = GetComponent<HingeJoint>();
			if (joint == null)
			{
				throw new Exception("ToggleSwitch needs a HingeJoint");
			}
			if (joint.spring.spring == 0f)
			{
				Debug.LogError("Joint spring is 0, switch will not work", base.gameObject);
			}
			if (!joint.useLimits)
			{
				Debug.LogError("Joint needs to have limits set", base.gameObject);
			}
			SetJointTargetPosition(IsOn ? joint.limits.max : joint.limits.min);
			isInitialized = true;
		}

		protected virtual void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading && autoOffCoro != null)
			{
				SingletonBehaviour<CoroutineManager>.Instance.Stop(autoOffCoro);
			}
		}

		public override void ResetParent(bool forced = false)
		{
			if (isInitialized || forced)
			{
				hj.connectedBody = base.transform.parent.GetComponentInParentIncludingInactive<Rigidbody>();
			}
		}

		private void SetJointTargetPosition(float value)
		{
			JointSpring spring = new JointSpring
			{
				spring = joint.spring.spring,
				damper = joint.spring.damper,
				targetPosition = value
			};
			joint.spring = spring;
		}

		public override void Use()
		{
			if (!base.InteractionAllowed)
			{
				return;
			}
			base.Use();
			float newValue = ((!IsOn) ? 1 : 0);
			RequestValueUpdate(newValue);
			AcceptSetValue(newValue);
			if (IsOn && autoOffTimer > 0f)
			{
				base.InteractionAllowed = false;
				if (autoOffCoro != null)
				{
					SingletonBehaviour<CoroutineManager>.Instance.Stop(autoOffCoro);
				}
				autoOffCoro = SingletonBehaviour<CoroutineManager>.Instance.Run(AutoOffCoro());
			}
		}

		protected override void AcceptSetValue(float newValue)
		{
			if (isInitialized)
			{
				SetJointTargetPosition((newValue >= 0.5f) ? joint.limits.max : joint.limits.min);
			}
		}

		public override void BlockControl(bool setBlock)
		{
			base.InteractionAllowed = !setBlock;
		}

		private IEnumerator AutoOffCoro()
		{
			yield return WaitFor.Seconds(autoOffTimer);
			yield return WaitFor.EndOfFrame;
			AutoOff();
			autoOffCoro = null;
		}

		private void AutoOff()
		{
			base.InteractionAllowed = true;
			if (IsOn)
			{
				Use();
			}
		}

		public bool IsAtEnd(bool scrollUp)
		{
			return false;
		}

		private void ScrollUse(bool state)
		{
			if (isInitialized && state && Time.time - lastScrollInteractionTime > 0.25f)
			{
				Use();
				lastScrollInteractionTime = Time.time;
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
			if (base.InteractionAllowed && action != ScrollAction.Release)
			{
				base.LastSetValueSource = SetValueSource.Default;
				ScrollUse(action.IsPositive() ? (!IsOn) : IsOn);
			}
		}

		public bool IsAtEnd(ScrollAction action)
		{
			return false;
		}
	}
}
