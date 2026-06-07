using System;
using UnityEngine;
using UnityEngine.UI;

public class PropertyBox : MonoBehaviour
{
	[Serializable]
	public class PropertyContainer
	{
		public string heading;

		public GameObject obj;
	}

	public Canvas canvas;

	public RectTransform mainTransform;

	public Vector4 screenPadding;

	[Header("Expanded Contents")]
	public GameObject expandedObject;

	public Vector2 baseSize;

	public Vector2 collapsedSize;

	private Vector2 prevSize;

	[Header("Collapsed Contents")]
	public GameObject collapsedObject;

	public Vector2 collapsedPos;

	[Header("Resize")]
	public Vector2 minSize;

	[Header("Main Contents")]
	public Text heading;

	public Text minHeading;

	public PropertyContainer[] propertyContainers;

	public static PropertyBox inst;

	private Vector3 mouseDragStart;

	private Vector3 basePosition;

	private Vector2 baseSizeDelta;

	private Vector2 prevScreen;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void Close()
	{
	}

	public static void Hide()
	{
	}

	private void Clear()
	{
	}

	public static void Load(int id)
	{
	}

	public static void Load(int id, Vector2 overrideSize)
	{
	}

	public void Expand()
	{
	}

	public static void CollapseStatic()
	{
	}

	public void Collapse()
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

	private void Update()
	{
	}
}
