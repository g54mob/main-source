using System;
using DV.CabControls.VRTK;
using DV.Highlighting;
using DV.Items;
using DV.Player;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

namespace DV.Customization.Gadgets.Implementations
{
	public class HoleFiller : GadgetInteractor, ItemPositionController.IPositionProvider
	{
		public AudioClip soundOnFill;

		public ItemWorkingAnimation itemWorkingAnimation;

		private VRTK_ControllerReference controllerReference;

		private Customization customization;

		private Customization fillingCustomization;

		private HighlightTag oldHole;

		private Collider hole;

		public override bool CallRegularUpdateWhenNull => true;

		protected override Predicate<RaycastHitDV> QueryPredicate => delegate(RaycastHitDV hit)
		{
			Transform transform = TrainCar.Resolve(hit.collider.transform)?.transform ?? hit.collider.transform;
			customization = transform.GetComponentInParent<Customization>();
			return !VRManager.IsVREnabled() || customization != null;
		};

		public int Priority => 1;

		private void Awake()
		{
			if (VRManager.IsVREnabled())
			{
				return;
			}
			itemWorkingAnimation.AnimationStarted += delegate
			{
				SingletonBehaviour<ItemPositionController>.Instance.Add(this);
				fillingCustomization = customization;
			};
			itemWorkingAnimation.AnimationStopped += delegate
			{
				SingletonBehaviour<ItemPositionController>.Instance.Remove(this);
			};
			itemWorkingAnimation.WorkStarted += delegate
			{
				if (soundOnFill != null)
				{
					soundOnFill.Play(base.transform.position);
				}
			};
			itemWorkingAnimation.WorkStopped += delegate
			{
				if (itemWorkingAnimation.WorkProgress == 1f)
				{
					fillingCustomization.RemoveHole(hole);
				}
			};
			itemWorkingAnimation.InputPressedCallback = () => base.IsPressed && GadgetInteractor.IsCameraInInteractionRange(hole.transform.position);
		}

		protected override HighlightMode OnUpdate(GadgetBase target, bool use)
		{
			ClearOldHighlight();
			if (!base.RaycastHit.collider)
			{
				return HighlightMode.None;
			}
			if (customization == null)
			{
				return HighlightMode.None;
			}
			if (!customization.IsHole(base.RaycastHit.collider))
			{
				return HighlightMode.None;
			}
			oldHole = base.RaycastHit.collider.gameObject.GetComponent<HighlightTag>();
			SingletonBehaviour<AGeneralHighlighter>.Instance.ToggleHighlight(on: true, oldHole, AGeneralHighlighter.HighlightType.Generic, useObstructedMaterial: true);
			if (itemWorkingAnimation.IsAnimating)
			{
				return HighlightMode.None;
			}
			if (use)
			{
				if (VRManager.IsVREnabled())
				{
					if (customization.RemoveHole(base.RaycastHit.collider))
					{
						if (soundOnFill != null)
						{
							soundOnFill.Play(base.transform.position);
						}
						HapticUtils.DoHapticPulse(controllerReference, HapticIntensityType.Normal);
					}
				}
				else
				{
					hole = base.RaycastHit.collider;
					itemWorkingAnimation.StartAnimating();
				}
			}
			GadgetInteractor.ShowInteractionTextLMB("interaction/hole_filler");
			return HighlightMode.Good;
		}

		private void ClearOldHighlight()
		{
			SingletonBehaviour<AGeneralHighlighter>.Instance.ToggleHighlight(on: false, oldHole, AGeneralHighlighter.HighlightType.Generic, useObstructedMaterial: true);
		}

		protected override void OnUngrabbed()
		{
			ClearOldHighlight();
			if (!VRManager.IsVREnabled())
			{
				itemWorkingAnimation.StopAnimating();
			}
		}

		protected override void OnGrabbed()
		{
			if (VRManager.IsVREnabled())
			{
				GameObject grabbingObject = base.gameObject.GetComponent<ItemVRTK>().Interactable.GetGrabbingObject();
				controllerReference = VRTK_ControllerReference.GetControllerReference(grabbingObject);
			}
		}

		private void OnDestroy()
		{
			if (!VRManager.IsVREnabled())
			{
				itemWorkingAnimation.StopAnimating();
			}
		}

		public (Vector3 pos, Quaternion rot, float overridePreviousPerc) GetPose(Vector3 pos, Quaternion rot)
		{
			if (hole == null)
			{
				return (pos: default(Vector3), rot: default(Quaternion), overridePreviousPerc: 0f);
			}
			Vector3 upwards = Vector3.Normalize(hole.transform.position - PlayerManager.ActiveCamera.transform.position);
			Quaternion quaternion = Quaternion.LookRotation(hole.transform.forward, upwards);
			(Vector3, Quaternion) tuple = TransformUtils.CalculateAlignmentTargets(SingletonBehaviour<ItemPositionController>.Instance.itemAnchor, hole.transform.position, quaternion * Quaternion.Euler(Mathf.Lerp(-15f, 15f, ItemWorkingAnimation.EaseInOutCubic(itemWorkingAnimation.WorkProgress)), 180f, 0f), vrInteractionPoint);
			return (pos: tuple.Item1, rot: tuple.Item2, overridePreviousPerc: ItemWorkingAnimation.EaseOutCubic(itemWorkingAnimation.MoveToWorkProgress));
		}
	}
}
