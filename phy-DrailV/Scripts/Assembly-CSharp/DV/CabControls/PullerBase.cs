using System.Collections;
using System.Collections.Generic;
using DV.CabControls.Spec;
using DV.HUD;
using DV.Interaction;
using UnityEngine;

namespace DV.CabControls
{
	public abstract class PullerBase : ControlImplBase, IScrollable
	{
		private const float CHECK_VALUE_CHANGED_PERIOD = 0.02f;

		private static int ItemLayerMask;

		private ConfigurableJoint cj;

		private float prevVal;

		private float scrollWheelHoverScroll;

		protected Puller spec;

		private ControlNameHolderBase nameHolder;

		private Collider[] overlapHits;

		protected bool hasInsideVolume;

		private bool isInitialized;

		private HashSet<Rigidbody> moveAlongHashSet = new HashSet<Rigidbody>();

		protected override InteractionHandPoses GenericHandPoses { get; } = new InteractionHandPoses(HandPose.PreGrab, HandPose.PreGrab, HandPose.Grab);

		protected virtual void Awake()
		{
			spec = GetComponent<Puller>();
			hasInsideVolume = spec.insideVolume != null;
			if (hasInsideVolume)
			{
				if (ItemLayerMask == 0)
				{
					ItemLayerMask = LayerMask.GetMask("World_Item");
				}
				overlapHits = new Collider[5];
			}
			if (spec.linearLimit == 0f)
			{
				Debug.LogError("Joint linear limit must be non-zero", base.gameObject);
			}
			Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
			rigidbody.mass = spec.rigidbodyMass;
			rigidbody.drag = spec.rigidbodyDrag;
			rigidbody.useGravity = false;
			if (spec.zeroCenterOfMass)
			{
				rigidbody.centerOfMass = Vector3.zero;
			}
			cj = base.gameObject.AddComponent<ConfigurableJoint>();
			ResetParent(forced: true);
			if (spec.useCustomConnectionAnchor)
			{
				cj.autoConfigureConnectedAnchor = false;
				cj.connectedAnchor = cj.connectedBody.transform.InverseTransformPoint(spec.connectionAnchor.position);
			}
			cj.xMotion = ConfigurableJointMotion.Locked;
			cj.yMotion = ConfigurableJointMotion.Limited;
			cj.zMotion = ConfigurableJointMotion.Locked;
			cj.angularXMotion = ConfigurableJointMotion.Locked;
			cj.angularYMotion = ConfigurableJointMotion.Locked;
			cj.angularZMotion = ConfigurableJointMotion.Locked;
			SoftJointLimit linearLimit = new SoftJointLimit
			{
				limit = spec.linearLimit
			};
			cj.linearLimit = linearLimit;
			if ((spec.drag != null && spec.limitHit != null) || (bool)spec.notch)
			{
				PullerAudio pullerAudio = base.gameObject.AddComponent<PullerAudio>();
				pullerAudio.dragClip = spec.drag;
				pullerAudio.hitClip = spec.limitHit;
				pullerAudio.notchClip = spec.notch;
			}
			if (spec.useSteppedPuller)
			{
				SteppedPuller steppedPuller = base.gameObject.AddComponent<SteppedPuller>();
				steppedPuller.notches = spec.notches;
				steppedPuller.invertEventDelta = spec.invertDirection;
				steppedPuller.PositionChanged += OnSteppedPullerValueChanged;
			}
			scrollWheelHoverScroll = spec.scrollWheelHoverScroll;
			nameHolder = GetComponent<ControlNameHolderBase>();
			isInitialized = true;
		}

		public override void ResetParent(bool forced = false)
		{
			if (isInitialized || forced)
			{
				cj.connectedBody = base.transform.parent.GetComponentInParentIncludingInactive<Rigidbody>();
			}
		}

		private void OnEnable()
		{
			if (!spec.useSteppedPuller)
			{
				StartCoroutine(CheckValueChange());
			}
		}

		private void OnDisable()
		{
			StopAllCoroutines();
		}

		private void OnSteppedPullerValueChanged(ValueChangedEventArgs e)
		{
			float num = e.newValue / (float)spec.notches;
			if (spec.invertDirection)
			{
				num = 1f - num;
			}
			RequestValueUpdate(num);
		}

		private IEnumerator CheckValueChange()
		{
			while (!isInitialized)
			{
				yield return null;
			}
			float num = GetNormalizedPosition();
			if (spec.invertDirection)
			{
				num = 1f - num;
			}
			RequestValueUpdate(num);
			prevVal = num;
			while (true)
			{
				yield return WaitFor.Seconds(0.02f);
				float num2 = GetNormalizedPosition();
				if (num2 != prevVal)
				{
					prevVal = num2;
					if (spec.invertDirection)
					{
						num2 = 1f - num2;
					}
					RequestValueUpdate(num2);
				}
			}
		}

		public float GetTotalLinearLimitLength()
		{
			return 2f * cj.linearLimit.limit;
		}

		public float GetNormalizedPosition()
		{
			return Mathf.Round(Mathf.Clamp01(Mathf.Abs(base.transform.localPosition.y) / GetTotalLinearLimitLength()) * 100f) / 100f;
		}

		public void SetNormalizedPosition(float percentPulled, bool moveItems = true)
		{
			percentPulled = Mathf.Clamp01(percentPulled);
			Vector3 position = base.transform.position;
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, -1f * percentPulled * GetTotalLinearLimitLength(), base.transform.localPosition.z);
			if (moveItems)
			{
				MoveItemsAlong(position);
			}
		}

		protected void MoveItemsAlong(Vector3 oldPosition)
		{
			if (!hasInsideVolume)
			{
				return;
			}
			Vector3 position = base.transform.position;
			Vector3 vector = position - oldPosition;
			int num = Physics.OverlapBoxNonAlloc(spec.insideVolume.transform.TransformPoint(spec.insideVolume.center) - vector, spec.insideVolume.size / 2f, overlapHits, spec.insideVolume.transform.rotation, ItemLayerMask);
			Vector3 vector2 = position - oldPosition;
			RaycastUtils.ExtendOnCacheFull(ref overlapHits, num);
			for (int i = 0; i < num; i++)
			{
				Rigidbody attachedRigidbody = overlapHits[i].attachedRigidbody;
				if (moveAlongHashSet.Add(attachedRigidbody) && attachedRigidbody.TryGetComponent<ItemBase>(out var component) && !component.IsGrabbed() && !component.IsSnapped)
				{
					attachedRigidbody.transform.position += vector2;
				}
			}
			moveAlongHashSet.Clear();
		}

		protected override void AcceptSetValue(float newValue)
		{
			if (isInitialized && !IsGrabbed())
			{
				if (spec.invertDirection)
				{
					newValue = 1f - newValue;
				}
				SetNormalizedPosition(newValue);
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

		public override void BlockControl(bool setBlock)
		{
			base.InteractionAllowed = !setBlock;
		}

		public void Scroll(ScrollAction action, ScrollSource source = ScrollSource.Mouse)
		{
			if (base.InteractionAllowed && action != ScrollAction.Release)
			{
				base.LastSetValueSource = SetValueSource.Default;
				SetNormalizedPosition(GetNormalizedPosition() + scrollWheelHoverScroll * (float)action.IsPositive().ToDir());
			}
		}

		public bool IsAtEnd(ScrollAction action)
		{
			bool flag = action.IsPositive();
			if (scrollWheelHoverScroll < 0f)
			{
				flag = !flag;
			}
			return Mathf.Approximately(GetNormalizedPosition(), flag ? 1 : 0);
		}
	}
}
