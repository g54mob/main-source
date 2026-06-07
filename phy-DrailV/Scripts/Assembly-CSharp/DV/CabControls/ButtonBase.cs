using System.Collections;
using DV.CabControls.Spec;
using DV.Interaction;
using UnityEngine;

namespace DV.CabControls
{
	public abstract class ButtonBase : ControlImplBase, IScrollable
	{
		private float pushStrength;

		protected Button spec;

		protected bool isInitialized;

		private ConfigurableJoint joint;

		private AudioClip sound;

		private AudioClip toggleOnSound;

		private AudioClip toggleOffSound;

		private bool play2DAudio;

		private bool isToggleOffSoundNeeded;

		private Vector3 defaultLocalPos;

		public bool IsOn => base.Value >= 0.5f;

		public bool IsHoldMode
		{
			get
			{
				if (spec.isToggle)
				{
					return spec.isTogglingBack;
				}
				return false;
			}
		}

		protected override InteractionHandPoses GenericHandPoses { get; } = new InteractionHandPoses(HandPose.Point, HandPose.Point, HandPose.Point);

		protected virtual void Awake()
		{
			spec = GetComponent<Button>();
			defaultLocalPos = base.transform.localPosition;
		}

		protected virtual void OnEnable()
		{
			if (!isInitialized)
			{
				StartCoroutine(Initialize());
			}
		}

		protected virtual void OnDisable()
		{
			if (spec.isTogglingBack && IsOn)
			{
				RequestValueUpdate(0f);
				AcceptSetValue(0f);
			}
		}

		private IEnumerator Initialize()
		{
			yield return null;
			pushStrength = spec.pushStrength;
			sound = spec.press;
			toggleOnSound = spec.toggleOn;
			toggleOffSound = spec.toggleOff;
			play2DAudio = spec.play2DAudio;
			if (spec.createRigidbody)
			{
				Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
				rigidbody.useGravity = false;
				rigidbody.mass = 0.1f;
				rigidbody.isKinematic = !spec.useJoints;
			}
			if (spec.useJoints)
			{
				if (GetComponent<Rigidbody>() == null)
				{
					Debug.LogError("No rb attached, configurable joint will create default one (it will have gravity enabled)!");
				}
				if (spec.linearLimit == 0f)
				{
					Debug.LogError("Joint linear limit must be non-zero", base.gameObject);
				}
				joint = base.gameObject.AddComponent<ConfigurableJoint>();
				ResetParent(forced: true);
				joint.autoConfigureConnectedAnchor = false;
				joint.xMotion = ConfigurableJointMotion.Locked;
				joint.yMotion = ConfigurableJointMotion.Locked;
				joint.zMotion = ConfigurableJointMotion.Limited;
				joint.angularXMotion = ConfigurableJointMotion.Locked;
				joint.angularYMotion = ConfigurableJointMotion.Locked;
				joint.angularZMotion = ConfigurableJointMotion.Locked;
				JointDrive zDrive = new JointDrive
				{
					positionSpring = 5f,
					maximumForce = 100f
				};
				joint.zDrive = zDrive;
				SoftJointLimit linearLimit = new SoftJointLimit
				{
					limit = spec.linearLimit
				};
				joint.linearLimit = linearLimit;
				SetJointTargetPosition(pushStrength);
			}
			isInitialized = true;
		}

		public override void ResetParent(bool forced = false)
		{
			if ((isInitialized || forced) && spec.useJoints)
			{
				joint.connectedBody = base.transform.parent.GetComponentInParentIncludingInactive<Rigidbody>();
			}
		}

		public override void Use()
		{
			if (!base.InteractionAllowed)
			{
				return;
			}
			base.Use();
			if (spec.isToggle)
			{
				int num = ((!IsOn) ? 1 : 0);
				RequestValueUpdate(num);
				AcceptSetValue(num);
				if (num == 1 && PlayButtonSound(toggleOnSound))
				{
					isToggleOffSoundNeeded = true;
				}
				if (num == 0 && isToggleOffSoundNeeded && PlayButtonSound(toggleOffSound))
				{
					isToggleOffSoundNeeded = false;
				}
				if (!toggleOffSound && !toggleOnSound)
				{
					PlayButtonSound(sound);
				}
			}
			else
			{
				if (base.gameObject.activeInHierarchy)
				{
					StartCoroutine(ValueClickCoro());
					AnimateClick();
				}
				PlayButtonSound(sound);
			}
		}

		private bool PlayButtonSound(AudioClip soundToPlay)
		{
			if (soundToPlay == null)
			{
				return false;
			}
			if (play2DAudio)
			{
				soundToPlay.Play2D();
			}
			else
			{
				soundToPlay.Play(base.transform.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
			}
			return true;
		}

		protected override void AcceptSetValue(float newValue)
		{
			if (isInitialized && spec.isToggle)
			{
				if (spec.useJoints)
				{
					SetJointTargetPosition((newValue >= 0.5f) ? (0f - pushStrength) : pushStrength);
				}
				else
				{
					base.transform.localPosition = ((newValue >= 0.5f) ? (defaultLocalPos + spec.pushLocalOffset) : defaultLocalPos);
				}
			}
		}

		public override void BlockControl(bool setBlock)
		{
			base.InteractionAllowed = !setBlock;
		}

		private void AnimateClick()
		{
			if (base.isActiveAndEnabled)
			{
				if (spec.useJoints)
				{
					SetJointTargetPosition(0f - pushStrength);
				}
				else
				{
					base.transform.localPosition = defaultLocalPos + spec.pushLocalOffset;
				}
				StartCoroutine(ToRestingPosition());
			}
		}

		private IEnumerator ValueClickCoro()
		{
			RequestValueUpdate(1f);
			yield return null;
			RequestValueUpdate(0f);
		}

		private IEnumerator ToRestingPosition()
		{
			yield return WaitFor.Seconds(0.1f);
			if (spec.useJoints)
			{
				SetJointTargetPosition(pushStrength);
			}
			else
			{
				base.transform.localPosition = defaultLocalPos;
			}
		}

		private void SetJointTargetPosition(float value)
		{
			if (spec.useJoints)
			{
				joint.targetPosition = new Vector3(0f, 0f, value);
				GetComponent<Rigidbody>().WakeUp();
			}
		}

		public void Scroll(ScrollAction action, ScrollSource source = ScrollSource.Mouse)
		{
			if (!isInitialized || source != ScrollSource.HUD)
			{
				return;
			}
			base.LastSetValueSource = SetValueSource.Default;
			if (action == ScrollAction.Release)
			{
				if (IsHoldMode && IsOn)
				{
					Use();
				}
			}
			else if (base.InteractionAllowed && (!spec.isToggle || IsOn != action.IsPositive()))
			{
				Use();
			}
		}

		public bool IsAtEnd(ScrollAction action)
		{
			return false;
		}
	}
}
