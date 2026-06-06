using System;
using System.Collections.Generic;
using UnityEngine;

public class DecorationAlertPanel : MonoBehaviour, IDecorationPanelElement
{
	[SerializeField]
	private PlaceableAlertIcon _statusIcon;

	[SerializeField]
	private ChildBehaviourCache<PlaceableAlertIcon> _malfunctionIconCache;

	private Decoration _decoration;

	private readonly List<PlaceableAlertProperties> _malfunctions = new List<PlaceableAlertProperties>();

	DecorationPanelElementId IDecorationPanelElement.Id => DecorationPanelElementId.Malfunction;

	public void Activate(Decoration decoration)
	{
		_decoration = decoration;
		ConstructibleStatus statusHolder = _decoration.StatusHolder;
		statusHolder.OnMalfunctionsUpdated = (Action)Delegate.Combine(statusHolder.OnMalfunctionsUpdated, new Action(UpdatePanel));
		UpdatePanel();
	}

	public void Deactivate()
	{
		base.gameObject.SetActive(value: false);
	}

	private void OnDisable()
	{
		if (_decoration != null)
		{
			ConstructibleStatus statusHolder = _decoration.StatusHolder;
			statusHolder.OnMalfunctionsUpdated = (Action)Delegate.Remove(statusHolder.OnMalfunctionsUpdated, new Action(UpdatePanel));
		}
	}

	public void UpdatePanel()
	{
		_malfunctions.Clear();
		_decoration.StatusHolder.PopulateMalfunctions(_malfunctions);
		_malfunctionIconCache.Reset();
		foreach (PlaceableAlertProperties malfunction in _malfunctions)
		{
			_malfunctionIconCache.Get(active: true).Initialize(malfunction, _decoration.Name);
		}
		_malfunctionIconCache.Trim();
		bool flag = _malfunctions.Count > 0;
		_statusIcon.gameObject.SetActive(!flag);
		if (_statusIcon.gameObject.activeSelf)
		{
			_statusIcon.Initialize(_decoration.StatusHolder.Status, _decoration.Name);
		}
		base.gameObject.SetActive(flag || _statusIcon.gameObject.activeSelf);
	}
}
