using System.Collections.Generic;
using UnityEngine;

public class BuildableAlertPanel : MonoBehaviour, IBuildablePanelElement
{
	[SerializeField]
	private PlaceableAlertIcon _statusIcon;

	[SerializeField]
	private ChildBehaviourCache<PlaceableAlertIcon> _malfunctionIconCache;

	private Buildable _buildable;

	private List<PlaceableAlertProperties> _malfunctions = new List<PlaceableAlertProperties>();

	private List<PlaceableAlertIcon> _malfunctionIcons = new List<PlaceableAlertIcon>();

	public BuildablePanelElementId Id => BuildablePanelElementId.Malfunction;

	public bool Activate(Buildable buildable, bool finished)
	{
		if (buildable.Properties.ReturnShowElement(this, finished))
		{
			_buildable = buildable;
			_buildable.MalfunctionUpdatedEvent += UpdatePanel;
			UpdatePanel();
			return true;
		}
		return false;
	}

	public void Deactivate()
	{
		base.gameObject.SetActive(value: false);
	}

	private void OnDisable()
	{
		if (_buildable != null)
		{
			_buildable.MalfunctionUpdatedEvent -= UpdatePanel;
		}
	}

	private void OnDestroy()
	{
		_buildable.MalfunctionUpdatedEvent -= UpdatePanel;
	}

	public void UpdatePanel()
	{
		_malfunctions.Clear();
		_buildable.PopulateMalfunctions(_malfunctions, (_buildable.BuildPhase != BuildPhase.Finished) ? PlaceableAlertProperties.AlertType.Major : PlaceableAlertProperties.AlertType.Minor);
		_malfunctionIconCache.Reset();
		foreach (PlaceableAlertProperties malfunction in _malfunctions)
		{
			_malfunctionIconCache.Get(active: true).Initialize(malfunction, _buildable.Name);
		}
		_malfunctionIconCache.Trim();
		bool flag = 0 < _malfunctions.Count;
		_statusIcon.gameObject.SetActive(!flag);
		if (_statusIcon.gameObject.activeSelf)
		{
			_statusIcon.Initialize(_buildable.Status, _buildable.Name);
		}
		base.gameObject.SetActive(flag || _statusIcon.gameObject.activeSelf);
	}
}
