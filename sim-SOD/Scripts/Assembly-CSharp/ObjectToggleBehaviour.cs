using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class ObjectToggleBehaviour : SwitchSyncBehaviour
{
	[ReorderableList]
	public List<GameObject> objectsToToggle;

	public override void SetOn(bool val)
	{
	}
}
