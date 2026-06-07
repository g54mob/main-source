using DV.CabControls;
using DV.Items;
using DV.Items.Snapping;
using DV.Localization;
using DV.Utils;
using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	public class SnapPointGadgetSliding : SnapPointGadget
	{
		private const float SLIDE_ANGLE_HORIZONTAL_THRESHOLD = 0.25f;

		[SerializeField]
		private float cylinderRadius = 0.025f;

		private LayerMask layerMask;

		private Drillable drillable;

		private SnapPointGadgetSlidingVisualHelper visualHelper;

		protected override void Awake()
		{
			base.Awake();
			layerMask = LayerMask.GetMask("Default", "Train_Interior", "Terrain");
			drillable = GetComponentInParent<Drillable>();
			visualHelper = base.gameObject.AddComponent<SnapPointGadgetSlidingVisualHelper>();
			visualHelper.Initialize(base.SnapPointType, this, (snapPointTarget != null) ? snapPointTarget : base.transform);
		}

		public override bool CanSnapCheck(SnappableItem snappableItem, bool forced)
		{
			if (!base.CanSnapCheck(snappableItem, forced))
			{
				return false;
			}
			Transform anchor = snappableItem.GetAnchor(base.SnapPointType);
			SnapPointAnchorSliding snapPointAnchorSliding = ((anchor != null) ? anchor.GetComponent<SnapPointAnchorSliding>() : null);
			if (snapPointAnchorSliding == null)
			{
				return false;
			}
			bool flag = VRManager.IsVREnabled();
			if (drillable != null && drillable.AttachedPointCount <= 0)
			{
				if (!flag)
				{
					SingletonBehaviour<InteractionTextControllerNonVr>.Instance.DisplayText(LocalizationAPI.L("interaction/gadget_placement/mount_not_secured"));
				}
				return false;
			}
			(bool, Vector3) slideData = CalculateSlide(snappableItem, snapPointAnchorSliding);
			if (!flag && !slideData.Item1)
			{
				SingletonBehaviour<InteractionTextControllerNonVr>.Instance.DisplayText(LocalizationAPI.L("interaction/gadget_placement/obstructed"));
			}
			visualHelper.RequestDrawSnapGhost(snappableItem, slideData);
			return slideData.Item1;
		}

		private (bool valid, Vector3 localPostion) CalculateSlide(SnappableItem snappableItem, SnapPointAnchorSliding slidingAnchor)
		{
			ItemBase itemBase = ((snappableItem != null) ? snappableItem.Item : null);
			if (itemBase == null || slidingAnchor == null)
			{
				return default((bool, Vector3));
			}
			bool flag = Mathf.Abs(Vector3.Dot(base.transform.forward, Vector3.up)) > 0.25f;
			Vector3 initialLocalPosition = slidingAnchor.InitialLocalPosition;
			Bounds previewBounds = itemBase.InventorySpecs.PreviewBounds;
			Vector3 center = previewBounds.center;
			Vector3 extents = previewBounds.extents;
			float z = (initialLocalPosition - center).z;
			float num = Mathf.Max(extents.x, extents.y, extents.z);
			if (!flag)
			{
				var (point, point2) = GetOverlapCapsulePoints(z, num);
				if (OverlapSpaceCheck(point, point2))
				{
					return (valid: true, localPostion: slidingAnchor.InitialLocalPosition);
				}
				return default((bool, Vector3));
			}
			Vector3 position = base.transform.position;
			PhysicsQueryBuilder.QueryResults queryResults = from t in PhysicsQueryBuilder.SphereCast(distance: num - z - cylinderRadius + slidingAnchor.SlidingOffsetRange.y, origin: position, radius: cylinderRadius, direction: base.transform.forward, layerMask: layerMask)
				where t.collider != null && t.collider.GetComponentInParent<GadgetBase>() != gadgetBase
				select t;
			bool flag2 = queryResults.Length > 0;
			Vector3 vector = (flag2 ? queryResults[0].point : Vector3.zero);
			PhysicsQueryBuilder.QueryResults queryResults2 = from t in PhysicsQueryBuilder.SphereCast(distance: num + z - cylinderRadius - slidingAnchor.SlidingOffsetRange.x, origin: position, radius: cylinderRadius, direction: -base.transform.forward, layerMask: layerMask)
				where t.collider != null && t.collider.GetComponentInParent<GadgetBase>() != gadgetBase
				select t;
			bool flag3 = queryResults2.Length > 0;
			Vector3 vector2 = (flag3 ? queryResults2[0].point : Vector3.zero);
			bool flag4 = Vector3.Dot(Vector3.up, base.transform.forward) < 0f;
			Vector3 vector3 = new Vector3(0f, 0f, slidingAnchor.SlidingOffsetRange.y);
			Vector3 vector4 = new Vector3(0f, 0f, slidingAnchor.SlidingOffsetRange.x);
			if (!flag2 && !flag3)
			{
				return (valid: true, localPostion: flag4 ? (-vector3) : (-vector4));
			}
			if (flag2 && flag3)
			{
				Vector3 vector5 = base.transform.InverseTransformPoint(vector);
				Vector3 vector6 = base.transform.InverseTransformPoint(vector2);
				if (Mathf.Abs(vector5.z - vector6.z) - 2f * num < 0f)
				{
					return default((bool, Vector3));
				}
				float num2 = vector5.z - num + z;
				if (num2 < 0f)
				{
					return default((bool, Vector3));
				}
				float num3 = vector6.z + num + z;
				if (num3 > 0f)
				{
					return default((bool, Vector3));
				}
				if (Vector3.Dot(vector - base.transform.position, Vector3.up) < 0f)
				{
					vector4 = new Vector3(0f, 0f, Mathf.Max(num2, vector4.z));
					flag4 = false;
				}
				else
				{
					vector3 = new Vector3(0f, 0f, Mathf.Min(num3, vector3.z));
					flag4 = true;
				}
				Vector3 item = (flag4 ? (-vector3) : (-vector4));
				item.x = slidingAnchor.transform.localPosition.x;
				item.y = slidingAnchor.transform.localPosition.y;
				return (valid: true, localPostion: item);
			}
			if (flag2)
			{
				Vector3 vector7 = base.transform.InverseTransformPoint(vector);
				float num4 = vector7.z - num + z;
				if (num4 < vector4.z)
				{
					return default((bool, Vector3));
				}
				vector7.x = slidingAnchor.transform.localPosition.x;
				vector7.y = slidingAnchor.transform.localPosition.y;
				if (Vector3.Dot(vector - base.transform.position, Vector3.up) < 0f)
				{
					vector4 = new Vector3(0f, 0f, Mathf.Max(num4, vector4.z));
					flag4 = false;
				}
			}
			else
			{
				Vector3 vector8 = base.transform.InverseTransformPoint(vector2);
				float num5 = vector8.z + num + z;
				if (num5 > vector3.z)
				{
					return default((bool, Vector3));
				}
				vector8.x = slidingAnchor.transform.localPosition.x;
				vector8.y = slidingAnchor.transform.localPosition.y;
				if (Vector3.Dot(vector2 - base.transform.position, Vector3.up) < 0f)
				{
					vector3 = new Vector3(0f, 0f, Mathf.Min(num5, vector3.z));
					flag4 = true;
				}
			}
			Vector3 item2 = (flag4 ? (-vector3) : (-vector4));
			return (valid: true, localPostion: item2);
		}

		private bool OverlapSpaceCheck(Vector3 point0, Vector3 point1)
		{
			return (from t in PhysicsQueryBuilder.OverlapCapsule(point0, point1, cylinderRadius, layerMask)
				where t.collider != null && t.collider.GetComponentInParent<GadgetBase>() != gadgetBase
				select t).Length <= 0;
		}

		private (Vector3 point0, Vector3 point1) GetOverlapCapsulePoints(float offset, float halfSize)
		{
			Vector3 item = base.transform.position + base.transform.forward * (halfSize - offset - cylinderRadius - 0.005f);
			Vector3 item2 = base.transform.position - base.transform.forward * (halfSize + offset - cylinderRadius - 0.005f);
			return (point0: item, point1: item2);
		}

		public override bool SnapItem(ItemBase itemToSnap, bool forced = false)
		{
			Transform anchor = itemToSnap.SnappableItem.GetAnchor(base.SnapPointType);
			SnapPointAnchorSliding snapPointAnchorSliding = ((anchor != null) ? anchor.GetComponent<SnapPointAnchorSliding>() : null);
			if (snapPointAnchorSliding == null)
			{
				return false;
			}
			(bool, Vector3) tuple = CalculateSlide(itemToSnap.SnappableItem, snapPointAnchorSliding);
			if (!tuple.Item1)
			{
				return false;
			}
			anchor.transform.localPosition = tuple.Item2;
			return base.SnapItem(itemToSnap, forced);
		}

		public override bool UnsnapItem(bool forced = false)
		{
			SnappableItem snappableItem = ((base.SnappedItem != null) ? base.SnappedItem.SnappableItem : null);
			Transform transform = ((snappableItem != null) ? snappableItem.GetAnchor(base.SnapPointType) : null);
			if (transform == null)
			{
				return false;
			}
			SnapPointAnchorSliding component = transform.GetComponent<SnapPointAnchorSliding>();
			if (component == null)
			{
				return false;
			}
			if (!base.UnsnapItem(forced))
			{
				return false;
			}
			component.Reset();
			return true;
		}

		public override void HoverVR(SnappableItem hoveredBy, bool hovered)
		{
			base.HoverVR(hoveredBy, hovered);
			visualHelper.RequestDrawSnapGhostVR(hoveredBy, hovered);
		}
	}
}
