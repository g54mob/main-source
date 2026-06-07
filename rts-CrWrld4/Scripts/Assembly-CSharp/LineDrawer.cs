using System;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
	[NonSerialized]
	public List<Vector3> lines;

	public Color lineColor;

	private Material lineMaterial;

	private void Awake()
	{
	}

	private void CreateLineMaterial()
	{
	}

	private void OnRenderObject()
	{
	}
}
