using UnityEngine;

public class Tracker : SceneBehaviour
{
	[SerializeField]
	private Transform _arrow;

	[SerializeField]
	private ResolutionEllipse _ellipse;

	private Transform _viewTransform;

	private Camera _camera;

	private Transform _trackingTransform;

	private bool _isVisible = true;

	public void Initialize(Camera camera, Transform view, Transform tracking = null)
	{
		_camera = camera;
		_viewTransform = view;
		_trackingTransform = tracking;
		_isVisible = _arrow.gameObject.activeSelf;
	}

	private void Update()
	{
		Vector3 trackingPosition = GetTrackingPosition();
		Vector3 vector = _camera.WorldToViewportPoint(trackingPosition);
		bool flag = vector.x >= 0f && vector.x <= 1f && vector.y >= 0f && vector.y <= 1f && vector.z >= 0f;
		if (_isVisible == flag)
		{
			_isVisible = !flag;
			_arrow.gameObject.SetActive(_isVisible);
		}
		if (_isVisible)
		{
			float num = Vector3.SignedAngle((trackingPosition - _viewTransform.position).normalized, _viewTransform.forward, Vector3.up);
			_arrow.position = _ellipse.ReturnPoint(num + 90f);
			_arrow.rotation = Quaternion.Euler(0f, 0f, num);
		}
	}

	public virtual Vector3 GetTrackingPosition()
	{
		return _trackingTransform.position;
	}
}
