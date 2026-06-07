using Presentation.Locators;
using UnityEngine;

public class CanvasFollowCamera : MonoBehaviour
{
	[SerializeField]
	private GameObject _canvas;

	[SerializeField]
	private CameraLocator _cameraLocator;

	private void Update()
	{
		if (_canvas != null && _cameraLocator.Camera != null)
		{
			Quaternion rotation = _canvas.transform.rotation;
			rotation.y = _cameraLocator.Camera.transform.rotation.y;
			_canvas.transform.rotation = _cameraLocator.Camera.transform.rotation;
		}
	}
}
