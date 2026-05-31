using System.Collections.Generic;
using UnityEngine;

public class Industry_Vertical : MonoBehaviour
{
	public List<GameObject> Bars;

	private int _cnt;

	private Color _color = Color.white;

	private void Start()
	{
		for (int i = 0; i < Bars.Count; i++)
		{
			Bars[i].SetActive(value: false);
		}
		_cnt = 0;
	}

	public void SetBarVisibility(int cnt)
	{
		if (_cnt == cnt)
		{
			return;
		}
		_cnt = cnt;
		for (int i = 0; i < Bars.Count; i++)
		{
			if (i < _cnt)
			{
				Bars[i].SetActive(value: true);
			}
			else
			{
				Bars[i].SetActive(value: false);
			}
		}
	}

	public void SetBarColor(Color newColor)
	{
		if (newColor != _color)
		{
			_color = newColor;
			for (int i = 0; i < Bars.Count; i++)
			{
				Bars[i].GetComponent<SpriteRenderer>().color = _color;
			}
		}
	}
}
