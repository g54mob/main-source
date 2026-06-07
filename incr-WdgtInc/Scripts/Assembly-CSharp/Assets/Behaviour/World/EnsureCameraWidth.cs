using UnityEngine;

namespace Assets.Behaviour.World
{
	public class EnsureCameraWidth : MonoBehaviour
	{
		[SerializeField]
		private float _minWidth;

		private Camera _cam;

		private float _defaultSize;

		private void Awake()
		{
			_cam = GetComponent<Camera>();
			_defaultSize = _cam.orthographicSize;
		}

		private void OnEnable()
		{
			_cam.orthographicSize = _defaultSize;
			_updateSize();
		}

		private void Update()
		{
			_updateSize();
		}

		private void _updateSize()
		{
			float num = (float)Screen.width / (float)Screen.height;
			if (_cam.orthographicSize * 2f * num * 1.01f < _minWidth)
			{
				_cam.orthographicSize = _minWidth / num / 2f;
			}
		}
	}
}
