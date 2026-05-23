using Presentation.Locators;
using UnityEngine;

namespace Presentation.UI.WorldMap
{
	[RequireComponent(typeof(RectTransform))]
	public class ScreenSpacePosUpdater : MonoBehaviour
	{
		[SerializeField]
		private Transform _3dTransform;

		[SerializeField]
		private CameraLocator _cameraLocator;

		[SerializeField]
		private Vector3 _offset;

		private RectTransform _rectTransform;

		private void Awake()
		{
			_rectTransform = GetComponent<RectTransform>();
		}

		private void Update()
		{
			Vector2 vector = _cameraLocator.Camera.WorldToScreenPoint(_3dTransform.position + _offset);
			_rectTransform.position = vector;
		}
	}
}
