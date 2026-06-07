using UnityEngine;

public class BoxWindow : MonoBehaviour
{
	public bool awakeOn;

	public Canvas canvas;

	public RectTransform mainTransform;

	public Vector4 screenPadding;

	[Header("Expanded Contents")]
	public GameObject expandedObject;

	public Vector2 baseSize;

	public Vector2 collapsedSize;

	protected Vector2 prevSize;

	[Header("Collapsed Contents")]
	public GameObject collapsedObject;

	public Vector2 collapsedPos;

	[Header("Resize")]
	public Vector2 minSize;

	private Vector3 mouseDragStart;

	private Vector3 basePosition;

	private Vector2 baseSizeDelta;

	private Vector2 prevScreen;

	protected virtual void Update()
	{
	}

	private void Start()
	{
	}

	public virtual void Close()
	{
	}

	public virtual void Hide()
	{
	}

	public virtual void Display()
	{
	}

	public virtual void Expand()
	{
	}

	public virtual void Collapse()
	{
	}

	public void Drag()
	{
	}

	public void BeginDrag()
	{
	}

	public void ResizeDrag()
	{
	}

	private void Clamp()
	{
	}

	public void BeginResizeDrag()
	{
	}

	private void BasePosition()
	{
	}

	public virtual void SizeUpdated()
	{
	}
}
