using Presentation.FactoryFloor;
using Presentation.Locators;
using UnityEngine;

public class FactoryObjectUIFollower : MonoBehaviour
{
	[SerializeField]
	private FactoryObjectView _objectView;

	[SerializeField]
	private CameraLocator _mainCameraLocator;

	[SerializeField]
	private RectTransform _UIElement;

	[SerializeField]
	private Vector3 _worldOffset;

	[SerializeField]
	private Vector3 _localOffset;

	[SerializeField]
	private Vector2 _cameraSpaceOffset;

	[SerializeField]
	private Vector2 _screenOffset;

	private void Update()
	{
		UpdateWindowPosition();
	}

	private void UpdateWindowPosition()
	{
		Vector3 position = _objectView.FactoryObject.Position;
		position += _worldOffset;
		position += _objectView.FactoryObject.DataPosToWorldPos(_localOffset) - _objectView.FactoryObject.Position;
		Vector3 right = _mainCameraLocator.Camera.transform.right;
		Vector3 forward = _mainCameraLocator.Camera.transform.forward;
		right.y = 0f;
		forward.y = 0f;
		position += right.normalized * _cameraSpaceOffset.x + forward.normalized * _cameraSpaceOffset.y;
		_UIElement.position = _mainCameraLocator.Camera.WorldToScreenPoint(position) + (Vector3)_screenOffset;
	}
}
