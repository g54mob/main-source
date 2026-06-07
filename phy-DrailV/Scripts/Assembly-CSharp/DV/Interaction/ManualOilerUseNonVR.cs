using DV.CabControls;
using DV.Items;
using DV.Player;
using DV.Simulation.Ports;
using DV.Utils;
using UnityEngine;

namespace DV.Interaction
{
	public class ManualOilerUseNonVR : MonoBehaviour, ItemPositionController.IPositionProvider
	{
		public ItemWorkingAnimation itemWorkingAnimation;

		public Transform interactionPoint;

		private GrabHandlerItem grabHandlerItem;

		private OilingPointPortFeederReader refillingOilingPoint;

		private LayerMask layerMask;

		private Vector3 finishPos;

		private Quaternion finishRot;

		public int Priority => 1;

		private void Start()
		{
			if (VRManager.IsVREnabled())
			{
				Object.Destroy(this);
				return;
			}
			itemWorkingAnimation.AnimationStarted += delegate
			{
				SingletonBehaviour<ItemPositionController>.Instance.Add(this);
			};
			itemWorkingAnimation.AnimationStopped += delegate
			{
				SingletonBehaviour<ItemPositionController>.Instance.Remove(this);
			};
			itemWorkingAnimation.WorkDoneCallback = () => refillingOilingPoint == null;
			itemWorkingAnimation.InputPressedCallback = () => refillingOilingPoint != null && PlayerManager.IsCameraWithinRangeOf(refillingOilingPoint.transform.position, 4f);
			itemWorkingAnimation.WorkStopped += delegate
			{
				finishPos = SingletonBehaviour<ItemPositionController>.Instance.itemAnchor.position;
				finishRot = SingletonBehaviour<ItemPositionController>.Instance.itemAnchor.rotation;
			};
			layerMask = LayerMask.GetMask("Interactable");
			ItemBase component = GetComponent<ItemBase>();
			grabHandlerItem = GetComponent<GrabHandlerItem>();
			component.Grabbed += OnGrabbedChanged;
			component.Ungrabbed += OnGrabbedChanged;
			component.Used += OnUsed;
			component.UnUsed += OnUnUsed;
			OnGrabbedChanged(component);
		}

		private void OnDestroy()
		{
			itemWorkingAnimation.StopAnimating();
		}

		private void OnGrabbedChanged(ControlImplBase item)
		{
			base.enabled = item.IsGrabbed();
			if (!base.enabled)
			{
				itemWorkingAnimation.StopAnimating();
			}
		}

		private void Update()
		{
			if (!itemWorkingAnimation.IsAnimating)
			{
				RaycastHit hit;
				OilingPointPortFeederReader oilingPoint;
				bool flag = ScanHit(out hit) && PointingAtOpenOilingPoint(hit, out oilingPoint);
				if ((bool)SingletonBehaviour<InteractionTextControllerNonVr>.Instance && flag)
				{
					SingletonBehaviour<InteractionTextControllerNonVr>.Instance.DisplayText(InteractionInfoType.OilerRefill);
				}
			}
		}

		private void OnUsed()
		{
			if (ScanHit(out var hit) && PointingAtOpenOilingPoint(hit, out var oilingPoint))
			{
				refillingOilingPoint = oilingPoint;
				refillingOilingPoint.SetRefill(1f);
				itemWorkingAnimation.StartAnimating();
			}
		}

		private void OnUnUsed()
		{
			if (!(refillingOilingPoint == null))
			{
				refillingOilingPoint.SetRefill(0f);
				refillingOilingPoint = null;
			}
		}

		private bool PointingAtOpenOilingPoint(RaycastHit potentialHit, out OilingPointPortFeederReader oilingPoint)
		{
			oilingPoint = null;
			Transform transform = potentialHit.collider?.transform?.parent;
			if (transform != null && transform.TryGetComponent<OilingPointPortFeederReader>(out oilingPoint) && oilingPoint.TryGetComponent<OilingPointReactionOnControlChange>(out var component))
			{
				return component.OilingPointOpened;
			}
			return false;
		}

		private bool ScanHit(out RaycastHit hit)
		{
			hit = default(RaycastHit);
			Grabber grabber = grabHandlerItem.GetGrabber();
			if (grabber == null)
			{
				return false;
			}
			return Physics.Raycast(grabber.Cursor.GetRay(), out hit, 4f, layerMask, QueryTriggerInteraction.Collide);
		}

		public (Vector3 pos, Quaternion rot, float overridePreviousPerc) GetPose(Vector3 pos, Quaternion rot)
		{
			float item = ItemWorkingAnimation.EaseInCubic(itemWorkingAnimation.MoveToWorkProgress);
			if (itemWorkingAnimation.WorkDone)
			{
				return (pos: finishPos, rot: finishRot, overridePreviousPerc: item);
			}
			Transform transform = ((refillingOilingPoint != null) ? refillingOilingPoint.transform : null);
			if (transform == null)
			{
				return default((Vector3, Quaternion, float));
			}
			Quaternion matchToRot = Quaternion.LookRotation(-transform.up, transform.right);
			if (Vector3.Dot(transform.right, rot * Vector3.forward) < 0f)
			{
				matchToRot *= Quaternion.AngleAxis(180f, Vector3.forward);
			}
			(Vector3, Quaternion) tuple = TransformUtils.CalculateAlignmentTargets(SingletonBehaviour<ItemPositionController>.Instance.itemAnchor, transform.position, matchToRot, interactionPoint);
			return (pos: tuple.Item1, rot: tuple.Item2, overridePreviousPerc: item);
		}
	}
}
