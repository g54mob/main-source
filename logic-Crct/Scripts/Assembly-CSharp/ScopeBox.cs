using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ScopeBox : MonoBehaviour
{
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

	[Header("Scope Frame")]
	public RectTransform scopeFrame;

	public ScopeTool scopeTool;

	public Material lineMat;

	public int lineCall;

	[Header("X Axis")]
	public RectTransform[] xAxisNumbers;

	[Header("Current Axis")]
	public Text currentLabel;

	public Text currentMaxText;

	public Text currentMinText;

	public RectTransform currentZeroText;

	[Header("Voltage Axis")]
	public Text voltLabel;

	public Text voltMaxText;

	public Text voltMinText;

	public RectTransform voltZeroText;

	public bool dispCurrent;

	public bool dispVoltage;

	private Vector3 numPos;

	private int i;

	private Vector3 lowerRight;

	private Vector2 currentMaxMin;

	private float currentRange;

	private Vector2 prevCurrentMaxMin;

	private Vector2 voltMaxMin;

	private float voltRange;

	private Vector2 prevVoltMaxMin;

	private float currentScaleTx;

	private float voltageScaleT;

	private Vector3 mouseDragStart;

	private Vector3 basePosition;

	private Vector2 baseSizeDelta;

	private Vector2 prevScreen;

	private void Update()
	{
	}

	private void OnGUI()
	{
	}

	private void Start()
	{
	}

	public void Close()
	{
	}

	public void Hide()
	{
	}

	public void Display()
	{
	}

	public void Expand()
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
}
