using System;
using UnityEngine;

[Serializable]
public class CameraPersistentData
{
	public Vector3 Position;

	public Quaternion Rotation;

	public float ZoomLevel;

	public CameraPersistentData(CameraController cameraController)
	{
		Position = cameraController.transform.position;
		Rotation = cameraController.transform.rotation;
		ZoomLevel = cameraController.CurrentZoomLevel;
	}

	public void Restore(CameraController cameraController)
	{
		cameraController.transform.position = Position;
		cameraController.transform.rotation = Rotation;
		cameraController.SetZoom(ZoomLevel, overwriteDesiredZoom: true);
	}
}
