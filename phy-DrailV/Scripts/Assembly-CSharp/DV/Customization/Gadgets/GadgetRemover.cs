using DV.CabControls.VRTK;
using DV.Common;
using DV.Items;
using DV.Player;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

namespace DV.Customization.Gadgets
{
	public class GadgetRemover : GadgetInteractor, ItemPositionController.IPositionProvider
	{
		public AudioClip soundOnGadgetRemoved;

		public float vrSpeedThreshold;

		public ItemWorkingAnimation itemWorkingAnimation;

		private ItemVelocityEstimator vel;

		private ItemSimulationSpace simulationSpace;

		private Vector3 lastPositionRelativeToSimSpace;

		private VRTK_ControllerReference controllerReference;

		private ItemPositionController.OGPoseAnimationHelper animationPoseHelper;

		private GadgetBase targetGadget;

		private Vector3 startingLocalPos;

		private Transform startingTransformReference;

		public override bool CallRegularUpdateWhenNull => true;

		private bool AnimationBlocking
		{
			get
			{
				if (itemWorkingAnimation.IsAnimating)
				{
					return !itemWorkingAnimation.WorkDone;
				}
				return false;
			}
		}

		int ItemPositionController.IPositionProvider.Priority => 1;

		private void Awake()
		{
			if (VRManager.IsVREnabled())
			{
				vel = GetComponent<ItemVelocityEstimator>();
				simulationSpace = GetComponent<ItemSimulationSpace>();
				return;
			}
			itemWorkingAnimation.AnimationStarted += delegate
			{
				SingletonBehaviour<ItemPositionController>.Instance.Add(this);
				animationPoseHelper.SetAnimationStartValues();
			};
			itemWorkingAnimation.AnimationStopped += delegate
			{
				SingletonBehaviour<ItemPositionController>.Instance.Remove(this);
			};
			itemWorkingAnimation.WorkDoneCallback = delegate
			{
				GadgetBase component = animationPoseHelper.animationTarget.GetComponent<GadgetBase>();
				(Vector3, Quaternion) tuple = (animationPoseHelper.animationTarget.position, animationPoseHelper.animationTarget.rotation);
				Transform animationTarget = component.Custom.transform;
				Remove(component);
				animationPoseHelper.animationTarget = animationTarget;
				animationPoseHelper.SetAnimationStopValues(tuple.Item1, tuple.Item2);
				return true;
			};
			itemWorkingAnimation.InputPressedCallback = () => true;
		}

		private void OnDestroy()
		{
			if (!VRManager.IsVREnabled())
			{
				itemWorkingAnimation.StopAnimating();
			}
		}

		protected override HighlightMode OnUpdate(GadgetBase hoveredTarget, bool use)
		{
			if (AnimationBlocking || !GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.HammeringGadgets))
			{
				return HighlightMode.None;
			}
			if (VRManager.IsVREnabled())
			{
				Vector3 pointVelocity = base.transform.GetPointVelocity(base.transform.TransformPoint(vrInteractionPoint.localPosition), vel.GetWorldVelocityEstimate(), vel.GetWorldAngularVelocityEstimate());
				if (pointVelocity.magnitude > vrSpeedThreshold)
				{
					Vector3 vector = simulationSpace.TransformPoint(lastPositionRelativeToSimSpace);
					Vector3 vector2 = vrInteractionPoint.position - vector;
					if (vector2 != Vector3.zero && (from h in PhysicsQueryBuilder.Raycast(vector, vector2, vector2.magnitude, (Layers.DVLayerMask.Train_Interior | Layers.DVLayerMask.Interactable).ToLayerMask())
						where h.collider.GetComponentInParent<GadgetBase>()
						select h).TryGetFirst(out var hit))
					{
						hoveredTarget = hit.collider.GetComponentInParent<GadgetBase>();
						if (Vector3.Dot(pointVelocity, vrInteractionPoint.forward) > 0.5f && CanRemoveTarget(hoveredTarget))
						{
							Remove(hoveredTarget);
							return HighlightMode.None;
						}
					}
				}
				lastPositionRelativeToSimSpace = simulationSpace.InverseTransformPoint(vrInteractionPoint.position);
			}
			if (hoveredTarget == null || !CanRemoveTarget(hoveredTarget))
			{
				return HighlightMode.None;
			}
			if (use && !AnimationBlocking)
			{
				if (VRManager.IsVREnabled())
				{
					Remove(hoveredTarget);
				}
				else
				{
					animationPoseHelper.animationTarget = hoveredTarget.transform;
					itemWorkingAnimation.StartAnimating();
				}
			}
			GadgetInteractor.ShowInteractionTextLMB("interaction/remove");
			return HighlightMode.Bad;
		}

		private GadgetItem Remove(GadgetBase target)
		{
			GadgetItem gadgetItem = target.Remove();
			if (gadgetItem != null)
			{
				soundOnGadgetRemoved?.Play(base.transform.position);
				if (VRManager.IsVREnabled())
				{
					HapticUtils.DoHapticPulse(controllerReference, HapticIntensityType.Normal);
				}
			}
			return gadgetItem;
		}

		private bool CanRemoveTarget(GadgetBase target)
		{
			return target.CanBeRemovedUsingMethod(GadgetBase.GadgetRemovalMethod.Remover);
		}

		protected override void OnGrabbed()
		{
			if (VRManager.IsVREnabled())
			{
				GameObject grabbingObject = base.gameObject.GetComponent<ItemVRTK>().Interactable.GetGrabbingObject();
				controllerReference = VRTK_ControllerReference.GetControllerReference(grabbingObject);
			}
		}

		protected override void OnUngrabbed()
		{
			if (!VRManager.IsVREnabled())
			{
				itemWorkingAnimation.StopAnimating();
			}
		}

		public (Vector3 pos, Quaternion rot, float overridePreviousPerc) GetPose(Vector3 pos, Quaternion rot)
		{
			return animationPoseHelper.GetPose(vrInteractionPoint, itemWorkingAnimation);
		}
	}
}
