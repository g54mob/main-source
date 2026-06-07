using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLineGraphic : MaskableGraphic
{
	public Texture Tex;

	public Text LabelPrefab;

	private List<Text> _labelPool = new List<Text>();

	private int _currentLabel;

	public float LineHeight = 4f;

	public List<int[]> Values = new List<int[]>();

	public Color[] Colors;

	public override Texture mainTexture
	{
		get
		{
			return Tex ?? base.mainTexture;
		}
	}

	public void UpdateSize()
	{
	}

	private Text GetLabel()
	{
		if (_currentLabel < _labelPool.Count)
		{
			Text text = _labelPool[_currentLabel];
			text.gameObject.SetActive(true);
			_currentLabel++;
			return text;
		}
		Text text2 = Object.Instantiate(LabelPrefab);
		text2.transform.SetParent(base.transform, false);
		_labelPool.Add(text2);
		_currentLabel++;
		return text2;
	}

	protected override void OnPopulateMesh(VertexHelper vh)
	{
		vh.Clear();
	}

	public void RefreshLabels()
	{
	}
}
