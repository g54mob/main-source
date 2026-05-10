using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BarcodeDragger : MonoBehaviour
{
	private Camera m_Camera;

	[SerializeField]
	private Transform m_PlaneOrigin;

	private Barcode m_TargetBarcode;

	private ScreenPlaneFollower m_TargetFollower;

	private Vector2 m_DragStart;

	private const float k_DragThreshold = 5f;

	private bool m_IsWaitingDrag;

	private bool dr;

	private bool m_IsDragging
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool IsDragging => false;

	public event Action BarcodeDropped
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action DragStarted
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private void UpdateTargets(Vector3 mousePosition)
	{
	}

	private void OnDragStarted()
	{
	}

	public void ReleaseDrag()
	{
	}
}
