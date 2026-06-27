using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class ItemSlot : MonoBehaviour
{
	[Header("Runtime State")]
	[Tooltip("The DraggableItem currently held in this slot. Read-only at runtime.")]
	public DraggableItem CurrentItem;

	[Header("Behavior")]
	[Tooltip("If true, placing a new item into an occupied slot ejects the existing item\nback to the drag surface rather than rejecting the new item.")]
	public bool ejectExistingOnNewDrop;

	[Header("Anchor")]
	[Tooltip("If assigned, items placed into this slot are re-parented to this transform.\nIf null, items are re-parented to this slot's transform.")]
	public Transform itemAnchor;

	[Header("Ejection")]
	[Tooltip("Which in-plane axis of the item's DragSurface to launch the ejected item along.\n\nAssumes the DragSurface always uses planeNormalAxis = Forward, so the in-plane\naxes are the surface's local X (Right) and local Y (Up).\n\nPositiveX  : eject toward  +surface.transform.right\nNegativeX  : eject toward  -surface.transform.right  (default — 'left')\nPositiveY  : eject toward  +surface.transform.up\nNegativeY  : eject toward  -surface.transform.up\n\nThe perpendicular in-plane axis is used automatically for spread.\n\nSafe default: NegativeX.")]
	public DraggableItem.EjectAxis ejectAxis;

	[Tooltip("Base distance (world units) the ejected item travels along the eject axis.\nFinal distance = ejectDistance ± ejectDistanceRandomness.\n\nSafe default: 0.8.")]
	public float ejectDistance;

	[Tooltip("Maximum random variance (world units) added to or subtracted from ejectDistance.\nFinal distance = ejectDistance + Random.Range(-ejectDistanceRandomness, +ejectDistanceRandomness).\n\nSet to 0 for a fixed, deterministic eject distance.\n\nSafe default: 0.4.")]
	public float ejectDistanceRandomness;

	[Tooltip("Maximum random spread (world units) applied to the ejected item on the\nperpendicular in-plane axis (i.e. the axis that is NOT the eject axis).\n\nA value of 0 sends every card in a straight line; higher values fan them out.\n\nSafe default: 0.15.")]
	public float spreadAmount;

	[Tooltip("Duration in seconds for the ejected item's slide animation.\n\nSafe default: 0.35.")]
	public float ejectSlideDuration;

	[Header("Events")]
	[Tooltip("Fired when any DraggableItem is successfully placed into this slot.\nThe item's GameObject is passed as the argument.")]
	public UnityEvent<GameObject> onItemAdded;

	[Tooltip("Fired when the item is removed from this slot (by the player dragging it out,\nor by code). The item's GameObject is passed as the argument.")]
	public UnityEvent<GameObject> onItemRemoved;

	[Tooltip("Fired after all placement logic completes and the slot is confirmed occupied.\nNo argument — use onItemAdded to access the item.")]
	public UnityEvent onSlotFilled;

	[Tooltip("Fired after the slot becomes empty (item removed or cleared).")]
	public UnityEvent onSlotCleared;

	[Header("Debug")]
	[Tooltip("If true, logs slot state changes and resolved eject target positions\nto the Console.")]
	public bool debugLogs;

	private BoxCollider boxCol;

	public bool HasItem => false;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	public void PlaceItem(DraggableItem item)
	{
	}

	public void RemoveItem(DraggableItem item, bool autoEject = false)
	{
	}

	public void ClearSlot()
	{
	}

	public bool Overlaps(DraggableItem item)
	{
		return false;
	}

	private static void ResolveEjectAxes(DragSurface surf, DraggableItem.EjectAxis axis, out Vector3 ejectDir, out Vector3 spreadDir)
	{
		ejectDir = default(Vector3);
		spreadDir = default(Vector3);
	}
}
