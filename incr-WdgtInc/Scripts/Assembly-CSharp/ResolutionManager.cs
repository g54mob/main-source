using System.Collections.Generic;
using Assets.Behaviour.UI;
using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
	private static List<UIResolutionScaling> _elements = new List<UIResolutionScaling>();

	private int _resX;

	private int _resY;

	private void OnEnable()
	{
		_resX = Screen.width;
		_resY = Screen.height;
	}

	private void Update()
	{
		int width = Screen.width;
		int height = Screen.height;
		if (width == _resX && height == _resY)
		{
			return;
		}
		foreach (UIResolutionScaling element in _elements)
		{
			if ((bool)element)
			{
				element.UpdateResolutionScale();
			}
		}
		_resX = width;
		_resY = height;
	}

	public static void Add(UIResolutionScaling element)
	{
		_elements.Add(element);
	}

	private void OnDisable()
	{
		_elements.Clear();
	}
}
