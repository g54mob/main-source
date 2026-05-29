using System;
using UnityEngine;

[Serializable]
public class TaskManagerRouterBase
{
	public string name;

	[Header("Object")]
	public Transform RouterGameObject;

	[Header("Components")]
	public MiniMapDeviceInfo miniMapDeviceInfo;

	public NetworkRouter networkRouter;
}
