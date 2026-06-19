using Aggro.Core;
using UnityEngine;

public class CameraSpaceCanvas : EntityBehaviourBase
{
	protected override void OnEntityCreated()
	{
		Canvas[] componentsInChildren = GetComponentsInChildren<Canvas>();
		foreach (Canvas obj in componentsInChildren)
		{
			obj.renderMode = RenderMode.ScreenSpaceCamera;
			obj.planeDistance = 1f;
			obj.worldCamera = Camera.main;
		}
	}

	private void Update()
	{
	}
}
