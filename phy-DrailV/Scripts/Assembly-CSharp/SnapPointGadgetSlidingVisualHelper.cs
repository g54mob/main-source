using DV.CabControls.Spec;
using DV.Customization.Gadgets;
using DV.Customization.Gadgets.Implementations;
using DV.Items;
using UnityEngine;

public class SnapPointGadgetSlidingVisualHelper : MonoBehaviour
{
	private SnappableItem snappableItem;

	private (bool valid, Vector3 localPostion) slideData;

	private SnapPointTypes snapPointType;

	private Transform snapPointTarget;

	private bool isVr;

	private SnapPointGadgetSliding snapPoint;

	private void Awake()
	{
		isVr = VRManager.IsVREnabled();
		base.enabled = false;
	}

	public void Initialize(SnapPointTypes snapPointType, SnapPointGadgetSliding snapPoint, Transform snapPointTarget)
	{
		this.snapPointType = snapPointType;
		this.snapPointTarget = snapPointTarget;
		this.snapPoint = snapPoint;
	}

	private void LateUpdate()
	{
		if (snappableItem == null)
		{
			base.enabled = false;
		}
		else if (isVr)
		{
			if (snapPoint == null)
			{
				base.enabled = false;
			}
			else if (!(snapPoint.SnappedItem != null) && snappableItem.Item.IsGrabbed())
			{
				snapPoint.CanSnapCheck(snappableItem, forced: false);
				DrawSnapGhost();
			}
		}
		else
		{
			DrawSnapGhost();
			snappableItem = null;
			slideData = default((bool, Vector3));
			base.enabled = false;
		}
	}

	public void RequestDrawSnapGhost(SnappableItem snappableItem, (bool valid, Vector3 localPostion) slideData)
	{
		this.snappableItem = snappableItem;
		this.slideData = slideData;
		base.enabled = true;
	}

	private void DrawSnapGhost()
	{
		if (!(snappableItem == null))
		{
			Vector3 position = snappableItem.transform.position;
			Quaternion rotation = snappableItem.transform.rotation;
			Vector3 position2 = snapPointTarget.position;
			Quaternion rotation2 = snapPointTarget.rotation;
			Transform anchor = snappableItem.GetAnchor(snapPointType);
			Vector3 anchorPos = anchor.TransformPoint(slideData.valid ? (anchor.localPosition + slideData.localPostion) : anchor.localPosition);
			Quaternion rotation3 = anchor.rotation;
			(Vector3 targetPosition, Quaternion targetRotation) tuple = TransformUtils.CalculateAlignmentTargets(position, rotation, position2, rotation2, anchorPos, rotation3);
			Vector3 item = tuple.targetPosition;
			Quaternion item2 = tuple.targetRotation;
			Color color = (slideData.valid ? GadgetSystemUtility.COLOR_HIGHLIGHT_GOOD : GadgetSystemUtility.COLOR_HIGHLIGHT_BAD);
			GadgetSystemUtility.DrawHighlight(item, item2, snappableItem.HighlightMeshes, color);
		}
	}

	public void RequestDrawSnapGhostVR(SnappableItem hoveredBy, bool draw)
	{
		if (draw)
		{
			snappableItem = hoveredBy;
		}
		else
		{
			snappableItem = null;
			slideData = default((bool, Vector3));
		}
		base.enabled = draw;
	}
}
