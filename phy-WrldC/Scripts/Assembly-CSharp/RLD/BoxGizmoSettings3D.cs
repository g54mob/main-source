using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class BoxGizmoSettings3D : Settings
	{
		[SerializeField]
		private float _xSnapStep = 0.1f;

		[SerializeField]
		private float _ySnapStep = 0.1f;

		[SerializeField]
		private float _zSnapStep = 0.1f;

		[SerializeField]
		private float _dragSensitivity = 1f;

		public float XSnapStep => _xSnapStep;

		public float YSnapStep => _ySnapStep;

		public float ZSnapStep => _zSnapStep;

		public float DragSensitivity => _dragSensitivity;

		public void SetXSnapStep(float snapStep)
		{
			_xSnapStep = Mathf.Max(0.0001f, snapStep);
		}

		public void SetYSnapStep(float snapStep)
		{
			_ySnapStep = Mathf.Max(0.0001f, snapStep);
		}

		public void SetZSnapStep(float snapStep)
		{
			_zSnapStep = Mathf.Max(0.0001f, snapStep);
		}

		public void SetDragSensitivity(float sensitivity)
		{
			_dragSensitivity = Mathf.Max(0.0001f, sensitivity);
		}
	}
}
