using System;
using UnityEngine;

[Serializable]
public struct ProjectMalfunction
{
	[SerializeField]
	private ProjectBlocker _blocker;

	[SerializeField]
	private PlaceableAlertProperties _alertProperties;

	public ProjectBlocker Blocker => _blocker;

	public PlaceableAlertProperties AlertProperties => _alertProperties;
}
