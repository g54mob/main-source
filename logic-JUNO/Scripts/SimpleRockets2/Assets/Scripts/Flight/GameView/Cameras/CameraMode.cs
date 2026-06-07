using UnityEngine;

namespace Assets.Scripts.Flight.GameView.Cameras
{
	public class CameraMode
	{
		public CameraController CameraController { get; private set; }

		public float Dirt { get; set; }

		public string DisplayPrefix { get; set; }

		public bool IsHidden { get; set; } = true;

		public Color NightVision { get; set; } = Color.black;

		public bool IsSelected { get; set; }

		public string Name { get; set; }

		public int SubMode { get; private set; }

		public CameraMode(string name, CameraController cameraController, int subMode)
		{
			CameraController = cameraController;
			CameraController.CameraModes.Add(this);
			SubMode = subMode;
			Name = name;
		}
	}
}
