using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectorZoneIndicator : MonoBehaviour
{
	[NonSerialized]
	public bool dirty;

	private int lastX;

	private int lastY;

	private Mesh mesh;

	private MeshFilter meshFilter;

	public Color32 color;

	public float SQUARE_SIZE;

	public bool allOn;

	public TextMeshPro text;

	public float verticalOffset;

	private MeshRenderer meshRenderer;

	private Vector2 deployedPosition;

	private int cellX => 0;

	private int cellY => 0;

	private void Start()
	{
	}

	public void OnEnable()
	{
	}

	public void OnDisable()
	{
	}

	private void LateUpdate()
	{
	}

	public void Refresh()
	{
	}

	public void DeployFootprint(bool deploy)
	{
	}

	protected virtual void DeployFootprint(bool deploy, int cellX, int cellY)
	{
	}

	private void UpdateMesh(List<CollectorZone.ColonizedCell> colonizedCells)
	{
	}
}
