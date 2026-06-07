using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
	public enum DragMode
	{
		None = 0,
		Distance = 1,
		DistanceAndTime = 2
	}

	public Mask mask;

	public RewiredEnum[] interactionButtons;

	public CursorGestaltEnum mouseHoverCursor;

	public CursorGestaltEnum interactionCursor;

	public UnityEvent onInteractionDown;

	public UnityEvent onInteractionUp;

	public UnityEvent onInteractionClick;

	public UnityEvent onInteractionDrag;

	public UnityEvent onInteractionStop;

	public DragMode dragMode;

	private const float dragDistanceThreshold = 0.5f;

	private const float dragTimeThreshold = 0.25f;

	private Vector2 interactionPoint;

	private float interactionDownTime;

	public bool interactable;

	public bool interacting { get; protected set; }

	public bool dragging { get; protected set; }

	public bool isMouseHover { get; private set; }

	public virtual bool InteractionEnabled()
	{
		return false;
	}

	public virtual CursorGestaltEnum OnInteractionHover()
	{
		return default(CursorGestaltEnum);
	}

	public virtual void OnInteractionLeave()
	{
	}

	public virtual void OnInteractionDown()
	{
	}

	public virtual void OnInteractionUp()
	{
	}

	public virtual void OnInteractionStop()
	{
	}

	public virtual CursorGestaltEnum OnInteractionUpdate()
	{
		return default(CursorGestaltEnum);
	}

	public virtual void OnDragStart()
	{
	}

	public virtual bool IsValidInteractionPosition(Vector2 position)
	{
		return false;
	}

	public virtual void Update()
	{
	}
}
