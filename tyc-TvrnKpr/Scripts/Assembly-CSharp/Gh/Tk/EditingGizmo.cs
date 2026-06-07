using UnityEngine;

namespace Gh.Tk
{
	public class EditingGizmo : MonoBehaviour
	{
		public enum EditingMode
		{
			Scale = 0,
			Position = 1,
			Rotation = 2,
			Default = 3
		}

		public GameObject scaleHandles;

		public GameObject positionHandles;

		public GameObject rotationHandles;

		private EditingMode _lastEditingMode;

		public Transform visualScaler;

		public float defaultDistance;

		public float defaultScale;

		public float defaultFOV;

		private bool _wasLeftControlPressed;

		private EditControlHandle[] _controlHandles;

		public void SetEditingMode(EditingMode mode)
		{
		}

		[ContextMenu("CalibrateDefaultDistance")]
		public void CalibrateDefaultDistance()
		{
		}

		private void UpdateScaler()
		{
		}

		private void LateUpdate()
		{
		}

		private void Start()
		{
		}
	}
}
