using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLerp : Text
{
	private List<UIVertex> _stream = new List<UIVertex>();

	private int _maxChars;

	public int MaxChars
	{
		get
		{
			return _maxChars;
		}
		set
		{
			_maxChars = value;
			SetVerticesDirty();
		}
	}

	protected override void OnPopulateMesh(VertexHelper toFill)
	{
		base.OnPopulateMesh(toFill);
		int num = toFill.currentVertCount / 4;
		toFill.GetUIVertexStream(_stream);
		for (int i = MaxChars; i < num; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				UIVertex vertex = _stream[i * 4 + j];
				vertex.color = Color.clear;
				toFill.SetUIVertex(vertex, i * 4 + j);
			}
		}
		_stream.Clear();
	}
}
