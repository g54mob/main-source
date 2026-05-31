using System;
using System.Collections.Generic;
using UnityEngine;
using __Project__.Scripts.WallPaintSystem;

public class FurniturePlacer : MonoBehaviour
{
	[SerializeField]
	private float m_MaxRaycastDistanceForward;

	[SerializeField]
	private float m_MaxRaycastDistanceDownward;

	[SerializeField]
	private float m_MaxRaycastDistanceSide;

	[SerializeField]
	[Range(0f, 1f)]
	private float m_MovingObjectSmoothness;

	[SerializeField]
	private float m_ScalingDownAnimationTime;

	[SerializeField]
	private float m_AngleSnapValue;

	[SerializeField]
	private float m_WallAngleSnapValue;

	[SerializeField]
	private Material m_HologramMaterial;

	[SerializeField]
	private LayerMask m_FurniturePlacingLayer;

	private FurniturePlacingMode m_CurrentPlacingMode;

	private Camera m_Camera;

	private List<LayerMask> m_CurrentObjectCollidersLayer;

	private bool m_PlacingMode;

	private List<string> m_CurrentPlacingTag;

	private Ray m_Ray;

	private RaycastHit m_HitInfo;

	private PlayerInstance m_OwnPlayerInstance;

	public Action<GameObject> OnFurniturePlaced;

	public Action<GameObject> OnFurnitureBoxUp;

	public Action<GameObject> OnFurnitureStartPlacingMode;

	public FurniturePlacingMode CurrentPlacingMode
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public List<string> CurrentPlacingTag
	{
		set
		{
		}
	}

	public float ScalingDownAnimationTime => 0f;

	public PlayerInstance OwnPlayerInstance => null;

	public bool PlacingMode => false;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	public void StartPlacingMode()
	{
	}

	public void Rotate(bool clockvise)
	{
	}

	public void PlaceFurniture()
	{
	}

	public void CancelPlaceFurnitureForOnlyMultiplayer()
	{
	}

	public bool CheckPlaceFurniture()
	{
		return false;
	}

	public void BoxUp()
	{
	}

	public void BoxUp(PaintBucket bucket)
	{
	}

	private void StopPlacingMode()
	{
	}

	private void PlacingRaycast()
	{
	}

	private void MoveFurniture(Vector3 targetPos)
	{
	}

	private float GetNearestSnapAngle(float angle)
	{
		return 0f;
	}
}
