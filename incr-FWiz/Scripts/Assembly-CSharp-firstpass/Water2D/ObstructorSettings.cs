using System;
using UnityEngine;
using UnityEngine.Events;

namespace Water2D
{
	[Serializable]
	public class ObstructorSettings
	{
		public Camera mainCamera;

		public WaterCryo<float> textureResolution;

		public WaterCryo<bool> overrideMainCamera;

		public WaterCryo<bool> obstructionObjectsVisible;

		public WaterCryo<bool> cameraVisible;

		internal void onValueChanged(UnityAction onObstructionChanged)
		{
		}
	}
}
