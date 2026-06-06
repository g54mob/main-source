using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PolygonLineRenderer : MonoBehaviour
{
	[SerializeField]
	private Vector3 _offset = new Vector3(0f, -0.1f, 0f);

	[SerializeField]
	private LineRenderer _lineRenderer;

	public void InitializeLocalSpace(IReadOnlyList<Vector2> vertices2D)
	{
		int count = vertices2D.Count;
		_lineRenderer.useWorldSpace = false;
		_lineRenderer.positionCount = count;
		if ((bool)base.transform.parent)
		{
			for (int i = 0; i < count; i++)
			{
				_lineRenderer.SetPosition(i, base.transform.parent.InverseTransformPoint(vertices2D[i].Vector3TopDown()).Vector2TopDown());
			}
		}
		else
		{
			for (int j = 0; j < count; j++)
			{
				_lineRenderer.SetPosition(j, vertices2D[j]);
			}
		}
		_lineRenderer.transform.position += _offset;
	}
}
