using System;
using UnityEngine;

namespace SceneFocus
{
	[Serializable]
	public class TransitionCameraInfo
	{
		public Vector3 position;

		public Vector3 eulerAngles;

		public float fieldOfView;

		public bool toBattleScene;

		private float? _currentFOV;

		public float CurrentFOV => 0f;

		public void SetCurrentFOV(float ratio)
		{
		}

		public TransitionCameraInfo(Vector3 position, Vector3 eulerAngles, float fieldOfView, bool toBattleScene = false)
		{
		}
	}
}
