using System;
using UnityEngine;

public class TransformHandle : MonoBehaviour
{
	[Header("Display")]
	public float baseScale;

	public Camera handleCam;

	public Canvas canvas;

	public Vector2 finishOffset;

	public RectTransform rotTr;

	[Header("Components")]
	public RectTransform origin;

	public RectTransform xHandle;

	public RectTransform yHandle;

	public RectTransform xyHandle;

	public RectTransform rotHandle;

	[Header("Attached Object")]
	public BaseComponent attachedComp;

	public static TransformHandle inst;

	public static float ScalingFactor;

	private Camera cam;

	private RectTransform tr;

	private Action valueChangedAction;

	private Vector2 handleDir;

	private Vector3 handlePoint;

	private Vector3 currentPoint;

	private Vector3 nearP;

	private void Awake()
	{
	}

	public static void Display(BaseComponent c, Action a)
	{
	}

	public static void Refresh()
	{
	}

	public static void Hide()
	{
	}

	private void LateUpdate()
	{
	}

	public void DragRot()
	{
	}

	public void InitDragX()
	{
	}

	public void DragX()
	{
	}

	public void InitDragY()
	{
	}

	public void DragY()
	{
	}

	private void RefreshPhysics()
	{
	}

	public void DragXY()
	{
	}

	private Vector3 RoundTo(Vector3 vec, int val)
	{
		return default(Vector3);
	}

	private Vector3 IntersectPoint(Vector3 rayVector, Vector3 rayPoint, Vector3 planeNormal, Vector3 planePoint)
	{
		return default(Vector3);
	}

	private Vector2 FindNearestPointOnLine(Vector2 origin, Vector2 direction, Vector2 point)
	{
		return default(Vector2);
	}
}
