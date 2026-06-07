using System.Collections;
using DV.CabControls.VRTK;
using DV.Items;
using DV.Player;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

namespace DV.Customization.Gadgets
{
	public class DrillTool : MountHoleInteractor, HandPositionOverride.IPositionProvider, ItemPositionController.IPositionProvider
	{
		private const float DRILL_PUSH_DISTANCE = 0.15f;

		private const float DRILL_EXIT_THRESHOLD = -0.02f;

		public float processingTime;

		public float drillBitLength;

		[Tooltip("Out of drillBitLength, what percentage of that is material vs air?")]
		public float drillMaterialPercentage = 0.25f;

		[Tooltip("How fast does the item switch between hand position and drilling position")]
		public float vrSnapSpeed = 0.1f;

		[Tooltip("How fast does the item switch between hand position and drilling position")]
		public float nonVRSnapSpeed = 0.2f;

		public ItemWorkingAnimation itemWorkingAnimation;

		private Coroutine coro;

		private float posLerpAmount;

		private Drillable lastTargetDrillable;

		private int lastTargetHoleIndex;

		private VRTK_ControllerReference controllerReference;

		private HandPositionOverride positionOverrideVR;

		private Quaternion anchorLocalToReference;

		private Vector3 localStartPosition;

		private float lastDepth;

		public bool TargetIsValid { get; private set; }

		public float ProcessingProgress { get; private set; }

		int ItemPositionController.IPositionProvider.Priority => 1;

		int HandPositionOverride.IPositionProvider.Priority => 0;

		private void Awake()
		{
			if (VRManager.IsVREnabled())
			{
				return;
			}
			itemWorkingAnimation.minWorkTime = processingTime;
			itemWorkingAnimation.AnimationStarted += delegate
			{
				SingletonBehaviour<ItemPositionController>.Instance.Add(this);
				ProcessingProgress = 0f;
			};
			itemWorkingAnimation.AnimationStopped += delegate
			{
				SingletonBehaviour<ItemPositionController>.Instance.Remove(this);
				ProcessingProgress = 0f;
				TargetIsValid = false;
				base.HighlightFill = 0f;
			};
			itemWorkingAnimation.WorkStarted += delegate
			{
				TargetIsValid = true;
			};
			itemWorkingAnimation.WorkDoneCallback = delegate
			{
				ProcessingProgress = itemWorkingAnimation.WorkProgress;
				base.HighlightFill = ProcessingProgress;
				return false;
			};
			itemWorkingAnimation.WorkStopped += delegate
			{
				if (ProcessingProgress >= 1f)
				{
					lastTargetDrillable.SetMountPointState(lastTargetHoleIndex, MountPoint.States.Mounted);
				}
				TargetIsValid = false;
				ProcessingProgress = 0f;
				base.HighlightFill = 0f;
			};
			itemWorkingAnimation.InputPressedCallback = () => base.IsPressed && GadgetInteractor.IsCameraInInteractionRange(lastTargetDrillable.transform.position);
		}

		protected override bool OnUpdateHoles(Drillable drillable, int holeIndex, bool use)
		{
			if (coro != null)
			{
				return false;
			}
			if (itemWorkingAnimation.IsAnimating)
			{
				return false;
			}
			lastTargetDrillable = drillable;
			lastTargetHoleIndex = holeIndex;
			if (!drillable.CheckIfCanChangeToState(holeIndex, MountPoint.States.Mounted, out var failedDueToSurfaceConditions))
			{
				if (failedDueToSurfaceConditions)
				{
					GadgetInteractor.ShowInteractionTextLMB("interaction/drill_not_here");
				}
				return false;
			}
			GadgetInteractor.ShowInteractionTextLMB("interaction/drill");
			if (base.IsPressed)
			{
				if (VRManager.IsVREnabled())
				{
					if (coro == null)
					{
						coro = StartCoroutine(CoroVR());
					}
				}
				else
				{
					itemWorkingAnimation.StartAnimating();
				}
			}
			return true;
		}

		protected override bool TryGetQueryPose(out Vector3 pos, out Quaternion rot)
		{
			if (VRManager.IsVREnabled())
			{
				pos = vrInteractionPoint.position + vrInteractionPoint.forward * drillBitLength;
				rot = vrInteractionPoint.rotation;
				return true;
			}
			return base.TryGetQueryPose(out pos, out rot);
		}

		protected override void OnGrabbed()
		{
			if (VRManager.IsVREnabled())
			{
				GameObject grabbingObject = base.gameObject.GetComponent<ItemVRTK>().Interactable.GetGrabbingObject();
				controllerReference = VRTK_ControllerReference.GetControllerReference(grabbingObject);
				positionOverrideVR = controllerReference.actual.GetComponentInChildren<HandPositionOverride>();
			}
		}

		protected override void OnUngrabbed()
		{
			if (VRManager.IsVREnabled())
			{
				StopVR();
			}
			else
			{
				itemWorkingAnimation.StopAnimating();
			}
		}

		private void OnDestroy()
		{
			if (VRManager.IsVREnabled())
			{
				StopVR();
			}
			else
			{
				itemWorkingAnimation.StopAnimating();
			}
		}

		public (Vector3 pos, Quaternion rot, float overridePreviousPerc) GetPose(Vector3 pos, Quaternion rot)
		{
			if (lastTargetDrillable == null || lastTargetDrillable.MountPointCount <= lastTargetHoleIndex || lastTargetHoleIndex < 0)
			{
				return (pos: pos, rot: rot, overridePreviousPerc: posLerpAmount);
			}
			MountPoint mountPoint = lastTargetDrillable.GetMountPoint(lastTargetHoleIndex);
			(Vector3, Quaternion) tuple = TransformUtils.CalculateAlignmentTargets(SingletonBehaviour<ItemPositionController>.Instance.itemAnchor, mountPoint.transform, vrInteractionPoint);
			return (pos: tuple.Item1 - mountPoint.transform.forward * (drillBitLength * (1f - ProcessingProgress * drillMaterialPercentage)), rot: tuple.Item2, overridePreviousPerc: ItemWorkingAnimation.EaseInOutCubic(itemWorkingAnimation.MoveToWorkProgress));
		}

		private void StopVR()
		{
			posLerpAmount = 0f;
			ProcessingProgress = 0f;
			TargetIsValid = false;
			base.HighlightFill = 0f;
			lastDepth = 0f;
			if (positionOverrideVR != null)
			{
				positionOverrideVR.Remove(this);
			}
			if (coro != null)
			{
				StopCoroutine(coro);
				coro = null;
			}
		}

		private IEnumerator CoroVR()
		{
			posLerpAmount = 0f;
			ProcessingProgress = 0f;
			positionOverrideVR.Add(this);
			anchorLocalToReference = Quaternion.Inverse(controllerReference.actual.transform.rotation) * vrInteractionPoint.rotation;
			MountPoint point = lastTargetDrillable.GetMountPoint(lastTargetHoleIndex);
			localStartPosition = point.transform.InverseTransformPointUnscaled(controllerReference.actual.transform.position);
			while (posLerpAmount < 1f && base.IsPressed)
			{
				posLerpAmount = Mathf.Min(posLerpAmount + Time.deltaTime / vrSnapSpeed, 1f);
				yield return null;
			}
			float depth = 0f;
			while (ProcessingProgress < 1f && base.IsPressed && depth > -0.02f)
			{
				depth = GetControllerDepth(point);
				float num = depth - ProcessingProgress * drillBitLength * drillMaterialPercentage;
				if (num > 0f)
				{
					float num2 = Mathf.Clamp01(num / 0.15f);
					ProcessingProgress += num2 * Time.deltaTime / processingTime;
					TargetIsValid = true;
					VRTK_ControllerHaptics.TriggerHapticPulse(controllerReference, num2);
				}
				else
				{
					TargetIsValid = false;
				}
				base.HighlightFill = ProcessingProgress;
				yield return null;
			}
			if (ProcessingProgress >= 1f)
			{
				lastTargetDrillable.SetMountPointState(lastTargetHoleIndex, MountPoint.States.Mounted);
			}
			TargetIsValid = false;
			ProcessingProgress = 0f;
			base.HighlightFill = 0f;
			while (depth > -0.02f)
			{
				depth = GetControllerDepth(point);
				yield return null;
			}
			HapticUtils.DoHapticPulse(controllerReference, HapticIntensityType.Normal);
			while (posLerpAmount > 0f)
			{
				posLerpAmount = Mathf.Max(posLerpAmount - Time.deltaTime / vrSnapSpeed, 0f);
				yield return null;
			}
			StopVR();
		}

		private float GetControllerDepth(MountPoint point)
		{
			return point.transform.InverseTransformPointUnscaled(controllerReference.actual.transform.position).z - localStartPosition.z;
		}

		public (Vector3 pos, Quaternion rot, float lerp) GetPose()
		{
			if (lastTargetDrillable == null || lastTargetDrillable.MountPointCount <= lastTargetHoleIndex || lastTargetHoleIndex < 0)
			{
				return (pos: default(Vector3), rot: default(Quaternion), lerp: 0f);
			}
			MountPoint mountPoint = lastTargetDrillable.GetMountPoint(lastTargetHoleIndex);
			Quaternion matchToRot = Quaternion.LookRotation(mountPoint.transform.forward, controllerReference.actual.transform.rotation * anchorLocalToReference * Vector3.up);
			(Vector3, Quaternion) tuple = TransformUtils.CalculateAlignmentTargets(controllerReference.scriptAlias.transform, mountPoint.transform.position, matchToRot, vrInteractionPoint);
			float controllerDepth = GetControllerDepth(mountPoint);
			lastDepth = Mathf.Lerp(b: (mountPoint.State == MountPoint.States.Mounted) ? Mathf.Min(controllerDepth, drillBitLength) : Mathf.Min(controllerDepth, ProcessingProgress * drillBitLength * drillMaterialPercentage), a: lastDepth, t: Time.deltaTime * 5f);
			return (pos: tuple.Item1 - mountPoint.transform.forward * (drillBitLength - lastDepth), rot: tuple.Item2, lerp: posLerpAmount);
		}
	}
}
