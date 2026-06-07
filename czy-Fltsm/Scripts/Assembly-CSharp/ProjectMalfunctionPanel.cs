using System.Collections.Generic;
using UnityEngine;

public class ProjectMalfunctionPanel : MonoBehaviour
{
	[SerializeField]
	private ChildBehaviourCache<PlaceableAlertIcon> _malfunctionIconCache;

	private Project _project;

	private List<PlaceableAlertProperties> _malfunctions = new List<PlaceableAlertProperties>();

	public void Initialize(Project project)
	{
		Uninitialize(update: false);
		_project = project;
		_project.MalfunctionsUpdated += OnMalfunctionsUpdated;
		OnMalfunctionsUpdated();
	}

	public void Uninitialize(bool update = true)
	{
		if (_project != null)
		{
			_project.MalfunctionsUpdated -= OnMalfunctionsUpdated;
			_project = null;
		}
		if (update)
		{
			OnMalfunctionsUpdated();
		}
	}

	private void OnMalfunctionsUpdated()
	{
		_malfunctions.Clear();
		_malfunctionIconCache.Reset();
		if (_project != null)
		{
			_project.PopulateMalfunctions(_malfunctions);
		}
		foreach (PlaceableAlertProperties malfunction in _malfunctions)
		{
			_malfunctionIconCache.Get(active: true).Initialize(malfunction, _project.Properties.name);
		}
		_malfunctionIconCache.Trim();
		base.gameObject.SetActive(_malfunctions.Count > 0);
	}
}
