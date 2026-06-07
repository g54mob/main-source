using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleText : Text
{
	public float WrapWidth = 512f;

	public float AngleStart;

	public bool Reverse;

	private List<UIVertex> _stream = new List<UIVertex>();

	protected override void OnPopulateMesh(VertexHelper toFill)
	{
		base.OnPopulateMesh(toFill);
		toFill.GetUIVertexStream(_stream);
		toFill.Clear();
		for (int i = 0; i < _stream.Count && i + 5 < _stream.Count; i += 6)
		{
			UIVertex uIVertex = _stream[i];
			UIVertex uIVertex2 = _stream[i + 1];
			UIVertex uIVertex3 = _stream[i + 2];
			UIVertex uIVertex4 = _stream[i + 4];
			Rect rect = new Rect(uIVertex.position.x, uIVertex.position.y, uIVertex3.position.x - uIVertex.position.x, uIVertex3.position.y - uIVertex.position.y);
			float f = AngleStart / 180f * (float)Math.PI + rect.center.x / base.rectTransform.rect.size.magnitude * (float)Math.PI;
			Vector2 vector = new Vector2(Mathf.Cos(f), Mathf.Sin(f));
			if (Reverse)
			{
				vector = new Vector2(vector.x, 0f - vector.y);
			}
			Vector2 vector2 = vector * Mathf.Abs(rect.center.y);
			Vector2 sz = rect.size * 0.5f;
			uIVertex.position = vector2 + GetSizeVector(sz, vector, !Reverse, !Reverse);
			uIVertex2.position = vector2 + GetSizeVector(sz, vector, Reverse, !Reverse);
			uIVertex3.position = vector2 + GetSizeVector(sz, vector, Reverse, Reverse);
			uIVertex4.position = vector2 + GetSizeVector(sz, vector, !Reverse, Reverse);
			toFill.AddUIVertexQuad(new UIVertex[4] { uIVertex, uIVertex2, uIVertex3, uIVertex4 });
		}
		_stream.Clear();
	}

	private Vector2 GetSizeVector(Vector2 sz, Vector2 rot, bool invertX, bool invertY)
	{
		float num = (invertX ? (0f - sz.x) : sz.x);
		float num2 = (invertY ? (0f - sz.y) : sz.y);
		rot = new Vector2(0f - rot.y, rot.x);
		return new Vector2(num * rot.x - num2 * rot.y, num2 * rot.x + num * rot.y);
	}
}
