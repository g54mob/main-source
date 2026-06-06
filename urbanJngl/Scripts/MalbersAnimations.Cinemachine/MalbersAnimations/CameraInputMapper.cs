using Cinemachine;
using UnityEngine;

namespace MalbersAnimations
{
	public class CameraInputMapper : MonoBehaviour
	{
		public string TouchXInputMapTo = "Mouse X";

		public string TouchYInputMapTo = "Mouse Y";

		private Vector2 delta;

		private void Start()
		{
			CinemachineCore.GetInputAxis = GetInputAxis;
		}

		private float GetInputAxis(string axisName)
		{
			if (string.Equals(axisName, TouchXInputMapTo))
			{
				return delta.x;
			}
			if (string.Equals(axisName, TouchYInputMapTo))
			{
				return delta.y;
			}
			return 0f;
		}

		public void CameraInput(Vector2 value)
		{
			delta = value;
		}
	}
}
