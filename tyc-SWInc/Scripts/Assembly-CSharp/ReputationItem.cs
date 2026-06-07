using System;
using UnityEngine;
using UnityEngine.UI;

public class ReputationItem : MonoBehaviour
{
	public Text Label;

	public IconFillBar FillBar;

	public Image Back;

	public GameObject Top;

	public PosNegBar PNBar;

	[NonSerialized]
	private float _lastValue = -1f;

	[NonSerialized]
	private uint _lastPop;

	[NonSerialized]
	private bool _isNew = true;

	private void Start()
	{
		FillBar.Colors[1] = HUD.GetWarningColor();
	}

	public void SetFull()
	{
		Back.sprite = ObjectDatabase.Instance.GetSprite(true, true, true, true);
		Top.SetActive(true);
		Label.fontSize = 16;
		Label.alignment = TextAnchor.UpperLeft;
	}

	public void SetMiddle()
	{
		Back.sprite = null;
	}

	public void SetBottom()
	{
		Back.sprite = ObjectDatabase.Instance.GetSprite(false, true, true, false);
	}

	public void SetRep(float pct, uint pop)
	{
		if (_lastPop == pop && !_isNew)
		{
			return;
		}
		_isNew = false;
		if (_isNew)
		{
			PNBar.SetValues(0f, 0f);
		}
		else
		{
			int num = (int)((pop <= _lastPop) ? (0 - (_lastPop - pop)) : (pop - _lastPop));
			if (num > 0)
			{
				PNBar.SetValues(num.MapRange(0f, 10000f, 0f, 2f, true), 0f);
			}
			else
			{
				PNBar.SetValues(0f, (-num).MapRange(0f, 10000f, 0f, 2f, true));
			}
		}
		_lastPop = pop;
		_lastValue = pct;
		FillBar.Values[1] = Mathf.Sqrt(pct) * 6f;
		FillBar.SetVerticesDirty();
	}
}
