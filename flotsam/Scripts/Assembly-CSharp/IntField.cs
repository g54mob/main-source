using System;
using TMPro;
using UnityEngine;

public class IntField : MonoBehaviour
{
	private enum Sign
	{
		NegativeOnly = 0,
		NegativeAndPositive = 1,
		NegativeAndPositiveZeroExcluded = 2,
		None = 3
	}

	private enum RangeType
	{
		Range = 0,
		SmallerThen = 1,
		LargerThen = 2
	}

	[Serializable]
	private struct ColorRange
	{
		public RangeType RangeType;

		public int from;

		[ConditionalEnumHide("RangeType", 0, false)]
		public int to;

		public Color Color;

		public bool IsInRange(int value)
		{
			switch (RangeType)
			{
			case RangeType.Range:
				if (from <= value)
				{
					return value <= to;
				}
				return false;
			case RangeType.SmallerThen:
				return value < from;
			case RangeType.LargerThen:
				return from < value;
			default:
				throw new NotImplementedException();
			}
		}
	}

	[SerializeField]
	protected TextMeshProUGUI _text;

	[SerializeField]
	private Sign _sign;

	[SerializeField]
	private ColorRange[] _colorRanges;

	public void SetInt(int value, bool activate = true)
	{
		switch (_sign)
		{
		case Sign.NegativeOnly:
			_text.text = value.ToString();
			break;
		case Sign.NegativeAndPositive:
			_text.text = ((value < 0) ? value.ToString() : $"+{value}");
			break;
		case Sign.NegativeAndPositiveZeroExcluded:
			_text.text = ((value <= 0) ? value.ToString() : $"+{value}");
			break;
		case Sign.None:
			_text.text = Mathf.Abs(value).ToString();
			break;
		}
		if (activate)
		{
			base.gameObject.SetActive(value: true);
		}
		if (_colorRanges.IsNullOrEmpty())
		{
			return;
		}
		ColorRange[] colorRanges = _colorRanges;
		for (int i = 0; i < colorRanges.Length; i++)
		{
			ColorRange colorRange = colorRanges[i];
			if (colorRange.IsInRange(value))
			{
				_text.color = colorRange.Color;
			}
		}
	}

	public void SetFloat(float value)
	{
		SetInt(Mathf.RoundToInt(value));
	}
}
