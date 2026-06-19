using System.Collections.Generic;
using HighlightingSystem;
using UnityEngine;

public class PipeFocusArrow : MonoBehaviour
{
	public GameObject roomToFocus;

	public Color highlightColor = Color.blue;

	public Highlighter highlighterRef;

	public List<Renderer> rendererList = new List<Renderer>();

	private void Awake()
	{
		RemoveHighlight();
	}

	public void Highlight()
	{
		SetRendererValues(value: true);
		highlighterRef.ConstantOn(highlightColor);
	}

	public void RemoveHighlight()
	{
		SetRendererValues(value: false);
		highlighterRef.ConstantOff();
	}

	private void SetRendererValues(bool value)
	{
		for (int i = 0; i < rendererList.Count; i++)
		{
			rendererList[i].enabled = value;
		}
	}
}
