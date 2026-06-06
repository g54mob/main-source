using System;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineRendererCircle : MonoBehaviour
{
	[SerializeField]
	private float _radius = 10f;

	[SerializeField]
	private int _points = 8;

	[SerializeField]
	private LineRenderer _lineRenderer;

	[ContextMenu("Set Circle Positions")]
	public void SetCirclePositions()
	{
		float num = 360f / (float)_points;
		Vector3[] array = new Vector3[_points];
		for (int i = 0; i < _points; i++)
		{
			array[i] = new Vector3(Mathf.Cos(num * (float)i * (MathF.PI / 180f)) * _radius, Mathf.Sin(num * (float)i * (MathF.PI / 180f)) * _radius, 0f);
		}
		_lineRenderer.positionCount = _points;
		_lineRenderer.SetPositions(array);
	}
}
