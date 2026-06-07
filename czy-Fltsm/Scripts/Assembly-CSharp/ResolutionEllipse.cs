using System;
using UnityEngine;

[Serializable]
public class ResolutionEllipse
{
	[SerializeField]
	[Range(0f, 1f)]
	private float _widthFill = 0.8f;

	[SerializeField]
	[Range(0f, 1f)]
	private float _heightFill = 0.8f;

	public Vector2 ReturnPoint(float angle)
	{
		angle *= MathF.PI / 180f;
		float num = (float)Screen.width / 2f;
		float num2 = (float)Screen.height / 2f;
		return new Vector2(num * _widthFill * Mathf.Cos(angle) + num, num2 * _heightFill * Mathf.Sin(angle) + num2);
	}
}
