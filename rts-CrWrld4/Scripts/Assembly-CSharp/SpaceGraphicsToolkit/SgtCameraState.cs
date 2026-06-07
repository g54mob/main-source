using System.Collections.Generic;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	public class SgtCameraState
	{
		public Camera Camera;

		public static T Find<T>(ref List<T> cameraStates, Camera camera) where T : SgtCameraState, new()
		{
			return null;
		}

		public static T Restore<T>(List<T> cameraStates, Camera camera) where T : SgtCameraState
		{
			return null;
		}

		public static void Clear<T>(List<T> cameraStates) where T : SgtCameraState
		{
		}
	}
}
