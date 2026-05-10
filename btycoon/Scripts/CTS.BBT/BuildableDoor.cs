using System;
using UnityEngine;
using UnityEngine.AI;

public class BuildableDoor : BuildableElement
{
	[SerializeField]
	private NavMeshObstacle[] _forwardObstacles;

	[SerializeField]
	private NavMeshObstacle[] _backObstacles;

	[SerializeField]
	private DoorVisualSelector[] _doorVisualSelector;

	[SerializeField]
	public Renderer[] ExteriorCursorRenderers;

	private bool _isEntrance;

	private bool oncrecreate;

	private bool? _exteriorDoor;

	public bool IsExteriorDoor { get; private set; }

	public bool IsEntrance
	{
		get
		{
			return _isEntrance;
		}
		set
		{
			if (_isEntrance != value)
			{
				_isEntrance = value;
				this.EntranceValueChanged?.Invoke(_isEntrance);
			}
		}
	}

	public event Action<bool> EntranceValueChanged;

	public void SetFrontObstacleActive(bool value)
	{
		NavMeshObstacle[] forwardObstacles = _forwardObstacles;
		foreach (NavMeshObstacle navMeshObstacle in forwardObstacles)
		{
			if ((bool)navMeshObstacle)
			{
				navMeshObstacle.enabled = value;
			}
		}
	}

	public void SetBackObstacleActive(bool value)
	{
		NavMeshObstacle[] backObstacles = _backObstacles;
		foreach (NavMeshObstacle navMeshObstacle in backObstacles)
		{
			if ((bool)navMeshObstacle)
			{
				navMeshObstacle.enabled = value;
			}
		}
	}

	public void ShowInterior()
	{
		_exteriorDoor = false;
		IsExteriorDoor = false;
		for (int i = 0; i < _doorVisualSelector.Length; i++)
		{
			_doorVisualSelector[i].ShowInterior();
		}
	}

	public void ShowExterior()
	{
		_exteriorDoor = true;
		IsExteriorDoor = true;
		for (int i = 0; i < _doorVisualSelector.Length; i++)
		{
			_doorVisualSelector[i].ShowExterior();
		}
	}

	public override void OnPlaced(BuildingWall wall)
	{
		base.OnPlaced(wall);
		if (!wall.IsInterior)
		{
			ShowExterior();
		}
		else
		{
			ShowInterior();
		}
	}
}
