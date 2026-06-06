using System.Collections.Generic;
using UnityEngine;

public class NavigatorLineRenderer
{
	private Navigator _navigator;

	private LineRenderer _lineRenderer;

	private ITarget _target;

	private bool _displayPath;

	private List<Vector3> _linePath = new List<Vector3>();

	public NavigatorLineRenderer(Navigator navigator)
	{
		_navigator = navigator;
		_lineRenderer = _navigator.GetComponent<LineRenderer>();
	}

	public void UpdateLineRenderer(ITarget target, NavigatorPathBase path)
	{
		_target = target;
		if (_navigator.State != NavigatorState.Navigating && _navigator.State != NavigatorState.Transitioning)
		{
			if (_lineRenderer.positionCount > 0)
			{
				ClearLineRenderer();
			}
		}
		else if (_displayPath && _target != null && path != null)
		{
			_linePath.Clear();
			_linePath.Add(_navigator.transform.position + Vector3.up * 0.25f);
			path.PopulateLineRenderer(_linePath, Vector3.up);
			if (_target.tag != "Construction")
			{
				_linePath.Add(_target.ReturnPosition() + Vector3.up * 0.25f);
			}
			_lineRenderer.positionCount = _linePath.Count;
			for (int i = 0; i < _linePath.Count; i++)
			{
				_lineRenderer.SetPosition(i, _linePath[i]);
			}
		}
	}

	private void ClearLineRenderer()
	{
		_lineRenderer.positionCount = 0;
	}

	public void EnablePathVisuals(bool enabled = true)
	{
		_lineRenderer.enabled = enabled;
		_displayPath = enabled;
		if (!enabled)
		{
			ClearLineRenderer();
		}
	}
}
