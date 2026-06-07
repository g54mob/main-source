using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HighlightManager : MonoBehaviour
{
	private HashSet<OutlineRendererComponent> _highlightedFlotsam = new HashSet<OutlineRendererComponent>();

	private OutlineRendererComponent _previousOutlineComponent;

	public void ClearHighlight(OutlineRendererComponent outlineRendererComponent)
	{
		if (!(outlineRendererComponent == null) && _highlightedFlotsam.Contains(outlineRendererComponent))
		{
			_highlightedFlotsam.Remove(outlineRendererComponent);
		}
	}

	public void ClearHighlights()
	{
		for (int i = 0; i < _highlightedFlotsam.Count; i++)
		{
			_highlightedFlotsam.ElementAt(i).GetComponentInParent<OutlineRendererComponent>().ResetOutline();
		}
		_highlightedFlotsam.Clear();
	}

	public void HighlightObject(OutlineRendererComponent outlineRendererComponent)
	{
		if (outlineRendererComponent != null)
		{
			outlineRendererComponent.UpdateSelectedObject();
		}
	}

	public void ResetOutlineHover()
	{
		if (_previousOutlineComponent != null)
		{
			_previousOutlineComponent.ResetOutline();
			_previousOutlineComponent = null;
		}
	}

	public void AddOutlineHover(SelectionLink selectionLink)
	{
		if ((bool)selectionLink.OutlineRenderer)
		{
			selectionLink.OutlineRenderer.UpdateHoverObject();
			_previousOutlineComponent = selectionLink.OutlineRenderer;
		}
	}

	public void DeselectAll(bool resetSelectedType = true)
	{
		OutlineRendererComponent componentInParent = Selector.Selection.GetComponentInParent<OutlineRendererComponent>();
		if (componentInParent != null)
		{
			componentInParent.ResetHighlightOutline();
		}
	}
}
