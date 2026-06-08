using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColorContextStack
{
	public bool DebugThisStack;

	private List<ColorContext> _contextStack = new List<ColorContext>(10);

	private Color _defaultColor = Color.black;

	public void SetDefaultColor(Color color)
	{
		if (DebugThisStack)
		{
			Debug.Log("SetDefaultColor: " + color.ToString());
		}
		_defaultColor = color;
	}

	public Color Push(Color color, float lerpFactor, string context)
	{
		if (_contextStack.Any((ColorContext x) => x.Context == context))
		{
			ColorContext item = _contextStack.First((ColorContext x) => x.Context == context);
			_contextStack.Remove(item);
		}
		ColorContext item2 = new ColorContext(color, lerpFactor, context);
		_contextStack.Add(item2);
		if (DebugThisStack)
		{
			Debug.Log(string.Format("Push {0},{1},'{2}'; stack size: {3}", color, lerpFactor, context, _contextStack.Count));
		}
		return GetTopColor();
	}

	public Color Remove(string context)
	{
		if (_contextStack.Count == 0)
		{
			return _defaultColor;
		}
		if (_contextStack.Any((ColorContext x) => x.Context == context))
		{
			ColorContext item = _contextStack.First((ColorContext x) => x.Context == context);
			_contextStack.Remove(item);
		}
		if (DebugThisStack)
		{
			Debug.Log(string.Format("Remove '{0}'; stack size: {1}", context, _contextStack.Count));
		}
		return GetTopColor();
	}

	public Color GetTopColor()
	{
		if (_contextStack.Count > 0)
		{
			ColorContext colorContext = _contextStack.Last();
			if (DebugThisStack)
			{
				Debug.Log(string.Format("GetTopColor {0}; stack size: {1}", colorContext.ColorToUse, _contextStack.Count));
			}
			return Color.Lerp(_defaultColor, colorContext.ColorToUse, colorContext.LerpFactor);
		}
		if (DebugThisStack)
		{
			Debug.Log(string.Format("GetTopColor default ({0})", _defaultColor));
		}
		return _defaultColor;
	}

	public Color ClearAllColors()
	{
		if (DebugThisStack)
		{
			Debug.Log("ClearAllColors");
		}
		_contextStack.Clear();
		return _defaultColor;
	}

	public int Count()
	{
		return _contextStack.Count();
	}
}
