using UnityEngine;

namespace Gh.Tk
{
	public class TavernSpaceUIPositoner : MonoBehaviour
	{
		[SerializeField]
		private GameObject _hideHelper;

		private Camera _currentCam;

		public float scaleFactor;

		private Vector3 _worldPositionAnchor;

		private float _zLevel;

		private Vector3 _lastPosition;

		private Quaternion _lastRotation;

		private void Awake()
		{
		}

		public void SetWorldPosition(Vector3 worldPosition)
		{
		}

		private void UpdateAnchoredPosition()
		{
		}

		private void UpdateSize(CameraRigBase tavernCam)
		{
		}

		protected void LateUpdate()
		{
		}

		private void UpdateRotation()
		{
		}
	}
}
