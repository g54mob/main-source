using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGraphBuilder : MonoBehaviour
{
	public List<float> _lstGraphYValues;

	public Vector2 _vecSize;

	public Vector2 _vecMinValues;

	public Vector2 _vecMaxValues;

	protected List<UILine> _lstLines;

	protected List<Graphic> _lstLineEnds;

	public UILine _lrnTemplateLine;

	public Graphic _gphLineEndsTemplate;

	public void DestroyLinelist()
	{
		if (_lstLines != null)
		{
			foreach (UILine lstLine in _lstLines)
			{
				if (lstLine != null)
				{
					Object.Destroy(lstLine.gameObject);
				}
			}
		}
		if (_lstLineEnds != null)
		{
			foreach (Graphic lstLineEnd in _lstLineEnds)
			{
				Object.Destroy(lstLineEnd.gameObject);
			}
		}
		_lstLineEnds = null;
		_lstLines = null;
	}

	public void BuildLineList()
	{
		DestroyLinelist();
		_lstLines = new List<UILine>(Mathf.Clamp(_lstGraphYValues.Count - 1, 0, int.MaxValue));
		_lstLineEnds = new List<Graphic>(_lstGraphYValues.Count);
		for (int i = 0; i < _lstGraphYValues.Count - 1; i++)
		{
			UILine uILine = Object.Instantiate(_lrnTemplateLine);
			uILine.transform.parent = base.transform;
			_lstLines.Add(uILine);
		}
		for (int j = 0; j < _lstGraphYValues.Count; j++)
		{
			Graphic graphic = Object.Instantiate(_gphLineEndsTemplate);
			graphic.transform.parent = base.transform;
			_lstLineEnds.Add(graphic);
		}
		Debug.Log("Built " + _lstLines.Count + " Lines and " + _lstLineEnds.Count + " Line Ends");
	}

	public Vector2 DataPointToUICord(int iDataPointIndex, float fValue)
	{
		float num = ((float)iDataPointIndex - _vecMinValues.x) / Mathf.Clamp(_vecMaxValues.x - _vecMinValues.x, 0f, 2.1474836E+09f);
		return new Vector2(y: ((fValue - _vecMinValues.y) / Mathf.Clamp(_vecMaxValues.y - _vecMinValues.y, 0f, 2.1474836E+09f) - 0.5f) * 2f * _vecSize.y, x: (num - 0.5f) * 2f * _vecSize.x);
	}

	public void SetGraphLines()
	{
		if (_lstGraphYValues.Count >= 2)
		{
			for (int i = 1; i < _lstGraphYValues.Count; i++)
			{
				Vector2 startPoint = DataPointToUICord(i - 1, _lstGraphYValues[i - 1]);
				Vector2 endPoint = DataPointToUICord(i, _lstGraphYValues[i]);
				_lstLines[i - 1].StartPoint = startPoint;
				_lstLines[i - 1].EndPoint = endPoint;
			}
			for (int j = 0; j < _lstGraphYValues.Count; j++)
			{
				Vector2 vector = DataPointToUICord(j, _lstGraphYValues[j]);
				_lstLineEnds[j].rectTransform.localPosition = new Vector3(vector.x, vector.y, 1f);
			}
		}
	}

	public void SetupGraph()
	{
		BuildLineList();
		SetGraphLines();
	}

	public float GetMaxYValue()
	{
		return Mathf.Max(_lstGraphYValues.ToArray());
	}

	public float GetMaxXValue()
	{
		return _lstGraphYValues.Count - 1;
	}

	public float GetMinYValue()
	{
		return Mathf.Min(_lstGraphYValues.ToArray());
	}

	public float GetMinXValue()
	{
		return 0f;
	}

	public void SyncMinMaxValues(UIGraphBuilder ugpSyncTarget)
	{
		float num = float.MinValue;
		float num2 = float.MaxValue;
		float num3 = 0f;
		float num4 = 0f;
		num = Mathf.Max(GetMaxYValue(), ugpSyncTarget.GetMaxYValue());
		num2 = Mathf.Min(GetMinYValue(), ugpSyncTarget.GetMinYValue());
		num3 = Mathf.Max(GetMaxXValue(), ugpSyncTarget.GetMaxXValue());
		num4 = Mathf.Min(GetMinXValue(), ugpSyncTarget.GetMinXValue());
		_vecMaxValues = new Vector2(num3, num);
		ugpSyncTarget._vecMaxValues = new Vector2(num3, num);
		_vecMinValues = new Vector2(num4, num2);
		ugpSyncTarget._vecMinValues = new Vector2(num4, num2);
	}
}
